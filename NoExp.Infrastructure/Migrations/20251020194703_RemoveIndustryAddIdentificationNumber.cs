using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoExp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIndustryAddIdentificationNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Industry",
                table: "UserProfiles");

            migrationBuilder.AddColumn<int>(
                name: "IdentificationNumber",
                table: "UserProfiles",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentificationNumber",
                table: "UserProfiles");

            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "UserProfiles",
                type: "text",
                nullable: true);
        }
    }
}
