using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBookProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_payment_invoice_name_change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_AspNetUsers_AppUserId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Payment_PaymentId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Reservations_ReservationId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_AspNetUsers_AppUserId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Reservations_ReservationId",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "Payments");

            migrationBuilder.RenameTable(
                name: "Invoice",
                newName: "Invoices");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_ReservationId",
                table: "Payments",
                newName: "IX_Payments_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_AppUserId",
                table: "Payments",
                newName: "IX_Payments_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_ReservationId",
                table: "Invoices",
                newName: "IX_Invoices_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_PaymentId",
                table: "Invoices",
                newName: "IX_Invoices_PaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_AppUserId",
                table: "Invoices",
                newName: "IX_Invoices_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "PaymentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AspNetUsers_AppUserId",
                table: "Invoices",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Payments_PaymentId",
                table: "Invoices",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Reservations_ReservationId",
                table: "Invoices",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_AspNetUsers_AppUserId",
                table: "Payments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Reservations_ReservationId",
                table: "Payments",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AspNetUsers_AppUserId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Payments_PaymentId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Reservations_ReservationId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_AspNetUsers_AppUserId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Reservations_ReservationId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Payment");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoice");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_ReservationId",
                table: "Payment",
                newName: "IX_Payment_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_AppUserId",
                table: "Payment",
                newName: "IX_Payment_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_ReservationId",
                table: "Invoice",
                newName: "IX_Invoice_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_PaymentId",
                table: "Invoice",
                newName: "IX_Invoice_PaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_AppUserId",
                table: "Invoice",
                newName: "IX_Invoice_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "PaymentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_AspNetUsers_AppUserId",
                table: "Invoice",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Payment_PaymentId",
                table: "Invoice",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Reservations_ReservationId",
                table: "Invoice",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_AspNetUsers_AppUserId",
                table: "Payment",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Reservations_ReservationId",
                table: "Payment",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
