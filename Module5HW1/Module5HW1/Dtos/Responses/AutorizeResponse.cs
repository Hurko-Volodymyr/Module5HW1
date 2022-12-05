using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module5HW1.Dtos.Responses
{
    public class AutorizeResponse
    {
        public int Id { get; set; }
        public string? Token { get; set; }
        public string? Error { get; set; }
    }
}
