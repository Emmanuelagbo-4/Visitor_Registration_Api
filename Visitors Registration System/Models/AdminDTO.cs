using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Visitors_Registration_System.Models
{
    public class AdminDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
