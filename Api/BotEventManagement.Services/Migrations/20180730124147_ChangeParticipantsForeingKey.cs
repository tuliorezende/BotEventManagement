using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class ChangeParticipantsForeingKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_EventParticipants_EventParticipantsId",
                table: "Speaker");

            migrationBuilder.DropIndex(
                name: "IX_Speaker_EventParticipantsId",
                table: "Speaker");

            migrationBuilder.DropColumn(
                name: "EventParticipantsId",
                table: "Speaker");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventParticipantsId",
                table: "Speaker",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_EventParticipantsId",
                table: "Speaker",
                column: "EventParticipantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_EventParticipants_EventParticipantsId",
                table: "Speaker",
                column: "EventParticipantsId",
                principalTable: "EventParticipants",
                principalColumn: "EventParticipantsId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
