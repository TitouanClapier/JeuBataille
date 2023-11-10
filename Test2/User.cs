public class User
{
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public int Victoires { get; set; }
    public List<Carte> ListeCarte { get; set; }

    public User(string nom, string prenom)
    {
        Nom = nom;
        Prenom = prenom;
        Victoires = 0;
        ListeCarte = new List<Carte>();
    }

    public void AfficherInformations()
    {
        Console.WriteLine("Nom : " + Nom);
        Console.WriteLine("Prénom : " + Prenom);
    }
}