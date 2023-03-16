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
        public Botiga()
        {
            nomBotiga = String.Empty;
            productes = new Producte[10];
            nElements = 0;
        }
        public Botiga(string nom, int nProductes) : this()
        {
            nomBotiga = nom;
            productes = new Producte[nProductes];
        }
        public Botiga(string nom, Producte[] productes)
        {
            nomBotiga = nom;
            this.productes = new Producte[productes.Length];
            for(int i = 0; i < productes.Length; i++)
                this.productes[i] = productes[i];
            nElements = productes.Length;
        }
        //Metodes

    }
}
