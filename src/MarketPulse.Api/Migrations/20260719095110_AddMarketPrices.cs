using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarketPulse.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddMarketPrices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarketPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FinancialInstrumentId = table.Column<Guid>(type: "uuid", nullable: false),
                    TimestampUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClosePrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketPrices_Instruments_FinancialInstrumentId",
                        column: x => x.FinancialInstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MarketPrices",
                columns: new[] { "Id", "ClosePrice", "FinancialInstrumentId", "TimestampUtc" },
                values: new object[,]
                {
                    { new Guid("3039f58b-557f-4a25-a3df-c2eebdb554a1"), 173.45m, new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 7, 16, 21, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("3039f58b-557f-4a25-a3df-c2eebdb554a2"), 176.92m, new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 7, 17, 21, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("3039f58b-557f-4a25-a3df-c2eebdb554a3"), 179.84m, new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 7, 18, 21, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("568d3499-2337-4dfa-9edc-cdf202d3f901"), 212.43m, new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 7, 16, 21, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("568d3499-2337-4dfa-9edc-cdf202d3f902"), 214.10m, new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 7, 17, 21, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("568d3499-2337-4dfa-9edc-cdf202d3f903"), 215.87m, new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 7, 18, 21, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("ebfcf39f-b825-46cf-bb43-3bb687a52341"), 501.22m, new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 7, 16, 21, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("ebfcf39f-b825-46cf-bb43-3bb687a52342"), 503.15m, new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 7, 17, 21, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("ebfcf39f-b825-46cf-bb43-3bb687a52343"), 505.61m, new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 7, 18, 21, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarketPrices_FinancialInstrumentId",
                table: "MarketPrices",
                column: "FinancialInstrumentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketPrices");
        }
    }
}
