﻿// <auto-generated />
using System;
using JobApplicationTracker.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobApplicationTracker.Api.Data.Migrations
{
    [DbContext(typeof(ApplicationTrackerContext))]
    partial class ApplicationTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("JobApplicationTracker.Api.Entities.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("Deadline")
                        .HasColumnType("TEXT");

                    b.Property<int>("TitleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TitleId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("JobApplicationTracker.Api.Entities.Title", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Titles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Backend Developer"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Frontend Developer"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Fullstack Developer"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Mobile Developer"
                        });
                });

            modelBuilder.Entity("JobApplicationTracker.Api.Entities.Application", b =>
                {
                    b.HasOne("JobApplicationTracker.Api.Entities.Title", "Title")
                        .WithMany()
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Title");
                });
#pragma warning restore 612, 618
        }
    }
}
