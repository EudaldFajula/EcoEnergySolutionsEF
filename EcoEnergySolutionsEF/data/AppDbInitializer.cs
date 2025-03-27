using CsvHelper;
using CsvHelper.Configuration;
using EcoEnergySolutionsEF.Classes;
using System.Formats.Asn1;
using System.Globalization;

namespace EcoEnergySolutionsEF.data
{
    public class AppDbInitializer
    {
        private readonly AppDbContext _context;

        public AppDbInitializer(AppDbContext context) 
        { 
            _context = context; 
        }
        public void Seed()
        {
            if (!_context.WaterConsumption.Any())
            {
                var consums = CsvReader<WaterConsumption>(Path.GetFullPath("./wwwroot/Files/InfoFiles/consum_aigua_cat_per_comarques.csv"));
                _context.WaterConsumption.AddRange(consums);
            }

            if (!_context.EnergyIndicator.Any())
            {
                var indicadors = CsvReader<EnergyIndicator>(Path.GetFullPath("./wwwroot/Files/InfoFiles/indicadors_energetics_cat.csv"));
                _context.EnergyIndicator.AddRange(indicadors);
            }

            _context.SaveChanges();
        }

        private static List<T> CsvReader<T>(string path)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
                HeaderValidated = null
            };

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<T>().ToList();
            }
        }
    }
}
