namespace ClubMembershipApplication.Data
{
    public interface IRegister
    {
        bool Register(string[] fields);
        bool EmailExists(string email);
    }
}
