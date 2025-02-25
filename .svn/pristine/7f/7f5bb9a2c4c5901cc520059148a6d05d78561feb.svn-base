using CourseWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseWeb.Context
{
    public class CourseDbContext :DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<UserModel> Users { get; set; }

        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlServer(@"Server=HUSEYIN;Database=Course;User Id=hcevik;Password=1A2B3C4D;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()

           .HasOne(c => c.UserModel)  // Candidate, bir User'a bağlı
            .WithMany(u => u.Candidates)// Bir User'ın birçok Candidate kaydı olabilir
            .HasForeignKey(c => c.UserId);// Foreign Key UserId
            /*.OnDelete(DeleteBehavior.Cascade);*/// Kullanıcı silinirse başvuruları da silinsin
        }

    }
}
