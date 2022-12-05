using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module5HW1.Dtos.Requests
{
    public class AutorizeRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
