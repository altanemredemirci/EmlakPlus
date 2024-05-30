using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmlakPlus.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMailReply : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mails_Agencies_AgencyId",
                table: "Mails");

            migrationBuilder.AlterColumn<int>(
                name: "AgencyId",
                table: "Mails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Reply",
                table: "Mails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Mails_Agencies_AgencyId",
                table: "Mails",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mails_Agencies_AgencyId",
                table: "Mails");

            migrationBuilder.DropColumn(
                name: "Reply",
                table: "Mails");

            migrationBuilder.AlterColumn<int>(
                name: "AgencyId",
                table: "Mails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Mails_Agencies_AgencyId",
                table: "Mails",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "Id");
        }
    }
}
