using Microsoft.EntityFrameworkCore.Migrations;

namespace DashboardCovid.Data.Migrations
{
    public partial class CovidMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Infeccoes",
                columns: table => new
                {
                    InfeccaoPaisId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Pais = table.Column<string>(nullable: true),
                    CasosConfirmados = table.Column<int>(nullable: false),
                    Mortes = table.Column<int>(nullable: false),
                    Recuperados = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infeccoes", x => x.InfeccaoPaisId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Infeccoes");
        }
    }
}
