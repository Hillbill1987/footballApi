using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FootballApi.Migrations
{
    /// <inheritdoc />
    public partial class dataadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "players",
                columns: new[] { "Id", "Age", "FirstName", "LastName", "Team" },
                values: new object[,]
                {
                    { 1, 25, "Dave", "test", "Underwood" },
                    { 2, 35, "Roger", "Owens", "Cola" },
                    { 3, 30, "Kello", "Dance", "Water" }
                });

            migrationBuilder.InsertData(
                table: "teams",
                columns: new[] { "Id", "Country", "Manager", "Name", "YearFounded" },
                values: new object[,]
                {
                    { 1, "England", "Mr T", "Fc Cola", 1987 },
                    { 2, "Nigeria", "Mr No", "RunTime Warriors", 1912 },
                    { 3, "Scotland", "Mr Yu", "Shavers head", 1956 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
