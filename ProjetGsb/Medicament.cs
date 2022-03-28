using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGsb
{
    public class Medicament
    {
        private int depotMedicament;
        private string nomMedicament;
        private Famille codeFamille;
        private double prixChantillon;
        private string compoMedicament;
        private string contreIndicMedicament;
        private string effetsMedicament;

        public Medicament(int unDepot, string unNom, Famille unCode, double unPrix, string uneCompo, string uneContreIndic, string desEffets)
        {
            DepotMedicament = unDepot;
            NomMedicament = unNom;
            CodeFamille = unCode;
            PrixChantillon = unPrix;
            CompoMedicament = uneCompo;
            ContreIndicMedicament = uneContreIndic;
            EffetsMedicament = desEffets;
        }

        public int DepotMedicament { get => depotMedicament; set => depotMedicament = value; }
        public string NomMedicament { get => nomMedicament; set => nomMedicament = value; }
        public double PrixChantillon { get => prixChantillon; set => prixChantillon = value; }
        public string CompoMedicament { get => compoMedicament; set => compoMedicament = value; }
        public string ContreIndicMedicament { get => contreIndicMedicament; set => contreIndicMedicament = value; }
        public string EffetsMedicament { get => effetsMedicament; set => effetsMedicament = value; }
        public Famille CodeFamille { get => codeFamille; set => codeFamille = value; }
    }
}
