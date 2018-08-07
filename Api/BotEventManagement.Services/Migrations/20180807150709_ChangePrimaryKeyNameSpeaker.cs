using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class ChangePrimaryKeyNameSpeaker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Speaker_SpeakerId2_SpeakerEventId",
                table: "Activity");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Speaker_SpeakerId2",
                table: "Speaker");

            migrationBuilder.RenameColumn(
                name: "SpeakerId2",
                table: "Speaker",
                newName: "SpeakerId");

            migrationBuilder.RenameIndex(
                name: "IX_Speaker_SpeakerId2_EventId",
                table: "Speaker",
                newName: "IX_Speaker_SpeakerId_EventId");

            migrationBuilder.RenameColumn(
                name: "SpeakerId2",
                table: "Activity",
                newName: "SpeakerId1");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_SpeakerId2_SpeakerEventId",
                table: "Activity",
                newName: "IX_Activity_SpeakerId1_SpeakerEventId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Speaker_SpeakerId",
                table: "Speaker",
                column: "SpeakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Speaker_SpeakerId1_SpeakerEventId",
                table: "Activity",
                columns: new[] { "SpeakerId1", "SpeakerEventId" },
                principalTable: "Speaker",
                principalColumns: new[] { "SpeakerId", "EventId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Speaker_SpeakerId1_SpeakerEventId",
                table: "Activity");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Speaker_SpeakerId",
                table: "Speaker");

            migrationBuilder.RenameColumn(
                name: "SpeakerId",
                table: "Speaker",
                newName: "SpeakerId2");

            migrationBuilder.RenameIndex(
                name: "IX_Speaker_SpeakerId_EventId",
                table: "Speaker",
                newName: "IX_Speaker_SpeakerId2_EventId");

            migrationBuilder.RenameColumn(
                name: "SpeakerId1",
                table: "Activity",
                newName: "SpeakerId2");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_SpeakerId1_SpeakerEventId",
                table: "Activity",
                newName: "IX_Activity_SpeakerId2_SpeakerEventId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Speaker_SpeakerId2",
                table: "Speaker",
                column: "SpeakerId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Speaker_SpeakerId2_SpeakerEventId",
                table: "Activity",
                columns: new[] { "SpeakerId2", "SpeakerEventId" },
                principalTable: "Speaker",
                principalColumns: new[] { "SpeakerId2", "EventId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
