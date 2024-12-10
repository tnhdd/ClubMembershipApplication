using ClubMembershipApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Data
{
    public class LoginUser : Ilogin
    {
        public User Login(string email, string password)
        {
            User user = null;
            using (var dbContext = new ClubMembershipDbContext())
            {
                user = dbContext.Users.FirstOrDefault(u => u.Email.Trim().ToLower() == email.ToLower() && u.Password.Equals(password));
            }
            return user;
        }
    }
}
