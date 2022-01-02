using SSCommunication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SSCommunication.Models
{
    public class CommonGenericResponse : IGenericHttpResponse
    {
        
        public GenericHttpResponse<string> CreateExceptionResponse(string message)
        {
            return new GenericHttpResponse<string> { Message = message, statusCode = HttpStatusCode.InternalServerError };
        }

        public GenericHttpResponse<string> CreateForbiddenResponse(string message)
        {
            return new GenericHttpResponse<string> { Message = message, statusCode = HttpStatusCode.Forbidden };
        }

        public GenericHttpResponse<string> CreateSuccessResponse()
        {
            return new GenericHttpResponse<string> { Message = "success", statusCode = HttpStatusCode.OK };
        }

        public GenericHttpResponse<string> CreateSuccessResponse(string message)
        {
            return new GenericHttpResponse<string> { Message = message, statusCode = HttpStatusCode.OK };
        }
    }
}
