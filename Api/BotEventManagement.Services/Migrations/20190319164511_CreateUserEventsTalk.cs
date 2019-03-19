using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class CreateUserEventsTalk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "BotEventManagement",
                table: "Users",
                newName: "UserId");

            migrationBuilder.CreateTable(
                name: "UserEvents",
                schema: "BotEventManagement",
                columns: table => new
                {
                    EventId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEvents", x => new { x.UserId, x.EventId });
                    table.ForeignKey(
                        name: "FK_UserEvents_Event_EventId",
                        column: x => x.EventId,
                        principalSchema: "BotEventManagement",
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEvents_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "BotEventManagement",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_EventId",
                schema: "BotEventManagement",
                table: "UserEvents",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEvents",
                schema: "BotEventManagement");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "BotEventManagement",
                table: "Users",
                newName: "Id");
        }
    }
}
