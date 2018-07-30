using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class CreateEventParticipantsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventParticipants",
                columns: table => new
                {
                    EventParticipantsId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipants", x => x.EventParticipantsId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventParticipants");
        }
    }
}
