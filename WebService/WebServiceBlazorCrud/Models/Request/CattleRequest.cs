using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceBlazorCrud.Models.Request
{
    public class CattleRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
    }
}
