using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj.Models
{
    public class SQLUserRepository : IUser
    {
        private readonly AppDbContext context;
        public SQLUserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public User AddQuizToUser(User user, Quiz quiz)
        {
            user.Quizes.Add(quiz);

            return UpdateUser(user);
        }

        public User AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public User DeteleUser(int id)
        {
            User u = context.Users.Find(id);
            if (u != null)
            {
                context.Users.Remove(u);
                context.SaveChanges();
            }
            return u;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users;
        }

        public User GetUser(int id)
        {
            return context.Users.Find(id);
        }

        public User UpdateUser(User userChange)
        {
            var u = context.Users.Attach(userChange);
            u.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return userChange;
        }
    }
    
}
