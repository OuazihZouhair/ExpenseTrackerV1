﻿// <auto-generated />
using System;
using Expense_Tracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Expense_Tracker.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Expense_Tracker.Entities.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<double>("amount")
                        .HasColumnType("float");

                    b.Property<int?>("category")
                        .HasColumnType("int");

                    b.Property<DateOnly>("date")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("Expense_Tracker.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("mBudget")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Expense_Tracker.Entities.Expense", b =>
                {
                    b.HasOne("Expense_Tracker.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
