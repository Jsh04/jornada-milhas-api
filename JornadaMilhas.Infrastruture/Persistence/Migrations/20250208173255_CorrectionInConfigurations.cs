using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JornadaMilhas.Infrastruture.Migrations
{
    public partial class CorrectionInConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BusinessClassId",
                table: "Planes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "EconomicClassId",
                table: "Planes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "InOperation",
                table: "Planes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Planes",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Planes",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BusinessClass",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TotalSeats = table.Column<int>(type: "int", nullable: false),
                    PriceSeat = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ReservedSeats = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PlaneId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessClass_Planes_PlaneId",
                        column: x => x.PlaneId,
                        principalTable: "Planes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EconomicClass",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TotalSeats = table.Column<int>(type: "int", nullable: false),
                    PriceSeat = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ReservedSeats = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PlaneId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EconomicClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EconomicClass_Planes_PlaneId",
                        column: x => x.PlaneId,
                        principalTable: "Planes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planes_BusinessClassId",
                table: "Planes",
                column: "BusinessClassId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Planes_EconomicClassId",
                table: "Planes",
                column: "EconomicClassId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessClass_PlaneId",
                table: "BusinessClass",
                column: "PlaneId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EconomicClass_PlaneId",
                table: "EconomicClass",
                column: "PlaneId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Planes_BusinessClass_BusinessClassId",
                table: "Planes",
                column: "BusinessClassId",
                principalTable: "BusinessClass",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Planes_EconomicClass_EconomicClassId",
                table: "Planes",
                column: "EconomicClassId",
                principalTable: "EconomicClass",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planes_BusinessClass_BusinessClassId",
                table: "Planes");

            migrationBuilder.DropForeignKey(
                name: "FK_Planes_EconomicClass_EconomicClassId",
                table: "Planes");

            migrationBuilder.DropTable(
                name: "BusinessClass");

            migrationBuilder.DropTable(
                name: "EconomicClass");

            migrationBuilder.DropIndex(
                name: "IX_Planes_BusinessClassId",
                table: "Planes");

            migrationBuilder.DropIndex(
                name: "IX_Planes_EconomicClassId",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "BusinessClassId",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "EconomicClassId",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "InOperation",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Planes");
        }
    }
}
