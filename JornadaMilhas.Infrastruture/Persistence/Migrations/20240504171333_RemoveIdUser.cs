using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JornadaMilhas.Infrastruture.Persistence.Migrations
{
    public partial class RemoveIdUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "UsersLimited");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IdUser",
                table: "UsersLimited",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
