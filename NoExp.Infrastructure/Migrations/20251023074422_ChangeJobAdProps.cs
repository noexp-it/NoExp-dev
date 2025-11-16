using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoExp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeJobAdProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "JobAds");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "JobAds",
                newName: "WorkType");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "JobAds",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<decimal>(
                name: "SalaryMax",
                table: "JobAds",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SalaryMin",
                table: "JobAds",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalaryMax",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "SalaryMin",
                table: "JobAds");

            migrationBuilder.RenameColumn(
                name: "WorkType",
                table: "JobAds",
                newName: "Type");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "JobAds",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "JobAds",
                type: "numeric",
                nullable: true);
        }
    }
}
