using System;
using System.Collections.Generic;

namespace Core_SimulazioniScambiatore.Models
{
    public partial class Scambiatore1
    {
        public Scambiatore1()
        {
            Flussos = new HashSet<Flusso>();
        }

        public int IdScambiatore { get; set; }
        public string Nome { get; set; } = null!;
        public double Lunghezza { get; set; }
        public double Superficie { get; set; }
        public double DiametroInterno { get; set; }
        public double DiametroEsterno { get; set; }
        public double RaggioInterno { get; set; }
        public double RaggioEsterno { get; set; }
        public double RaggioMedioInterno { get; set; }
        public double RaggioMedioEsterno { get; set; }
        public double SuperficeDiScambio { get; set; }

        public virtual ICollection<Flusso> Flussos { get; set; }
    }
}
