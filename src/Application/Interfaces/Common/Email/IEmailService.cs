using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Common.Email
{
    public interface IEmailService
    {
        public Task SendEmailAsync(MailMessage mailMessage);

        public Task SaveEmail(MailMessage mailMessage, string path);
    }
}
