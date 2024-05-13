using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmlakPlus.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddingContactandMail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Contacts",
                newName: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contacts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Contacts",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Contacts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Contacts",
                newName: "Subject");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contacts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Contacts",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Contacts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
