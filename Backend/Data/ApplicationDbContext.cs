using Microsoft.EntityFrameworkCore;
using CourseHouse.Models;

namespace CourseHouse.Data
{

    public class ApplicationDbContext : DbContext
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
        public DbSet<ViewTest>? viewTest { get; set; }
        public DbSet<Content>? content { get; set; }
        public DbSet<Picture>? picture { get; set; }
        public DbSet<Video>? video { get; set; }
        public DbSet<LastVisited>? lastVisited { get; set; }

    }
}
