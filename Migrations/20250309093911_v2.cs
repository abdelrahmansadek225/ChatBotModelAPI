using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChatBotModelAPI.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ab84209-6f00-4085-9688-118c5ff79e5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "644a040b-4386-4d4a-8aa1-a68cb66bad54");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec0aa1c1-8e0a-453b-9834-a9754603b30d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07c67238-a4df-41ec-84a6-2fb761c8bfbd", null, "SuperAdmin", "SUPERADMIN" },
                    { "909908dd-889e-45f6-bd27-80221f376bde", null, "Admin", "ADMIN" },
                    { "96641ffa-b6af-46f1-b974-3f020305b613", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07c67238-a4df-41ec-84a6-2fb761c8bfbd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "909908dd-889e-45f6-bd27-80221f376bde");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96641ffa-b6af-46f1-b974-3f020305b613");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ab84209-6f00-4085-9688-118c5ff79e5e", null, "SuperAdmin", "SUPERADMIN" },
                    { "644a040b-4386-4d4a-8aa1-a68cb66bad54", null, "User", "USER" },
                    { "ec0aa1c1-8e0a-453b-9834-a9754603b30d", null, "Admin", "ADMIN" }
                });
        }
    }
}
