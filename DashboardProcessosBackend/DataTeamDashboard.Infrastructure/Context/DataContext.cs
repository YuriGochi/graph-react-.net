using DataTeamDashboard.Domain.Entities;
using DataTeamDashboard.Domain.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Emit;

namespace DataTeamDashboard.Infrastructure.Context
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        protected readonly Settings settings;

        public DataContext(Settings _settings, IConfiguration configuration)
        {
            Configuration = configuration;
            settings = _settings;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(settings.ConnectionString, ServerVersion.Create(new Version(), Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MariaDb));
            options.EnableDetailedErrors(true);

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Process>().ToTable("Process");

            modelBuilder.Entity<Process>()
          .HasKey(b => b.Id);

            modelBuilder.Entity<Dashboard>().ToTable("Dashboard");

            modelBuilder.Entity<Dashboard>()
          .HasKey(b => b.Id);
        }

        public virtual DbSet<Process> Processes { get; set; }
        public virtual DbSet<Dashboard> Dashboard { get; set; }

    }
}
