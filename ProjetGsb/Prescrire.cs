using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGsb
{
    public class Prescrire
    {
        private Medicament depotMedicament;
        private TypeIndividu codeTypeIndividu;
        private Dosage codeDosage;

        public Prescrire(Medicament unDepot, TypeIndividu unCode, Dosage unDosage)
        {
            DepotMedicament = unDepot;
            CodeTypeIndividu = unCode;
            CodeDosage = unDosage;
        }

        public Medicament DepotMedicament { get => depotMedicament; set => depotMedicament = value; }
        public Dosage CodeDosage { get => codeDosage; set => codeDosage = value; }
        public TypeIndividu CodeTypeIndividu { get => codeTypeIndividu; set => codeTypeIndividu = value; }
    }
}
