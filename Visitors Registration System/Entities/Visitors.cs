using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Visitors_Registration_System.Entities
{
    public class Visitors
    {
        [Key]
        public Guid Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VisitorReg { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        [MaxLength(10)]
        public string VehicleNumber { get; set; }
        [Required]
        [MaxLength(11)]
        public string EmergencyContact { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
