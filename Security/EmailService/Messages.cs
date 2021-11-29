﻿using Microsoft.AspNetCore.Http;
using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace ApiProductManagment.Security.EmailService
{
    public class Messages
    {
        public List<MailboxAddress> To { get; set; }
        public string Sujeto { get; set; } 
        public string Contenido { get; set; }

        public IFormFileCollection Archivos { get; set; }

        public Messages(IEnumerable<string> to, string sujeto, string contenido, IFormFileCollection archivos)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(x => new MailboxAddress(x)));
            Sujeto = sujeto;
            Contenido = contenido;
            Archivos = archivos;
        }
    }
}
