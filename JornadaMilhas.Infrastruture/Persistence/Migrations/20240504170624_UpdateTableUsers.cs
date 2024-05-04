using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JornadaMilhas.Infrastruture.Persistence.Migrations
{
    public partial class UpdateTableUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depoimentos_Users_UserId",
                table: "Depoimentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CodeEmployee",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UsersLimited");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Picture",
                table: "UsersLimited",
                type: "varbinary(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UsersLimited",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "EmailExists",
                table: "UsersLimited",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Adress",
                table: "UsersLimited",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Cep",
                table: "UsersLimited",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "UsersLimited",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_District",
                table: "UsersLimited",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "UsersLimited",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmEmail_Address",
                table: "UsersLimited",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cpf_Number",
                table: "UsersLimited",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DtBirth_Date",
                table: "UsersLimited",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email_Address",
                table: "UsersLimited",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "IdUser",
                table: "UsersLimited",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Phone_Number",
                table: "UsersLimited",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersLimited",
                table: "UsersLimited",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UsersAdmin",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeEmployee = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DtCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAdmin", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersLimited_ConfirmEmail_Address",
                table: "UsersLimited",
                column: "ConfirmEmail_Address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersLimited_Cpf_Number",
                table: "UsersLimited",
                column: "Cpf_Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersLimited_Email_Address",
                table: "UsersLimited",
                column: "Email_Address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersAdmin_ConfirmEmail_Address",
                table: "UsersAdmin",
                column: "ConfirmEmail_Address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersAdmin_Cpf_Number",
                table: "UsersAdmin",
                column: "Cpf_Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersAdmin_Email_Address",
                table: "UsersAdmin",
                column: "Email_Address",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Depoimentos_UsersLimited_UserId",
                table: "Depoimentos",
                column: "UserId",
                principalTable: "UsersLimited",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depoimentos_UsersLimited_UserId",
                table: "Depoimentos");

            migrationBuilder.DropTable(
                name: "UsersAdmin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersLimited",
                table: "UsersLimited");

            migrationBuilder.DropIndex(
                name: "IX_UsersLimited_ConfirmEmail_Address",
                table: "UsersLimited");

            migrationBuilder.DropIndex(
                name: "IX_UsersLimited_Cpf_Number",
                table: "UsersLimited");

            migrationBuilder.DropIndex(
                name: "IX_UsersLimited_Email_Address",
                table: "UsersLimited");

            migrationBuilder.DropColumn(
                name: "Address_Adress",
                table: "UsersLimited");

            migrationBuilder.DropColumn(
                name: "Address_Cep",
                table: "UsersLimited");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "UsersLimited");

            migrationBuilder.DropColumn(
                name: "Address_District",
                table: "UsersLimited");

            migrationBuilder.DropColumn(
                name: "Address_State",
                table: "UsersLimited");

            migrationBuilder.DropColumn(
                name: "ConfirmEmail_Address",
                table: "UsersLimited");

            migrationBuilder.DropColumn(
                name: "Cpf_Number",
                table: "UsersLimited");

            migrationBuilder.DropColumn(
                name: "DtBirth_Date",
                table: "UsersLimited");

            migrationBuilder.DropColumn(
                name: "Email_Address",
                table: "UsersLimited");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "UsersLimited");

            migrationBuilder.DropColumn(
                name: "Phone_Number",
                table: "UsersLimited");

            migrationBuilder.RenameTable(
                name: "UsersLimited",
                newName: "Users");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Picture",
                table: "Users",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<bool>(
                name: "EmailExists",
                table: "Users",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "CodeEmployee",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Depoimentos_Users_UserId",
                table: "Depoimentos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
