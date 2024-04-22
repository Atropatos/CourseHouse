using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoursesHouse.Migrations
{
    /// <inheritdoc />
    public partial class migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_id",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_id",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41aad95f-258a-41ec-8903-9fc7ba42f73c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1af1d74-e26b-41c5-addb-64bf18ae2119");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Courses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3176e466-1499-414f-88af-409bae33fe17", null, "User", "USER" },
                    { "3f280511-5d5d-437f-bff5-50875ee89543", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3176e466-1499-414f-88af-409bae33fe17");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f280511-5d5d-437f-bff5-50875ee89543");

            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "Courses",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "41aad95f-258a-41ec-8903-9fc7ba42f73c", null, "User", "USER" },
                    { "a1af1d74-e26b-41c5-addb-64bf18ae2119", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_id",
                table: "Courses",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_id",
                table: "Courses",
                column: "id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
