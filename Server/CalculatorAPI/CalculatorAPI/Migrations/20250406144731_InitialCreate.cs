using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalculatorAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "storedCalculation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstNumber = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Operator = table.Column<int>(type: "int", nullable: false),
                    SecondNumber = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Result = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storedCalculation", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "storedCalculation");
        }
    }
}
