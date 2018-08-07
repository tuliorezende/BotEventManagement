using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class ChangePrimaryKeySpeaker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Speaker_SpeakerId",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_Event_EventId",
                table: "Speaker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Speaker",
                table: "Speaker");

            migrationBuilder.DropIndex(
                name: "IX_Activity_SpeakerId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "SpeakerId",
                table: "Speaker");

            migrationBuilder.AlterColumn<string>(
                name: "EventId",
                table: "Speaker",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpeakerId2",
                table: "Speaker",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpeakerEventId",
                table: "Activity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpeakerId2",
                table: "Activity",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Speaker_SpeakerId2",
                table: "Speaker",
                column: "SpeakerId2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Speaker",
                table: "Speaker",
                columns: new[] { "SpeakerId2", "EventId" });

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_SpeakerId2_EventId",
                table: "Speaker",
                columns: new[] { "SpeakerId2", "EventId" });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_SpeakerId2_SpeakerEventId",
                table: "Activity",
                columns: new[] { "SpeakerId2", "SpeakerEventId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Speaker_SpeakerId2_SpeakerEventId",
                table: "Activity",
                columns: new[] { "SpeakerId2", "SpeakerEventId" },
                principalTable: "Speaker",
                principalColumns: new[] { "SpeakerId2", "EventId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_Event_EventId",
                table: "Speaker",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Speaker_SpeakerId2_SpeakerEventId",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_Event_EventId",
                table: "Speaker");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Speaker_SpeakerId2",
                table: "Speaker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Speaker",
                table: "Speaker");

            migrationBuilder.DropIndex(
                name: "IX_Speaker_SpeakerId2_EventId",
                table: "Speaker");

            migrationBuilder.DropIndex(
                name: "IX_Activity_SpeakerId2_SpeakerEventId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "SpeakerId2",
                table: "Speaker");

            migrationBuilder.DropColumn(
                name: "SpeakerEventId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "SpeakerId2",
                table: "Activity");

            migrationBuilder.AlterColumn<string>(
                name: "EventId",
                table: "Speaker",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "SpeakerId",
                table: "Speaker",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Speaker",
                table: "Speaker",
                column: "SpeakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_SpeakerId",
                table: "Activity",
                column: "SpeakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Speaker_SpeakerId",
                table: "Activity",
                column: "SpeakerId",
                principalTable: "Speaker",
                principalColumn: "SpeakerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_Event_EventId",
                table: "Speaker",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
