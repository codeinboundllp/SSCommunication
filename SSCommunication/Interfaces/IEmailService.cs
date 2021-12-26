using SSCommunication.Models;
using System;
using System.Threading.Tasks;

namespace SSCommunication.Interfaces
{
    public interface IEmailService
    {
        void Configure();
        Task<EmailServiceResponse> SendEmailAsync<TData>(Uri templateUrl, TData? data) where TData : IEmailTemplate;
        Task<EmailServiceResponse> SendEmailAsync<TData>(string htmlTemplate, TData? data) where TData : IEmailTemplate;
    }
}
