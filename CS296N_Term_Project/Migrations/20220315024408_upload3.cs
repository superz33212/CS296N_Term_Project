using Microsoft.EntityFrameworkCore.Migrations;

namespace CS296N_Term_Project.Migrations
{
    public partial class upload3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Path",
                value: "wwwroot\\MagicaVoxelImages\\k5isoc00.f5g");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Path",
                value: "C:\\MagicaVoxelImages\\1hclz1se.g0y");
        }
    }
}
