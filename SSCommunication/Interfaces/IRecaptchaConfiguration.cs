using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCommunication.Interfaces
{
    public interface IRecaptchaConfiguration
    {
        public string SecretKey { get; set; }
        public string SiteKey { get; set; }
    }
}
