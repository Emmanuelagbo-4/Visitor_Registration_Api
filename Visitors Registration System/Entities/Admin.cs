using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Visitors_Registration_System.Entities
{
    public class Admin
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Status { get; set; }
    }
}
