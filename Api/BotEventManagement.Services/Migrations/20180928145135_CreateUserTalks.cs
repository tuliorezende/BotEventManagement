using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class CreateUserTalks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BotEventManagement");

            migrationBuilder.RenameTable(
                name: "Speaker",
                newName: "Speaker",
                newSchema: "BotEventManagement");

            migrationBuilder.RenameTable(
                name: "EventParticipants",
                newName: "EventParticipants",
                newSchema: "BotEventManagement");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Event",
                newSchema: "BotEventManagement");

            migrationBuilder.RenameTable(
                name: "Activity",
                newName: "Activity",
                newSchema: "BotEventManagement");

            migrationBuilder.CreateTable(
                name: "UserTalks",
                schema: "BotEventManagement",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    EventId = table.Column<string>(nullable: false),
                    ActivityId = table.Column<string>(nullable: false),
                    ActivityId1 = table.Column<string>(nullable: true),
                    ActivityEventId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTalks", x => new { x.UserId, x.EventId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_UserTalks_Event_EventId",
                        column: x => x.EventId,
                        principalSchema: "BotEventManagement",
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTalks_Activity_ActivityId1_ActivityEventId",
                        columns: x => new { x.ActivityId1, x.ActivityEventId },
                        principalSchema: "BotEventManagement",
                        principalTable: "Activity",
                        principalColumns: new[] { "Id", "EventId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTalks_EventId",
                schema: "BotEventManagement",
                table: "UserTalks",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTalks_ActivityId1_ActivityEventId",
                schema: "BotEventManagement",
                table: "UserTalks",
                columns: new[] { "ActivityId1", "ActivityEventId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTalks_UserId_EventId_ActivityId",
                schema: "BotEventManagement",
                table: "UserTalks",
                columns: new[] { "UserId", "EventId", "ActivityId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTalks",
                schema: "BotEventManagement");

            migrationBuilder.RenameTable(
                name: "Speaker",
                schema: "BotEventManagement",
                newName: "Speaker");

            migrationBuilder.RenameTable(
                name: "EventParticipants",
                schema: "BotEventManagement",
                newName: "EventParticipants");

            migrationBuilder.RenameTable(
                name: "Event",
                schema: "BotEventManagement",
                newName: "Event");

            migrationBuilder.RenameTable(
                name: "Activity",
                schema: "BotEventManagement",
                newName: "Activity");
        }
    }
}
