using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class WrittenWorksInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "姓読みソート用",
                table: "Authors",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "姓読み",
                table: "Authors",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "姓ローマ字",
                table: "Authors",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "姓",
                table: "Authors",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    出版社名 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WriterRoles",
                columns: table => new
                {
                    役割フラグ = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriterRoles", x => x.役割フラグ);
                });

            migrationBuilder.CreateTable(
                name: "WritingStyles",
                columns: table => new
                {
                    文字使い種別 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WritingStyles", x => x.文字使い種別);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    底本名 = table.Column<string>(type: "TEXT", nullable: false),
                    底本出版社ID = table.Column<string>(type: "TEXT", nullable: true),
                    底本出版社発行年 = table.Column<string>(type: "TEXT", nullable: true),
                    底本の親元ID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sources_Publishers_底本出版社ID",
                        column: x => x.底本出版社ID,
                        principalTable: "Publishers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sources_Sources_底本の親元ID",
                        column: x => x.底本の親元ID,
                        principalTable: "Sources",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WrittenWorks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    作品名 = table.Column<string>(type: "TEXT", nullable: false),
                    作品名読み = table.Column<string>(type: "TEXT", nullable: false),
                    ソート用読み = table.Column<string>(type: "TEXT", nullable: false),
                    副題 = table.Column<string>(type: "TEXT", nullable: true),
                    副題読み = table.Column<string>(type: "TEXT", nullable: true),
                    原題 = table.Column<string>(type: "TEXT", nullable: true),
                    初出 = table.Column<string>(type: "TEXT", nullable: true),
                    文字使い種別ID = table.Column<string>(type: "TEXT", nullable: false),
                    作品著作権フラグ = table.Column<bool>(type: "INTEGER", nullable: false),
                    人物ID = table.Column<string>(type: "TEXT", nullable: false),
                    役割フラグID = table.Column<string>(type: "TEXT", nullable: false),
                    底本ID = table.Column<string>(type: "TEXT", nullable: true),
                    テキストファイルURL = table.Column<string>(type: "TEXT", nullable: false),
                    XHTMLHTMLファイルURL = table.Column<string>(name: "XHTML/HTMLファイルURL", type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WrittenWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WrittenWorks_Authors_人物ID",
                        column: x => x.人物ID,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WrittenWorks_Sources_底本ID",
                        column: x => x.底本ID,
                        principalTable: "Sources",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WrittenWorks_WriterRoles_役割フラグID",
                        column: x => x.役割フラグID,
                        principalTable: "WriterRoles",
                        principalColumn: "役割フラグ",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WrittenWorks_WritingStyles_文字使い種別ID",
                        column: x => x.文字使い種別ID,
                        principalTable: "WritingStyles",
                        principalColumn: "文字使い種別",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sources_底本の親元ID",
                table: "Sources",
                column: "底本の親元ID");

            migrationBuilder.CreateIndex(
                name: "IX_Sources_底本出版社ID",
                table: "Sources",
                column: "底本出版社ID");

            migrationBuilder.CreateIndex(
                name: "IX_WrittenWorks_人物ID",
                table: "WrittenWorks",
                column: "人物ID");

            migrationBuilder.CreateIndex(
                name: "IX_WrittenWorks_底本ID",
                table: "WrittenWorks",
                column: "底本ID");

            migrationBuilder.CreateIndex(
                name: "IX_WrittenWorks_役割フラグID",
                table: "WrittenWorks",
                column: "役割フラグID");

            migrationBuilder.CreateIndex(
                name: "IX_WrittenWorks_文字使い種別ID",
                table: "WrittenWorks",
                column: "文字使い種別ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WrittenWorks");

            migrationBuilder.DropTable(
                name: "Sources");

            migrationBuilder.DropTable(
                name: "WriterRoles");

            migrationBuilder.DropTable(
                name: "WritingStyles");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.AlterColumn<string>(
                name: "姓読みソート用",
                table: "Authors",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "姓読み",
                table: "Authors",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "姓ローマ字",
                table: "Authors",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "姓",
                table: "Authors",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
