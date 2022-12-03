using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoApp.API.Migrations
{
    public partial class DBSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "Stocks",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "Currencies",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "CryptoCurrencies",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.InsertData(
                table: "CryptoCurrencies",
                columns: new[] { "Id", "Change", "Description", "IsSupported", "MarketCap", "Name", "Price", "ShortName", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { 1, -0.72999999999999998, "Bitcoin (abbreviation: BTC; sign: ₿) is a decentralized digital currency that can be transferred on the peer-to-peer bitcoin network.", true, null, "Bitcoin", 6599123.5899999999, "BTC", null, null },
                    { 2, -0.72999999999999998, " Ether (Abbreviation: ETH;[a] sign: Ξ) is the native cryptocurrency of the Ethereum blockcahin.", true, null, "Ether", 494679.16999999998, "ETH", null, null },
                    { 3, -0.72999999999999998, "Polygon (MATIC) is an Ethereum token that powers the Polygon Network, a scaling solution for Ethereum.", true, 3100000000000.0, "Polygon", 358.19, "MATIC", null, null }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "CentralBank", "Change", "Description", "ExchangeRateEUR", "ExchangeRateHUF", "ExchangeRateUSD", "IsSupported", "MinorUnit", "Name", "ShortName", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { 1, "Hungarian National Bank", 0.93000000000000005, "HUF is the currency of Hungary", 408.23000000000002, 1.0, 392.02999999999997, true, null, "Hungarian Forint", "HUF", null, null },
                    { 2, "Eurosystem", -0.13, "The euro (symbol: €; code: EUR) is the official currency of 19 out of the 27 member states of the European Union (EU).", 1.0, 0.0023999999999999998, 0.94999999999999996, true, null, "euro", "EUR", null, null },
                    { 3, "Eurosystem", -0.13, "The United States dollar (symbol: $; code: USD; also abbreviated US$ or U.S. Dollar, to distinguish it from other dollar-denominated currencies; referred to as the dollar, U.S. dollar, American dollar, or colloquially buck) is the official currency of the United States and several other countries.", 1.05, 0.0025999999999999999, 1.0, true, null, "United States dollar", "USD", null, null }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedById", "Label", "ModifiedAt", "ModifiedById", "Title" },
                values: new object[] { 1, "There’s no way around it — November was a rough month for crypto. Markets are down, lenders and funds are dropping like flies, and the bear market vibes are in full effect. As we continue to wade through the wreckage of FTX and Alameda, it’s clear some communities were hit a lot harder than others. This week, we dive into the tough times that have hit the Solana ecosystem, digging into how exactly the network is struggling and where the community is showing resilience.", new DateTime(2022, 12, 3, 11, 35, 6, 813, DateTimeKind.Local).AddTicks(993), "4a3bb735-a5bf-469d-a60d-f0f8eac836eb", "Crypto", null, null, "Is Solana Dead?" });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Change", "Description", "IsSupported", "Name", "Price", "ShortName", "Spread", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { 1, 1.75, "Uniper SE. An international energy company, based in Düsseldorf, Germany.", true, "Uniper", 3.5099999999999998, "UN01.DE", 0.029999999999999999, null, null },
                    { 2, -0.34000000000000002, "An American multinational hardware and software company.", true, "Apple", 147.25, "AAPL", 1.1100000000000001, null, null },
                    { 3, 1.0800000000000001, "A leading online entertainment services company.", true, "Netflix", 319.16000000000003, "NFLX", 2.3999999999999999, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CryptoCurrencies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CryptoCurrencies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CryptoCurrencies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "Stocks",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "Currencies",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "CryptoCurrencies",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);
        }
    }
}
