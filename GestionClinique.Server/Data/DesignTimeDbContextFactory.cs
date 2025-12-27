using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GestionClinique.Server.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Try to build configuration from appsettings.json and environment variables.
            var basePath = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            // Get connection string or fallback to a sensible default (127.0.0.1 to force TCP)
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                                   ?? Environment.GetEnvironmentVariable("DefaultConnection")
                                   ?? "Server=127.0.0.1;Database=gestion_clinique_db;User=root;Password=;";

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
