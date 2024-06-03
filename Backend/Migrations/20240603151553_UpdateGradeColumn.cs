using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoursesHouse.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGradeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0383d143-3191-4ae5-96d5-cc672685552a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7007f0e9-c6d8-4aaa-981d-4f195c9c50eb");

            migrationBuilder.AlterColumn<decimal>(
                name: "Grade",
                table: "CourseGrades",
                type: "decimal(4,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44aafd07-8b03-4bcc-8a5a-b7b16084937c", null, "User", "USER" },
                    { "e103dd78-b2a7-4663-9ead-51db56e012f7", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44aafd07-8b03-4bcc-8a5a-b7b16084937c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e103dd78-b2a7-4663-9ead-51db56e012f7");

            migrationBuilder.AlterColumn<decimal>(
                name: "Grade",
                table: "CourseGrades",
                type: "decimal(2,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0383d143-3191-4ae5-96d5-cc672685552a", null, "Admin", "ADMIN" },
                    { "7007f0e9-c6d8-4aaa-981d-4f195c9c50eb", null, "User", "USER" }
                });
        }
    }
}
