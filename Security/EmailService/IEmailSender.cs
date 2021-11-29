using System.Threading.Tasks;

namespace ApiProductManagment.Security.EmailService
{
    public interface IEmailSender
    {
        void SendEmail(Messages mensaje); 
        Task SendEmailAsync(Messages mensaje);
    }
}
