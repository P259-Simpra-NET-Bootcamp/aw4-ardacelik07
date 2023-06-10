using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimApi.Data.Migrations
{
    public partial class letter2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Customer_CustomerId",
                schema: "dbo",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Account_AccountId",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                schema: "dbo",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Account",
                schema: "dbo",
                newName: "account",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Account_CustomerId",
                schema: "dbo",
                table: "account",
                newName: "IX_account_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Account_AccountNumber",
                schema: "dbo",
                table: "account",
                newName: "IX_account_AccountNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_account",
                schema: "dbo",
                table: "account",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_account_Customer_CustomerId",
                schema: "dbo",
                table: "account",
                column: "CustomerId",
                principalSchema: "dbo",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_account_AccountId",
                schema: "dbo",
                table: "Transaction",
                column: "AccountId",
                principalSchema: "dbo",
                principalTable: "account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_account_Customer_CustomerId",
                schema: "dbo",
                table: "account");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_account_AccountId",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_account",
                schema: "dbo",
                table: "account");

            migrationBuilder.RenameTable(
                name: "account",
                schema: "dbo",
                newName: "Account",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_account_CustomerId",
                schema: "dbo",
                table: "Account",
                newName: "IX_Account_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_account_AccountNumber",
                schema: "dbo",
                table: "Account",
                newName: "IX_Account_AccountNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                schema: "dbo",
                table: "Account",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Customer_CustomerId",
                schema: "dbo",
                table: "Account",
                column: "CustomerId",
                principalSchema: "dbo",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Account_AccountId",
                schema: "dbo",
                table: "Transaction",
                column: "AccountId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
