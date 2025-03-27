using EcoEnergySolutionsEF.Classes.Simulacio;
using EcoEnergySolutionsEF.data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace EcoEnergySolutionsEF.Pages
{
    public class ViewSimulationsModel : PageModel
    {
        private readonly AppDbContext _context;
        public List<Simulacio> Simulacions { get; set; } = new List<Simulacio>();
        public ViewSimulationsModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Simulacions = _context.Simulacio.ToList();
        }
    }
}
