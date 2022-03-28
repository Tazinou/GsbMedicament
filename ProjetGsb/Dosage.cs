using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*using GestionnaireBdd;
using GsbMedicament;*/

namespace ProjetGsb
{
    public class Dosage
    {

        private int codeDosage;
        private string quantiteDosage;
        private int uniteDosage;

        public Dosage(int unCode, string uneQuantite, int uneUnite)
        {
            CodeDosage = unCode;
            QuantiteDosage = uneQuantite;
            UniteDosage = uneUnite;
        }

        public int CodeDosage { get => codeDosage; set => codeDosage = value; }
        public string QuantiteDosage { get => quantiteDosage; set => quantiteDosage = value; }
        public int UniteDosage { get => uniteDosage; set => uniteDosage = value; }
    }
}
