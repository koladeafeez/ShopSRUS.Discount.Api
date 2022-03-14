﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopsRCUS.Discount.API.Entities.Models;

#nullable disable

namespace ShopsRCUS.Discount.API.Migrations
{
    [DbContext(typeof(ShopsRUSDiscountDbContext))]
    partial class ShopsRUSDiscountDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("ShopsRCUS.Discount.API.Entities.Models.GlobalEmployeeMock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LocationCode")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("TEXT");

                    b.Property<string>("LocationCoverageName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("globalEmployeeMocks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c0515528-1891-4968-9a22-ef202a5c7acb"),
                            DateOfBirth = new DateTime(1995, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "employee1@shopsrus.us",
                            FirstName = "Johnney",
                            LastName = "Donney",
                            LocationCode = "us-200",
                            LocationCoverageName = "United State"
                        },
                        new
                        {
                            Id = new Guid("81923066-da0d-4bbd-aec5-925c038e01fd"),
                            DateOfBirth = new DateTime(1996, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "employee2@shopsrus.uk",
                            FirstName = "Alina",
                            LastName = "Fisher",
                            LocationCode = "uk-100",
                            LocationCoverageName = "United Kingdom"
                        },
                        new
                        {
                            Id = new Guid("0362aa24-3ac5-48ed-a984-c18f9fd97dbe"),
                            DateOfBirth = new DateTime(1995, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "longtimeemployee@shopsrus.us",
                            FirstName = "Kelvin",
                            LastName = "Doe",
                            LocationCode = "us-50",
                            LocationCoverageName = "United State"
                        },
                        new
                        {
                            Id = new Guid("3ce4beec-a185-4b8b-8494-ad408f41436a"),
                            DateOfBirth = new DateTime(1995, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "longtimeaffiliate@shopsrus.ng",
                            FirstName = "Samson",
                            LastName = "Jude",
                            LocationCode = "ng-50",
                            LocationCoverageName = "Nigeria"
                        },
                        new
                        {
                            Id = new Guid("d1d609ff-ae3f-4da5-a2de-f1d18fbb6b2f"),
                            DateOfBirth = new DateTime(1995, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "affiliate@shopsrus.ng",
                            FirstName = "Samson",
                            LastName = "Jude",
                            LocationCode = "ng-50",
                            LocationCoverageName = "Nigeria"
                        });
                });

            modelBuilder.Entity("ShopsRCUS.Discount.API.Models.Coupon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("DiscountPercentage")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ValidUntill")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("ShopsRCUS.Discount.API.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHashed")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("669497a1-9f29-4123-a504-d1cd922e892a"),
                            Address = "Around 127.0.0.1",
                            CreatedAt = new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8864),
                            EmailAddress = "user2@gmail.com",
                            FirstName = "User1",
                            LastName = "Seed1",
                            PasswordHashed = "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2",
                            UpdatedAt = new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8864)
                        },
                        new
                        {
                            Id = new Guid("0e37ad08-9dc1-44fd-b01d-32ed60a75e14"),
                            Address = "Around 127.0.0.1",
                            CreatedAt = new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8874),
                            EmailAddress = "employee1@shopsrus.us",
                            FirstName = "User2",
                            LastName = "Seed2",
                            PasswordHashed = "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2",
                            UpdatedAt = new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8875)
                        },
                        new
                        {
                            Id = new Guid("446dff2a-5e91-48a2-994a-4362a21b2fc1"),
                            Address = "Around 127.0.0.1",
                            CreatedAt = new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8877),
                            EmailAddress = "employee3@shopsrus.uk",
                            FirstName = "User5",
                            LastName = "Seed5",
                            PasswordHashed = "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2",
                            UpdatedAt = new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8878)
                        },
                        new
                        {
                            Id = new Guid("8d30913c-8647-48a7-992a-0844b44e644c"),
                            Address = "Around 127.0.0.1",
                            CreatedAt = new DateTime(2019, 11, 20, 6, 20, 40, 0, DateTimeKind.Unspecified),
                            EmailAddress = "oldcustomer@gmail.com",
                            FirstName = "User3",
                            LastName = "Seed3",
                            PasswordHashed = "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2",
                            UpdatedAt = new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8890)
                        },
                        new
                        {
                            Id = new Guid("8bab2892-e8e5-4252-aabe-7c97ebc755f3"),
                            Address = "Around 127.0.0.1",
                            CreatedAt = new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8893),
                            EmailAddress = "affiliate@shopsrus.ng",
                            FirstName = "User4",
                            LastName = "Seed4",
                            PasswordHashed = "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2",
                            UpdatedAt = new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8894)
                        },
                        new
                        {
                            Id = new Guid("3087811f-3539-4a8a-971c-1ee3dc172ab0"),
                            Address = "Lagos Nigeria",
                            CreatedAt = new DateTime(2019, 11, 20, 6, 20, 40, 0, DateTimeKind.Unspecified),
                            EmailAddress = "longtimeemployee@shopsrus.us",
                            FirstName = "Employee2",
                            LastName = "oregon",
                            PasswordHashed = "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2",
                            UpdatedAt = new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8897)
                        },
                        new
                        {
                            Id = new Guid("e8427d69-7fc7-4804-94dc-50964a7a7f16"),
                            Address = "Lagos Nigeria",
                            CreatedAt = new DateTime(2019, 11, 20, 6, 20, 40, 0, DateTimeKind.Unspecified),
                            EmailAddress = "longtimeaffiliate@shopsrus.ng",
                            FirstName = "audu",
                            LastName = "ikeji",
                            PasswordHashed = "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2",
                            UpdatedAt = new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8900)
                        });
                });

            modelBuilder.Entity("ShopsRCUS.Discount.API.Models.Discount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("DiscountPercentage")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCouponType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ValidUntill")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Discounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1f78fcc9-35ec-43d4-804f-2fd4804628a4"),
                            CreatedAt = new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8220),
                            Description = "an affiliate of the store discount",
                            DiscountPercentage = 10m,
                            IsCouponType = false,
                            Type = "affiliatediscount",
                            UpdatedAt = new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8221),
                            ValidUntill = new DateTime(2025, 11, 20, 6, 20, 40, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("a947feef-a419-437f-ae1b-6aafe88d4140"),
                            CreatedAt = new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8229),
                            Description = "$5 is deducted for every $100",
                            DiscountPercentage = 5m,
                            IsCouponType = false,
                            Type = "everyhundreddollardiscount",
                            UpdatedAt = new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8229),
                            ValidUntill = new DateTime(2025, 11, 20, 6, 20, 40, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("40db375f-7bed-46ec-9648-8b126579909b"),
                            CreatedAt = new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8233),
                            Description = "an employee of the store discount",
                            DiscountPercentage = 30m,
                            IsCouponType = false,
                            Type = "employeediscount",
                            UpdatedAt = new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8233),
                            ValidUntill = new DateTime(2025, 11, 20, 6, 20, 40, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("b83b3842-ba2e-4d96-a7a8-b3d95d36bc17"),
                            CreatedAt = new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8236),
                            Description = "customers of over 2 years discount",
                            DiscountPercentage = 5m,
                            IsCouponType = false,
                            Type = "longtimecustomerdiscount",
                            UpdatedAt = new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8236),
                            ValidUntill = new DateTime(2025, 11, 20, 6, 20, 40, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ShopsRCUS.Discount.API.Models.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Discounts")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPaymentComplete")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("PaymentBalance")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalAmountAfterDiscounts")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("ShopsRCUS.Discount.API.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsGroceryType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ShopsRCUS.Discount.API.Models.Product", b =>
                {
                    b.HasOne("ShopsRCUS.Discount.API.Models.Invoice", null)
                        .WithMany("Products")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShopsRCUS.Discount.API.Models.Invoice", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
