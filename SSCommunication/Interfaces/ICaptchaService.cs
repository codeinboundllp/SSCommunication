using SSCommunication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCommunication.Interfaces
{
    public interface ICaptchaService
    {
        Task<GenericHttpResponse<string>> ValidateCaptcha(string token);
    }
}
