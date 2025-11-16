using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoExp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorJobAdModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Offer",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "Requirements",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "Responsibilities",
                table: "JobAds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Offer",
                table: "JobAds",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<List<string>>(
                name: "Requirements",
                table: "JobAds",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<List<string>>(
                name: "Responsibilities",
                table: "JobAds",
                type: "text[]",
                nullable: false);
        }
    }
}
