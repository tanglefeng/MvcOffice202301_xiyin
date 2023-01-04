using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcOffice.Migrations
{
    public partial class InitialFour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KengicAspnetcorePictureSum",
                columns: table => new
                {
                    KengicAspnetcorePictureSumId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    srcaddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    detail2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KengicAspnetcorePictureSum", x => x.KengicAspnetcorePictureSumId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KengicAspnetcorePictureSum");
        }
    }
}
