using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCrudWebApp.Data
{
    public class Response
    {
        public int Success { get; set; }
        public string Message { get; set; }
        public List<Cattle> Data { get; set; }

        public Response()
        {
            this.Success = 0;
        }
    }
}
