using EcoEnergySolutionsEF.Classes;
using EcoEnergySolutionsEF.data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace EcoEnergySolutionsEF.Pages
{
    public class ViewEnergyIndicatorModel : PageModel
    {
        private readonly AppDbContext _context;

        public List<EnergyIndicator> records { get; set; } = new List<EnergyIndicator>();
        public List<EnergyIndicator> highNetProduction { get; set; }
        public List<EnergyIndicator> highAutoGasConsumption { get; set; }
        public Dictionary<string, double> averageNetProductionByYear { get; set; }
        public List<EnergyIndicator> highDemandLowProduction { get; set; }
        public ViewEnergyIndicatorModel(AppDbContext context) 
        { 
            _context = context; 
        }
        public void OnGet()
        {
            records = _context.EnergyIndicator.ToList();

            
            if (records != null && records.Any())
            {
                highNetProduction = records
                    .Where(r => r.CDEEBC_NetProduction > 3000)
                    .OrderBy(r => r.CDEEBC_NetProduction)
                    .ToList();

                highAutoGasConsumption = records
                    .Where(r => r.CCAC_AutoGas > 100)
                    .OrderByDescending(r => r.CCAC_AutoGas)
                    .ToList();
                
                averageNetProductionByYear = records
                    .GroupBy(r => r.Date.Substring(3)) 
                    .ToDictionary(g => g.Key, g => g.Average(r => r.CDEEBC_NetProduction))
                    .OrderBy(kvp => kvp.Key)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                highDemandLowProduction = records
                    .Where(r => r.CDEEBC_ElectricDemand > 4000 && r.CDEEBC_DispProd < 300)
                    .ToList();
            }
        }
    }
}
