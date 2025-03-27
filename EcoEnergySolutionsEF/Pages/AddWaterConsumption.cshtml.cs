using EcoEnergySolutionsEF.Classes;
using EcoEnergySolutionsEF.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Serialization;

namespace EcoEnergySolutionsEF.Pages
{
    public class AddWaterConsumptionModel : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public WaterConsumption Record { get; set; }
        public AddWaterConsumptionModel(AppDbContext context) 
        { 
            _context = context; 
        }
        public IActionResult OnPost()
        {
            _context.WaterConsumption.Add(Record);
            _context.SaveChanges();

            return RedirectToPage("ViewWaterConsumption");
        }
    }
}