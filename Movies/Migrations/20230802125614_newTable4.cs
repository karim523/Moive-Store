using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieStore.Migrations
{
    /// <inheritdoc />
    public partial class newTable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedMovie_Customer_CustomerId",
                table: "PurchasedMovie");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedMovie_Customer_CustomerId",
                table: "PurchasedMovie",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedMovie_Customer_CustomerId",
                table: "PurchasedMovie");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedMovie_Customer_CustomerId",
                table: "PurchasedMovie",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
