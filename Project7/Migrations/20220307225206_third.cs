using Microsoft.EntityFrameworkCore.Migrations;

namespace Project7.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OrderReceived",
                table: "Checkout",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderReceived",
                table: "Checkout");
        }
    }
}
