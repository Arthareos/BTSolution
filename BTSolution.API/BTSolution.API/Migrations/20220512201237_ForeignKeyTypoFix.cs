using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTSolution.API.Migrations
{
    public partial class ForeignKeyTypoFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "AccessTokens",
                newName: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AccessTokens",
                newName: "userId");
        }
    }
}
