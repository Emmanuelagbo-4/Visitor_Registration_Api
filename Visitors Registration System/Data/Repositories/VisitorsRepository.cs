using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Visitors_Registration_System.Data.Interfaces;
using Visitors_Registration_System.Entities;
using Visitors_Registration_System.Helpers;

namespace Visitors_Registration_System.Data.Repositories
{
    public class VisitorsRepository : IVisitors
    {
        private readonly AppDbContext _appDbContext;
        private readonly AppSettings _appSettings;
        public VisitorsRepository(
            AppDbContext appDbContext,
            IOptions<AppSettings> appSettings)
        {
            _appDbContext = appDbContext;
            _appSettings = appSettings.Value;
        }
        public Visitors Authenticate(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            var user = _appDbContext.Visitors.SingleOrDefault(c => c.Email == email);

            //check if user exists
            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            //authentication successful
            return user;
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

       
    }
}
