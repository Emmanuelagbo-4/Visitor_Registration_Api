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
        

        public Visitors Create(Visitors visitors, string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new AppException("Email is required");

            if(_appDbContext.Visitors.Any(c => c.Email == email))
                throw new AppException("Email \"" + email + "\" is already registered");

            visitors.Role = Role.Visitor;

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

        public Visitors  Login(string Email)
        {
            if (string.IsNullOrEmpty(Email))
                throw new AppException("Phone number or Email is required");

            var User = _appDbContext.Visitors.Where(x => x.Email == Email).FirstOrDefault();
            if (User == null)
                throw new AppException("Email is incorrect");

            var EmailExists = _appDbContext.Visitors.Any(x => x.Email == Email);
            
            if (EmailExists)
                return User;
            
            return User;
            
        }
    }
}
