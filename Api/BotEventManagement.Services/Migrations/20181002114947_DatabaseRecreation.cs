using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class DatabaseRecreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BotEventManagement");

            migrationBuilder.CreateTable(
                name: "Event",
                schema: "BotEventManagement",
                columns: table => new
                {
                    EventId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                schema: "BotEventManagement",
                columns: table => new
                {
                    SpeakerId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Biography = table.Column<string>(nullable: true),
                    UploadedPhoto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.SpeakerId);
                });

            migrationBuilder.CreateTable(
                name: "EventParticipants",
                schema: "BotEventManagement",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    EventId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipants", x => new { x.Id, x.EventId });
                    table.ForeignKey(
                        name: "FK_EventParticipants_Event_EventId",
                        column: x => x.EventId,
                        principalSchema: "BotEventManagement",
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                schema: "BotEventManagement",
                columns: table => new
                {
                    ActivityId = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EventId = table.Column<string>(nullable: true),
                    SpeakerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activity_Event_EventId",
                        column: x => x.EventId,
                        principalSchema: "BotEventManagement",
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activity_Speaker_SpeakerId",
                        column: x => x.SpeakerId,
                        principalSchema: "BotEventManagement",
                        principalTable: "Speaker",
                        principalColumn: "SpeakerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTalks",
                schema: "BotEventManagement",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    ActivityId = table.Column<string>(nullable: false),
                    EventId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTalks", x => new { x.UserId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_UserTalks_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalSchema: "BotEventManagement",
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTalks_Event_EventId",
                        column: x => x.EventId,
                        principalSchema: "BotEventManagement",
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_EventId",
                schema: "BotEventManagement",
                table: "Activity",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_SpeakerId",
                schema: "BotEventManagement",
                table: "Activity",
                column: "SpeakerId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_EventId",
                schema: "BotEventManagement",
                table: "EventParticipants",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_Id_EventId",
                schema: "BotEventManagement",
                table: "EventParticipants",
                columns: new[] { "Id", "EventId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTalks_ActivityId",
                schema: "BotEventManagement",
                table: "UserTalks",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTalks_EventId",
                schema: "BotEventManagement",
                table: "UserTalks",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTalks_UserId_ActivityId",
                schema: "BotEventManagement",
                table: "UserTalks",
                columns: new[] { "UserId", "ActivityId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventParticipants",
                schema: "BotEventManagement");

            migrationBuilder.DropTable(
                name: "UserTalks",
                schema: "BotEventManagement");

            migrationBuilder.DropTable(
                name: "Activity",
                schema: "BotEventManagement");

            migrationBuilder.DropTable(
                name: "Event",
                schema: "BotEventManagement");

            migrationBuilder.DropTable(
                name: "Speaker",
                schema: "BotEventManagement");
        }
    }
}
