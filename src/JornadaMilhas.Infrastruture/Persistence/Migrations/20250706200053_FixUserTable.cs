using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JornadaMilhas.Infrastruture.Migrations
{
    public partial class FixUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Company_CompanyId",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Planes_Company_CompanyId",
                table: "Planes");

            migrationBuilder.DropIndex(
                name: "IX_Customer_ConfirmEmail_Address",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_Cpf_Number",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_Email_Address",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Admin_ConfirmEmail_Address",
                table: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Admin_Cpf_Number",
                table: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Admin_Email_Address",
                table: "Admin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Address_Cep",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Address_District",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Address_State",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ConfirmEmail_Address",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Cpf_Number",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "DtBirth_Date",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Email_Address",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Phone_Number",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Address_Cep",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Address_District",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Address_State",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "ConfirmEmail_Address",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Cpf_Number",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "DtBirth_Date",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Email_Address",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Phone_Number",
                table: "Admin");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

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

            migrationBuilder.AddColumn<string>(
                name: "Address_Cep",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_District",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmEmail_Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cpf_Number",
                table: "Users",
                type: "nvarchar(max)",
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
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone_Number",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Companies_CompanyId",
                table: "Admin",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Planes_Companies_CompanyId",
                table: "Planes",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Companies_CompanyId",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Planes_Companies_CompanyId",
                table: "Planes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

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
                name: "Address_Street",
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

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Picture",
                table: "Users",
                type: "varbinary(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address_Cep",
                table: "Customer",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Customer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_District",
                table: "Customer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "Customer",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Customer",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmEmail_Address",
                table: "Customer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cpf_Number",
                table: "Customer",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DtBirth_Date",
                table: "Customer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email_Address",
                table: "Customer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone_Number",
                table: "Customer",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Cep",
                table: "Admin",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Admin",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_District",
                table: "Admin",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "Admin",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Admin",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmEmail_Address",
                table: "Admin",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cpf_Number",
                table: "Admin",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DtBirth_Date",
                table: "Admin",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email_Address",
                table: "Admin",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone_Number",
                table: "Admin",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Company_CompanyId",
                table: "Admin",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Planes_Company_CompanyId",
                table: "Planes",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
