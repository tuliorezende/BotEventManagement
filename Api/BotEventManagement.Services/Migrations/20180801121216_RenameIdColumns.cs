using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class RenameIdColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Speaker",
                newName: "SpeakerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Event",
                newName: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpeakerId",
                table: "Speaker",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Event",
                newName: "Id");
        }
    }
}
