using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicList.Migrations
{
    public partial class updateNameProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Musics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Musics",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
