using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class changeDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Doktorlar_DoktorTcNo",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Hastaneler");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "DoktorHastane");

            migrationBuilder.AlterColumn<string>(
                name: "DoktorTcNo",
                table: "Doktorlar",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 11);

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_DoktorTcNo",
                table: "Doktorlar",
                column: "DoktorTcNo",
                unique: true,
                filter: "[DoktorTcNo] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Doktorlar_DoktorTcNo",
                table: "Doktorlar");

            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "Hastaneler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoktorTcNo",
                table: "Doktorlar",
                type: "int",
                maxLength: 11,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "Doktorlar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "DoktorHastane",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_DoktorTcNo",
                table: "Doktorlar",
                column: "DoktorTcNo",
                unique: true);
        }
    }
}
