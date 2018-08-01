using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class ChangeIdPropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpeakerId",
                table: "Speaker",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EventParticipantsId",
                table: "EventParticipants",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ActivityId",
                table: "Activity",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Speaker",
                newName: "SpeakerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EventParticipants",
                newName: "EventParticipantsId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Activity",
                newName: "ActivityId");
        }
    }
}
