using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessMobileApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    ip = table.Column<string>(nullable: false),
                    connected = table.Column<int>(nullable: false),
                    seller = table.Column<int>(nullable: false),
                    paidAmount = table.Column<decimal>(nullable: false),
                    unpaidAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
