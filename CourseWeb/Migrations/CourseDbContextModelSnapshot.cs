﻿// <auto-generated />
using System;
using CourseWeb.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseWeb.Migrations
{
    [DbContext(typeof(CourseDbContext))]
    partial class CourseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseWeb.Models.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ApplyAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("SelectedCourse")
                        .HasMaxLength(19)
                        .HasColumnType("nvarchar(19)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Candidates", (string)null);
                });

            modelBuilder.Entity("CourseWeb.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(19)
                        .HasColumnType("nvarchar(19)");

                    b.Property<string>("Gender")
                        .HasMaxLength(19)
                        .HasColumnType("nvarchar(19)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(19)
                        .HasColumnType("nvarchar(19)");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("CourseWeb.Models.Candidate", b =>
                {
                    b.HasOne("CourseWeb.Models.UserModel", "UserModel")
                        .WithMany("Candidates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserModel");
                });

            modelBuilder.Entity("CourseWeb.Models.UserModel", b =>
                {
                    b.Navigation("Candidates");
                });
#pragma warning restore 612, 618
        }
    }
}
