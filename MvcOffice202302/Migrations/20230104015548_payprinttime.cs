using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcOffice.Migrations
{
    /// <inheritdoc />
    public partial class payprinttime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "payTime",
                table: "TimeSetAlarm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "printTime",
                table: "TimeSetAlarm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "payTime",
                table: "TimeSetAlarm");

            migrationBuilder.DropColumn(
                name: "printTime",
                table: "TimeSetAlarm");
        }
    }
}
