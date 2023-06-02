using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contact_list_api.Migrations
{
    /// <inheritdoc />
    public partial class contact_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1L, new DateTime(1991, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "elvis@eblocks.co.za", "Elvis", "Thelemuka", "073-607-0756" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1L);
        }
    }
}
