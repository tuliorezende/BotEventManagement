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
                name: "Speaker",
                schema: "BotEventManagement",
                columns: table => new
                {
                    SpeakerId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Biography = table.Column<string>(nullable: true),
                    UploadedPhoto = table.Column<string>(nullable: true),
                    EventId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => new { x.SpeakerId, x.EventId });
                    table.ForeignKey(
                        name: "FK_Speaker_Event_EventId",
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
                    EventId = table.Column<string>(nullable: false),
                    SpeakerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => new { x.ActivityId, x.EventId });
                    table.ForeignKey(
                        name: "FK_Activity_Event_EventId",
                        column: x => x.EventId,
                        principalSchema: "BotEventManagement",
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_Speaker_SpeakerId_EventId",
                        columns: x => new { x.SpeakerId, x.EventId },
                        principalSchema: "BotEventManagement",
                        principalTable: "Speaker",
                        principalColumns: new[] { "SpeakerId", "EventId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTalks",
                schema: "BotEventManagement",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    ActivityId = table.Column<string>(nullable: false),
                    ActivityId1 = table.Column<string>(nullable: true),
                    ActivityEventId = table.Column<string>(nullable: true),
                    EventId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTalks", x => new { x.UserId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_UserTalks_Event_EventId",
                        column: x => x.EventId,
                        principalSchema: "BotEventManagement",
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTalks_Activity_ActivityId1_ActivityEventId",
                        columns: x => new { x.ActivityId1, x.ActivityEventId },
                        principalSchema: "BotEventManagement",
                        principalTable: "Activity",
                        principalColumns: new[] { "ActivityId", "EventId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_EventId",
                schema: "BotEventManagement",
                table: "Activity",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ActivityId_EventId",
                schema: "BotEventManagement",
                table: "Activity",
                columns: new[] { "ActivityId", "EventId" });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_SpeakerId_EventId",
                schema: "BotEventManagement",
                table: "Activity",
                columns: new[] { "SpeakerId", "EventId" });

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
                name: "IX_Speaker_EventId",
                schema: "BotEventManagement",
                table: "Speaker",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_SpeakerId_EventId",
                schema: "BotEventManagement",
                table: "Speaker",
                columns: new[] { "SpeakerId", "EventId" });

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
                name: "Speaker",
                schema: "BotEventManagement");

            migrationBuilder.DropTable(
                name: "Event",
                schema: "BotEventManagement");
        }
    }
}
