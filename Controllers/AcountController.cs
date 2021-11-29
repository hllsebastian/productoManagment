using ApiProductManagment.Dtos;
using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Security;
using ApiProductManagment.Security.EmailService;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoExtintores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[AllowAnonymous]

    public class AcountController : ControllerBase
    {
		private readonly UserManager<Users> _userManager;
		private readonly IMapper _mapper;
		private readonly IEmailSender _emailSender;
		private readonly JwtHandler _jwtHandler;

		public AcountController(UserManager<Users> userManager, IMapper mapper, 
			                       JwtHandler jwtHandler, IEmailSender emailSender)
		{
			_userManager = userManager;
			_mapper = mapper;
			_jwtHandler = jwtHandler;
			_emailSender = emailSender;
		}

		[HttpPost("Register")]
		public async Task<IActionResult> RegistrarUsuario([FromBody] RegisterUserDto registerUser)
		{
			if (registerUser == null || !ModelState.IsValid) 
				return BadRequest();
			
			var user = _mapper.Map<Users>(registerUser);

			var result = await _userManager.CreateAsync(user, registerUser.Password);
			if (!result.Succeeded)
			{
				var errors = result.Errors.Select(e => e.Description);

				return BadRequest(new RegisterResponseDto { Errors = errors });
			}

			var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
			var param = new Dictionary<string, string>
			{
				{"token", token },
				{"email", user.Email }
			};

			var callback = QueryHelpers.AddQueryString(registerUser.ClientURI, param);
			await _userManager.AddToRoleAsync(user, "Admin");

			return StatusCode(201);
		}

		[HttpPost("login")] 
		public async Task<IActionResult> InicioSeccion([FromBody] AutenticationUserDto autenticationUser)
		{
			var user = await _userManager.FindByEmailAsync(autenticationUser.Email);
			if (user == null)
				return BadRequest("El usuario no existe.");

			//if (!await _userManager.IsEmailConfirmedAsync(usuario))
				//return Unauthorized(new AuthRespuestaDTO { MensajeError = "Email no confirmado." });

			if (!await _userManager.CheckPasswordAsync(user, autenticationUser.Password))
			{
				await _userManager.AccessFailedAsync(user);

				if (await _userManager.IsLockedOutAsync(user))
				{
					var contenido = $"Su cuenta esta bloqueada. Pararestablecer su contraseña has clic en este enlace: {autenticationUser.ClientURI}";
					var message = new Messages(new string[] { autenticationUser.Email }, "Informacion de cuenta bloqueada.", contenido, null);
					await _emailSender.SendEmailAsync(message);

					return Unauthorized(new AuthResponseDto { MensajeError = "La cuenta esta bloqueada." });
				}

				return Unauthorized(new AuthResponseDto { MensajeError = "Autentificacion invalida" });
			}

			if (await _userManager.GetTwoFactorEnabledAsync(user))
				return await GenerarOTPDeVerificacionEnDosPasos(user);

			var token = await _jwtHandler.GenerarToken(user);

			await _userManager.ResetAccessFailedCountAsync(user);

			return Ok(new AuthResponseDto { AuthExitosa = true, Token = token });
		}

		private async Task<IActionResult> GenerarOTPDeVerificacionEnDosPasos(Users user)   
		{
			var proveedor = await _userManager.GetValidTwoFactorProvidersAsync(user);
			if (!proveedor.Contains("Email"))
			{
				return Unauthorized(new AuthResponseDto { MensajeError = "Verificacion de proveedor en dos pasos no valida." });
			}

			var token = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");
			var mensaje = new Messages(new string[] { user.Email }, "Authentication token", token, null);
			await _emailSender.SendEmailAsync(mensaje);

			return Ok(new AuthResponseDto { Verificacion = true, Proveedor = "Email" });
		}
		 
		[HttpPost("forgot- password")]
		public async Task<IActionResult> OlvidoContraceña([FromBody] ForgotPasswordDto forgotPassword)
		{
			if (!ModelState.IsValid) 
				return BadRequest();

			var usuario = await _userManager.FindByEmailAsync(forgotPassword.Email);
			if (usuario == null)
				return BadRequest("Usuario Invalido.");

			var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);
			var param = new Dictionary<string, string>
			{
				{"token", token },
				{"email", forgotPassword.Email }
			};

			var callback = QueryHelpers.AddQueryString(forgotPassword.ClientURI, param);

			return Ok();
		}

		[HttpPost("Restore-password")]
		public async Task<IActionResult> ResetPassword([FromBody] RestorePasswordDto restorePassword)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var usuario = await _userManager.FindByEmailAsync(restorePassword.Email);
			if (usuario == null) 
				return BadRequest("Usuario invalido.");

			var resetPassResult = await _userManager.ResetPasswordAsync(usuario, restorePassword.Token, restorePassword.Contrasena);
			if (!resetPassResult.Succeeded)
			{
				var errors = resetPassResult.Errors.Select(e => e.Description);

				return BadRequest(new { Errors = errors });
			}

			await _userManager.SetLockoutEndDateAsync(usuario, new DateTime(2000, 1, 1));

			return Ok();
		}

		[HttpGet("email-confirmation")]
		public async Task<IActionResult> EmailConfirmation([FromQuery] string email, [FromQuery] string token)
		{
			var usuario = await _userManager.FindByEmailAsync(email);
			if (usuario == null)
				return BadRequest("Email de usuario invalido");

			var confirmResult = await _userManager.ConfirmEmailAsync(usuario, token);
			if (!confirmResult.Succeeded)
				return BadRequest("Solicitud de confirmación por correo electrónico no válida.");

			return Ok();
		}

		
	}
}
