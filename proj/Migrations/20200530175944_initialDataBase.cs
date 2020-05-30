using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace proj.Migrations
{
    public partial class initialDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Quizes",
                columns: table => new
                {
                    IdQuiz = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuizName = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    IdUserFK = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizes", x => x.IdQuiz);
                    table.ForeignKey(
                        name: "FK_Quizes_Users_IdUserFK",
                        column: x => x.IdUserFK,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    IdQuestion = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TextQuestion = table.Column<string>(nullable: false),
                    Answer1 = table.Column<string>(nullable: false),
                    Answer1Bool = table.Column<bool>(nullable: false),
                    Answer2 = table.Column<string>(nullable: false),
                    Answer2Bool = table.Column<bool>(nullable: false),
                    Answer3 = table.Column<string>(nullable: true),
                    Answer3Bool = table.Column<bool>(nullable: false),
                    Answer4 = table.Column<string>(nullable: true),
                    Answer4Bool = table.Column<bool>(nullable: false),
                    Answer5 = table.Column<string>(nullable: true),
                    Answer5Bool = table.Column<bool>(nullable: false),
                    Answer6 = table.Column<string>(nullable: true),
                    Answer6Bool = table.Column<bool>(nullable: false),
                    Answer7 = table.Column<string>(nullable: true),
                    Answer7Bool = table.Column<bool>(nullable: false),
                    Answer8 = table.Column<string>(nullable: true),
                    Answer8Bool = table.Column<bool>(nullable: false),
                    IdQuizFK = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.IdQuestion);
                    table.ForeignKey(
                        name: "FK_Questions_Quizes_IdQuizFK",
                        column: x => x.IdQuizFK,
                        principalTable: "Quizes",
                        principalColumn: "IdQuiz",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_IdQuizFK",
                table: "Questions",
                column: "IdQuizFK");

            migrationBuilder.CreateIndex(
                name: "IX_Quizes_IdUserFK",
                table: "Quizes",
                column: "IdUserFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Quizes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
