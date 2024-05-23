using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmlakPlus.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddingMailRead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Read",
                table: "Mails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Read",
                table: "Mails");
        }
    }
}
