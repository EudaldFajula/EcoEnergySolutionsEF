using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcoEnergySolutionsEF.Classes
{
    public class WaterConsumption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Name("Any")]
        public int Year { get; set; } 
        [Name("Codi comarca")]
        public int RegionCode { get; set; } 
        [Name("Comarca")]
        public string Region { get; set; } 
        [Name("Població")]
        public int Population { get; set; } 
        [Name("Domèstic xarxa")]
        public double DomesticConsumption { get; set; } 
        [Name("Activitats econòmiques i fonts pròpies")]
        public double EconomicActivitiesConsumption { get; set; } 
        [Name("Total")]
        public double TotalConsumption { get; set; } 
        [Name("Consum domèstic per càpita")]
        public double DomesticConsumptionPerCapita { get; set; } 
    }
}
