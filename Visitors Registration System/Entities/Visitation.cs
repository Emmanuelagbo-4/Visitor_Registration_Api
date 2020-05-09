using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Visitors_Registration_System.Entities
{
    public class Visitation
    {
        [Key]
        public Guid Id { get; set; }
        public Visitors Visitors { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        [Required]
        [MaxLength(50)]
        public string WhoToVisit { get; set; }
        [Required]
        public string PurposeOfVisit { get; set; }
        public string Feedback { get; set; }
    }
}
