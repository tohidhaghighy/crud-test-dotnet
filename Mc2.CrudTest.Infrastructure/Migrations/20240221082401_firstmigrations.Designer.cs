﻿// <auto-generated />
using System;
using Mc2.CrudTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mc2.CrudTest.Infrastructure.Migrations
{
    [DbContext(typeof(CustomerDbContext))]
    [Migration("20240221082401_firstmigrations")]
    partial class firstmigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Mc2.CrudTest.Domain.Entities.Customer.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Mc2.CrudTest.Domain.Entities.Customer.Customer", b =>
                {
                    b.OwnsOne("Mc2.CrudTest.Domain.Entities.Customer.CustomerInfo", "CustomerInfo", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("DateOfBirth")
                                .HasColumnType("datetime2");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("Mc2.CrudTest.Domain.ValueObjects.BankAccountNumber", "BankAccountNumber", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("BankAccount")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("Mc2.CrudTest.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("email")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("Mc2.CrudTest.Domain.ValueObjects.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("BankAccountNumber")
                        .IsRequired();

                    b.Navigation("CustomerInfo")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("PhoneNumber")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}