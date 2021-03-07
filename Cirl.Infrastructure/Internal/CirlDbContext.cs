using Cirl.Application;
using Cirl.Connector;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cirl.Infrastructure.Internal
{
    internal class CirlDbContext : DbContext
    {
        public DbSet<LogCollection> Collections { get; set; }

        public DbSet<LogApplication> Applications { get; set; }

        public DbSet<LogEntry> Logs { get; set; }

        public CirlDbContext(DbContextOptions<CirlDbContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigureLogCollection(builder);
            ConfigureLogApplication(builder);
            ConfigureLogEntry(builder);
            SeedData(builder);
        }

        private static void ConfigureLogCollection(ModelBuilder builder)
        {
            builder.Entity<LogCollection>(a =>
            {
                a.Property(a => a.Name).HasMaxLength(255).IsRequired();
                a.Property(a => a.Key).HasMaxLength(64);
            });
        }

        private static void ConfigureLogApplication(ModelBuilder builder)
        {
            builder.Entity<LogApplication>(a =>
            {
                a.Property(a => a.Name).HasMaxLength(255).IsRequired();
                a.Property(a => a.Key).HasMaxLength(64);
            });
        }

        private static void ConfigureLogEntry(ModelBuilder builder)
        {
            builder.Entity<LogEntry>(a =>
            {
                a.Property(a => a.Message).HasMaxLength(2048).IsRequired();
            });
        }

        private static void SeedData(ModelBuilder builder)
        {
            var collectionId = Guid.Parse("74423A21-A8E4-4F09-B60F-BABA7602BDD9");
            var applicationId = Guid.Parse("16DF48D3-4930-44B9-AADE-EA975F74C8C0");

            builder.Entity<LogCollection>().HasData(
                new LogCollection { Id = collectionId, Name = "DefaultCollection" }
            );

            builder.Entity<LogApplication>().HasData(
                new LogApplication { Id = applicationId, Name = "MyApplication", CollectionId = collectionId }
            );

            builder.Entity<LogEntry>().HasData(
                new LogEntry
                {
                    Id = 1,
                    ApplicationId = applicationId,
                    Severity = LogSeverity.Debug,
                    Date = DateTimeOffset.UtcNow.AddSeconds(-51252),
                    Message = "This is a test"
                },
                new LogEntry
                {
                    Id = 2,
                    ApplicationId = applicationId,
                    Severity = LogSeverity.Error,
                    Date = DateTimeOffset.UtcNow.AddSeconds(-2952),
                    Message = "Something crashed!"
                },
                new LogEntry
                {
                    Id = 3,
                    ApplicationId = applicationId,
                    Severity = LogSeverity.Information,
                    Date = DateTimeOffset.UtcNow.AddSeconds(-2840),
                    Message = "System restored"
                }
            );
        }
    }
}
