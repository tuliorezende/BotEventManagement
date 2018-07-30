using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class ChangeEventColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Event",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EventStartDate",
                table: "Event",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "Event",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EventEndDate",
                table: "Event",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "EventDescription",
                table: "Event",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Event",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Event",
                newName: "EventStartDate");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Event",
                newName: "EventName");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Event",
                newName: "EventEndDate");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Event",
                newName: "EventDescription");
        }
    }
}
