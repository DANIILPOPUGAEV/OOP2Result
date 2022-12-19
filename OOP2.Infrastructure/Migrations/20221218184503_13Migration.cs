using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OOP2.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _13Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Writers",
                columns: new[] { "Id", "Name", "Patronymic", "SecondName" },
                values: new object[,]
                {
                    { new Guid("5f5f1688-6379-441b-9ed3-66a9b1a0b10a"), "Фёдор", "Михайлович", "Достоевский" },
                    { new Guid("60b5b2e2-9d5c-4d77-95f5-83560e3c246b"), "Антон", "Павлович", "Чехов" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Writers",
                keyColumn: "Id",
                keyValue: new Guid("5f5f1688-6379-441b-9ed3-66a9b1a0b10a"));

            migrationBuilder.DeleteData(
                table: "Writers",
                keyColumn: "Id",
                keyValue: new Guid("60b5b2e2-9d5c-4d77-95f5-83560e3c246b"));
        }
    }
}
