using Microsoft.EntityFrameworkCore;
using CourseEFCore.Domain;
using CourseEFCore.Course.Configurations;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace CourseEFCore.Data
{
    public class ApplicationContext : DbContext
    {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p=>p.AddConsole());

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(_logger)
                .EnableSensitiveDataLogging()
                .UseSqlServer("Data source=(localdb)\\mssqllocaldb;Initial Catalog=CourseEFCore;Integrated Security=true",
                p=>p.EnableRetryOnFailure(
                    maxRetryCount: 2,
                    maxRetryDelay:
                    System.TimeSpan.FromSeconds(5),
                    errorNumbersToAdd: null).MigrationsHistoryTable("course_ef_core"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

        }

        private void MappingforgetedEntities(ModelBuilder modelBuilder)
        {
            foreach(var entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entity.GetProperties().Where(p => p.ClrType == typeof(string));

                foreach(var property in properties)
                {
                    if (string.IsNullOrEmpty(property.GetColumnType()) 
                        && !property.GetMaxLength().HasValue)
                    {
                        property.SetColumnType("VARCHAR(100)");
                            
                    }
                }
            }
        }
    }   
}