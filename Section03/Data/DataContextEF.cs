using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Section03.Models;

namespace Section03.Data
{   
    public class DataContextEF : DbContext                  // Inherit from the DbContext class 
    {
        private IConfiguration _config;
        public DataContextEF(IConfiguration config)
        {
            _config = config;
        }
        
        // The "?" makes the Computer method nullable so that if there is a model, we can retrieve
        // the data.  Because there might not actually be an existing one.    
        public DbSet<Computer>? Computer {get; set;}        
        // Whenever the DataContextEF class is created, we will check if it's been configured.
        // If it hasn't been yet, we give Entity framework access to our connection string:
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection"),
                options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TutorialAppSchema");
            modelBuilder.Entity<Computer>().HasKey(c => c.ComputerId);
                // .ToTable("Computer", "TutorialAppSchema");
                // .ToTable("TableName", "Schema");
        }
    }

}