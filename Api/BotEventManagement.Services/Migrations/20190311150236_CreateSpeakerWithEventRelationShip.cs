using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class CreateSpeakerWithEventRelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventId",
                schema: "BotEventManagement",
                table: "Speaker",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_EventId",
                schema: "BotEventManagement",
                table: "Speaker",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_Event_EventId",
                schema: "BotEventManagement",
                table: "Speaker",
                column: "EventId",
                principalSchema: "BotEventManagement",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_Event_EventId",
                schema: "BotEventManagement",
                table: "Speaker");

            migrationBuilder.DropIndex(
                name: "IX_Speaker_EventId",
                schema: "BotEventManagement",
                table: "Speaker");

            migrationBuilder.DropColumn(
                name: "EventId",
                schema: "BotEventManagement",
                table: "Speaker");
        }
    }
}
