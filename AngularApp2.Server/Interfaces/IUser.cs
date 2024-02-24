using AngularApp2.Server.Modelz;

namespace AngularApp2.Server.Interfaces
{
    public interface IUser
    {
        string Login(User user);
        IEnumerable<User> GetAllActiveUsers();
    }
}
