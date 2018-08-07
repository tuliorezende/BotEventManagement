using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class ChangeColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id2",
                table: "Activity",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_Id2_EventId",
                table: "Activity",
                newName: "IX_Activity_Id_EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Activity",
                newName: "Id2");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_Id_EventId",
                table: "Activity",
                newName: "IX_Activity_Id2_EventId");
        }
    }
}
