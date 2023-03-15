using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotigaCistella
{
    internal class Cistella
    {
        //Atributs
        private Botiga botiga;
        private DateTime data;
        private Producte[] productes;
        private int[] quantitat;
        private int nElements;
        private double diners;
        //Propietats
        public Producte[] Productes
        {
            get { return productes; }
            set 
            {
                
            }
        }
        public int NElements
        {
            get { return nElements; }
        }
        public double Diners
        {
            get { return diners - CostTotal(); }
            set { if(value > 0) diners += value; }
        }
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }
        public string DataString
        {
            get { return data.ToString(); }
            set { DateTime.TryParse(value, out data); }
        }
        //Constructors

        //Metodes
        public double CostTotal() { }
    }
}
