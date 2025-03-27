using EcoEnergySolutionsEF.Classes;
using EcoEnergySolutionsEF.Classes.Simulacio;
using EcoEnergySolutionsEF.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EcoEnergySolutionsEF.Pages
{
    public class DeletePageModel : PageModel
    {
        private readonly AppDbContext _context;
        public DeletePageModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string SelectedCategory { get; set; } // Holds the selected dropdown value

        [BindProperty]
        [Required(ErrorMessage = "Please enter a number.")]
        [Range(0, int.MaxValue, ErrorMessage = "Only positive numbers are allowed.")]
        public int InputNumber { get; set; }
        public IActionResult OnPost()
        {
            switch (SelectedCategory)
            {
                case "Simulacions":
                    Simulacio simulacioFind = _context.Simulacio.Find(InputNumber);
                    _context.Simulacio.Remove(simulacioFind);
                    _context.SaveChanges();
                    break;
                case "Consums d'aigua":
                    WaterConsumption WaterConsumptionFind = _context.WaterConsumption.Find(InputNumber);
                    _context.WaterConsumption.Remove(WaterConsumptionFind);
                    _context.SaveChanges();
                    break;
                case "Indicadors energetics":
                    EnergyIndicator EnergyIndicatorFind = _context.EnergyIndicator.Find(InputNumber);
                    _context.EnergyIndicator.Remove(EnergyIndicatorFind);
                    _context.SaveChanges();
                    break;
            }
            return RedirectToPage("Index");
        }
    }
}
