using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class ChangeTableNameToGuestUserTalks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTalks_Activity_ActivityId",
                schema: "BotEventManagement",
                table: "UserTalks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTalks_Event_EventId",
                schema: "BotEventManagement",
                table: "UserTalks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTalks",
                schema: "BotEventManagement",
                table: "UserTalks");

            migrationBuilder.RenameTable(
                name: "UserTalks",
                schema: "BotEventManagement",
                newName: "GuestUserTalks",
                newSchema: "BotEventManagement");

            migrationBuilder.RenameIndex(
                name: "IX_UserTalks_GuestId_ActivityId",
                schema: "BotEventManagement",
                table: "GuestUserTalks",
                newName: "IX_GuestUserTalks_GuestId_ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTalks_EventId",
                schema: "BotEventManagement",
                table: "GuestUserTalks",
                newName: "IX_GuestUserTalks_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTalks_ActivityId",
                schema: "BotEventManagement",
                table: "GuestUserTalks",
                newName: "IX_GuestUserTalks_ActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuestUserTalks",
                schema: "BotEventManagement",
                table: "GuestUserTalks",
                columns: new[] { "GuestId", "ActivityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GuestUserTalks_Activity_ActivityId",
                schema: "BotEventManagement",
                table: "GuestUserTalks",
                column: "ActivityId",
                principalSchema: "BotEventManagement",
                principalTable: "Activity",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestUserTalks_Event_EventId",
                schema: "BotEventManagement",
                table: "GuestUserTalks",
                column: "EventId",
                principalSchema: "BotEventManagement",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestUserTalks_Activity_ActivityId",
                schema: "BotEventManagement",
                table: "GuestUserTalks");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestUserTalks_Event_EventId",
                schema: "BotEventManagement",
                table: "GuestUserTalks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GuestUserTalks",
                schema: "BotEventManagement",
                table: "GuestUserTalks");

            migrationBuilder.RenameTable(
                name: "GuestUserTalks",
                schema: "BotEventManagement",
                newName: "UserTalks",
                newSchema: "BotEventManagement");

            migrationBuilder.RenameIndex(
                name: "IX_GuestUserTalks_GuestId_ActivityId",
                schema: "BotEventManagement",
                table: "UserTalks",
                newName: "IX_UserTalks_GuestId_ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_GuestUserTalks_EventId",
                schema: "BotEventManagement",
                table: "UserTalks",
                newName: "IX_UserTalks_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_GuestUserTalks_ActivityId",
                schema: "BotEventManagement",
                table: "UserTalks",
                newName: "IX_UserTalks_ActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTalks",
                schema: "BotEventManagement",
                table: "UserTalks",
                columns: new[] { "GuestId", "ActivityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserTalks_Activity_ActivityId",
                schema: "BotEventManagement",
                table: "UserTalks",
                column: "ActivityId",
                principalSchema: "BotEventManagement",
                principalTable: "Activity",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTalks_Event_EventId",
                schema: "BotEventManagement",
                table: "UserTalks",
                column: "EventId",
                principalSchema: "BotEventManagement",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
