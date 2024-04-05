using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBookProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_update_payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Reservations_ReservationId",
                table: "Payment");

            migrationBuilder.RenameColumn(
                name: "CarReservationId",
                table: "Payment",
                newName: "Status");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Method",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TransactionFee",
                table: "Payment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Reservations_ReservationId",
                table: "Payment",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Reservations_ReservationId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Method",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "TransactionFee",
                table: "Payment");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Payment",
                newName: "CarReservationId");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "Payment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Reservations_ReservationId",
                table: "Payment",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId");
        }
    }
}
