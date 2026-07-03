using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DKRSLandingPage_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocationImage",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationImage",
                table: "Projects");
        }
    }
}
