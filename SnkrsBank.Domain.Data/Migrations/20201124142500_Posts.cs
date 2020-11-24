using Microsoft.EntityFrameworkCore.Migrations;

namespace SnkrsBank.Domain.Data.Migrations
{
    public partial class Posts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalePosts_AspNetUsers_UserId",
                table: "SalePosts");

            migrationBuilder.DropForeignKey(
                name: "FK_SalePosts_Sneakers_SneakerId",
                table: "SalePosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalePosts",
                table: "SalePosts");

            migrationBuilder.RenameTable(
                name: "SalePosts",
                newName: "SalePost");

            migrationBuilder.RenameIndex(
                name: "IX_SalePosts_UserId",
                table: "SalePost",
                newName: "IX_SalePost_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SalePosts_SneakerId",
                table: "SalePost",
                newName: "IX_SalePost_SneakerId");

            migrationBuilder.RenameIndex(
                name: "IX_SalePosts_IsDeleted",
                table: "SalePost",
                newName: "IX_SalePost_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalePost",
                table: "SalePost",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalePost_AspNetUsers_UserId",
                table: "SalePost",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalePost_Sneakers_SneakerId",
                table: "SalePost",
                column: "SneakerId",
                principalTable: "Sneakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalePost_AspNetUsers_UserId",
                table: "SalePost");

            migrationBuilder.DropForeignKey(
                name: "FK_SalePost_Sneakers_SneakerId",
                table: "SalePost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalePost",
                table: "SalePost");

            migrationBuilder.RenameTable(
                name: "SalePost",
                newName: "SalePosts");

            migrationBuilder.RenameIndex(
                name: "IX_SalePost_UserId",
                table: "SalePosts",
                newName: "IX_SalePosts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SalePost_SneakerId",
                table: "SalePosts",
                newName: "IX_SalePosts_SneakerId");

            migrationBuilder.RenameIndex(
                name: "IX_SalePost_IsDeleted",
                table: "SalePosts",
                newName: "IX_SalePosts_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalePosts",
                table: "SalePosts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalePosts_AspNetUsers_UserId",
                table: "SalePosts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalePosts_Sneakers_SneakerId",
                table: "SalePosts",
                column: "SneakerId",
                principalTable: "Sneakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
