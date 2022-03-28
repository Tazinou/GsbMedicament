using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGsb
{
    public class TypeIndividu
    {
        private int codeTypeIndividu;
        private string libelleTypeIndividu;

        public TypeIndividu(int unCode, string unLibelle)
        {
            CodeTypeIndividu = unCode;
            LibelleTypeIndividu = unLibelle;
        }

        public int CodeTypeIndividu { get => codeTypeIndividu; set => codeTypeIndividu = value; }
        public string LibelleTypeIndividu { get => libelleTypeIndividu; set => libelleTypeIndividu = value; }
    }
}
