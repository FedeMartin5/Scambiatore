using System;
using System.Collections.Generic;

namespace Core_SimulazioniScambiatore.Models
{
    public partial class Fluido1
    {
        public Fluido1()
        {
            Flussos = new HashSet<Flusso>();
        }

        public int IdFluido { get; set; }
        public string Nome { get; set; } = null!;
        public double Densita { get; set; }
        public double CapacitàTermica { get; set; }
        public double Viscosita { get; set; }
        public double FattoreDiSporcamento { get; set; }
        public double CaloreSpecifico { get; set; }
        public double ConducibilitaTermica { get; set; }

        public virtual ICollection<Flusso> Flussos { get; set; }
    }
}
