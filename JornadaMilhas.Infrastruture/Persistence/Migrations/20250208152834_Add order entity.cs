using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JornadaMilhas.Infrastruture.Migrations
{
    public partial class Addorderentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depoimentos_UserLimited_UserId",
                table: "Depoimentos");

            migrationBuilder.DropTable(
                name: "ImagemDestino");

            migrationBuilder.DropTable(
                name: "UserAdmin");

            migrationBuilder.DropTable(
                name: "UserLimited");

            migrationBuilder.DropTable(
                name: "Destinos");

            migrationBuilder.DropIndex(
                name: "IX_Users_ConfirmEmail_Address",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Cpf_Number",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email_Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_Adress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_Cep",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_District",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_State",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ConfirmEmail_Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Cpf_Number",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DtBirth_Date",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email_Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone_Number",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Depoimentos");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Depoimentos",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Depoimentos_UserId",
                table: "Depoimentos",
                newName: "IX_Depoimentos_CustomerId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyId1 = table.Column<long>(type: "bigint", nullable: true),
                    DtBirth_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cpf_Number = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Phone_Number = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Address_Cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Address_Street = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Address_District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email_Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ConfirmEmail_Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admin_Company_CompanyId1",
                        column: x => x.CompanyId1,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Admin_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    DtBirth_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cpf_Number = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Phone_Number = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Address_Cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Address_Street = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Address_District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email_Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ConfirmEmail_Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentificationCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planes_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalValue = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LandingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    FlightCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destiny_Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Destiny_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Destiny_Latitude = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Destiny_Longitude = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Source_Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Source_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Source_Latitude = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Source_Longitude = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    PlaneId = table.Column<long>(type: "bigint", nullable: false),
                    PlaneId1 = table.Column<long>(type: "bigint", nullable: true),
                    DtCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Planes_PlaneId",
                        column: x => x.PlaneId,
                        principalTable: "Planes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Planes_PlaneId1",
                        column: x => x.PlaneId1,
                        principalTable: "Planes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Passage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    EnumTypeSeat = table.Column<int>(type: "int", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    EnumTypeClass = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<long>(type: "bigint", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passage_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passage_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PathS3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightId = table.Column<long>(type: "bigint", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Picture_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_CompanyId",
                table: "Admin",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_CompanyId1",
                table: "Admin",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_ConfirmEmail_Address",
                table: "Admin",
                column: "ConfirmEmail_Address",
                unique: true,
                filter: "[ConfirmEmail_Address] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Cpf_Number",
                table: "Admin",
                column: "Cpf_Number",
                unique: true,
                filter: "[Cpf_Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Email_Address",
                table: "Admin",
                column: "Email_Address",
                unique: true,
                filter: "[Email_Address] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ConfirmEmail_Address",
                table: "Customer",
                column: "ConfirmEmail_Address",
                unique: true,
                filter: "[ConfirmEmail_Address] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Cpf_Number",
                table: "Customer",
                column: "Cpf_Number",
                unique: true,
                filter: "[Cpf_Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Email_Address",
                table: "Customer",
                column: "Email_Address",
                unique: true,
                filter: "[Email_Address] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PlaneId",
                table: "Flights",
                column: "PlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PlaneId1",
                table: "Flights",
                column: "PlaneId1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Passage_FlightId",
                table: "Passage",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Passage_OrderId",
                table: "Passage",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_FlightId",
                table: "Picture",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_CompanyId",
                table: "Planes",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depoimentos_Customer_CustomerId",
                table: "Depoimentos",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depoimentos_Customer_CustomerId",
                table: "Depoimentos");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Passage");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Depoimentos",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Depoimentos_CustomerId",
                table: "Depoimentos",
                newName: "IX_Depoimentos_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Address_Adress",
                table: "Users",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Cep",
                table: "Users",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_District",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "Users",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmEmail_Address",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cpf_Number",
                table: "Users",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DtBirth_Date",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email_Address",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone_Number",
                table: "Users",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "IdUser",
                table: "Depoimentos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionPortuguese = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.Id);
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
                name: "ImagemDestino",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinoId = table.Column<long>(type: "bigint", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdDestino = table.Column<long>(type: "bigint", nullable: false),
                    ImagemBytes = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_ImagemDestino_DestinoId",
                table: "ImagemDestino",
                column: "DestinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depoimentos_UserLimited_UserId",
                table: "Depoimentos",
                column: "UserId",
                principalTable: "UserLimited",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
