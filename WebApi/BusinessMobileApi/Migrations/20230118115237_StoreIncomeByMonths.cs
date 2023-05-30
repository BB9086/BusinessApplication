using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessMobileApi.Migrations
{
    public partial class StoreIncomeByMonths : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoreIncomePerMonths",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    date = table.Column<string>(nullable: false),
                    sdate = table.Column<string>(nullable: false),
                    gdate = table.Column<string>(nullable: false),
                    dname = table.Column<string>(nullable: false),
                    amount = table.Column<decimal>(nullable: false),
                    idc = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreIncomePerMonths", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreIncomePerMonths");
        }
    }
}
