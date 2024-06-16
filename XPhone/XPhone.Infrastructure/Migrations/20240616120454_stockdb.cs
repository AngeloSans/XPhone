using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XPhone.Infra.Migrations
{
    /// <inheritdoc />
    public partial class stockdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "stockName",
                table: "Stocks",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "stockName",
                table: "Stocks");
        }
    }
}
