using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Visitors_Registration_System.Data.Interfaces;
using Visitors_Registration_System.Entities;
using Visitors_Registration_System.Helpers;

namespace Visitors_Registration_System.Data.Repositories
{
    public class VisitorsRepository : IVisitors
    {
        private readonly AppDbContext _appDbContext;
        public VisitorsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Visitors Authenticate(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            var user = _appDbContext.Visitors.SingleOrDefault(c => c.Email == email);

            //check if user exists
            if (user == null)
                return null;

            //authentication successful
            return user;
        }

        public Visitors Create(Visitors visitors, string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new AppException("Email is required");

            if(_appDbContext.Visitors.Any(c => c.Email == email))
                throw new AppException("Email \"" + email + "\" is already registered");
             
             _appDbContext.Visitors.Add(visitors);
             _appDbContext.SaveChanges();

            return visitors;
            
        }

        public IEnumerable<Visitors> GetAll()
        {
            var RegVisitors = _appDbContext.Visitors.ToList();
            return RegVisitors;
        }

        public Visitors GetById(Guid id)
        {
            var RegVisitor = _appDbContext.Visitors.FirstOrDefault(c => c.Id == id);
            return RegVisitor;
        }

       
    }
}
