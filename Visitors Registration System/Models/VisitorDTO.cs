using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Visitors_Registration_System.Models
{
    public class VisitorDTO
    {
        public Guid Id { get; set; }
        public int VisitorReg { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string VehicleNumber { get; set; }
        public int EmergencyContact { get; set; }
    }
}
