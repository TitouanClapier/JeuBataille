class Program
{
    static void Main()
    {
        User joueur1 = new User("Noyon", "Patrick");
        User joueur2 = new User("Clapier", "Titouan");

        List<Carte> ListeCarte = new List<Carte>();
        Random random = new Random();

        for (int i = 0; i < 52; i++)
        {
            string[] signes = { "coeur", "carreau", "pique", "trefle" };
            int valeur = (i % 13) + 1;
            Carte carte = new Carte(signes[i / 13], valeur);
            ListeCarte.Add(carte);
        }

        ListeCarte = ListeCarte.OrderBy(x => random.Next()).ToList();

        for (int i = 0; i < ListeCarte.Count; i++)
        {
            if (i % 2 == 0)
            {
                joueur1.ListeCarte.Add(ListeCarte[i]);
            }
            else
            {
                joueur2.ListeCarte.Add(ListeCarte[i]);
            }
        }
        int nbrPartie = 1;
        int nbrEgaliter = 0;
        while (joueur1.ListeCarte.Count > 0 && joueur2.ListeCarte.Count > 0)
        {
            Carte CarteJ1 = joueur1.ListeCarte[0];
            Carte CarteJ2 = joueur2.ListeCarte[0];

            Console.WriteLine("--------------------------------------------------------------------" + Environment.NewLine + "Duel n" + nbrPartie + " :");
            nbrPartie = nbrPartie + 1;

            //Console.WriteLine(joueur1.Prenom + " joue " + CarteJ1.Valeur + " de " + CarteJ1.Signe);
            Console.WriteLine(joueur1.Prenom + "joue" + AfficherCarte(CarteJ1, joueur1));
            //Console.WriteLine(joueur2.Prenom + " joue " + CarteJ2.Valeur + " de " + CarteJ2.Signe);
            Console.WriteLine(joueur2.Prenom + "joue" + AfficherCarte(CarteJ2, joueur2));

            if (CarteJ1.Valeur > CarteJ2.Valeur)
            {
                joueur1.Victoires++;
                Console.WriteLine(AfficherCarte(CarteJ1, joueur1) + " vs " + AfficherCarte(CarteJ2, joueur2) + " manche gagner par " + joueur1.Prenom);
                joueur1.ListeCarte.Add(CarteJ2);
                joueur2.ListeCarte.RemoveAt(0);
                joueur1.ListeCarte.Add(CarteJ1);
                joueur1.ListeCarte.RemoveAt(0);
            }
            else if (CarteJ1.Valeur < CarteJ2.Valeur)
            {
                joueur2.Victoires++;
                Console.WriteLine(AfficherCarte(CarteJ1, joueur1) + " vs " + AfficherCarte(CarteJ2, joueur2) + " manche gagner par " + joueur2.Prenom);
                joueur2.ListeCarte.Add(CarteJ1);
                joueur2.ListeCarte.Add(CarteJ2);
                joueur1.ListeCarte.RemoveAt(0);
                joueur2.ListeCarte.RemoveAt(0);
            }
            else
            {
                if (joueur1.ListeCarte.Count < 2 || joueur2.ListeCarte.Count < 2)
                {
                    Console.WriteLine("Pas assez de cartes du coup c est fini");
                    Console.WriteLine("--------------------------------------------------------------------" + Environment.NewLine + "Finito");

                    if (joueur1.Victoires > joueur2.Victoires)
                    {
                        Console.WriteLine(joueur1.Prenom + " gagne avec " + joueur1.Victoires + " victoires gg mec");
                    }
                    else if (joueur1.Victoires < joueur2.Victoires)
                    {
                        Console.WriteLine(joueur2.Prenom + " gagne avec " + joueur2.Victoires + " victoires gg mec");
                    }
                    else
                    {
                        Console.WriteLine("match nul rip");
                    }
                    Console.WriteLine(" Il y as eu : " + nbrEgaliter + " egaliter");
                    return;
                }
                else
                {
                Console.WriteLine("Bataille !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Bataille(joueur1, joueur2);
                nbrEgaliter = nbrEgaliter + 1;
                }


            }        
            Console.WriteLine("Cartes restantes de " + joueur1.Prenom + ": " + joueur1.ListeCarte.Count);
            Console.WriteLine("Cartes restantes de " + joueur2.Prenom + ": " + joueur2.ListeCarte.Count);
            
        }

        Console.WriteLine("--------------------------------------------------------------------" + Environment.NewLine + "Finito");

        if (joueur1.Victoires > joueur2.Victoires)
        {
            Console.WriteLine(joueur1.Prenom + " gagne avec " + joueur1.Victoires + " victoires gg mec");
        }
        else if (joueur1.Victoires < joueur2.Victoires)
        {
            Console.WriteLine(joueur2.Prenom + " gagne avec " + joueur2.Victoires + " victoires gg mec");
        }
        else
        {
            Console.WriteLine("match nul rip");
        }
        Console.WriteLine(" Il y as eu : " + nbrEgaliter + " batailles");


    }

    public static void Bataille(User joueur1, User joueur2)
    {
  
        if (joueur1.ListeCarte.Count <= 2 || joueur2.ListeCarte.Count <= 2)
        {
            Console.WriteLine("Pas assez de cartes du coup c est fini");
            return;
        }

        Carte carteBaseJ1 = joueur1.ListeCarte[0];
        Carte carteBaseJ2 = joueur2.ListeCarte[0];
        Carte carteCacheeJ1 = joueur1.ListeCarte[1];
        Carte carteCacheeJ2 = joueur2.ListeCarte[1];

        Console.WriteLine(joueur1.Prenom + " pose une carte face cacher");
        Console.WriteLine(joueur2.Prenom + " pose une carte face cacher");

        Carte CarteJ1 = joueur1.ListeCarte[2];
        Carte CarteJ2 = joueur2.ListeCarte[2];

        Console.WriteLine(joueur1.Prenom + " sort : " + AfficherCarte(CarteJ1, joueur1));
        Console.WriteLine(joueur2.Prenom + " sort " + AfficherCarte(CarteJ2, joueur2));

        joueur1.ListeCarte.RemoveRange(0, 3);
        joueur2.ListeCarte.RemoveRange(0, 3);


        if (CarteJ1.Valeur > CarteJ2.Valeur)
        {
            Console.WriteLine(joueur1.Prenom + " remporte la bataille et gagne les cartes de " + joueur2.Prenom);
            joueur1.ListeCarte.AddRange(new List<Carte> { carteBaseJ1, carteBaseJ2, carteCacheeJ1, carteCacheeJ2, CarteJ1, CarteJ2 });
        }
        else if (CarteJ1.Valeur < CarteJ2.Valeur)
        {
            Console.WriteLine(joueur2.Prenom + " remporte la bataille et gagne les cartes de " + joueur1.Prenom);
            joueur2.ListeCarte.AddRange(new List<Carte> { carteBaseJ1, carteBaseJ2, carteCacheeJ1, carteCacheeJ2, CarteJ1, CarteJ2 });
        }
        else
        {
            Console.WriteLine(joueur1.Prenom + " avais pour carte face cachee : " + AfficherCarte(carteCacheeJ1, joueur1));
            Console.WriteLine(joueur2.Prenom + " avais pour carte face cachee : " + AfficherCarte(carteCacheeJ2, joueur2));
            Console.WriteLine("Omg une super Bataille");
            Bataille(joueur1, joueur2);
        }
    }

    public static string AfficherCarte(Carte carte, User joueur)
    {
        string symboleValeur = carte.Valeur switch
        {
            10 => "Valet",
            11 => "Reine",
            12 => "Roi",
            13 => "As",
            _ => carte.Valeur.ToString()
        };

        return $" {symboleValeur} de {carte.Signe}";
    }
}