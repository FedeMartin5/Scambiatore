using System;
using System.Collections.Generic;

namespace Core_SimulazioniScambiatore.Models
{
    public partial class Flusso
    {
        public Flusso()
        {
            CoefficentiDiTrasferimento1s = new HashSet<CoefficentiDiTrasferimento1>();
            CoefficentiDiTrasferimentos = new HashSet<CoefficentiDiTrasferimento>();
            CoefficentiGlobalis = new HashSet<CoefficentiGlobali>();
        }

        public int IdFlusso { get; set; }
        public int IdScambiatore { get; set; }
        public int IdFluido { get; set; }
        public string Tipo { get; set; } = null!;
        public double Portata { get; set; }
        public double TemperaturaIniziale { get; set; }

        public virtual Fluido1 IdFluido1 { get; set; } = null!;
        public virtual Fluido IdFluidoNavigation { get; set; } = null!;
        public virtual Scambiatore1 IdScambiatore1 { get; set; } = null!;
        public virtual Scambiatore IdScambiatoreNavigation { get; set; } = null!;
        public virtual ICollection<CoefficentiDiTrasferimento1> CoefficentiDiTrasferimento1s { get; set; }
        public virtual ICollection<CoefficentiDiTrasferimento> CoefficentiDiTrasferimentos { get; set; }
        public virtual ICollection<CoefficentiGlobali> CoefficentiGlobalis { get; set; }
    }
}
