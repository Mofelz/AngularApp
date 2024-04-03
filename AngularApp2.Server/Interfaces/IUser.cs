using AngularApp2.Server.Models;
using AngularApp2.Server.Repository;

namespace AngularApp2.Server.Interfaces
{
    public interface IUser
    {
        string Login(User user);
        string Registration(User user);
    }
}
