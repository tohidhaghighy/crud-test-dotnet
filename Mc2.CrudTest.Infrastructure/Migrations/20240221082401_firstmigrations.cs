using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mc2.CrudTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class firstmigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumberNumber = table.Column<string>(name: "PhoneNumber_Number", type: "nvarchar(max)", nullable: false),
                    Emailemail = table.Column<string>(name: "Email_email", type: "nvarchar(max)", nullable: false),
                    BankAccountNumberBankAccount = table.Column<string>(name: "BankAccountNumber_BankAccount", type: "nvarchar(max)", nullable: false),
                    CustomerInfoFirstName = table.Column<string>(name: "CustomerInfo_FirstName", type: "nvarchar(max)", nullable: false),
                    CustomerInfoLastName = table.Column<string>(name: "CustomerInfo_LastName", type: "nvarchar(max)", nullable: false),
                    CustomerInfoDateOfBirth = table.Column<DateTime>(name: "CustomerInfo_DateOfBirth", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
