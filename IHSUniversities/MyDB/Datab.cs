using Microsoft.EntityFrameworkCore;
namespace IHSUniversities
{
    public class Datab : DbContext
    {
        string connect = @"Data Source=Klymp3;Initial Catalog=ВУЗЫ;Integrated Security=True;Trust Server Certificate=True";

        public DbSet<University> Universities { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSpeciality> UsersSpecialitys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connect);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserSpeciality>().HasKey(us => new { us.IdUser, us.IdSpeciality });
        }
    }
}
