using Microsoft.EntityFrameworkCore.Migrations;

namespace PlatDuJour.DAL.Migrations
{
    public partial class removeuserIDfromDailyPlate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyPlates_AspNetUsers_UserId",
                table: "DailyPlates");

            migrationBuilder.DropIndex(
                name: "IX_DailyPlates_UserId",
                table: "DailyPlates");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DailyPlates");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "DailyPlates",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyPlates_ApplicationUserId",
                table: "DailyPlates",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyPlates_AspNetUsers_ApplicationUserId",
                table: "DailyPlates",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyPlates_AspNetUsers_ApplicationUserId",
                table: "DailyPlates");

            migrationBuilder.DropIndex(
                name: "IX_DailyPlates_ApplicationUserId",
                table: "DailyPlates");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "DailyPlates");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "DailyPlates",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DailyPlates_UserId",
                table: "DailyPlates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyPlates_AspNetUsers_UserId",
                table: "DailyPlates",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
