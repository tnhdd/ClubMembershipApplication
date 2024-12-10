using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Data
{
    public class RegisterUser : IRegister
    {
        public bool EmailExists(string email)
        {
            bool emailExists = false;
            using (var dbContext = new ClubMembershipDbContext())
            {
                emailExists = dbContext.Users.Any(u => u.Email.ToLower().Trim() == email.Trim().ToLower());
            }
            return emailExists;
        }

        public bool Register(string[] fields)
        {
            using (var dbContext = new ClubMembershipDbContext())
            {
                User user = new User
                {
                    Email = fields[(int)FieldConstants.UserRegistrationField.Email],
                    FirstName = fields[(int)FieldConstants.UserRegistrationField.FirstName],
                    LastName = fields[(int)FieldConstants.UserRegistrationField.LastName],
                    Password = fields[(int)FieldConstants.UserRegistrationField.Password],
                    DateOfBirth = DateTime.Parse(fields[(int)FieldConstants.UserRegistrationField.DateOfBirth]),
                    Address = fields[(int)FieldConstants.UserRegistrationField.Address],
                    
                    City = fields[(int)FieldConstants.UserRegistrationField.City],
                    PostCode = fields[(int)FieldConstants.UserRegistrationField.PostCode]
                };

                dbContext.Users.Add(user);

                dbContext.SaveChanges();
            }
            return true;
        }
    }

}
