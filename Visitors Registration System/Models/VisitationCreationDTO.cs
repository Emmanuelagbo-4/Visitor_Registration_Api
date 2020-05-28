using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Visitors_Registration_System.Models
{
    public class VisitationCreationDTO
    {
        public Guid VisitorsId { get; set; }
        public string WhoToVisit { get; set; }
        public string PurposeOfVisit { get; set; }
        
    }
}
