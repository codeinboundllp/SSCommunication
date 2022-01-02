using SSCommunication.Interfaces;
using SSCommunication.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SSCommunication.Implementations
{
    public class RecaptchaService : ICaptchaService
    {
        private const string RemoteAddress = "https://www.google.com/recaptcha/api/siteverify";
        private readonly IRecaptchaConfiguration _config;
        private readonly IGenericHttpResponse _httpresponse;
        public RecaptchaService(IRecaptchaConfiguration config)
        {
            _config = config;
            _httpresponse = new CommonGenericResponse();
        }

        public async Task<GenericHttpResponse<string>> ValidateCaptcha(string token)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("secret", _config.SiteKey),
                        new KeyValuePair<string, string>("response", token)
                    });

                HttpClient client = new HttpClient();
                var result = await client.PostAsync(RemoteAddress, content);
                if (result.IsSuccessStatusCode)
                {
                    return _httpresponse.CreateSuccessResponse();
                }
                else
                {
                    return _httpresponse.CreateForbiddenResponse("Unable to validate the captcha. Please try again");
                }
              
            }
            catch (Exception ex)
            {
                return _httpresponse.CreateExceptionResponse("There was some exception while validating the captcha");
            }
        }
    }
}
