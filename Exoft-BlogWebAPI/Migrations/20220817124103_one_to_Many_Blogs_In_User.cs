using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exoft_BlogWebAPI.Migrations
{
    public partial class one_to_Many_Blogs_In_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Blog_BlogId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_BlogId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Blog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Blog_UserId",
                table: "Blog",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_User_UserId",
                table: "Blog",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_User_UserId",
                table: "Blog");

            migrationBuilder.DropIndex(
                name: "IX_Blog_UserId",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Blog");

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_BlogId",
                table: "User",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Blog_BlogId",
                table: "User",
                column: "BlogId",
                principalTable: "Blog",
                principalColumn: "Id");
        }
    }
}
