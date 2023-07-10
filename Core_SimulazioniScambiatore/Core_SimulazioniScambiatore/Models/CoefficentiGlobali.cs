using System;
using System.Collections.Generic;

namespace Core_SimulazioniScambiatore.Models
{
    public partial class CoefficentiGlobali
    {
        public int Id { get; set; }
        public double TrasferimentoGlobale { get; set; }
        public double FattoreDiSporcamento { get; set; }
        public double SuperficieDiScambio { get; set; }
        public double NumeroDiHairpin { get; set; }
        public int IdFlusso { get; set; }

        public virtual Flusso IdFlussoNavigation { get; set; } = null!;
    }
}
