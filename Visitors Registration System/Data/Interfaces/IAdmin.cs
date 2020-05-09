using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Visitors_Registration_System.Entities;

namespace Visitors_Registration_System.Data.Interfaces
{
    public interface IAdmin
    {
        Admin Authenticate(string username, string password);
        IEnumerable<Admin> GetAll();
        Admin GetById(Guid id);
        Admin Create(Admin admin, string password);
        
    }
}
