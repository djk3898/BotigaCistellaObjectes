using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotigaCistella
{
    internal class Producte
    {
        //Atributs
        private string nom;
        private double preuSenseIva;
        private int iva;
        private int quantitat;
        //Propietats
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public double PreuSenseIva
        {
            get { return preuSenseIva; }
            set { if (value > 0) preuSenseIva = value; }
        }
        public int Iva
        {
            get { return iva; }
            set { if (value > 0) iva = value; }
        }
        public int Quantitat
        {
            get { return quantitat; }
            set { if(value > 0) quantitat = value; }
        }
        //Constructors

        //Metodes

    }
}
