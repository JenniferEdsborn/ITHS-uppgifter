using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Films.Database.Migrations
{
    public partial class AddedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "ID", "GenreName" },
                values: new object[,]
                {
                    { 1, "Fantasy" },
                    { 2, "Animated" },
                    { 3, "Adventure" },
                    { 4, "Action" },
                    { 5, "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Peter Jackson" },
                    { 2, "Warner Bros." },
                    { 3, "Buttercup Films Ltd." }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "ID", "ProducerID", "Released", "Title" },
                values: new object[] { 1, 1, new DateTime(2001, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lord of the Rings" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "ID", "ProducerID", "Released", "Title" },
                values: new object[] { 2, 2, new DateTime(2014, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lego Movie" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "ID", "ProducerID", "Released", "Title" },
                values: new object[] { 3, 3, new DateTime(1988, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Princess Bride" });

            migrationBuilder.InsertData(
                table: "FilmGenres",
                columns: new[] { "FilmID", "GenreID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 3 },
                    { 3, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmID", "GenreID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmID", "GenreID" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmID", "GenreID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmID", "GenreID" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmID", "GenreID" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmID", "GenreID" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmID", "GenreID" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
