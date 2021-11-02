using Microsoft.EntityFrameworkCore.Migrations;

namespace RapidPay.Migrations
{
    public partial class LastModificationInCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Available",
                table: "Cards",
                type: "decimal(8,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<byte[]>(
                name: "LastModification",
                table: "Cards",
                rowVersion: true,
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "LastModification",
                table: "Cards");
        }
    }
}
