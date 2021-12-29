using SSCommunication.Models;
using System;
using System.Threading.Tasks;

namespace SSCommunication.Interfaces
{
    public interface IEmailService
    {
        Task<EmailServiceResponse<string>> SendEmailAsync(Uri templateUrl, EmailTemplate? data);
        Task<EmailServiceResponse<string>> SendEmailAsync(string htmlTemplate, EmailTemplate? data);
    }
}
