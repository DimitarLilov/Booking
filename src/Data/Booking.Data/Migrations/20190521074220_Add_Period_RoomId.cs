using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.Data.Migrations
{
    public partial class Add_Period_RoomId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Periods_Rooms_RoomId",
                table: "Periods");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Periods",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Periods_Rooms_RoomId",
                table: "Periods",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Periods_Rooms_RoomId",
                table: "Periods");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Periods",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Periods_Rooms_RoomId",
                table: "Periods",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
