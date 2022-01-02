using SSCommunication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCommunication.Interfaces
{
    public interface IGenericHttpResponse
    {
        GenericHttpResponse<string> CreateSuccessResponse();
        GenericHttpResponse<string> CreateSuccessResponse(string message);

        GenericHttpResponse<string> CreateForbiddenResponse(string message);
        GenericHttpResponse<string> CreateExceptionResponse(string message);
    }
}
