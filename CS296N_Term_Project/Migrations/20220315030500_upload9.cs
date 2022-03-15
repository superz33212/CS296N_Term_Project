using Microsoft.EntityFrameworkCore.Migrations;

namespace CS296N_Term_Project.Migrations
{
    public partial class upload9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Path",
                value: "~/MagicaVoxelImages/k5isoc00.f5g");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Path",
                value: "MagicaVoxelImages/k5isoc00.f5g");
        }
    }
}
