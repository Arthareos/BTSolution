using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTSolution.API.Migrations
{
    public partial class UpdatedAccessToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "AccessTokens",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "AccessTokens");
        }
    }
}
