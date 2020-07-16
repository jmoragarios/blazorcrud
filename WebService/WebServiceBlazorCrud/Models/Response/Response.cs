using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebServiceBlazorCrud.Models.Response
{
    public class Response
    {
        public int Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public Response()
        {
            this.Success = 0;
        }
    }
}
