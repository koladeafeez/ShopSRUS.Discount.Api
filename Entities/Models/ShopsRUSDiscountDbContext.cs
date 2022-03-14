using Microsoft.EntityFrameworkCore;
using ShopsRCUS.Discount.API.Models;

namespace ShopsRCUS.Discount.API.Entities.Models
{
    public class ShopsRUSDiscountDbContext : DbContext
    {
        public ShopsRUSDiscountDbContext(DbContextOptions<ShopsRUSDiscountDbContext> contextOptions) : base(contextOptions)
        { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Coupon> Coupons { get; set; }
        
        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<ShopsRCUS.Discount.API.Models.Discount> Discounts { get; set; }

        public DbSet<GlobalEmployeeMock> globalEmployeeMocks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopsRCUS.Discount.API.Models.Discount>().HasData(
                new ShopsRCUS.Discount.API.Models.Discount
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Description = "an affiliate of the store discount",
                    DiscountPercentage = 10,
                    IsCouponType = false,
                    Type = "affiliatediscount",
                    ValidUntill = new DateTime(2025, 11, 20, 6, 20, 40)

                },
                new ShopsRCUS.Discount.API.Models.Discount
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Description = "$5 is deducted for every $100",
                    DiscountPercentage = 5,
                    IsCouponType = false,
                    Type = "everyhundreddollardiscount",
                    ValidUntill = new DateTime(2025, 11, 20, 6, 20, 40)

                },
                new ShopsRCUS.Discount.API.Models.Discount
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Description = "an employee of the store discount",
                    DiscountPercentage = 30,
                    IsCouponType = false,
                    Type = "employeediscount",
                    ValidUntill = new DateTime(2025, 11, 20, 6, 20, 40)

                },
                new ShopsRCUS.Discount.API.Models.Discount
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Description = "customers of over 2 years discount",
                    DiscountPercentage = 5,
                    IsCouponType = false,
                    Type = "longtimecustomerdiscount",
                    ValidUntill = new DateTime(2025, 11, 20, 6, 20, 40)

                }
            );

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(i => i.EmailAddress).IsUnique();
                entity.HasData(
                    new Customer
                    {
                        Address = "Around 127.0.0.1",
                        EmailAddress = "user2@gmail.com",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        FirstName = "User1",
                        Id = Guid.NewGuid(),
                        LastName = "Seed1",
                        PasswordHashed = "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2"
                    },
                    new Customer
                    {
                        Address = "Around 127.0.0.1",
                        EmailAddress = "employee1@shopsrus.us",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        FirstName = "User2",
                        Id = Guid.NewGuid(),
                        LastName = "Seed2",
                        PasswordHashed = "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2"
                    },
                                        new Customer
                                        {
                                            Address = "Around 127.0.0.1",
                                            EmailAddress = "employee3@shopsrus.uk",
                                            CreatedAt = DateTime.Now,
                                            UpdatedAt = DateTime.Now,
                                            FirstName = "User5",
                                            Id = Guid.NewGuid(),
                                            LastName = "Seed5",
                                            PasswordHashed = "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2"
                                        },
                    new Customer
                    {
                        Address = "Around 127.0.0.1",
                        EmailAddress = "oldcustomer@gmail.com",
                        CreatedAt = new DateTime(2019, 11, 20, 6, 20, 40),
                        UpdatedAt = DateTime.Now,
                        FirstName = "User3",
                        Id = Guid.NewGuid(),
                        LastName = "Seed3",
                        PasswordHashed = "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2"
                    },
                    new Customer
                    {
                        Address = "Around 127.0.0.1",
                        EmailAddress = "affiliate@shopsrus.ng",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        FirstName = "User4",
                        Id = Guid.NewGuid(),
                        LastName = "Seed4",
                        PasswordHashed = "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2"
                    },
                     new Customer
                     {
                         Address = "Lagos Nigeria",
                         EmailAddress = "longtimeemployee@shopsrus.us",
                         CreatedAt = new DateTime(2019, 11, 20, 6, 20, 40),
                         UpdatedAt = DateTime.Now,
                         FirstName = "Employee2",
                         Id = Guid.NewGuid(),
                         LastName = "oregon",
                         PasswordHashed = "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2"
                     },
                      new Customer
                      {
                          Address = "Lagos Nigeria",
                          EmailAddress = "longtimeaffiliate@shopsrus.ng",
                          CreatedAt = new DateTime(2019, 11, 20, 6, 20, 40),
                          UpdatedAt = DateTime.Now,
                          FirstName = "audu",
                          Id = Guid.NewGuid(),
                          LastName = "ikeji",
                          PasswordHashed = "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2"
                      }
                    );
                });

            modelBuilder.Entity<GlobalEmployeeMock>(entity =>
            {
                entity.HasIndex(i => i.Email).IsUnique();
                entity.HasData(
                    new GlobalEmployeeMock
                    {
                        DateOfBirth = new DateTime(1995, 10, 10),
                        Email = "employee1@shopsrus.us",
                        LocationCode = "us-200",
                        LocationCoverageName = "United State",
                        FirstName = "Johnney",
                        Id = Guid.NewGuid(),
                        LastName = "Donney"
                    },
                     new GlobalEmployeeMock
                     {
                         DateOfBirth = new DateTime(1996, 10, 10),
                         Email = "employee2@shopsrus.uk",
                         LocationCode = "uk-100",
                         LocationCoverageName = "United Kingdom",
                         FirstName = "Alina",
                         Id = Guid.NewGuid(),
                         LastName = "Fisher"
                     },
                      new GlobalEmployeeMock
                      {
                          DateOfBirth = new DateTime(1995, 10, 10),
                          Email = "longtimeemployee@shopsrus.us",
                          LocationCode = "us-50",
                          LocationCoverageName = "United State",
                          FirstName = "Kelvin",
                          Id = Guid.NewGuid(),
                          LastName = "Doe"
                      },
                      new GlobalEmployeeMock
                      {
                          DateOfBirth = new DateTime(1995, 10, 10),
                          Email = "longtimeaffiliate@shopsrus.ng",
                          LocationCode = "ng-50",
                          LocationCoverageName = "Nigeria",
                          FirstName = "Samson",
                          Id = Guid.NewGuid(),
                          LastName = "Jude"
                      },
                      new GlobalEmployeeMock
                      {
                          DateOfBirth = new DateTime(1995, 10, 10),
                          Email = "affiliate@shopsrus.ng",
                          LocationCode = "ng-50",
                          LocationCoverageName = "Nigeria",
                          FirstName = "Samson",
                          Id = Guid.NewGuid(),
                          LastName = "Jude"
                      }                    
                    );
            });
        }
        }

    }

    


