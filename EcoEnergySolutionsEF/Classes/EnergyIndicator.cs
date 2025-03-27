using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcoEnergySolutionsEF.Classes
{
    public class EnergyIndicator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Name("Data")]
        public string Date { get; set; }
        [Name("CDEEBC_ProdNeta")]
        public double CDEEBC_NetProduction { get; set; }
        [Name("CCAC_GasolinaAuto")]
        public double CCAC_AutoGas { get; set; }
        [Name("CDEEBC_DemandaElectr")]
        public double CDEEBC_ElectricDemand { get; set; }
        [Name("CDEEBC_ProdDisp")]
        public double CDEEBC_DispProd { get; set; }
    }
}
