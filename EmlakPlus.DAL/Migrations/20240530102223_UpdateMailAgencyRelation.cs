using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmlakPlus.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMailAgencyRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgencyId",
                table: "Mails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mails_AgencyId",
                table: "Mails",
                column: "AgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mails_Agencies_AgencyId",
                table: "Mails",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mails_Agencies_AgencyId",
                table: "Mails");

            migrationBuilder.DropIndex(
                name: "IX_Mails_AgencyId",
                table: "Mails");

            migrationBuilder.DropColumn(
                name: "AgencyId",
                table: "Mails");
        }
    }
}
