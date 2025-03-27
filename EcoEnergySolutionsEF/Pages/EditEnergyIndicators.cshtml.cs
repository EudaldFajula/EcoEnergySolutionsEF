using EcoEnergySolutionsEF.Classes;
using EcoEnergySolutionsEF.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EcoEnergySolutionsEF.Pages
{
    public class EditEnergyIndicatorsModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditEnergyIndicatorsModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public EnergyIndicator EnergyIndicator { get; set; }
        public IActionResult OnGet(int id)
        {
            EnergyIndicator = _context.EnergyIndicator.FirstOrDefault(s => s.Id == id);
            if (EnergyIndicator == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            // Validar número no negativo
            if (EnergyIndicator.Date.Length < 0)
            {
                ModelState.AddModelError("EnergyIndicator.Date", "El valor no puede ser negativo.");
            }
            if (EnergyIndicator.CDEEBC_NetProduction < 0)
            {
                ModelState.AddModelError("EnergyIndicator.CDEEBC_NetProduction ", "El valor no puede ser negativo.");
            }
            if (EnergyIndicator.CCAC_AutoGas < 0)
            {
                ModelState.AddModelError("EnergyIndicator.CCAC_AutoGas", "El valor no puede ser negativo.");
            }
            if (EnergyIndicator.CDEEBC_ElectricDemand < 0)
            {
                ModelState.AddModelError("EnergyIndicator.CDEEBC_ElectricDemand", "El valor no puede ser negativo.");
            }
            if (EnergyIndicator.CDEEBC_DispProd < 0)
            {
                ModelState.AddModelError("EnergyIndicator.CDEEBC_DispProd", "El valor no puede ser negativo.");
            }

            if (!ModelState.IsValid)
            {
                // Si las validaciones fallan, regresar a la página con los errores.
                return Page();
            }

            _context.Attach(EnergyIndicator).State = EntityState.Modified;
            _context.SaveChanges();

            TempData["Message"] = "Consumicions d'aigua actualizada correctamente.";
            return RedirectToPage("ViewEnergyIndicators");
        }
    }
}
