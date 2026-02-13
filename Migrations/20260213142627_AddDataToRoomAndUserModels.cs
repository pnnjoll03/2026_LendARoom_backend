using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _2026_LendARoom_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToRoomAndUserModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Location", "Name", "Status" },
                values: new object[,]
                {
                    { 1, 600, "Gedung SAW Lt.6", "Auditorium PENS", "Tersedia" },
                    { 2, 150, "Gedung SAW Lt.6", "Mini Teater", "Tersedia" },
                    { 3, 150, "Gedung D3 PENS", "Teater D3", "Tersedia" },
                    { 4, 200, "Disebelah Masjid An-Nahl PENS", "Student Center Lt.1", "Tersedia" },
                    { 5, 200, "Disebelah Masjid An-Nahl PENS", "Student Center Lt.2", "Tersedia" },
                    { 6, 200, "Disebelah Masjid An-Nahl PENS", "Student Center Lt.3", "Tersedia" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Class", "NRP", "Password", "Role", "Username" },
                values: new object[] { 1, "", "", "Admin123", "Admin", "Admin1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
