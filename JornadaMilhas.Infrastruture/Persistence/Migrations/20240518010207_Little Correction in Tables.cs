using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JornadaMilhas.Infrastruture.Persistence.Migrations
{
    public partial class LittleCorrectioninTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Depoimentos",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Depoimentos",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "Foto",
                table: "Depoimentos",
                newName: "Picture");

            migrationBuilder.RenameColumn(
                name: "DescricaoDepoimento",
                table: "Depoimentos",
                newName: "DepoimentDescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Depoimentos",
                newName: "Foto");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Depoimentos",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Depoimentos",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "DepoimentDescription",
                table: "Depoimentos",
                newName: "DescricaoDepoimento");
        }
    }
}
