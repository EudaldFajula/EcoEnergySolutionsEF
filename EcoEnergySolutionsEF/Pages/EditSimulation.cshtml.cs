using EcoEnergySolutionsEF.Classes.Simulacio;
using EcoEnergySolutionsEF.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EcoEnergySolutionsEF.Pages
{
    public class EditSimulationModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditSimulationModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Simulacio Simulacio { get; set; }

        public List<SelectListItem> EnergyTypes { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Text = "Solar", Value = "Solar" },
            new SelectListItem { Text = "HidroElectrica", Value = "HidroElectrica" },
            new SelectListItem { Text = "Eolica", Value = "Eolica" }
        };

        public IActionResult OnGet(int id)
        {
            Simulacio = _context.Simulacio.FirstOrDefault(s => s.Id == id);
            if (Simulacio == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            // Validar número no negativo
            if (Simulacio.Parametre < 0)
            {
                ModelState.AddModelError("Simulacio.Parametre", "El valor no puede ser negativo.");
            }
            if (Simulacio.Cost < 0)
            {
                ModelState.AddModelError("Simulacio.Cost", "El valor no puede ser negativo.");
            }
            if(Simulacio.Preu < 0)
            {
                ModelState.AddModelError("Simulacio.Preu", "El valor no puede ser negativo.");
            }
            if(Simulacio.Rati < 0)
            {
                ModelState.AddModelError("Simulacio.Rati", "El valor no puede ser negativo.");
            }

            // Validar según el tipo de energía
            if (Simulacio.TipusEnergia == "Solar" && Simulacio.Parametre < 0)
            {
                ModelState.AddModelError("Simulacio.Parametre", "Para Solar, el parámetro debe ser mayor o igual a 0.");
            }
            else if (Simulacio.TipusEnergia == "HidroElectrica" && Simulacio.Parametre < 19)
            {
                ModelState.AddModelError("Simulacio.Parametre", "Para HidroElectrica, el parámetro debe ser mayor o igual a 19.");
            }
            else if (Simulacio.TipusEnergia == "Eolica" && Simulacio.Parametre < 4)
            {
                ModelState.AddModelError("Simulacio.Parametre", "Para Eolica, el parámetro debe ser mayor o igual a 4.");
            }
            

            if (!ModelState.IsValid)
            {
                // Si las validaciones fallan, regresar a la página con los errores.
                return Page();
            }

            _context.Attach(Simulacio).State = EntityState.Modified;
            _context.SaveChanges();

            TempData["Message"] = "Simulación actualizada correctamente.";
            return RedirectToPage("ViewSimulations");
        }

    }
}
