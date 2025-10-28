using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoExp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangePublishDateType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
        @"ALTER TABLE ""JobAds"" 
          ALTER COLUMN ""Responsibilities"" TYPE text[] 
          USING ARRAY[""Responsibilities""];");

            // Alter Requirements column
            migrationBuilder.Sql(
                @"ALTER TABLE ""JobAds"" 
          ALTER COLUMN ""Requirements"" TYPE text[] 
          USING ARRAY[""Requirements""];");

            migrationBuilder.AlterColumn<List<string>>(
                name: "Responsibilities",
                table: "JobAds",
                type: "text[]",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<List<string>>(
                name: "Requirements",
                table: "JobAds",
                type: "text[]",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Responsibilities",
                table: "JobAds",
                type: "text",
                nullable: false,
                oldClrType: typeof(List<string>),
                oldType: "text[]");

            migrationBuilder.AlterColumn<string>(
                name: "Requirements",
                table: "JobAds",
                type: "text",
                nullable: false,
                oldClrType: typeof(List<string>),
                oldType: "text[]");
        }
    }
}
