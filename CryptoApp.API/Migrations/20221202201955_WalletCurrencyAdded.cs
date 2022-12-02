using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoApp.API.Migrations
{
    public partial class WalletCurrencyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Balance",
                table: "Wallet",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Wallet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_CurrencyId",
                table: "Wallet",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_Currencies_CurrencyId",
                table: "Wallet",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_Currencies_CurrencyId",
                table: "Wallet");

            migrationBuilder.DropIndex(
                name: "IX_Wallet_CurrencyId",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Wallet");
        }
    }
}
