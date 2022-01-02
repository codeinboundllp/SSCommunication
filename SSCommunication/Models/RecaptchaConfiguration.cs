using SSCommunication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCommunication.Models
{
    public class RecaptchaConfiguration : IRecaptchaConfiguration
    {
        public string SecretKey { get; set; }
        public string SiteKey { get; set; }
    }
}
