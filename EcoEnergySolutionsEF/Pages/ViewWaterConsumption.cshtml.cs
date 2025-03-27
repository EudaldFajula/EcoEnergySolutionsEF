using EcoEnergySolutionsEF.Classes;
using EcoEnergySolutionsEF.data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Serialization;

namespace EcoEnergySolutionsEF.Pages
{
    public class ViewWaterConsumptionModel : PageModel
    {
        private readonly AppDbContext _context;
        public List<WaterConsumption> records = new List<WaterConsumption>();
        public List<WaterConsumption> top10Regions = new List<WaterConsumption>();
        public Dictionary<string, double> averageConsumptionByRegion = new Dictionary<string, double>();
        public List<WaterConsumption> suspiciousConsumption = new List<WaterConsumption>();
        public List<string> increasingTrendRegions = new List<string>();
        public int mostRecentYear;
        public ViewWaterConsumptionModel(AppDbContext context) 
        { 
            _context = context;
        }

        public void OnGet()
        {
            records = _context.WaterConsumption.ToList();

            if (records.Any())
            {
                mostRecentYear = records.Max(r => r.Year);
                top10Regions = records
                    .Where(r => r.Year == mostRecentYear)
                    .OrderByDescending(r => r.TotalConsumption)
                    .Take(10)
                    .ToList();

                averageConsumptionByRegion = records
                    .GroupBy(r => r.Region)
                    .ToDictionary(g => g.Key, g => g.Average(r => r.TotalConsumption))
                    .OrderByDescending(kvp => kvp.Value)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                suspiciousConsumption = records
                    .Where(r => r.TotalConsumption > 999999) // Adjust threshold as needed
                    .ToList();

                increasingTrendRegions = records
                    .GroupBy(r => r.Region)
                    .Where(g => g.Count() >= 5)
                    .Select(g => new
                    {
                        Region = g.Key,
                        Trend = g.OrderBy(r => r.Year).Select(r => r.TotalConsumption).ToList()
                    })
                    .Where(g => g.Trend.Zip(g.Trend.Skip(1), (a, b) => b > a).All(x => x))
                    .Select(g => g.Region)
                    .ToList();
            }
        }
    }
}