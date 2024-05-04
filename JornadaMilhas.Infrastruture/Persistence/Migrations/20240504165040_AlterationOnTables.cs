using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JornadaMilhas.Infrastruture.Persistence.Migrations
{
    public partial class AlterationOnTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depoimentos_Usuarios_IdUsuario",
                table: "Depoimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_ImagemDestino_Destinos_IdDestino",
                table: "ImagemDestino");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_ImagemDestino_IdDestino",
                table: "ImagemDestino");

            migrationBuilder.DropIndex(
                name: "IX_Depoimentos_IdUsuario",
                table: "Depoimentos");

            migrationBuilder.AddColumn<long>(
                name: "DestinoId",
                table: "ImagemDestino",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtUpdated",
                table: "ImagemDestino",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Destinos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<DateTime>(
                name: "DtUpdated",
                table: "Destinos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DtUpdated",
                table: "Depoimentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Depoimentos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeEmployee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailExists = table.Column<bool>(type: "bit", nullable: true),
                    DtCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagemDestino_DestinoId",
                table: "ImagemDestino",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Depoimentos_UserId",
                table: "Depoimentos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depoimentos_Users_UserId",
                table: "Depoimentos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagemDestino_Destinos_DestinoId",
                table: "ImagemDestino",
                column: "DestinoId",
                principalTable: "Destinos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depoimentos_Users_UserId",
                table: "Depoimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_ImagemDestino_Destinos_DestinoId",
                table: "ImagemDestino");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_ImagemDestino_DestinoId",
                table: "ImagemDestino");

            migrationBuilder.DropIndex(
                name: "IX_Depoimentos_UserId",
                table: "Depoimentos");

            migrationBuilder.DropColumn(
                name: "DestinoId",
                table: "ImagemDestino");

            migrationBuilder.DropColumn(
                name: "DtUpdated",
                table: "ImagemDestino");

            migrationBuilder.DropColumn(
                name: "DtUpdated",
                table: "Destinos");

            migrationBuilder.DropColumn(
                name: "DtUpdated",
                table: "Depoimentos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Depoimentos");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Destinos",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeEmployee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailExists = table.Column<bool>(type: "bit", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagemDestino_IdDestino",
                table: "ImagemDestino",
                column: "IdDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Depoimentos_IdUsuario",
                table: "Depoimentos",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Depoimentos_Usuarios_IdUsuario",
                table: "Depoimentos",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagemDestino_Destinos_IdDestino",
                table: "ImagemDestino",
                column: "IdDestino",
                principalTable: "Destinos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
