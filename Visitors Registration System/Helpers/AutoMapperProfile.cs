using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Visitors_Registration_System.Helpers;

namespace Visitors_Registration_System.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Entities.Admin, Models.AdminDTO>();
            CreateMap<Models.AdminDTO, Entities.Admin>();
            CreateMap<Entities.Visitation, Models.VisitationDTO>();
            CreateMap<Models.VisitationDTO, Entities.Visitation>();
            CreateMap<Entities.Visitors, Models.VisitorDTO>();
            CreateMap<Models.VisitorDTO, Entities.Visitors>();
           
            
        }
    }
}


