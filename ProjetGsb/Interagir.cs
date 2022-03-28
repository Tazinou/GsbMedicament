using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetGsb
{
    public class Interagir
    {
        private Medicament etrePerturbateur;
        private Medicament etrePerturbe;

        public Interagir(Medicament unPerturbateur, Medicament unPerturbe)
        {
            EtrePerturbateur = unPerturbateur;
            EtrePerturbe = unPerturbe;
        }

        public Medicament EtrePerturbateur { get => etrePerturbateur; set => etrePerturbateur = value; }
        public Medicament EtrePerturbe { get => etrePerturbe; set => etrePerturbe = value; }
    }
}
