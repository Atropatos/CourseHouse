using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoursesHouse.Migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:Backend/Migrations/20240318143826_Init1.cs
    public partial class Init1 : Migration
========
    public partial class init_1 : Migration
>>>>>>>> origin/DawidDev:Backend/Migrations/20240318120347_init_1.cs
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseGrades",
                columns: table => new
                {
                    CourseGradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<decimal>(type: "decimal(2,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseGrades", x => x.CourseGradeId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    CreditCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreditCardNumber = table.Column<string>(type: "longtext", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Cvv = table.Column<string>(type: "longtext", nullable: false),
                    HolderName = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.CreditCardId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LastVisited",
                columns: table => new
                {
                    LastVisitedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    LastVisitedCourses = table.Column<string>(type: "longtext", nullable: false),
                    LastVisitedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastVisited", x => x.LastVisitedId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreditCardId = table.Column<int>(type: "int", nullable: false),
                    PurchasedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TotalSpend = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    ContentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "longtext", nullable: false),
                    CourseViewViewId = table.Column<int>(type: "int", nullable: true),
                    ViewTestTestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.ContentId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseComments",
                columns: table => new
                {
                    CourseCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CommentContent = table.Column<string>(type: "varchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseComments", x => x.CourseCommentId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "longtext", nullable: false),
                    CoursePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CourseFlow = table.Column<string>(type: "longtext", nullable: false),
                    PurchasedCourses = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Purchases_PurchasedCourses",
                        column: x => x.PurchasedCourses,
                        principalTable: "Purchases",
                        principalColumn: "PurchaseId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseViews",
                columns: table => new
                {
                    ViewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    ContentOrder = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseViews", x => x.ViewId);
                    table.ForeignKey(
                        name: "FK_CourseViews_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ViewTests",
                columns: table => new
                {
                    TestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    ContentOrder = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewTests", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_ViewTests_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    PictureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<int>(type: "int", nullable: false),
                    ContentUrl = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CourseViewViewId = table.Column<int>(type: "int", nullable: true),
                    ViewTestTestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.PictureId);
                    table.ForeignKey(
                        name: "FK_Pictures_CourseViews_CourseViewViewId",
                        column: x => x.CourseViewViewId,
                        principalTable: "CourseViews",
                        principalColumn: "ViewId");
                    table.ForeignKey(
                        name: "FK_Pictures_Users_Author",
                        column: x => x.Author,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pictures_ViewTests_ViewTestTestId",
                        column: x => x.ViewTestTestId,
                        principalTable: "ViewTests",
                        principalColumn: "TestId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TestAnswers",
                columns: table => new
                {
                    TestAnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    content = table.Column<string>(type: "longtext", nullable: false),
                    correct = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ViewTestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAnswers", x => x.TestAnswerId);
                    table.ForeignKey(
                        name: "FK_TestAnswers_ViewTests_ViewTestId",
                        column: x => x.ViewTestId,
                        principalTable: "ViewTests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    VideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    ContentUrl = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CourseViewViewId = table.Column<int>(type: "int", nullable: true),
                    ViewTestTestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.VideoId);
                    table.ForeignKey(
                        name: "FK_Videos_CourseViews_CourseViewViewId",
                        column: x => x.CourseViewViewId,
                        principalTable: "CourseViews",
                        principalColumn: "ViewId");
                    table.ForeignKey(
                        name: "FK_Videos_ViewTests_ViewTestTestId",
                        column: x => x.ViewTestTestId,
                        principalTable: "ViewTests",
                        principalColumn: "TestId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Admin" },
                    { 3, "Moderator" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CourseId", "Email", "LastName", "Name", "RoleId" },
                values: new object[,]
                {
                    { 1, null, "emanuel@admin.com", "Admin", "Emanuel", 2 },
                    { 2, null, "dawid@admin.com", "Admin", "Dawid", 2 },
                    { 3, null, "adam@nowak.com", "Nowak", "Adam", 1 },
                    { 4, null, "anna@kowalska.com", "Kowalska", "Anna", 1 },
                    { 5, null, "jan@kowalczyk.com", "Kowalczyk", "Jan", 1 },
                    { 6, null, "katarzyna@wisniewska.com", "Wiśniewska", "Katarzyna", 1 },
                    { 7, null, "magdalena@lewandowska.com", "Lewandowska", "Magdalena", 1 },
                    { 8, null, "tomasz@wojcik.com", "Wójcik", "Tomasz", 1 },
                    { 9, null, "agnieszka@kaminska.com", "Kamińska", "Agnieszka", 1 },
                    { 10, null, "marcin@kowalewski.com", "Kowalewski", "Marcin", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contents_Author",
                table: "Contents",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_CourseViewViewId",
                table: "Contents",
                column: "CourseViewViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_ViewTestTestId",
                table: "Contents",
                column: "ViewTestTestId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseComments_CourseId",
                table: "CourseComments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Author",
                table: "Courses",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_PurchasedCourses",
                table: "Courses",
                column: "PurchasedCourses");

            migrationBuilder.CreateIndex(
                name: "IX_CourseViews_CourseId",
                table: "CourseViews",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_Author",
                table: "Pictures",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_CourseViewViewId",
                table: "Pictures",
                column: "CourseViewViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ViewTestTestId",
                table: "Pictures",
                column: "ViewTestTestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAnswers_ViewTestId",
                table: "TestAnswers",
                column: "ViewTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CourseId",
                table: "Users",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_CourseViewViewId",
                table: "Videos",
                column: "CourseViewViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ViewTestTestId",
                table: "Videos",
                column: "ViewTestTestId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewTests_CourseId",
                table: "ViewTests",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_CourseViews_CourseViewViewId",
                table: "Contents",
                column: "CourseViewViewId",
                principalTable: "CourseViews",
                principalColumn: "ViewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Users_Author",
                table: "Contents",
                column: "Author",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_ViewTests_ViewTestTestId",
                table: "Contents",
                column: "ViewTestTestId",
                principalTable: "ViewTests",
                principalColumn: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseComments_Courses_CourseId",
                table: "CourseComments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_Author",
                table: "Courses",
                column: "Author",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_Author",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "CourseComments");

            migrationBuilder.DropTable(
                name: "CourseGrades");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "LastVisited");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TestAnswers");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "CourseViews");

            migrationBuilder.DropTable(
                name: "ViewTests");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Purchases");
        }
    }
}
