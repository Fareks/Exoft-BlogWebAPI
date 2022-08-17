using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exoft_BlogWebAPI.Migrations
{
    public partial class nullBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Blog_BlogId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Blog_BlogId",
                table: "User",
                column: "BlogId",
                principalTable: "Blog",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Blog_BlogId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Blog_BlogId",
                table: "User",
                column: "BlogId",
                principalTable: "Blog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
