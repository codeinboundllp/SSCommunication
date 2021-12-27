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
        public async Task<EmailServiceResponse<string>> SendEmailAsync<TDatas>(Uri templateUrl, TDatas? data) where TDatas : IEmailTemplate
        {
            try
            {
                SendEmailRequest req = new SendEmailRequest();
                var httpresponse = CommonStatic.GetHttpStringResponse(templateUrl.OriginalString);
                if (httpresponse.statusCode == HttpStatusCode.OK)
                {
                    req.Destination = new Destination { ToAddresses = data.ToEmail };
                    req.Source = data.FromEmail;

                    if (data == null)
                    {
                        req.Message = new Message { Subject = new Content(data.Subject), Body = new Body { Html = new Content(httpresponse.Data) } };
                        SendEmailResponse response = await client.SendEmailAsync(req);
                        return new EmailServiceResponse<string> { Status = response.HttpStatusCode, Response = response.MessageId, Error = null };
                    }
                    else
                    {
                        //html templating
                        string parsed_html = CommonStatic.HtmlTemplateParsing(httpresponse.Data, data);
                        req.Message = new Message { Subject = new Content(data.Subject), Body = new Body { Html = new Content(parsed_html) } };
                        SendEmailResponse response = await client.SendEmailAsync(req);
                        return new EmailServiceResponse<string> { Status = response.HttpStatusCode, Response = response.MessageId, Error = null };
                    }
                }
                else
                {
                    return new EmailServiceResponse<string> { Status = httpresponse.statusCode, Error = new ErrorResponse { ErrorMsg = "Template Not Found" } };
                }
            }
            catch (Exception ex)
            {
                //TODO : Add Logging
                return new EmailServiceResponse<string> { Status = HttpStatusCode.InternalServerError, Error = new ErrorResponse { ErrorMsg = ex.Message } };

            }
        }
        public Task<EmailServiceResponse<string>> SendEmailAsync<TData>(string htmlTemplate, TData? data) where TData : IEmailTemplate
        {
            throw new NotImplementedException();
        }
    }
}
