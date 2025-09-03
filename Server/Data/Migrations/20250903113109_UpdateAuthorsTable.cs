using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAuthorsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SurnameSort",
                table: "Authors",
                newName: "姓読みソート用");

            migrationBuilder.RenameColumn(
                name: "SurnameRomaji",
                table: "Authors",
                newName: "姓ローマ字");

            migrationBuilder.RenameColumn(
                name: "SurnameReading",
                table: "Authors",
                newName: "姓読み");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Authors",
                newName: "姓");

            migrationBuilder.RenameColumn(
                name: "PersonalityRights",
                table: "Authors",
                newName: "人物著作権フラグ");

            migrationBuilder.RenameColumn(
                name: "GivenNameSort",
                table: "Authors",
                newName: "名読みソート用");

            migrationBuilder.RenameColumn(
                name: "GivenNameRomaji",
                table: "Authors",
                newName: "名ローマ字");

            migrationBuilder.RenameColumn(
                name: "GivenNameReading",
                table: "Authors",
                newName: "名読み");

            migrationBuilder.RenameColumn(
                name: "GivenName",
                table: "Authors",
                newName: "名");

            migrationBuilder.RenameColumn(
                name: "DeathDate",
                table: "Authors",
                newName: "没年月日");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Authors",
                newName: "生年月日");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "生年月日",
                table: "Authors",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "没年月日",
                table: "Authors",
                newName: "DeathDate");

            migrationBuilder.RenameColumn(
                name: "姓読みソート用",
                table: "Authors",
                newName: "SurnameSort");

            migrationBuilder.RenameColumn(
                name: "姓読み",
                table: "Authors",
                newName: "SurnameReading");

            migrationBuilder.RenameColumn(
                name: "姓ローマ字",
                table: "Authors",
                newName: "SurnameRomaji");

            migrationBuilder.RenameColumn(
                name: "姓",
                table: "Authors",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "名読みソート用",
                table: "Authors",
                newName: "GivenNameSort");

            migrationBuilder.RenameColumn(
                name: "名読み",
                table: "Authors",
                newName: "GivenNameReading");

            migrationBuilder.RenameColumn(
                name: "名ローマ字",
                table: "Authors",
                newName: "GivenNameRomaji");

            migrationBuilder.RenameColumn(
                name: "名",
                table: "Authors",
                newName: "GivenName");

            migrationBuilder.RenameColumn(
                name: "人物著作権フラグ",
                table: "Authors",
                newName: "PersonalityRights");
        }
    }
}
