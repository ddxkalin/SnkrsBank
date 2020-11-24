using Microsoft.EntityFrameworkCore.Migrations;

namespace SnkrsBank.Domain.Data.Migrations
{
    public partial class Sneakers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Sneaker_SneakerId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Keyword_Sneaker_SneakerId",
                table: "Keyword");

            migrationBuilder.DropForeignKey(
                name: "FK_SalePost_Sneaker_SneakerId",
                table: "SalePost");

            migrationBuilder.DropForeignKey(
                name: "FK_Sneaker_Brand_BrandId",
                table: "Sneaker");

            migrationBuilder.DropForeignKey(
                name: "FK_SneakerCategory_Sneaker_SneakerId",
                table: "SneakerCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_SneakerRating_Sneaker_SneakerId",
                table: "SneakerRating");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOwnedSneaker_Sneaker_SneakerId",
                table: "UserOwnedSneaker");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWatchedSneaker_Sneaker_SneakerId",
                table: "UserWatchedSneaker");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWishlist_Sneaker_SneakerId",
                table: "UserWishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sneaker",
                table: "Sneaker");

            migrationBuilder.RenameTable(
                name: "Sneaker",
                newName: "Sneakers");

            migrationBuilder.RenameIndex(
                name: "IX_Sneaker_Slug",
                table: "Sneakers",
                newName: "IX_Sneakers_Slug");

            migrationBuilder.RenameIndex(
                name: "IX_Sneaker_IsDeleted",
                table: "Sneakers",
                newName: "IX_Sneakers_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Sneaker_BrandId",
                table: "Sneakers",
                newName: "IX_Sneakers_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sneakers",
                table: "Sneakers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Sneakers_SneakerId",
                table: "Event",
                column: "SneakerId",
                principalTable: "Sneakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Keyword_Sneakers_SneakerId",
                table: "Keyword",
                column: "SneakerId",
                principalTable: "Sneakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalePost_Sneakers_SneakerId",
                table: "SalePost",
                column: "SneakerId",
                principalTable: "Sneakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SneakerCategory_Sneakers_SneakerId",
                table: "SneakerCategory",
                column: "SneakerId",
                principalTable: "Sneakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SneakerRating_Sneakers_SneakerId",
                table: "SneakerRating",
                column: "SneakerId",
                principalTable: "Sneakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sneakers_Brand_BrandId",
                table: "Sneakers",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOwnedSneaker_Sneakers_SneakerId",
                table: "UserOwnedSneaker",
                column: "SneakerId",
                principalTable: "Sneakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWatchedSneaker_Sneakers_SneakerId",
                table: "UserWatchedSneaker",
                column: "SneakerId",
                principalTable: "Sneakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWishlist_Sneakers_SneakerId",
                table: "UserWishlist",
                column: "SneakerId",
                principalTable: "Sneakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Sneakers_SneakerId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Keyword_Sneakers_SneakerId",
                table: "Keyword");

            migrationBuilder.DropForeignKey(
                name: "FK_SalePost_Sneakers_SneakerId",
                table: "SalePost");

            migrationBuilder.DropForeignKey(
                name: "FK_SneakerCategory_Sneakers_SneakerId",
                table: "SneakerCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_SneakerRating_Sneakers_SneakerId",
                table: "SneakerRating");

            migrationBuilder.DropForeignKey(
                name: "FK_Sneakers_Brand_BrandId",
                table: "Sneakers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOwnedSneaker_Sneakers_SneakerId",
                table: "UserOwnedSneaker");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWatchedSneaker_Sneakers_SneakerId",
                table: "UserWatchedSneaker");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWishlist_Sneakers_SneakerId",
                table: "UserWishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sneakers",
                table: "Sneakers");

            migrationBuilder.RenameTable(
                name: "Sneakers",
                newName: "Sneaker");

            migrationBuilder.RenameIndex(
                name: "IX_Sneakers_Slug",
                table: "Sneaker",
                newName: "IX_Sneaker_Slug");

            migrationBuilder.RenameIndex(
                name: "IX_Sneakers_IsDeleted",
                table: "Sneaker",
                newName: "IX_Sneaker_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Sneakers_BrandId",
                table: "Sneaker",
                newName: "IX_Sneaker_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sneaker",
                table: "Sneaker",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Sneaker_SneakerId",
                table: "Event",
                column: "SneakerId",
                principalTable: "Sneaker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Keyword_Sneaker_SneakerId",
                table: "Keyword",
                column: "SneakerId",
                principalTable: "Sneaker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalePost_Sneaker_SneakerId",
                table: "SalePost",
                column: "SneakerId",
                principalTable: "Sneaker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sneaker_Brand_BrandId",
                table: "Sneaker",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SneakerCategory_Sneaker_SneakerId",
                table: "SneakerCategory",
                column: "SneakerId",
                principalTable: "Sneaker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SneakerRating_Sneaker_SneakerId",
                table: "SneakerRating",
                column: "SneakerId",
                principalTable: "Sneaker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOwnedSneaker_Sneaker_SneakerId",
                table: "UserOwnedSneaker",
                column: "SneakerId",
                principalTable: "Sneaker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWatchedSneaker_Sneaker_SneakerId",
                table: "UserWatchedSneaker",
                column: "SneakerId",
                principalTable: "Sneaker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWishlist_Sneaker_SneakerId",
                table: "UserWishlist",
                column: "SneakerId",
                principalTable: "Sneaker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
