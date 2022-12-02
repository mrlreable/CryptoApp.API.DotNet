using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoApp.API.Migrations
{
    public partial class Updated_Wallets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CCVHash",
                table: "Wallet");

            migrationBuilder.RenameColumn(
                name: "NameOnCard",
                table: "Wallet",
                newName: "Cardholder");

            migrationBuilder.RenameColumn(
                name: "CardNumberHash",
                table: "Wallet",
                newName: "CardNumber");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Wallet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Wallet");

            migrationBuilder.RenameColumn(
                name: "Cardholder",
                table: "Wallet",
                newName: "NameOnCard");

            migrationBuilder.RenameColumn(
                name: "CardNumber",
                table: "Wallet",
                newName: "CardNumberHash");

            migrationBuilder.AddColumn<string>(
                name: "CCVHash",
                table: "Wallet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
