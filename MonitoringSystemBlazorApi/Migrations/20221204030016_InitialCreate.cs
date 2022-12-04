using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MonitoringSystemBlazorApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    HealthConcerns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedingSchedule = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Habitats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temp = table.Column<int>(type: "int", nullable: true),
                    FoodSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsClean = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitats", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "FeedingSchedule", "HealthConcerns", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 5, "Twice daily", "Cut on left front paw", "Leo", 0 },
                    { 2, 15, "3x per day", "", "Maj", 1 },
                    { 3, 1, "", "", "Baloo", 2 },
                    { 4, 12, "Grazing", "", "Spots", 3 }
                });

            migrationBuilder.InsertData(
                table: "Habitats",
                columns: new[] { "Id", "FoodSource", "IsClean", "Name", "Temp" },
                values: new object[,]
                {
                    { 1, "Fish in water running low", true, "Penguin", 1 },
                    { 2, "Natural from environment", true, "Bird", 3 },
                    { 3, "Added daily", false, "Aquarium", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Habitats");
        }
    }
}
