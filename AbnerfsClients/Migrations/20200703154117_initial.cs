using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AbnerfsClients.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    DiscordID = table.Column<string>(nullable: true),
                    GitLabID = table.Column<string>(nullable: true),
                    RegisterDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 3, 12, 41, 17, 243, DateTimeKind.Local).AddTicks(4356))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plugins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    GitLabID = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 3, 12, 41, 17, 240, DateTimeKind.Local).AddTicks(8433))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plugins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false),
                    PluginID = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    PurchasedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 3, 12, 41, 17, 243, DateTimeKind.Local).AddTicks(5524)),
                    PricePayed = table.Column<string>(nullable: true),
                    PaymentMethod = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => new { x.ClientID, x.PluginID });
                    table.ForeignKey(
                        name: "FK_Purchases_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_Plugins_PluginID",
                        column: x => x.PluginID,
                        principalTable: "Plugins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PluginID",
                table: "Purchases",
                column: "PluginID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Plugins");
        }
    }
}
