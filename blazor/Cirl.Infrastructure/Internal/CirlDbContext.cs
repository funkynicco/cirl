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
            var collectionId = Guid.Parse("74423a21-a8e4-4f09-b60f-baba7602bdd9");
            var webApplicationId = Guid.Parse("16df48d3-4930-44b9-aade-ea975f74c8c0");
            var apiApplicationId = Guid.Parse("3a761b93-4aec-4a74-a52b-009190977903");

            builder.Entity<LogCollection>().HasData(
                new LogCollection { Id = collectionId, Name = "Cirl" }
            );

            builder.Entity<LogApplication>().HasData(
                new LogApplication { Id = webApplicationId, Name = "Web", CollectionId = collectionId },
                new LogApplication { Id = apiApplicationId, Name = "Api", CollectionId = collectionId }
            );
        }
    }
}
