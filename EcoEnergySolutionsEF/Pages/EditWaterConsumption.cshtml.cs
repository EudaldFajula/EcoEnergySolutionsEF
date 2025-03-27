using EcoEnergySolutionsEF.Classes;
using EcoEnergySolutionsEF.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EcoEnergySolutionsEF.Pages
{
    public class EditWaterConsumptionModel : PageModel
    {
		private readonly AppDbContext _context;

		public EditWaterConsumptionModel(AppDbContext context)
		{
			_context = context;
		}
		[BindProperty]
		public WaterConsumption WaterConsumption { get; set; }
		public IActionResult OnGet(int id)
		{
			WaterConsumption = _context.WaterConsumption.FirstOrDefault(s => s.Id == id);
			if (WaterConsumption == null)
			{
				return NotFound();
			}
			return Page();
		}
		public IActionResult OnPost()
		{
			// Validar número no negativo
			if (WaterConsumption.Year < 0)
			{
				ModelState.AddModelError("WaterConsumption.DomesticConsumption", "El valor no puede ser negativo.");
			}
			if (WaterConsumption.Region.Length < 0)
			{
				ModelState.AddModelError("WaterConsumption.Region", "El valor no puede ser negativo.");
			}
			if (WaterConsumption.Population < 0)
			{
				ModelState.AddModelError("WaterConsumption.Population", "El valor no puede ser negativo.");
			}
			if (WaterConsumption.DomesticConsumption < 0)
			{
				ModelState.AddModelError("WaterConsumption.DomesticConsumption", "El valor no puede ser negativo.");
			}
			if (WaterConsumption.EconomicActivitiesConsumption < 0)
			{
				ModelState.AddModelError("WaterConsumption.EconomicActivitiesConsumption", "El valor no puede ser negativo.");
			}
			if (WaterConsumption.TotalConsumption < 0)
			{
				ModelState.AddModelError("WaterConsumption.TotalConsumption", "El valor no puede ser negativo.");
			}
			if (WaterConsumption.DomesticConsumptionPerCapita < 0)
			{
				ModelState.AddModelError("WaterConsumption.DomesticConsumptionPerCapita", "El valor no puede ser negativo.");
			}

			if (!ModelState.IsValid)
			{
				// Si las validaciones fallan, regresar a la página con los errores.
				return Page();
			}

			_context.Attach(WaterConsumption).State = EntityState.Modified;
			_context.SaveChanges();

			TempData["Message"] = "Consumicions d'aigua actualizada correctamente.";
			return RedirectToPage("ViewWaterConsumption");
		}
	}
}
