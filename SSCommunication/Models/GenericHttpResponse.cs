using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCommunication.Models
{
    public class GenericHttpResponse<T>
    {
        public int statusCode { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; }
    }
}
