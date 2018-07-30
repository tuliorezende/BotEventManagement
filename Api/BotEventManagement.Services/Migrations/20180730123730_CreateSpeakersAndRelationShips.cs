using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class CreateSpeakersAndRelationShips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventId",
                table: "EventParticipants",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    SpeakerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Biography = table.Column<string>(nullable: true),
                    UploadedPhoto = table.Column<string>(nullable: true),
                    EventId = table.Column<string>(nullable: true),
                    EventParticipantsId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.SpeakerId);
                    table.ForeignKey(
                        name: "FK_Speaker_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Speaker_EventParticipants_EventParticipantsId",
                        column: x => x.EventParticipantsId,
                        principalTable: "EventParticipants",
                        principalColumn: "EventParticipantsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_EventId",
                table: "EventParticipants",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_EventId",
                table: "Speaker",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_EventParticipantsId",
                table: "Speaker",
                column: "EventParticipantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_Event_EventId",
                table: "EventParticipants",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_Event_EventId",
                table: "EventParticipants");

            migrationBuilder.DropTable(
                name: "Speaker");

            migrationBuilder.DropIndex(
                name: "IX_EventParticipants_EventId",
                table: "EventParticipants");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "EventParticipants");
        }
    }
}
