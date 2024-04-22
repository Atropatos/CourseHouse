using Microsoft.EntityFrameworkCore;
using CourseHouse.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CourseHouse.Data
{

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //data db set
        //public DbSet<Stock>? Stocks { get; set; }

        public DbSet<User>? user { get; set; }
        public DbSet<Role>? role { get; set; }
        public DbSet<Course>? course { get; set; }
        public DbSet<CourseComment>? courseComment { get; set; }
        public DbSet<CourseGrade>? courseGrade { get; set; }
        public DbSet<Purchase>? purchase { get; set; }
        public DbSet<CreditCard>? creditCard { get; set; }

        public DbSet<CourseView>? courseView { get; set; }
        public DbSet<Content>? content { get; set; }
        public DbSet<Picture>? picture { get; set; }
        public DbSet<Video>? video { get; set; }
        public DbSet<LastVisited>? lastVisited { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name="User",
                    NormalizedName="USER"
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
            /*  builder.Entity<Role>().HasData(
                  new Role
                  {
                      RoleId = 1,
                      RoleName = "User"
                  },
                  new Role
                  {
                      RoleId = 2,
                      RoleName = "Admin"
                  },
                  new Role
                  {
                      RoleId = 3,
                      RoleName = "Moderator"
                  }
              );

              builder.Entity<User>().HasData(
                  new User
                  {
                      Id = "1",
                      Name = "Emanuel",
                      LastName = "Admin",
                      Email = "emanuel@admin.com",
                      RoleId = 2,
                      Password = "zaq1@WSXcde3$RFV"
                  },
                  new User
                  {
                      UserId = 2,
                      Name = "Dawid",
                      LastName = "Admin",
                      Email = "dawid@admin.com",
                      RoleId = 2,
                      Password = "zaq1@WSXcde3$RFV"
                  },
                  new User
                  {
                      UserId = 3,
                      Name = "Adam",
                      LastName = "Nowak",
                      Email = "adam@nowak.com",
                      RoleId = 1,
                      Password = "zaq1@WSXcde3$RFV"
                  },
                  new User
                  {
                      UserId = 4,
                      Name = "Anna",
                      LastName = "Kowalska",
                      Email = "anna@kowalska.com",
                      RoleId = 1,
                      Password = "zaq1@WSXcde3$RFV"
                  },
                  new User
                  {
                      UserId = 5,
                      Name = "Jan",
                      LastName = "Kowalczyk",
                      Email = "jan@kowalczyk.com",
                      RoleId = 1,
                      Password = "zaq1@WSXcde3$RFV"
                  },
                  new User
                  {
                      UserId = 6,
                      Name = "Katarzyna",
                      LastName = "Wiśniewska",
                      Email = "katarzyna@wisniewska.com",
                      RoleId = 1,
                      Password = "zaq1@WSXcde3$RFV"
                  },
                  new User
                  {
                      UserId = 7,
                      Name = "Magdalena",
                      LastName = "Lewandowska",
                      Email = "magdalena@lewandowska.com",
                      RoleId = 1,
                      Password = "zaq1@WSXcde3$RFV"
                  },
                  new User
                  {
                      UserId = 8,
                      Name = "Tomasz",
                      LastName = "Wójcik",
                      Email = "tomasz@wojcik.com",
                      RoleId = 1,
                      Password = "zaq1@WSXcde3$RFV"
                  },
                  new User
                  {
                      UserId = 9,
                      Name = "Agnieszka",
                      LastName = "Kamińska",
                      Email = "agnieszka@kaminska.com",
                      RoleId = 1,
                      Password = "zaq1@WSXcde3$RFV"
                  },
                  new User
                  {
                      UserId = 10,
                      Name = "Marcin",
                      LastName = "Kowalewski",
                      Email = "marcin@kowalewski.com",
                      RoleId = 1,
                      Password = "zaq1@WSXcde3$RFV"
                  }
              );
          }*/
        }
    }
}