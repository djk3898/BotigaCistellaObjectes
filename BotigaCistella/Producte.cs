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
        private double iva;
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
        public double Iva
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
        public Producte()
        {
            iva = 1.21;
            quantitat = 0;
        }
        public Producte(string nom, int preu) : this()
        {
            this.nom = nom;
            preuSenseIva = preu;
        }
        public Producte(string nom, int preu, int iva, int quantitat)
        {
            this.nom = nom;
            preuSenseIva = preu;
            this.iva = iva;
            this.quantitat = quantitat;
        }
        //Metodes
        public double Preu()
        {
            return (preuSenseIva * iva) * quantitat;
        }
        public string ToString()
        {
            return $"Nom: {nom}\nPreu: {Preu()}";
        }
    }
}
