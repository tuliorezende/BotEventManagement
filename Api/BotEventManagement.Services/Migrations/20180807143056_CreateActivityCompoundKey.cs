using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class CreateActivityCompoundKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Event_EventId",
                table: "Activity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activity",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Activity");

            migrationBuilder.AlterColumn<string>(
                name: "EventId",
                table: "Activity",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id2",
                table: "Activity",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activity",
                table: "Activity",
                columns: new[] { "Id2", "EventId" });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_Id2_EventId",
                table: "Activity",
                columns: new[] { "Id2", "EventId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Event_EventId",
                table: "Activity",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Event_EventId",
                table: "Activity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activity",
                table: "Activity");

            migrationBuilder.DropIndex(
                name: "IX_Activity_Id2_EventId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "Id2",
                table: "Activity");

            migrationBuilder.AlterColumn<string>(
                name: "EventId",
                table: "Activity",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Activity",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activity",
                table: "Activity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Event_EventId",
                table: "Activity",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
