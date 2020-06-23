using NorthwindAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.Data
{
    public class UsersRepository : IDisposable
    {
        // SECURITY_DBEntities it is your context class
        NorthwindContext context = new NorthwindContext();
        //This method is used to check and validate the user credentials
        public Users ValidateUser(string email, string password)
        {
            return context.Users.FirstOrDefault(user =>
            user.UserEmail.Equals(email, StringComparison.OrdinalIgnoreCase)
            && user.UserPassword == password);
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}