using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Visitors_Registration_System.Entities;

namespace Visitors_Registration_System.Data.Interfaces
{
    public interface IVisitors
    {
        IEnumerable<Visitors> GetAll();
        Visitors GetById(Guid id);
        Visitors Create(Visitors visitors, string email);
        Visitors Login(string PhoneOrEmail);

    }
}
