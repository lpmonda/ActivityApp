using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
//using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFramework; // EntityFrameworkCore.Extensions;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.Extensions.Options;

namespace AspNetcore1.model
{
    public class ValveContext : DbContext
    {
            public ValveContext(DbContextOptions<ValveContext> options) : base(options)
             { 

             }
             public ValveContext()
             {

             }

             public DbSet<Valve> Valve { get; set; }

            public DbSet<Manufacturer> Manufacturer { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            //optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");
            // optionsBuilder.UseMySql("server=localhost;database=library;user=admin;password=valco");
            // 
            optionsBuilder.UseMySql("server=localhost;database=sakila;user=admin;password=valco;port=3306;Connect Timeout=5;",
              new MySqlServerVersion(new Version(8, 0, 11)));

            
        }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Manufacturer>(entity =>
                {
                    entity.HasKey(e => e.ID);
                    entity.Property(e => e.Name).IsRequired();
                });

                modelBuilder.Entity<Valve>(entity =>
                {
                    entity.HasKey(e => e.SerialNumber);
                    entity.Property(e => e.Name).IsRequired();
                    entity.Property(e => e.SerialNumber).IsRequired();
                    entity.Property(e => e.Type).IsRequired();
                    entity.Property(e => e.minVolt).IsRequired();
                    entity.Property(e => e.maxVolt).IsRequired();
                    entity.Property(e => e.units).IsRequired();
                    entity.HasOne(d => d.Manufacturer);
                     
                });
            }
        }
    
}
