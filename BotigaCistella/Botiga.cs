using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotigaCistella
{
    internal class Botiga
    {
        //Atributs
        private string nomBotiga;
        private Producte[] productes;
        private int nElements;
        //Propietats
        public string NomBotiga
        {
            get { return nomBotiga; }
            set { nomBotiga = value; }
        }
        public Producte[] Productes
        {
            get { return productes; }
            set { productes = value; }
        }
        public int NElements
        {
            get { return nElements; }
            set { nElements = value; }
        }
        //Constructors

        //Metodes

    }
}
