using Microsoft.EntityFrameworkCore.Migrations;

namespace CS296N_Term_Project.Migrations
{
    public partial class commentfix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ImageComments",
                columns: new[] { "CommentId", "CommenterId", "Description", "Likes", "PostId" },
                values: new object[] { 1, "6e421fd4-184e-48ed-b0e6-3308fa4ffd94", "This is a test", 0, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ImageComments",
                keyColumn: "CommentId",
                keyValue: 1);
        }
    }
}
