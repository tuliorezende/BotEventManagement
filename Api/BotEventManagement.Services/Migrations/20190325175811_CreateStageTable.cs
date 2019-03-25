using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class CreateStageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stages",
                schema: "BotEventManagement",
                columns: table => new
                {
                    StageId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ActivityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.StageId);
                    table.ForeignKey(
                        name: "FK_Stages_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalSchema: "BotEventManagement",
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stages_ActivityId",
                schema: "BotEventManagement",
                table: "Stages",
                column: "ActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stages",
                schema: "BotEventManagement");
        }
    }
}
