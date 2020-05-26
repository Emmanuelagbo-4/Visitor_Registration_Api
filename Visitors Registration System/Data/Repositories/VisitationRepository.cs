using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Visitors_Registration_System.Data.Interfaces;
using Visitors_Registration_System.Entities;
using Visitors_Registration_System.Helpers;

namespace Visitors_Registration_System.Data.Repositories
{
    public class VisitationRepository : IVisitation
    {
        private readonly AppDbContext _appDbContext;
        
        public VisitationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            
        }
        public Visitation Create(Visitation visitation)
        {
            var Visitor = _appDbContext.Visitors.Find(visitation.Visitors.Id);
            if (Visitor == null)
                throw new AppException("user is not registered");

            visitation.Visitors.Id = Visitor.Id;

            visitation.TimeIn = DateTime.Now;
            visitation.VisitDate = DateTime.Today;
            _appDbContext.Visitation.Add(visitation);
            _appDbContext.SaveChanges();
            return visitation;
        }

        public IEnumerable<Visitation> GetAll()
        {
           return _appDbContext.Visitation.ToList();
        }

        public Visitation GetById(Guid Id)
        {
            return _appDbContext.Visitation.SingleOrDefault(x => x.Id == Id);
        }

        public Visitation Leave(Guid Id, Visitation visitation)
        {
            
            var VisitorVisit = _appDbContext.Visitation.LastOrDefault(x => x.Id == Id);
            VisitorVisit.TimeOut = DateTime.Now;
            VisitorVisit.Feedback = visitation.Feedback;

            _appDbContext.Entry(visitation).State = EntityState.Modified;
            _appDbContext.SaveChanges();
            return VisitorVisit;

        }
    }
}
