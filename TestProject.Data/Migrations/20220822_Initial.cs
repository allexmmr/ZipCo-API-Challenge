using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProject.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Users",
                x => new
                {
                    Id = x.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = x.Column<string>(nullable: false),
                    EmailAdress = x.Column<string>(nullable: false),
                    Password = x.Column<string>(nullable: false),
                    MonthlySalary = x.Column<string>(nullable: true),
                    MonthlyExpenses = x.Column<string>(nullable: true)
                }).PrimaryKey("PK_Users", x => x.Id);

            migrationBuilder.CreateTable(
                "Accounts",
                x => new
                {
                    Id = x.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = x.Column<int>(nullable: false),
                    AccountNumber = x.Column<string>(nullable: false)
                }).PrimaryKey("PK_Accounts", x => x.Id);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Accounts");
            migrationBuilder.DropTable("Users");
        }
    }
}
