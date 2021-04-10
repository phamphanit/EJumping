using Microsoft.EntityFrameworkCore.Migrations;

namespace EJumping.DAL.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "exp",
                table: "users");

            migrationBuilder.DropColumn(
                name: "point",
                table: "users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "exp",
                table: "users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "point",
                table: "users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
