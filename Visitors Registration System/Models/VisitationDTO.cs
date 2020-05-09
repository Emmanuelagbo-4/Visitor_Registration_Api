using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Visitors_Registration_System.Models
{
    public class VisitationDTO
    {
        public Guid Id { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public string WhoToVisit { get; set; }
        public string PurposeOfVisit { get; set; }
        public string Feedback { get; set; }
    }
}
