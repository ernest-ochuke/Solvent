using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class initCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UniqueIdentityNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChipTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaDirPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Iins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Pan = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChipInventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChipTypeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateEntered = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KCV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChipInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChipInventories_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChipInventories_ChipTypes_ChipTypeId",
                        column: x => x.ChipTypeId,
                        principalTable: "ChipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChipId = table.Column<int>(type: "int", nullable: false),
                    ChipTypeId = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IinId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardProducts_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardProducts_ChipTypes_ChipTypeId",
                        column: x => x.ChipTypeId,
                        principalTable: "ChipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CardProducts_Iins_IinId",
                        column: x => x.IinId,
                        principalTable: "Iins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChipInventoryHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    Requester = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    ChipInventoryId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChipInventoryHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChipInventoryHistories_ChipInventories_ChipInventoryId",
                        column: x => x.ChipInventoryId,
                        principalTable: "ChipInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChipCertifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCertificationrRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChipTypeId = table.Column<int>(type: "int", nullable: false),
                    CertificationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChipCertifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChipCertifications_CardProducts_CardProductId",
                        column: x => x.CardProductId,
                        principalTable: "CardProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChipCertifications_ChipTypes_ChipTypeId",
                        column: x => x.ChipTypeId,
                        principalTable: "ChipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Banks_Name",
                table: "Banks",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Banks_UniqueIdentityNumber",
                table: "Banks",
                column: "UniqueIdentityNumber",
                unique: true,
                filter: "[UniqueIdentityNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CardProducts_BankId",
                table: "CardProducts",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_CardProducts_ChipTypeId",
                table: "CardProducts",
                column: "ChipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CardProducts_IinId",
                table: "CardProducts",
                column: "IinId");

            migrationBuilder.CreateIndex(
                name: "IX_ChipCertifications_CardProductId",
                table: "ChipCertifications",
                column: "CardProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ChipCertifications_ChipTypeId",
                table: "ChipCertifications",
                column: "ChipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChipInventories_BankId",
                table: "ChipInventories",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_ChipInventories_ChipTypeId",
                table: "ChipInventories",
                column: "ChipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChipInventoryHistories_ChipInventoryId",
                table: "ChipInventoryHistories",
                column: "ChipInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Iins_Pan",
                table: "Iins",
                column: "Pan",
                unique: true,
                filter: "[Pan] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChipCertifications");

            migrationBuilder.DropTable(
                name: "ChipInventoryHistories");

            migrationBuilder.DropTable(
                name: "CardProducts");

            migrationBuilder.DropTable(
                name: "ChipInventories");

            migrationBuilder.DropTable(
                name: "Iins");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "ChipTypes");
        }
    }
}
