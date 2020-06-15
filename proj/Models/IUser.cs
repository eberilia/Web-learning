using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj.Models
{
    public interface IUser
    {
        User GetUser(string username);
        IEnumerable<User> GetAllUsers();
        User AddUser(User user);
        User UpdateUser(User userChange);
        User AddQuizToUser(User user, Quiz quiz);
        User DeteleUser(string username);
    }
}
