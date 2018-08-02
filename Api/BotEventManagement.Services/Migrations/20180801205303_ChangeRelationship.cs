using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class ChangeRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Activity_SpeakerId",
                table: "Activity");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_SpeakerId",
                table: "Activity",
                column: "SpeakerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Activity_SpeakerId",
                table: "Activity");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_SpeakerId",
                table: "Activity",
                column: "SpeakerId",
                unique: true);
        }
    }
}
