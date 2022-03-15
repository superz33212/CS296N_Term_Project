using Microsoft.EntityFrameworkCore.Migrations;

namespace CS296N_Term_Project.Migrations
{
    public partial class addvideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "PostId",
                keyValue: 1,
                column: "ThumbPath",
                value: "https://cdn.discordapp.com/attachments/623342534860603394/934979679654379680/Spiral_100000.png");

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "PostId",
                keyValue: 2,
                column: "ThumbPath",
                value: "https://cdn.discordapp.com/attachments/623342534860603394/953190646297030716/snap2020-08-19-15-19-27.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "PostId",
                keyValue: 1,
                column: "ThumbPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "PostId",
                keyValue: 2,
                column: "ThumbPath",
                value: null);
        }
    }
}
