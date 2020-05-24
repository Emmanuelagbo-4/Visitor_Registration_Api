using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Visitors_Registration_System.Data.Interfaces;
using Visitors_Registration_System.Entities;

namespace Visitors_Registration_System.Data.Repositories
{
    public class VisitationRepository : IVisitation
    {
        private readonly AppDbContext _appDbContext;
        private readonly IVisitors _visitors;
        public VisitationRepository(AppDbContext appDbContext, IVisitors visitors)
        {
            _appDbContext = appDbContext;
            _visitors = visitors;
        }
        public Visitation Create(Visitation visitation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Visitation> GetAll()
        {
            throw new NotImplementedException();
        }

        public Visitation GetById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
