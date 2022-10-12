using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class categoryimg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryImage_Category_CategoryId1",
                table: "CategoryImage");

            migrationBuilder.DropIndex(
                name: "IX_CategoryImage_CategoryId1",
                table: "CategoryImage");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "CategoryImage");

            migrationBuilder.DropColumn(
                name: "CategoryImageId",
                table: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryImage_CategoryId",
                table: "CategoryImage",
                column: "CategoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryImage_Category_CategoryId",
                table: "CategoryImage",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryImage_Category_CategoryId",
                table: "CategoryImage");

            migrationBuilder.DropIndex(
                name: "IX_CategoryImage_CategoryId",
                table: "CategoryImage");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId1",
                table: "CategoryImage",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryImageId",
                table: "Category",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryImage_CategoryId1",
                table: "CategoryImage",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryImage_Category_CategoryId1",
                table: "CategoryImage",
                column: "CategoryId1",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
