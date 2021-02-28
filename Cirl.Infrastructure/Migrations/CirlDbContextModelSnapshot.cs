﻿// <auto-generated />
using System;
using Cirl.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cirl.Infrastructure.Migrations
{
    [DbContext(typeof(CirlDbContext))]
    partial class CirlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cirl.Application.LogApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CollectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Key")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.ToTable("Applications");

                    b.HasData(
                        new
                        {
                            Id = new Guid("16df48d3-4930-44b9-aade-ea975f74c8c0"),
                            CollectionId = new Guid("74423a21-a8e4-4f09-b60f-baba7602bdd9"),
                            Name = "MyApplication"
                        });
                });

            modelBuilder.Entity("Cirl.Application.LogCollection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Key")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Collections");

                    b.HasData(
                        new
                        {
                            Id = new Guid("74423a21-a8e4-4f09-b60f-baba7602bdd9"),
                            Name = "DefaultCollection"
                        });
                });

            modelBuilder.Entity("Cirl.Application.LogEntry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<int>("Severity")
                        .HasColumnType("int");

                    b.Property<string>("StackTrace")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("Logs");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ApplicationId = new Guid("16df48d3-4930-44b9-aade-ea975f74c8c0"),
                            Date = new DateTimeOffset(new DateTime(2021, 2, 28, 5, 26, 51, 157, DateTimeKind.Unspecified).AddTicks(4349), new TimeSpan(0, 0, 0, 0, 0)),
                            Message = "This is a test",
                            Severity = 1
                        },
                        new
                        {
                            Id = 2L,
                            ApplicationId = new Guid("16df48d3-4930-44b9-aade-ea975f74c8c0"),
                            Date = new DateTimeOffset(new DateTime(2021, 2, 28, 18, 51, 51, 157, DateTimeKind.Unspecified).AddTicks(5280), new TimeSpan(0, 0, 0, 0, 0)),
                            Message = "Something crashed!",
                            Severity = 4
                        },
                        new
                        {
                            Id = 3L,
                            ApplicationId = new Guid("16df48d3-4930-44b9-aade-ea975f74c8c0"),
                            Date = new DateTimeOffset(new DateTime(2021, 2, 28, 18, 53, 43, 157, DateTimeKind.Unspecified).AddTicks(5293), new TimeSpan(0, 0, 0, 0, 0)),
                            Message = "System restored",
                            Severity = 2
                        });
                });

            modelBuilder.Entity("Cirl.Application.LogApplication", b =>
                {
                    b.HasOne("Cirl.Application.LogCollection", "Collection")
                        .WithMany("Applications")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("Cirl.Application.LogEntry", b =>
                {
                    b.HasOne("Cirl.Application.LogApplication", "Application")
                        .WithMany("Logs")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");
                });

            modelBuilder.Entity("Cirl.Application.LogApplication", b =>
                {
                    b.Navigation("Logs");
                });

            modelBuilder.Entity("Cirl.Application.LogCollection", b =>
                {
                    b.Navigation("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}
