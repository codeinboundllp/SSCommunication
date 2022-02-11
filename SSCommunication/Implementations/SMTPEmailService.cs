using SSCommunication.Interfaces;
using SSCommunication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SSCommunication.Implementations
{
    public class SMTPEmailService : IEmailService
    {
        private SmtpClient smtp;
        private readonly ISMTPConfiguration _config;
        public SMTPEmailService(ISMTPConfiguration config)
        {
            _config = config;
            smtp = new SmtpClient();
            smtp.Port = config.Port;
            smtp.Host = config.Host;

            if (config?.TimeOut != 0)
            {
                smtp.Timeout = config.TimeOut;
            }
            smtp.EnableSsl = config.IsSSLEnabled;
            smtp.Credentials = new NetworkCredential(config.UserName, config.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

        }
        public async Task<EmailServiceResponse<string>> SendEmailAsync(Uri templateUrl, EmailTemplate data)
        {
            try
            {
                var httpresponse = CommonStatic.GetHttpStringResponse(templateUrl.OriginalString);
                if (httpresponse.statusCode == HttpStatusCode.OK)
                {

                    await smtp.SendMailAsync(CreateMessage(httpresponse.Data, data));
                    return new EmailServiceResponse<string> { Status = HttpStatusCode.OK, Error = null };
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

        public async Task<EmailServiceResponse<string>> SendEmailAsync(string htmlTemplate, EmailTemplate data)
        {
            try
            {
                await smtp.SendMailAsync(CreateMessage(htmlTemplate, data));
                return new EmailServiceResponse<string> { Status = HttpStatusCode.OK, Error = null };
            }
            catch (Exception ex)
            {
                //TODO : Add Logging
                return new EmailServiceResponse<string> { Status = HttpStatusCode.InternalServerError, Error = new ErrorResponse { ErrorMsg = ex.Message } };
            }
        }
        private MailMessage CreateMessage(string emailTemplate, EmailTemplate data)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(_config.UserName);
                foreach (var email in data.ToEmail)
                {
                    message.To.Add(new MailAddress(email));
                }
                message.Subject = data.Subject;
                message.IsBodyHtml = true;
                string parsed_html = CommonStatic.HtmlTemplateParsing(emailTemplate, data);
                message.Body = parsed_html;
                return message;
            }
            catch
            {
                throw;
            }
        }
    }
}
