using AngularApp2.Server.Context;
using AngularApp2.Server.Interfaces;
using AngularApp2.Server.Modelz;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AngularApp2.Server.Repository
{
    public class UserRepository : IUser
    {
        private DazaBannixContext _context;

        public UserRepository(DazaBannixContext context) 
        {
            _context = context;
        }

        public string Login(User user)
        {
            try
            {
                User currentUser = _context.Users.FirstOrDefault(u => u.Name == user.Name);
                if (currentUser != null)
                {
                    if(currentUser.Password == user.Password)
                    {
                        return "Success";
                    }
                    else
                    {
                        return "Password error";
                    }
                }
                else
                {
                    return "User not found";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<User> GetAllActiveUsers()
        {
            return _context.Users.Where(u => u.Active == true);
        }
    }
}
