﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Visitors_Registration_System.Entities
{
    public class Visitors
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string VisitorReg { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(11)]
        public int PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        [MaxLength(10)]
        public string VehicleNumber { get; set; }
        [Required]
        [MaxLength(11)]
        public int EmergencyContact { get; set; }
    }
}