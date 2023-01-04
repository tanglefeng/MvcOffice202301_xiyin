using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcOffice.Migrations
{
    /// <inheritdoc />
    public partial class initialsixx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeSetAlarm",
                columns: table => new
                {
                    AlarmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlarmName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    baoming = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    signupTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    writtenExaminationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterviewTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hysicalExaminationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProposedAdmissionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportingTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSetAlarm", x => x.AlarmId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSetAlarm");
        }
    }
}
