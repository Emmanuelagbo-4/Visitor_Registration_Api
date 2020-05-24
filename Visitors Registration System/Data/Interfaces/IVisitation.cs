using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Visitors_Registration_System.Entities;

namespace Visitors_Registration_System.Data.Interfaces
{
    public interface IVisitation
    {
        IEnumerable<Visitation> GetAll();
        Visitation GetById(Guid Id);
        Visitation Create(Visitation visitation);
    }
}
