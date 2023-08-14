using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieStore.Migrations
{
    /// <inheritdoc />
    public partial class newtable6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedMovies_Customer_CustomerId",
                table: "PurchasedMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedMovies_Customer_CustomerId1",
                table: "PurchasedMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedMovies_Movie_MovieId",
                table: "PurchasedMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasedMovies",
                table: "PurchasedMovies");

            migrationBuilder.DropIndex(
                name: "IX_PurchasedMovies_CustomerId1",
                table: "PurchasedMovies");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "PurchasedMovies");

            migrationBuilder.RenameTable(
                name: "PurchasedMovies",
                newName: "PurchasedMovie");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedMovies_MovieId",
                table: "PurchasedMovie",
                newName: "IX_PurchasedMovie_MovieId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PurchasedMovie",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedMovie",
                table: "PurchasedMovie",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedMovie_CustomerId",
                table: "PurchasedMovie",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedMovie_Customer_CustomerId",
                table: "PurchasedMovie",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedMovie_Movie_MovieId",
                table: "PurchasedMovie",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedMovie_Customer_CustomerId",
                table: "PurchasedMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedMovie_Movie_MovieId",
                table: "PurchasedMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasedMovie",
                table: "PurchasedMovie");

            migrationBuilder.DropIndex(
                name: "IX_PurchasedMovie_CustomerId",
                table: "PurchasedMovie");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PurchasedMovie");

            migrationBuilder.RenameTable(
                name: "PurchasedMovie",
                newName: "PurchasedMovies");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedMovie_MovieId",
                table: "PurchasedMovies",
                newName: "IX_PurchasedMovies_MovieId");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "PurchasedMovies",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedMovies",
                table: "PurchasedMovies",
                columns: new[] { "CustomerId", "MovieId" });

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedMovies_CustomerId1",
                table: "PurchasedMovies",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedMovies_Customer_CustomerId",
                table: "PurchasedMovies",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedMovies_Customer_CustomerId1",
                table: "PurchasedMovies",
                column: "CustomerId1",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedMovies_Movie_MovieId",
                table: "PurchasedMovies",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
