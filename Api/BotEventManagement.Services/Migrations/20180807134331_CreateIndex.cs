using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class CreateIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_Id_EventId",
                table: "EventParticipants",
                columns: new[] { "Id", "EventId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EventParticipants_Id_EventId",
                table: "EventParticipants");
        }
    }
}
