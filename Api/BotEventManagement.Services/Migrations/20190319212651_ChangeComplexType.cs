using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class ChangeComplexType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Street",
                schema: "BotEventManagement",
                table: "Event",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                schema: "BotEventManagement",
                table: "Event",
                newName: "Address_Longitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                schema: "BotEventManagement",
                table: "Event",
                newName: "Address_Latitude");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_Street",
                schema: "BotEventManagement",
                table: "Event",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Address_Longitude",
                schema: "BotEventManagement",
                table: "Event",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "Address_Latitude",
                schema: "BotEventManagement",
                table: "Event",
                newName: "Latitude");
        }
    }
}
