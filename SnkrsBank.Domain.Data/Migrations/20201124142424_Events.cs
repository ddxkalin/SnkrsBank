using Microsoft.EntityFrameworkCore.Migrations;

namespace SnkrsBank.Domain.Data.Migrations
{
    public partial class Events : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Sneakers_SneakerId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipant_Event_UserId",
                table: "EventParticipant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.RenameIndex(
                name: "IX_Event_SneakerId",
                table: "Events",
                newName: "IX_Events_SneakerId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_IsDeleted",
                table: "Events",
                newName: "IX_Events_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipant_Events_UserId",
                table: "EventParticipant",
                column: "UserId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Sneakers_SneakerId",
                table: "Events",
                column: "SneakerId",
                principalTable: "Sneakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipant_Events_UserId",
                table: "EventParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Sneakers_SneakerId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.RenameIndex(
                name: "IX_Events_SneakerId",
                table: "Event",
                newName: "IX_Event_SneakerId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_IsDeleted",
                table: "Event",
                newName: "IX_Event_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Sneakers_SneakerId",
                table: "Event",
                column: "SneakerId",
                principalTable: "Sneakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipant_Event_UserId",
                table: "EventParticipant",
                column: "UserId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
