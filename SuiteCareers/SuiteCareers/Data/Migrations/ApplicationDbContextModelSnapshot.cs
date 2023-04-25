﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuiteCareers.Data;

#nullable disable

namespace SuiteCareers.Data.Migrations
{
    [DbContext(typeof(SuiteCareersDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("SuiteCareers.Models.Interview", b =>
                {
                    b.Property<long>("InterviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("InterviewId");

                    b.ToTable("Interviews");
                });

            modelBuilder.Entity("SuiteCareers.Models.Question", b =>
                {
                    b.Property<long>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("InterviewId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuestionContent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("QuestionId");

                    b.HasIndex("InterviewId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("SuiteCareers.Models.Response", b =>
                {
                    b.Property<long>("ResponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserResponse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ResponseId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("SuiteCareers.Models.Session", b =>
                {
                    b.Property<long>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<long>("InterviewId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SessionId");

                    b.HasIndex("UserId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("SuiteCareers.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SuiteCareers.Models.UserDescription", b =>
                {
                    b.Property<long>("DescriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

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

                    b.HasKey("DescriptionId");

                    b.ToTable("UserDescriptions");
                });

            modelBuilder.Entity("SuiteCareers.Models.Question", b =>
                {
                    b.HasOne("SuiteCareers.Models.Interview", "Interview")
                        .WithMany("Questions")
                        .HasForeignKey("InterviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interview");
                });

            modelBuilder.Entity("SuiteCareers.Models.Session", b =>
                {
                    b.HasOne("SuiteCareers.Models.User", "User")
                        .WithMany("Sessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SuiteCareers.Models.Interview", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("SuiteCareers.Models.User", b =>
                {
                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
