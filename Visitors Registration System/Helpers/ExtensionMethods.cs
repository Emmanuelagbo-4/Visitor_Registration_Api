using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Visitors_Registration_System.Entities;

namespace Visitors_Registration_System.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<Admin> WithOutPasswords(this IEnumerable<Admin> admins)
        {
            if (admins == null) return null;

            return admins.Select(c => c.WithoutPassword());

        }
        public static Admin WithoutPassword(this Admin admins)
        {
            if (admins == null) return null;

            admins.PasswordHash = null;
            admins.PasswordSalt = null;
            admins.DateCreated = DateTime.Now;
            return admins;
        }

    }
}
