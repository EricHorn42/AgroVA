using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroVA.Infra.Data.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Farmers",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                Phone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Farmers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Harvests",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Year = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Harvests", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Annotations",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Observation = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                Timestamp = table.Column<DateOnly>(type: "date", nullable: false),
                FarmerId = table.Column<int>(type: "int", nullable: false),
                HarvestId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Annotations", x => x.Id);
                table.ForeignKey(
                    name: "FK_Annotations_Farmers_FarmerId",
                    column: x => x.FarmerId,
                    principalTable: "Farmers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Annotations_Harvests_HarvestId",
                    column: x => x.HarvestId,
                    principalTable: "Harvests",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "HuskPrices",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Timestamp = table.Column<DateOnly>(type: "date", nullable: false),
                Percent = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: false),
                Price = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                HarvestId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_HuskPrices", x => x.Id);
                table.ForeignKey(
                    name: "FK_HuskPrices_Harvests_HarvestId",
                    column: x => x.HarvestId,
                    principalTable: "Harvests",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Loads",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Timestamp = table.Column<DateOnly>(type: "date", nullable: false),
                GreenWeight = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: true),
                DryWeight = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: true),
                Register = table.Column<int>(type: "int", nullable: false),
                Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                WholePercent = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: true),
                Invoice = table.Column<long>(type: "bigint", nullable: false),
                FarmerId = table.Column<int>(type: "int", nullable: false),
                HarvestId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Loads", x => x.Id);
                table.ForeignKey(
                    name: "FK_Loads_Farmers_FarmerId",
                    column: x => x.FarmerId,
                    principalTable: "Farmers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Loads_Harvests_HarvestId",
                    column: x => x.HarvestId,
                    principalTable: "Harvests",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Promissories",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Timestamp = table.Column<DateOnly>(type: "date", nullable: false),
                Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                FarmerId = table.Column<int>(type: "int", nullable: false),
                HarvestId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Promissories", x => x.Id);
                table.ForeignKey(
                    name: "FK_Promissories_Farmers_FarmerId",
                    column: x => x.FarmerId,
                    principalTable: "Farmers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Promissories_Harvests_HarvestId",
                    column: x => x.HarvestId,
                    principalTable: "Harvests",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Receipts",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Timestamp = table.Column<DateOnly>(type: "date", nullable: false),
                Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                FarmerId = table.Column<int>(type: "int", nullable: false),
                HarvestId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Receipts", x => x.Id);
                table.ForeignKey(
                    name: "FK_Receipts_Farmers_FarmerId",
                    column: x => x.FarmerId,
                    principalTable: "Farmers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Receipts_Harvests_HarvestId",
                    column: x => x.HarvestId,
                    principalTable: "Harvests",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Rents",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Person = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                Percent = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: false),
                Value = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                Annotation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                FarmerId = table.Column<int>(type: "int", nullable: false),
                HarvestId = table.Column<int>(type: "int", nullable: false),
                FarmerId1 = table.Column<int>(type: "int", nullable: true),
                HarvestId1 = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Rents", x => x.Id);
                table.ForeignKey(
                    name: "FK_Rents_Farmers_FarmerId",
                    column: x => x.FarmerId,
                    principalTable: "Farmers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Rents_Farmers_FarmerId1",
                    column: x => x.FarmerId1,
                    principalTable: "Farmers",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_Rents_Harvests_HarvestId",
                    column: x => x.HarvestId,
                    principalTable: "Harvests",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Rents_Harvests_HarvestId1",
                    column: x => x.HarvestId1,
                    principalTable: "Harvests",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_Annotations_FarmerId",
            table: "Annotations",
            column: "FarmerId");

        migrationBuilder.CreateIndex(
            name: "IX_Annotations_HarvestId",
            table: "Annotations",
            column: "HarvestId");

        migrationBuilder.CreateIndex(
            name: "IX_HuskPrices_HarvestId",
            table: "HuskPrices",
            column: "HarvestId");

        migrationBuilder.CreateIndex(
            name: "IX_Loads_FarmerId",
            table: "Loads",
            column: "FarmerId");

        migrationBuilder.CreateIndex(
            name: "IX_Loads_HarvestId",
            table: "Loads",
            column: "HarvestId");

        migrationBuilder.CreateIndex(
            name: "IX_Promissories_FarmerId",
            table: "Promissories",
            column: "FarmerId");

        migrationBuilder.CreateIndex(
            name: "IX_Promissories_HarvestId",
            table: "Promissories",
            column: "HarvestId");

        migrationBuilder.CreateIndex(
            name: "IX_Receipts_FarmerId",
            table: "Receipts",
            column: "FarmerId");

        migrationBuilder.CreateIndex(
            name: "IX_Receipts_HarvestId",
            table: "Receipts",
            column: "HarvestId");

        migrationBuilder.CreateIndex(
            name: "IX_Rents_FarmerId",
            table: "Rents",
            column: "FarmerId");

        migrationBuilder.CreateIndex(
            name: "IX_Rents_FarmerId1",
            table: "Rents",
            column: "FarmerId1");

        migrationBuilder.CreateIndex(
            name: "IX_Rents_HarvestId",
            table: "Rents",
            column: "HarvestId");

        migrationBuilder.CreateIndex(
            name: "IX_Rents_HarvestId1",
            table: "Rents",
            column: "HarvestId1");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Annotations");

        migrationBuilder.DropTable(
            name: "HuskPrices");

        migrationBuilder.DropTable(
            name: "Loads");

        migrationBuilder.DropTable(
            name: "Promissories");

        migrationBuilder.DropTable(
            name: "Receipts");

        migrationBuilder.DropTable(
            name: "Rents");

        migrationBuilder.DropTable(
            name: "Farmers");

        migrationBuilder.DropTable(
            name: "Harvests");
    }
}
