using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarketPulse.Api.Migrations
{
    /// <inheritdoc />
    public partial class RenameInstrumentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Instruments",
                columns: new[] { "Id", "Currency", "Exchange", "IsActive", "Name", "Ticker" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "USD", "NASDAQ", true, "Apple Inc.", "AAPL" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "USD", "NASDAQ", true, "Microsoft Corporation", "MSFT" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "USD", "NASDAQ", true, "NVIDIA Corporation", "NVDA" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));
        }
    }
}
