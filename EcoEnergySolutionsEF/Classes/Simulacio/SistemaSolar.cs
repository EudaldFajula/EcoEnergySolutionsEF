﻿using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EcoEnergySolutionsEF
{
    public class SistemaSolar : SistemaEnergia
    {
        
        public double HoresDeSol { get; set; }
        public SistemaSolar(double horesDeSol, double rati, double cost, double preu)
        {
            HoresDeSol = horesDeSol;
			Cost = cost;
			Preu = preu;
			Data = DateTime.Now;
            TipusEnergia = TipusEnergiaEnum.Solar;
        }
        public SistemaSolar() 
        {
		}
    }
}