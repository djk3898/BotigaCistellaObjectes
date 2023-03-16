﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

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
                if (value.Length < productes.Length - nElements)
                {
                    int j = 0, afegit = 0;
                    for (int i = nElements; i < productes.Length && j < value.Length; i++)
                    {
                        if (value[j].Preu() < diners)
                        {
                            productes[i] = value[j];
                            quantitat[i] = 1;
                            afegit++;
                            diners -= value[j].Preu();
                        }
                        else i--;
                        j++;
                    }
                    nElements += afegit;
                    if (afegit < value.Length) Console.WriteLine("Alguns productes no s'han afegit a la cistella per falta de diners.");
                }
                else Console.WriteLine("Els productes no caben a la cistella.");
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
        public Cistella()
        {
            productes = new Producte[10];
            nElements = 0;
            diners = 0;
            botiga = null;
        }
        public Cistella(Botiga botiga, Producte[] productes, int[] quantitats, double diners)
        {
            //productes
            this.productes = new Producte[productes.Length];
            for (int i = 0; i < productes.Length; i++)
                this.productes[i] = productes[i];
            //quantitats
            this.quantitat = new int[quantitats.Length];
            for (int i = 0; i < quantitats.Length; i++)
                this.quantitat[i] = quantitats[i];
            
            nElements = productes.Length;
            //diners
            if(CostTotal() > diners) { }
            else
            {
                this.diners = diners;
            }
        }
        //Metodes
        private double CostTotal() 
        {
            double total = 0;
            for(int i = 0; i < nElements; i++)
            {
                total += productes[i].Preu() * quantitat[i];
            }
            return total;
        }
        
    }
}
