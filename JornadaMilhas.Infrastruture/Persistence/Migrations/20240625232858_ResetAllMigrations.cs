using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JornadaMilhas.Infrastruture.Migrations
{
    public partial class ResetAllMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescriptionPortuguese = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DtBirth_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genre = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    Cpf_Number = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Phone_Number = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Address_Cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Address_Adress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Address_District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Picture = table.Column<byte[]>(type: "varbinary(1000)", maxLength: 1000, nullable: true),
                    Email_Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ConfirmEmail_Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImagemDestino",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagemBytes = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DestinoId = table.Column<long>(type: "bigint", nullable: false),
                    IdDestino = table.Column<long>(type: "bigint", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagemDestino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagemDestino_Destinos_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Destinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAdmin",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CodeEmployee = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdmin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAdmin_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserLimited",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EmailExists = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLimited", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLimited_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Depoimentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepoimentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depoimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Depoimentos_UserLimited_UserId",
                        column: x => x.UserId,
                        principalTable: "UserLimited",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Depoimentos_UserId",
                table: "Depoimentos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagemDestino_DestinoId",
                table: "ImagemDestino",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ConfirmEmail_Address",
                table: "Users",
                column: "ConfirmEmail_Address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Cpf_Number",
                table: "Users",
                column: "Cpf_Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email_Address",
                table: "Users",
                column: "Email_Address",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Depoimentos");

            migrationBuilder.DropTable(
                name: "ImagemDestino");

            migrationBuilder.DropTable(
                name: "UserAdmin");

            migrationBuilder.DropTable(
                name: "UserLimited");

            migrationBuilder.DropTable(
                name: "Destinos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
