namespace Statki;

public class Gracz : Postac
{
    public int Monety { get; set; }

    public Gracz(string nazwa)
    {
        Monety = 0;
        Nazwa = nazwa;
        HP = 100;
        Max_HP = HP;
        Atak = 5;
        Szczescie = 0;
        Obrona = 2;
    }
}