using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopsRCUS.Discount.API.Migrations
{
    public partial class SeedDb_WithData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DiscountPercentage = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValidUntill = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PasswordHashed = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DiscountPercentage = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValidUntill = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsCouponType = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "globalEmployeeMocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    LocationCode = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false),
                    LocationCoverageName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_globalEmployeeMocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsPaymentComplete = table.Column<bool>(type: "INTEGER", nullable: false),
                    PaymentBalance = table.Column<decimal>(type: "TEXT", nullable: false),
                    Discounts = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalAmountAfterDiscounts = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsGroceryType = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHashed", "UpdatedAt" },
                values: new object[] { new Guid("0e37ad08-9dc1-44fd-b01d-32ed60a75e14"), "Around 127.0.0.1", new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8874), "employee1@shopsrus.us", "User2", "Seed2", "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2", new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8875) });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHashed", "UpdatedAt" },
                values: new object[] { new Guid("3087811f-3539-4a8a-971c-1ee3dc172ab0"), "Lagos Nigeria", new DateTime(2019, 11, 20, 6, 20, 40, 0, DateTimeKind.Unspecified), "longtimeemployee@shopsrus.us", "Employee2", "oregon", "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2", new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8897) });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHashed", "UpdatedAt" },
                values: new object[] { new Guid("446dff2a-5e91-48a2-994a-4362a21b2fc1"), "Around 127.0.0.1", new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8877), "employee3@shopsrus.uk", "User5", "Seed5", "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2", new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8878) });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHashed", "UpdatedAt" },
                values: new object[] { new Guid("669497a1-9f29-4123-a504-d1cd922e892a"), "Around 127.0.0.1", new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8864), "user2@gmail.com", "User1", "Seed1", "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2", new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8864) });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHashed", "UpdatedAt" },
                values: new object[] { new Guid("8bab2892-e8e5-4252-aabe-7c97ebc755f3"), "Around 127.0.0.1", new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8893), "affiliate@shopsrus.ng", "User4", "Seed4", "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2", new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8894) });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHashed", "UpdatedAt" },
                values: new object[] { new Guid("8d30913c-8647-48a7-992a-0844b44e644c"), "Around 127.0.0.1", new DateTime(2019, 11, 20, 6, 20, 40, 0, DateTimeKind.Unspecified), "oldcustomer@gmail.com", "User3", "Seed3", "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2", new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8890) });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHashed", "UpdatedAt" },
                values: new object[] { new Guid("e8427d69-7fc7-4804-94dc-50964a7a7f16"), "Lagos Nigeria", new DateTime(2019, 11, 20, 6, 20, 40, 0, DateTimeKind.Unspecified), "longtimeaffiliate@shopsrus.ng", "audu", "ikeji", "$2a$11$TOc6SI3D8sqH.b.AtxWyzu2yc8eL6aR4C7yIVtNQuxmKRWbhimvg2", new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8900) });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "CreatedAt", "Description", "DiscountPercentage", "IsCouponType", "Type", "UpdatedAt", "ValidUntill" },
                values: new object[] { new Guid("1f78fcc9-35ec-43d4-804f-2fd4804628a4"), new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8220), "an affiliate of the store discount", 10m, false, "affiliatediscount", new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8221), new DateTime(2025, 11, 20, 6, 20, 40, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "CreatedAt", "Description", "DiscountPercentage", "IsCouponType", "Type", "UpdatedAt", "ValidUntill" },
                values: new object[] { new Guid("40db375f-7bed-46ec-9648-8b126579909b"), new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8233), "an employee of the store discount", 30m, false, "employeediscount", new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8233), new DateTime(2025, 11, 20, 6, 20, 40, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "CreatedAt", "Description", "DiscountPercentage", "IsCouponType", "Type", "UpdatedAt", "ValidUntill" },
                values: new object[] { new Guid("a947feef-a419-437f-ae1b-6aafe88d4140"), new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8229), "$5 is deducted for every $100", 5m, false, "everyhundreddollardiscount", new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8229), new DateTime(2025, 11, 20, 6, 20, 40, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "CreatedAt", "Description", "DiscountPercentage", "IsCouponType", "Type", "UpdatedAt", "ValidUntill" },
                values: new object[] { new Guid("b83b3842-ba2e-4d96-a7a8-b3d95d36bc17"), new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8236), "customers of over 2 years discount", 5m, false, "longtimecustomerdiscount", new DateTime(2022, 3, 14, 11, 51, 13, 83, DateTimeKind.Local).AddTicks(8236), new DateTime(2025, 11, 20, 6, 20, 40, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "globalEmployeeMocks",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "LocationCode", "LocationCoverageName" },
                values: new object[] { new Guid("0362aa24-3ac5-48ed-a984-c18f9fd97dbe"), new DateTime(1995, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "longtimeemployee@shopsrus.us", "Kelvin", "Doe", "us-50", "United State" });

            migrationBuilder.InsertData(
                table: "globalEmployeeMocks",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "LocationCode", "LocationCoverageName" },
                values: new object[] { new Guid("3ce4beec-a185-4b8b-8494-ad408f41436a"), new DateTime(1995, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "longtimeaffiliate@shopsrus.ng", "Samson", "Jude", "ng-50", "Nigeria" });

            migrationBuilder.InsertData(
                table: "globalEmployeeMocks",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "LocationCode", "LocationCoverageName" },
                values: new object[] { new Guid("81923066-da0d-4bbd-aec5-925c038e01fd"), new DateTime(1996, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "employee2@shopsrus.uk", "Alina", "Fisher", "uk-100", "United Kingdom" });

            migrationBuilder.InsertData(
                table: "globalEmployeeMocks",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "LocationCode", "LocationCoverageName" },
                values: new object[] { new Guid("c0515528-1891-4968-9a22-ef202a5c7acb"), new DateTime(1995, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "employee1@shopsrus.us", "Johnney", "Donney", "us-200", "United State" });

            migrationBuilder.InsertData(
                table: "globalEmployeeMocks",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "LocationCode", "LocationCoverageName" },
                values: new object[] { new Guid("d1d609ff-ae3f-4da5-a2de-f1d18fbb6b2f"), new DateTime(1995, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "affiliate@shopsrus.ng", "Samson", "Jude", "ng-50", "Nigeria" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_EmailAddress",
                table: "Customers",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_globalEmployeeMocks_Email",
                table: "globalEmployeeMocks",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_InvoiceId",
                table: "Product",
                column: "InvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "globalEmployeeMocks");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
