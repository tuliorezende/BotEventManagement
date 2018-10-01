using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class ChangeKeyType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTalks_Event_EventId",
                schema: "BotEventManagement",
                table: "UserTalks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTalks",
                schema: "BotEventManagement",
                table: "UserTalks");

            migrationBuilder.DropIndex(
                name: "IX_UserTalks_UserId_EventId_ActivityId",
                schema: "BotEventManagement",
                table: "UserTalks");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "BotEventManagement",
                table: "Activity",
                newName: "ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_Id_EventId",
                schema: "BotEventManagement",
                table: "Activity",
                newName: "IX_Activity_ActivityId_EventId");

            migrationBuilder.AlterColumn<string>(
                name: "EventId",
                schema: "BotEventManagement",
                table: "UserTalks",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTalks",
                schema: "BotEventManagement",
                table: "UserTalks",
                columns: new[] { "UserId", "ActivityId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTalks_UserId_ActivityId",
                schema: "BotEventManagement",
                table: "UserTalks",
                columns: new[] { "UserId", "ActivityId" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTalks_Event_EventId",
                schema: "BotEventManagement",
                table: "UserTalks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTalks",
                schema: "BotEventManagement",
                table: "UserTalks");

            migrationBuilder.DropIndex(
                name: "IX_UserTalks_UserId_ActivityId",
                schema: "BotEventManagement",
                table: "UserTalks");

            migrationBuilder.RenameColumn(
                name: "ActivityId",
                schema: "BotEventManagement",
                table: "Activity",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_ActivityId_EventId",
                schema: "BotEventManagement",
                table: "Activity",
                newName: "IX_Activity_Id_EventId");

            migrationBuilder.AlterColumn<string>(
                name: "EventId",
                schema: "BotEventManagement",
                table: "UserTalks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTalks",
                schema: "BotEventManagement",
                table: "UserTalks",
                columns: new[] { "UserId", "EventId", "ActivityId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTalks_UserId_EventId_ActivityId",
                schema: "BotEventManagement",
                table: "UserTalks",
                columns: new[] { "UserId", "EventId", "ActivityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserTalks_Event_EventId",
                schema: "BotEventManagement",
                table: "UserTalks",
                column: "EventId",
                principalSchema: "BotEventManagement",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
