using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBookProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_appuserid_add_invoice_payment1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_AspNetUsers_UserId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_AspNetUsers_UserId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reservations",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                newName: "IX_Reservations_AppUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Payment",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_UserId",
                table: "Payment",
                newName: "IX_Payment_AppUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Invoice",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_UserId",
                table: "Invoice",
                newName: "IX_Invoice_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_AspNetUsers_AppUserId",
                table: "Invoice",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_AspNetUsers_AppUserId",
                table: "Payment",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_AppUserId",
                table: "Reservations",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_AspNetUsers_AppUserId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_AspNetUsers_AppUserId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_AppUserId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Reservations",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_AppUserId",
                table: "Reservations",
                newName: "IX_Reservations_UserId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Payment",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_AppUserId",
                table: "Payment",
                newName: "IX_Payment_UserId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Invoice",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_AppUserId",
                table: "Invoice",
                newName: "IX_Invoice_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_AspNetUsers_UserId",
                table: "Invoice",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_AspNetUsers_UserId",
                table: "Payment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
