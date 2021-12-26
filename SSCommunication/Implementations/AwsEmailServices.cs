using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Microsoft.Extensions.Configuration;
using SSCommunication.Interfaces;
using SSCommunication.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SSCommunication.Implementations
{
    public class AwsEmailServices : IEmailService
    {
        private readonly IAwsConfiguration _configuration;
        private readonly RegionEndpoint region;
        private readonly AmazonSimpleEmailServiceClient client;
        public AwsEmailServices(IAwsConfiguration configuration)
        {
            _configuration = configuration;
            region = RegionEndpoint.GetBySystemName(configuration.Region);
            client = new AmazonSimpleEmailServiceClient(configuration.AccessKey, configuration.SecretKey, region);
        }
        public void Configure()
        {
        }
        public Task<EmailServiceResponse> SendEmailAsync<TData>(Uri templateUrl, TData? data) where TData : IEmailTemplate
        {
            try
            {
                SendEmailRequest req = new SendEmailRequest();
            }
            catch (Exception ex)
            {
                //TODO : Add Logging
                throw;
            }
        }
        public Task<EmailServiceResponse> SendEmailAsync<TData>(string htmlTemplate, TData? data) where TData : IEmailTemplate
        {
            throw new NotImplementedException();
        }
    }
}
