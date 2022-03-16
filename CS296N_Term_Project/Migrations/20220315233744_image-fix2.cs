using Microsoft.EntityFrameworkCore.Migrations;

namespace CS296N_Term_Project.Migrations
{
    public partial class imagefix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Path",
                value: "MagicaVoxelImages/5.1.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Path",
                value: "MagicaVoxelImages/Boat.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Path",
                value: "https://media.discordapp.net/attachments/623342534860603394/934990260058873896/V2_33000x3000.png?width=905&height=905");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Path",
                value: "https://media.discordapp.net/attachments/623342534860603394/934980542603075615/snap2020-02-02-20-44-10.png?width=1290&height=726");
        }
    }
}
