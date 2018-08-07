using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class CreateCompoundKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_Event_EventId",
                table: "EventParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventParticipants",
                table: "EventParticipants");

            migrationBuilder.AlterColumn<string>(
                name: "EventId",
                table: "EventParticipants",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventParticipants",
                table: "EventParticipants",
                columns: new[] { "Id", "EventId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_Event_EventId",
                table: "EventParticipants",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_Event_EventId",
                table: "EventParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventParticipants",
                table: "EventParticipants");

            migrationBuilder.AlterColumn<string>(
                name: "EventId",
                table: "EventParticipants",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventParticipants",
                table: "EventParticipants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_Event_EventId",
                table: "EventParticipants",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
