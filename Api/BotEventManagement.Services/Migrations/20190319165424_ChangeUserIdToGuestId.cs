using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class ChangeUserIdToGuestId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "BotEventManagement",
                table: "UserTalks",
                newName: "GuestId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTalks_UserId_ActivityId",
                schema: "BotEventManagement",
                table: "UserTalks",
                newName: "IX_UserTalks_GuestId_ActivityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "BotEventManagement",
                table: "EventParticipants",
                newName: "GuestId");

            migrationBuilder.RenameIndex(
                name: "IX_EventParticipants_Id_EventId",
                schema: "BotEventManagement",
                table: "EventParticipants",
                newName: "IX_EventParticipants_GuestId_EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GuestId",
                schema: "BotEventManagement",
                table: "UserTalks",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTalks_GuestId_ActivityId",
                schema: "BotEventManagement",
                table: "UserTalks",
                newName: "IX_UserTalks_UserId_ActivityId");

            migrationBuilder.RenameColumn(
                name: "GuestId",
                schema: "BotEventManagement",
                table: "EventParticipants",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_EventParticipants_GuestId_EventId",
                schema: "BotEventManagement",
                table: "EventParticipants",
                newName: "IX_EventParticipants_Id_EventId");
        }
    }
}
