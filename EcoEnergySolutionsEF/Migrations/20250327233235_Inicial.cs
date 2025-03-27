using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoEnergySolutionsEF.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnergyIndicator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CDEEBC_NetProduction = table.Column<double>(type: "float", nullable: false),
                    CCAC_AutoGas = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_ElectricDemand = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_DispProd = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyIndicator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Simulacio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipusEnergia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parametre = table.Column<double>(type: "float", nullable: false),
                    Rati = table.Column<double>(type: "float", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Preu = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulacio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterConsumption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    RegionCode = table.Column<int>(type: "int", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: false),
                    DomesticConsumption = table.Column<double>(type: "float", nullable: false),
                    EconomicActivitiesConsumption = table.Column<double>(type: "float", nullable: false),
                    TotalConsumption = table.Column<double>(type: "float", nullable: false),
                    DomesticConsumptionPerCapita = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterConsumption", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnergyIndicator");

            migrationBuilder.DropTable(
                name: "Simulacio");

            migrationBuilder.DropTable(
                name: "WaterConsumption");
        }
    }
}
