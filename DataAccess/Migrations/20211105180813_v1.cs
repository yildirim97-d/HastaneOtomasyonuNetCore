using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doktorlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoktorSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoktorTcNo = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    Guid = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktorlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hastaneler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastaneAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HastaneAdres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastaneler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoktorHastane",
                columns: table => new
                {
                    DoktorId = table.Column<int>(type: "int", nullable: false),
                    HastaneId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoktorHastane", x => new { x.DoktorId, x.HastaneId });
                    table.ForeignKey(
                        name: "FK_DoktorHastane_Doktorlar_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktorlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoktorHastane_Hastaneler_HastaneId",
                        column: x => x.HastaneId,
                        principalTable: "Hastaneler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoktorHastane_HastaneId",
                table: "DoktorHastane",
                column: "HastaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_DoktorTcNo",
                table: "Doktorlar",
                column: "DoktorTcNo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoktorHastane");

            migrationBuilder.DropTable(
                name: "Doktorlar");

            migrationBuilder.DropTable(
                name: "Hastaneler");
        }
    }
}
