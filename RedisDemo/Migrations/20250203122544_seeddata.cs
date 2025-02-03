using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RedisDemo.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "cars",
                columns: new[] { "Id", "Make", "Model", "Year" },
                values: new object[,]
                {
                    { 1, "Toyota", "Corolla", 2020 },
                    { 2, "Honda", "Civic", 2019 },
                    { 3, "Ford", "Mustang", 2021 },
                    { 4, "Chevrolet", "Camaro", 2022 },
                    { 5, "Tesla", "Model 3", 2023 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "cars",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
