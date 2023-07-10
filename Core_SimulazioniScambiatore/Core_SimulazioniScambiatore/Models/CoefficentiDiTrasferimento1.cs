using System;
using System.Collections.Generic;

namespace Core_SimulazioniScambiatore.Models
{
    public partial class CoefficentiDiTrasferimento1
    {
        public int IdCalcoli { get; set; }
        public int IdFlusso { get; set; }
        public double AreaDiPassaggio { get; set; }
        public double PortataVolumetrica { get; set; }
        public double VelocitàDiPassaggio { get; set; }
        public double DiametroInterno { get; set; }
        public double NumeroDiReynolds { get; set; }
        public double NumeroDiPrandtl { get; set; }
        public double CoefficenteDiPellicola { get; set; }

        public virtual Flusso IdFlussoNavigation { get; set; } = null!;
    }
}
