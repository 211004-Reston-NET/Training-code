using Microsoft.EntityFrameworkCore.Migrations;

namespace RRDL.Migrations
{
    public partial class InfoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    rest_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rest_city = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    rest_state = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    rest_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Restaura__9A2078C0B7A55AA5", x => x.rest_id);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    rev_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rev_rating = table.Column<int>(type: "int", nullable: false),
                    rest_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Review__397465D62DF3E169", x => x.rev_id);
                    table.ForeignKey(
                        name: "FK__Review__rest_id__01142BA1",
                        column: x => x.rest_id,
                        principalTable: "Restaurant",
                        principalColumn: "rest_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_rest_id",
                table: "Review",
                column: "rest_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Restaurant");
        }
    }
}
