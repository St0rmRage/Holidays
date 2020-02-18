using HolidayOptimizations.Service.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace HolidayOptimizations.Service.Processes
{
    public class BaseResponse<T>
    {
        public BaseResponse(T response)
        {
            Response = response;
            StatusCode = HttpStatusCode.OK;
            Exception = null;
        }

        public BaseResponse(Exception exception)
        {
            Response = default(T);
            StatusCode = HttpStatusCode.BadRequest;
            Exception = exception;
        }

        public T Response { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public Exception Exception { get; set; }
    }
}
