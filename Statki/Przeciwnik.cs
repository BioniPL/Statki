using System;

namespace Statki;

public class Przeciwnik : Postac
{
    public int Poziom { get; set; }

    public Przeciwnik(string nazwa, int poziom)
    {
        Poziom = poziom;
        Nazwa = nazwa;
        HP = 50 + new Random().Next(Poziom+1);
        Max_HP = HP;
        Atak = 5 + new Random().Next(Poziom+1);
        Obrona = 2 + new Random().Next(Poziom+1);
    }
}