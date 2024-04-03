using AngularApp2.Server.Context;
using AngularApp2.Server.Interfaces;
using AngularApp2.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AngularApp2.Server.Repository
{
    public class UserRepository : IUser
    {
        private ContextDB _context;

        public UserRepository(ContextDB context)
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
                    if (currentUser.Password == user.Password)
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
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Registration(User user)
        {
            try
            {
                if (!_context.Users.IsNullOrEmpty())
                {
                    if (_context.Users.Any(u => u.Login == user.Login))
                    {
                        return "LoginExist";
                    }
                }
                user.Id = GetMaxId();
                _context.Users.Add(user);
                _context.SaveChanges();
                return "Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private int GetMaxId()
        {
            if (_context.Users.IsNullOrEmpty())
            {
                return 1;
            }
            else
            {
                return _context.Users.Max(u => u.Id) + 1;
            }
        }
    }
}
