using SSCommunication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SSCommunication.Implementations
{
    public static class CommonStatic
    {
        public static GenericHttpResponse<string> GetHttpStringResponse(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream str = response.GetResponseStream();
                StreamReader rdr = new StreamReader(str);
                return new GenericHttpResponse<string> { Data = rdr.ReadToEnd(), statusCode = 200 };
            }
            catch (Exception ex)
            {

                return new GenericHttpResponse<string> { statusCode = 400, Message = ex.Message };
            }
        }
    }
}
