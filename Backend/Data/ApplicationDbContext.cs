using Microsoft.EntityFrameworkCore;
using CourseHouse.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Backend.Models.CourseModels;
using Backend.Models.UserModels;

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
        public DbSet<CourseCategory>? courseCategory { get; set; }
        public DbSet<CourseComment>? courseComment { get; set; }
        public DbSet<CourseGrade>? courseGrade { get; set; }
        public DbSet<Purchase>? purchase { get; set; }
        public DbSet<CreditCard>? creditCard { get; set; }
        public DbSet<UserTestAnswer>? userTestAnswers { get; set; }
        public DbSet<CourseView>? courseView { get; set; }
        public DbSet<Content>? content { get; set; }
        public DbSet<Picture>? picture { get; set; }
        public DbSet<Video>? video { get; set; }
        public DbSet<LastVisited>? lastVisited { get; set; }
        public DbSet<CourseCategoryMapping>? CourseCategoryMappings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CourseCategoryMapping>()
                .HasKey(ccm => new { ccm.CourseId, ccm.CategoryId });

            builder.Entity<CourseCategoryMapping>()
                .HasOne(ccm => ccm.Course)
                .WithMany(c => c.CourseCategoryMappings)
                .HasForeignKey(ccm => ccm.CourseId);

            builder.Entity<CourseCategoryMapping>()
                .HasOne(ccm => ccm.CourseCategory)
                .WithMany(cc => cc.CourseCategoryMappings)
                .HasForeignKey(ccm => ccm.CategoryId);

            builder.Entity<Course>()
                .HasMany(c => c.CourseViews)
                .WithOne(cv => cv.Course)
                .HasForeignKey(cv => cv.CourseId);

            builder.Entity<Course>()
                .HasMany(c => c.Grades)
                .WithOne(cv => cv.Course)
                .HasForeignKey(cv => cv.CourseId);

            builder.Entity<Course>()
                .HasMany(c => c.Comments)
                .WithOne(cv => cv.Course)
                .HasForeignKey(cv => cv.CourseId);

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

            builder.Entity<CourseCategory>().HasData(
                new CourseCategory
                {
                    CategoryId = 1,
                    CategoryName = "IT"
                },
                new CourseCategory
                {
                    CategoryId = 2,
                    CategoryName = "Math"
                },
                new CourseCategory
                {
                    CategoryId = 3,
                    CategoryName = "Physics"
                },
                new CourseCategory
                {
                    CategoryId = 4,
                    CategoryName = "Biology"
                },
                new CourseCategory
                {
                    CategoryId = 5,
                    CategoryName = "Chemistry"
                },
                new CourseCategory
                {
                    CategoryId = 6,
                    CategoryName = "History"
                },
                new CourseCategory
                {
                    CategoryId = 7,
                    CategoryName = "Geography"
                },
                new CourseCategory
                {
                    CategoryId = 8,
                    CategoryName = "Literature"
                },
                new CourseCategory
                {
                    CategoryId = 9,
                    CategoryName = "Music"
                },
                new CourseCategory
                {
                    CategoryId = 10,
                    CategoryName = "Art"
                },
                new CourseCategory
                {
                    CategoryId = 11,
                    CategoryName = "Sport"
                },
                new CourseCategory
                {
                    CategoryId = 12,
                    CategoryName = "Cooking"
                },
                new CourseCategory
                {
                    CategoryId = 13,
                    CategoryName = "Gardening"
                },
                new CourseCategory
                {
                    CategoryId = 14,
                    CategoryName = "Photography"
                },
                new CourseCategory
                {
                    CategoryId = 15,
                    CategoryName = "Fashion"
                },
                new CourseCategory
                {
                    CategoryId = 16,
                    CategoryName = "Health"
                },
                new CourseCategory
                {
                    CategoryId = 17,
                    CategoryName = "Psychology"
                },
                new CourseCategory
                {
                    CategoryId = 18,
                    CategoryName = "Business"
                },
                new CourseCategory
                {
                    CategoryId = 19,
                    CategoryName = "Marketing"
                },
                new CourseCategory
                {
                    CategoryId = 20,
                    CategoryName = "Economy"
                },
                new CourseCategory
                {
                    CategoryId = 21,
                    CategoryName = "Management"
                }
            );

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