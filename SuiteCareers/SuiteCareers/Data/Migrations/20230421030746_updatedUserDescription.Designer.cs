﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuiteCareers.Data;

#nullable disable

namespace SuiteCareers.Data.Migrations
{
    [DbContext(typeof(SuiteCareersDbContext))]
    [Migration("20230421030746_updatedUserDescription")]
    partial class updatedUserDescription
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("SuiteCareers.Models.Interview", b =>
                {
                    b.Property<long>("interviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("questionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("interviewId");

                    b.ToTable("Interviews");
                });

            modelBuilder.Entity("SuiteCareers.Models.Question", b =>
                {
                    b.Property<long>("questionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("question")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("questionId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("SuiteCareers.Models.Response", b =>
                {
                    b.Property<long>("responseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("questionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("response")
                        .HasColumnType("INTEGER");

                    b.HasKey("responseId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("SuiteCareers.Models.Session", b =>
                {
                    b.Property<long>("sessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("interviewId")
                        .HasColumnType("INTEGER");

                    b.HasKey("sessionId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("SuiteCareers.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SuiteCareers.Models.UserDescription", b =>
                {
                    b.Property<long>("DescriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EducationLevel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserJob")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkExperience")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.HasKey("DescriptionId");

                    b.ToTable("UserDescriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
