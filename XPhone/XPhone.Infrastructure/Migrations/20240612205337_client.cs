using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XPhone.Infra.Migrations
{
    /// <inheritdoc />
    public partial class client : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Fine = table.Column<bool>(type: "boolean", nullable: false),
                    FineAmount = table.Column<double>(type: "double precision", nullable: false),
                    Phone = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmartPhones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Model = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Avaiable = table.Column<bool>(type: "boolean", nullable: false),
                    OperationalSystem = table.Column<string>(type: "text", nullable: false),
                    Memory = table.Column<int>(type: "integer", nullable: false),
                    Core = table.Column<double>(type: "double precision", nullable: false),
                    StockId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmartPhones_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RentAmount = table.Column<double>(type: "double precision", nullable: false),
                    Devolution = table.Column<bool>(type: "boolean", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    SmartPhoneId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_SmartPhones_SmartPhoneId",
                        column: x => x.SmartPhoneId,
                        principalTable: "SmartPhones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Returns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Condition = table.Column<bool>(type: "boolean", nullable: false),
                    RentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Returns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Returns_Rents_RentId",
                        column: x => x.RentId,
                        principalTable: "Rents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rents_ClientId",
                table: "Rents",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_SmartPhoneId",
                table: "Rents",
                column: "SmartPhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Returns_RentId",
                table: "Returns",
                column: "RentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SmartPhones_StockId",
                table: "SmartPhones",
                column: "StockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Returns");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "SmartPhones");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
