using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BotEventManagement.Services.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<string>(nullable: false),
                    EventName = table.Column<string>(nullable: true),
                    EventDescription = table.Column<string>(nullable: true),
                    EventStartDate = table.Column<DateTime>(nullable: false),
                    EventEndDate = table.Column<DateTime>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");
        }
    }
}
