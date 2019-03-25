using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class ChangeStageRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stages_Activity_ActivityId",
                schema: "BotEventManagement",
                table: "Stages");

            migrationBuilder.RenameColumn(
                name: "ActivityId",
                schema: "BotEventManagement",
                table: "Stages",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Stages_ActivityId",
                schema: "BotEventManagement",
                table: "Stages",
                newName: "IX_Stages_EventId");

            migrationBuilder.AddColumn<string>(
                name: "StageId",
                schema: "BotEventManagement",
                table: "Activity",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activity_StageId",
                schema: "BotEventManagement",
                table: "Activity",
                column: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Stages_StageId",
                schema: "BotEventManagement",
                table: "Activity",
                column: "StageId",
                principalSchema: "BotEventManagement",
                principalTable: "Stages",
                principalColumn: "StageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stages_Event_EventId",
                schema: "BotEventManagement",
                table: "Stages",
                column: "EventId",
                principalSchema: "BotEventManagement",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Stages_StageId",
                schema: "BotEventManagement",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_Stages_Event_EventId",
                schema: "BotEventManagement",
                table: "Stages");

            migrationBuilder.DropIndex(
                name: "IX_Activity_StageId",
                schema: "BotEventManagement",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "StageId",
                schema: "BotEventManagement",
                table: "Activity");

            migrationBuilder.RenameColumn(
                name: "EventId",
                schema: "BotEventManagement",
                table: "Stages",
                newName: "ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_Stages_EventId",
                schema: "BotEventManagement",
                table: "Stages",
                newName: "IX_Stages_ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stages_Activity_ActivityId",
                schema: "BotEventManagement",
                table: "Stages",
                column: "ActivityId",
                principalSchema: "BotEventManagement",
                principalTable: "Activity",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
