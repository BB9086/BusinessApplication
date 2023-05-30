using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessMobileApi.Migrations
{
    public partial class StoreIncomeByYears : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoreIncomePerYears",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    smonth = table.Column<string>(nullable: false),
                    mname = table.Column<string>(nullable: false),
                    amount = table.Column<decimal>(nullable: false),
                    idc = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreIncomePerYears", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreIncomePerYears");
        }
    }
}
