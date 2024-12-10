using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Data
{
    public interface Ilogin
    {
        User Login(string email, string password);
    }
}
