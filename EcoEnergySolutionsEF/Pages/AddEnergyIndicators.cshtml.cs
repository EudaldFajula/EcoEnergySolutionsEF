using EcoEnergySolutionsEF.Classes;
using EcoEnergySolutionsEF.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Text.Json;

namespace EcoEnergySolutionsEF.Pages
{
    public class AddEnergyIndicatorModel : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public EnergyIndicator Record { get; set; }
        public AddEnergyIndicatorModel(AppDbContext context) 
        { 
            _context = context; 
        }
        public IActionResult OnPost()
        {
            _context.EnergyIndicator.Add(Record);
            _context.SaveChanges();

            return RedirectToPage("ViewEnergyIndicators");
        }
    }

    
}