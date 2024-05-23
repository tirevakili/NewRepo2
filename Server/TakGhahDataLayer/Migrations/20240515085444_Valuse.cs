using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakGhahDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Valuse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticlesCategories",
                columns: table => new
                {
                    ArticlesCategory_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticlesCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticlesCategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageArticlesCategory = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticlesCategories", x => x.ArticlesCategory_ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterUserDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ProfileImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Article_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticlesCategory_ID = table.Column<int>(type: "int", nullable: false),
                    TitleArticle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyArticle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Article_ID);
                    table.ForeignKey(
                        name: "FK_Articles_ArticlesCategories_ArticlesCategory_ID",
                        column: x => x.ArticlesCategory_ID,
                        principalTable: "ArticlesCategories",
                        principalColumn: "ArticlesCategory_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleImages",
                columns: table => new
                {
                    ArticleImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Article_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleImages", x => x.ArticleImageID);
                    table.ForeignKey(
                        name: "FK_ArticleImages_Articles_Article_ID",
                        column: x => x.Article_ID,
                        principalTable: "Articles",
                        principalColumn: "Article_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleImages_Article_ID",
                table: "ArticleImages",
                column: "Article_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticlesCategory_ID",
                table: "Articles",
                column: "ArticlesCategory_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleImages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "ArticlesCategories");
        }
    }
}
