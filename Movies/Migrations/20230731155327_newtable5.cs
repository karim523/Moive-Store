using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieStore.Migrations
{
    /// <inheritdoc />
    public partial class newtable5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedMovie_Customers_CustomerId",
                table: "PurchasedMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedMovie_Customers_CustomerId1",
                table: "PurchasedMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedMovie_Movies_MovieId",
                table: "PurchasedMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasedMovie",
                table: "PurchasedMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "PurchasedMovie",
                newName: "PurchasedMovies");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "Movie");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedMovie_MovieId",
                table: "PurchasedMovies",
                newName: "IX_PurchasedMovies_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedMovie_CustomerId1",
                table: "PurchasedMovies",
                newName: "IX_PurchasedMovies_CustomerId1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "PurchasedMovies",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Movie",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customer",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customer",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedMovies",
                table: "PurchasedMovies",
                columns: new[] { "CustomerId", "MovieId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie",
                table: "Movie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie",
                table: "Movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "PurchasedMovies",
                newName: "PurchasedMovie");

            migrationBuilder.RenameTable(
                name: "Movie",
                newName: "Movies");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedMovies_MovieId",
                table: "PurchasedMovie",
                newName: "IX_PurchasedMovie_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedMovies_CustomerId1",
                table: "PurchasedMovie",
                newName: "IX_PurchasedMovie_CustomerId1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "PurchasedMovie",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedMovie",
                table: "PurchasedMovie",
                columns: new[] { "CustomerId", "MovieId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedMovie_Customers_CustomerId",
                table: "PurchasedMovie",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedMovie_Customers_CustomerId1",
                table: "PurchasedMovie",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedMovie_Movies_MovieId",
                table: "PurchasedMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
