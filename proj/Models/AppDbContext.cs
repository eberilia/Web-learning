using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace proj.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {       
        }
  
        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Quiz> Quizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Question q1 = new Question(1, "Ile to 2*2?");
            q1.Answers_text.Add("2");
            q1.Answers_bool.Add(false);

            q1.Answers_text.Add("4");
            q1.Answers_bool.Add(true);

            Question q2 = new Question(2, "Iloczyn wektorowy daje w wyniku...");
            q2.Answers_text.Add("liczbę");
            q2.Answers_bool.Add(false);

            q2.Answers_text.Add("wektor");
            q2.Answers_bool.Add(true);

            q2.Answers_text.Add("kąt");
            q2.Answers_bool.Add(false);

            q2.Answers_text.Add("nic nie daje");
            q2.Answers_bool.Add(false);

            Question q3 = new Question(3, "Apple z języka angielskiego znaczy: ");
            q3.Answers_text.Add("książka");
            q3.Answers_bool.Add(false);

            q3.Answers_text.Add("woda");
            q3.Answers_bool.Add(false);

            q3.Answers_text.Add("stół");
            q3.Answers_bool.Add(false);

            q3.Answers_text.Add("jabłko");
            q3.Answers_bool.Add(true);

            q3.Answers_text.Add("piłka");
            q3.Answers_bool.Add(false);

            q3.Answers_text.Add("motyl");
            q3.Answers_bool.Add(false);

            modelBuilder.Entity<Question>().HasData(
                q1,
                q2,
               q3
               );

            modelBuilder.Entity<Quiz>().HasData(
                q1,
                q2,
               q3);

            modelBuilder.Entity<User>().HasData(
               
                new User() { IdUser = 1, Username = "", Email="", Password = "", }
                
               );*/
        }
    }

}
