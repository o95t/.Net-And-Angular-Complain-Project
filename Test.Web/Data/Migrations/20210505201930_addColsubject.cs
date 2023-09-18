using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Web.Data.Migrations
{
    public partial class addColsubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Complains",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Complains");
        }
    }
}
