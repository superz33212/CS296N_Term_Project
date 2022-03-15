using Microsoft.EntityFrameworkCore.Migrations;

namespace CS296N_Term_Project.Migrations
{
    public partial class upload13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Path",
                value: "~/MagicaVoxelImages/Spiral_100000.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Path",
                value: "Spiral_100000.png");
        }
    }
}
