using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Web.Data.Migrations
{
    public partial class addColComplaint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainProblem",
                table: "Complains",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Complains",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainProblem",
                table: "Complains");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Complains");
        }
    }
}
