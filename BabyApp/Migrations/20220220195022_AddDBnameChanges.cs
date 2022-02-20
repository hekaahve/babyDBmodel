using Microsoft.EntityFrameworkCore.Migrations;

namespace BabyApp.Migrations
{
    public partial class AddDBnameChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pees");

            migrationBuilder.DropTable(
                name: "Poos");

            migrationBuilder.CreateTable(
                name: "ninnis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    Age = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ninnis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "posSD2s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    Age = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posSD2s", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ninnis");

            migrationBuilder.DropTable(
                name: "posSD2s");

            migrationBuilder.CreateTable(
                name: "Pees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<string>(type: "TEXT", nullable: true),
                    Number = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Poos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<string>(type: "TEXT", nullable: true),
                    Delivery = table.Column<string>(type: "TEXT", nullable: true),
                    Quality = table.Column<string>(type: "TEXT", nullable: true),
                    Time = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poos", x => x.Id);
                });
        }
    }
}
