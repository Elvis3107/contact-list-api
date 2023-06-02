using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contact_list_api.Migrations
{
    /// <inheritdoc />
    public partial class add_office_number_field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OfficePhoneNumber",
                table: "Contacts",
                type: "longtext",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1L,
                column: "OfficePhoneNumber",
                value: "011-607-0756");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfficePhoneNumber",
                table: "Contacts");
        }
    }
}
