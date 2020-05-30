using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj.Models
{
    public interface IUser
    {
        User GetUser(int id);
        IEnumerable<User> GetAllUsers();
        User AddUser(User user);
        User UpdateUser(User userChange);
        User DeteleUser(int id);
    }
}
