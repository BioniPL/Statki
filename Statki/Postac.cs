using System;
using System.Threading;

namespace Statki;
public abstract class Postac
{
    public string Nazwa { get; set; }
    public int HP { get; set; }
    public int Max_HP { get; set; }
    public int Atak { get; set; }
    public int Obrona { get; set; }
    
    public int Szczescie { get; set; }

    private int ObliczObrazenia(int atak, double moc, int obrona)
    {
        int szansa = Random.Shared.Next(101);
        if (moc == 1 && szansa > (80 - Szczescie))
        {
            Console.WriteLine("Pudło!");
        }
        else if (moc == 2 && szansa > (50 - Szczescie))
        {
            Console.WriteLine("Pudło!");
        }
        else if (moc == 3 && szansa > (20 - Szczescie))
        {
            Console.WriteLine("Pudło!");
        }
        else
        {
            int x = (int)(atak * moc - obrona);
            if (x <= 0)
            {
                Console.WriteLine("O nie! nie jesteśmy w stanie przebić sie tym atakiem przez pancerz przeciwnika!");
                return 0;
            }
            Console.WriteLine("Zadano " + x + " obrazen");
            return x;
        }
        return 0;
    }

    public virtual void Atak_Lekki(Postac cel)
    {
        cel.HP = cel.HP - ObliczObrazenia(Atak, 1, cel.Obrona);
    }
    public virtual void Atak_Sredni(Postac cel)
    {
        cel.HP = cel.HP - ObliczObrazenia(Atak, 2, cel.Obrona);
    }
    public virtual void Atak_Mocny(Postac cel)
    {
        cel.HP = cel.HP - ObliczObrazenia(Atak, 3, cel.Obrona);
    }

    public void Statystki(Postac gracz, Postac przeciwnik)
    {
        string p0 = "======="+ gracz.Nazwa +"=======";
        Console.Write(p0);
        for (int i = 0; i < 50 - p0.Length; i++)
        {
            Console.Write(" ");
        }
        Console.WriteLine("=======WROG=======");
        
        
        string p1 = "Zdrowie: " + gracz.HP + "/" + gracz.Max_HP;
        Console.Write(p1);
        for (int i = 0; i < 50 - p1.Length; i++)
        {
            Console.Write(" ");
        }
        string b1 = "Zdrowie: " + przeciwnik.HP + "/" + przeciwnik.Max_HP;
        Console.WriteLine(b1);
        ////////////////////
        
        string p2 = "Atak: " + gracz.Atak + " Obrona: " + gracz.Obrona + " Szczescie: " + gracz.Szczescie;
        Console.Write(p2);
        for (int i = 0; i < 50 - p2.Length; i++)
        {
            Console.Write(" ");
        }
        string b2 = "Atak: " + przeciwnik.Atak + " Obrona: " + przeciwnik.Obrona + " Szczescie: " + przeciwnik.Szczescie;
        Console.WriteLine(b2);
    }

    public void Statystyki_Atakow(Postac gracz, Postac przeciwnik)
    {
        Console.WriteLine();
        Console.WriteLine("Aby zadać cios lekki: 1 - " + (int)(80+gracz.Szczescie) + "% - " + (int)(gracz.Atak * 1 - przeciwnik.Obrona) + " Obrażeń");
        Console.WriteLine("Aby zadać cios średni: 2 - " + (int)(50+gracz.Szczescie) + "% - " + (int)(gracz.Atak * 2 - przeciwnik.Obrona) + " Obrażeń");
        Console.WriteLine("Aby zadać cios silny: 3 - " + (int)(20+gracz.Szczescie) + "% - " + (int)(gracz.Atak * 3 - przeciwnik.Obrona) + " Obrażeń");
    }

    public void Wykonaj_Atak_Bot(Gracz gracz)
    {
        int wybor_bot = Random.Shared.Next(1,4);
        if (wybor_bot == 1)
        {
            Atak_Lekki(gracz);
        }
        else if (wybor_bot == 2)
        {
            Atak_Sredni(gracz);
        }
        else if (wybor_bot == 3)
        {
            Atak_Mocny(gracz);
        }
    }

}