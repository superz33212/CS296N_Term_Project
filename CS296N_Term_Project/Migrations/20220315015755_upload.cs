using Microsoft.EntityFrameworkCore.Migrations;

namespace CS296N_Term_Project.Migrations
{
    public partial class upload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "PostId", "Description", "Likes", "Path", "PosterName", "Title", "UserId" },
                values: new object[] { 3, "This is a with an uploaded image", 0, "C:/MagicaVoxelImages/1hclz1se.g0y", "Tester1", "Test3", "6e421fd4-184e-48ed-b0e6-3308fa4ffd94" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "PostId",
                keyValue: 3);
        }
    }
}
