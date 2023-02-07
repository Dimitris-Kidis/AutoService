using ApplicationCore.Domain.Entities;
using ApplicationCore.Domain.EntityConfigurations;
using Microsoft.EntityFrameworkCore;


namespace ApplicationCore.Domain
{

    public class AutoServiceDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Consultation> Consultaions { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Car> Cars { get; set; }



        public AutoServiceDbContext()
        {

        }

        public AutoServiceDbContext(DbContextOptions<AutoServiceDbContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=.;Database=AutoService;Integrated Security=True;TrustServerCertificate=True;");



        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsersConfiguration());
            builder.ApplyConfiguration(new CarsConfiguration());

        }

    }
}
