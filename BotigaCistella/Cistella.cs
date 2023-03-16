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
            get { return diners; }
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
        private Producte[] AmpliarCistella(int ampliacio)
        {
            Producte[] productesAmpliat = new Producte[productes.Length + ampliacio];
            for (int i = 0; i < productes.Length; i++)
                productesAmpliat[i] = productes[i];
            return productesAmpliat;
        }
        private int[] AmpliarQuantitat(int ampliacio)
        {
            int[] productesAmpliat = new int[quantitat.Length + ampliacio];
            for (int i = 0; i < quantitat.Length; i++)
                productesAmpliat[i] = quantitat[i];
            return productesAmpliat;
        }
        private string ToString()
        {
            string tiquet = "";
            tiquet += $"\n        {botiga}        \n\n";
            tiquet += $"{data}\n";
            tiquet += "--------------------------------";
            for(int i = 0; i < nElements; i++)
            {
                tiquet += $"{productes[i]} ({productes[i].Preu()})\t\t{productes[i].Preu() * quantitat[i]}\nx{quantitat[i]}";
                tiquet += "--------------------------------";
            }
            tiquet += $"TOTAL (IVA inclòs): {nElements}\t\t{CostTotal()}";
            tiquet += "\n\nGràcies per la seva compra!!";
            return tiquet;
        }
        private void OrdenarCistella()
        {
            bool ordenat = false;
            for(int volta = 0; volta < nElements - 1 && !ordenat; volta++)
            {
                ordenat = true;
                for(int i = 0; i < nElements - 1 - volta; i++)
                {
                    if (String.Compare(productes[i].Nom, productes[i + 1].Nom) < 0)
                    {
                        //reordena productes
                        Producte aux = productes[i];
                        productes[i] = productes[i + 1];
                        productes[i + 1] = aux;
                        //reordena quantitats
                        int auxQ = quantitat[i];
                        quantitat[i] = quantitat[i + 1];
                        quantitat[i + 1] = auxQ;

                        ordenat = false;
                    }
                }
            }
        }
        public void ComprarProducte(Producte compra, int quant)
        {
            char resposta;
            //comprova que producte existeix
            if (botiga.BuscarProducte(compra.Nom))
            {
                //comprova que hi ha espai a la cistella
                if (productes.Length > nElements)
                {
                    //comprova que tenim suficients diners
                    if (compra.Preu() * quant < diners)
                    {
                        //afegim producte
                        productes[nElements] = compra;
                        quantitat[nElements] = quant;
                        nElements++;
                        //restem diners
                        diners -= compra.Preu() * quant;
                    }
                    else
                    {
                        do
                        {
                            Console.WriteLine("Diners insuficients, vols ingresar? (s/n)");
                            resposta = Convert.ToChar(Console.ReadLine());
                        } while (resposta == 's' || resposta == 'n');
                        if (resposta == 's')
                        {
                            Console.Write("Indica els diners a ingressar: ");
                            diners = double.Parse(Console.ReadLine());
                        }
                    }
                }
                else
                {
                    do
                    {
                        Console.WriteLine("La cistella és plena, vols ampliar-la? (s/n)");
                        resposta = Convert.ToChar(Console.ReadLine());
                    } while (resposta == 's' || resposta == 'n');
                    if (resposta == 's')
                    {
                        productes = AmpliarCistella(1);
                        quantitat = AmpliarQuantitat(1);
                    }
                }
            }
            else Console.WriteLine("Aquest producte no està a la botiga.");
            data = DateTime.Now;
        }
        public void ComprarProducte(Producte[] compres, int[] quants)
        {
            char resposta = ' ';
            bool totsAfegits = true;
            //comprova espai a la cistella
            if (productes.Length - nElements > compres.Length)
            {
                //afegeix producte si existeix i tenim suficients diners
                for (int i = 0; i < compres.Length; i++)
                {
                    resposta = ' ';
                    //comprova que producte existeix
                    if (botiga.BuscarProducte(compres[i].Nom))
                    {
                        //comprova que tenim suficients diners
                        if (compres[i].Preu() * quants[i] < diners)
                        {
                            //afegim producte
                            productes[nElements] = compres[i];
                            quantitat[nElements] = quants[i];
                            nElements++;
                            //restem diners
                            diners -= compres[i].Preu() * quants[i];
                        }
                        else
                        {
                            do
                            {
                                Console.WriteLine("Diners insuficients, vols ingresar? (s/n)");
                                resposta = Convert.ToChar(Console.ReadLine());
                            } while (resposta == 's' || resposta == 'n');
                            if (resposta == 's')
                            {
                                Console.Write("Indica els diners a ingressar: ");
                                diners = double.Parse(Console.ReadLine());
                                i--;
                            }
                        }


                    }
                    else totsAfegits = false;
                }
            }
            else
            {
                do
                {
                    Console.WriteLine("La cistella és plena, vols ampliar-la? (s/n)");
                    resposta = Convert.ToChar(Console.ReadLine());
                } while (resposta == 's' || resposta == 'n');
                if (resposta == 's')
                {
                    Console.Write($"Falten {compres.Length - productes.Length - nElements} espais per completar aquesta compra.\nQuants espais vols afegir? ");
                    int ampliar = int.Parse(Console.ReadLine());
                    productes = AmpliarCistella(ampliar);
                    quantitat = AmpliarQuantitat(ampliar);
                }
            }
            if (!totsAfegits) Console.WriteLine("Algun dels productes indicats no es troba en aquesta botiga.");
            data = DateTime.Now;
        }
        public void Mostra()
        {
            OrdenarCistella();
            Console.WriteLine(ToString());
        }
    }
}
