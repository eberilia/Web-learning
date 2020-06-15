﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proj.Models;

namespace proj.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200609114642_QuestionType")]
    partial class QuestionType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("proj.Models.Question", b =>
                {
                    b.Property<uint>("IdQuestion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<string>("Answer1")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool?>("Answer1Bool")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Answer2")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool?>("Answer2Bool")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Answer3")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool?>("Answer3Bool")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Answer4")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool?>("Answer4Bool")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Answer5")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool?>("Answer5Bool")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Answer6")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool?>("Answer6Bool")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Answer7")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool?>("Answer7Bool")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Answer8")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool?>("Answer8Bool")
                        .HasColumnType("tinyint(1)");

                    b.Property<uint>("IdQuizFK")
                        .HasColumnType("int unsigned");

                    b.Property<string>("QuestionType")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TextQuestion")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IdQuestion");

                    b.HasIndex("IdQuizFK");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("proj.Models.Quiz", b =>
                {
                    b.Property<uint>("IdQuiz")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("QuizName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UsernameFK")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("IdQuiz");

                    b.HasIndex("UsernameFK");

                    b.ToTable("Quizes");
                });

            modelBuilder.Entity("proj.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ConfirmEmail")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("proj.Models.Question", b =>
                {
                    b.HasOne("proj.Models.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("IdQuizFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("proj.Models.Quiz", b =>
                {
                    b.HasOne("proj.Models.User", "User")
                        .WithMany("Quizes")
                        .HasForeignKey("UsernameFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
