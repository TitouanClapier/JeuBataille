using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Carte
{

        public string Signe { get; }
        public int Valeur { get; }

        public Carte(string signe, int valeur)
        {
            Signe = signe;
            Valeur = valeur;
        }

}

