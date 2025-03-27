using EcoEnergySolutionsEF.Classes.Simulacio;
using EcoEnergySolutionsEF.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;

namespace EcoEnergySolutionsEF.Pages
{
    public class AddSimulationsModel : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public SistemaEnergia SistemaEnergia { get; set; }
        [BindProperty]
        public SistemaSolar SistemaSolar { get; set; }
        [BindProperty]
        public SistemaHidroelectric SistemaHidroelectric { get; set; }
        [BindProperty]
        public SistemaEolic SistemaEolic { get; set; }
        //Constuctor per injecció de dependències
        public AddSimulationsModel(AppDbContext context) 
        { 
            _context = context; 
        }
        public IActionResult OnPost()
        {
            Simulacio simulacio;
           
            switch (SistemaEnergia.TipusEnergia)
            {
                case TipusEnergiaEnum.Solar:
                    simulacio = new Simulacio { TipusEnergia = TipusEnergiaEnum.Solar.ToString(), Parametre = SistemaSolar.HoresDeSol, Rati = SistemaEnergia.Rati, Cost = SistemaEnergia.Cost, Preu = SistemaEnergia.Preu };
                    
                    break;
                case TipusEnergiaEnum.Eolica:
                    simulacio = new Simulacio { TipusEnergia = TipusEnergiaEnum.Eolica.ToString(), Parametre = SistemaEolic.VelocitatVent, Rati = SistemaEnergia.Rati, Cost = SistemaEnergia.Cost, Preu = SistemaEnergia.Preu };
                    break;
                case TipusEnergiaEnum.Hidroelectrica:
                    simulacio = new Simulacio { TipusEnergia = TipusEnergiaEnum.Hidroelectrica.ToString(), Parametre = SistemaHidroelectric.CabalAigua, Rati = SistemaEnergia.Rati, Cost = SistemaEnergia.Cost, Preu = SistemaEnergia.Preu };
                    break;
                default:
                    return Page();
            }
            _context.Simulacio.Add(simulacio);
            _context.SaveChanges();

            return RedirectToPage("ViewSimulations");
        }
    }
}