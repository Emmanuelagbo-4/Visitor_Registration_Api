using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Visitors_Registration_System.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Entities.Admin, Models.AdminDTO>();
            CreateMap<Models.AdminDTO, Entities.Admin>();
            CreateMap<Entities.Visitation, Models.VisitationDTO>();
            CreateMap<Entities.Visitors, Models.VisitorDTO>();
        }
    }
}


