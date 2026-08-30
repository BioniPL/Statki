using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Platform;
using Avalonia.Threading;
using Avalonia.Media.Imaging;

namespace Statki;

public partial class MainWindow : Window
{
    private int klatka_gracz = 1;
    private int klatka_bandayta = 1;
    private DispatcherTimer ruch_bandziora;

    public MainWindow()
    {
        InitializeComponent();
        
        ruch_bandziora = new DispatcherTimer();
        ruch_bandziora.Interval = TimeSpan.FromMilliseconds(300);
        ruch_bandziora.Tick += Animacja_Bandyty;
        ruch_bandziora.Start();
    }

    public void Animacja_Bandyty(object? sender, EventArgs e)
    {
        Bandyta.Source = new Bitmap(AssetLoader.Open(new Uri($"avares://Statki/Assets/bandyta/bandyta{klatka_bandayta}.png")));
        klatka_bandayta++;
        if(klatka_bandayta > 7)
        {
            klatka_bandayta = 0;
        }
        CzyKolizja();
    }

    public bool CzyKolizja()
    {
        double GraczTop = Canvas.GetTop(Gracz);
        double GraczLeft = Canvas.GetLeft(Gracz);
        double BandytaTop = Canvas.GetTop(Bandyta);
        double BandytaLeft = Canvas.GetLeft(Bandyta);
        
        bool kolizjaX = Math.Abs(GraczLeft - BandytaLeft) < 50;
        bool kolizjaY = Math.Abs(GraczTop - BandytaTop) < 50;

        if (kolizjaY && kolizjaX)
        {
            Console.WriteLine("NAPADŁ NA MNIE TEN BURAK");
            Walka_GUI.IsVisible = true;
            Mapa_Gry.IsVisible = false;
            return true;
        }
        Walka_GUI.IsVisible = false;
        Mapa_Gry.IsVisible = true;
        return false;
    }

    public void Ucieczka(object? sender, RoutedEventArgs e)
    {
        Random losowe = new Random();
        int cos = losowe.Next(4);
        if (cos == 1)
        {
            Canvas.SetTop(Gracz, Canvas.GetTop(Gracz)+100);
            Canvas.SetLeft(Gracz, Canvas.GetLeft(Gracz)+100);
        }
        else if (cos == 2)
        {
            Canvas.SetTop(Gracz, Canvas.GetTop(Gracz)-100);
            Canvas.SetLeft(Gracz, Canvas.GetLeft(Gracz)+100);
        }
        else if (cos == 3)
        {
            Canvas.SetTop(Gracz, Canvas.GetTop(Gracz)+100);
            Canvas.SetLeft(Gracz, Canvas.GetLeft(Gracz)-100);
        }
        else
        {
            Canvas.SetTop(Gracz, Canvas.GetTop(Gracz)-100);
            Canvas.SetLeft(Gracz, Canvas.GetLeft(Gracz)-100);
        }
    }

    public void Zatrzymanie_Gracza(object? sender, KeyEventArgs klawisz)
    {
        if (klawisz.Key == Key.W)
        {
            Gracz.Source = new Bitmap(AssetLoader.Open(new Uri("avares://Statki/Assets/north0.png")));
        }
        if (klawisz.Key == Key.A)
        {
            Gracz.Source = new Bitmap(AssetLoader.Open(new Uri("avares://Statki/Assets/west0.png")));
        }
        if (klawisz.Key == Key.S)
        {
            Gracz.Source = new Bitmap(AssetLoader.Open(new Uri("avares://Statki/Assets/south0.png")));
        }
        if (klawisz.Key == Key.D)
        {
            Gracz.Source = new Bitmap(AssetLoader.Open(new Uri("avares://Statki/Assets/east0.png")));
        }
    }
    
    public void Sterowanie_Gracza(object? sender, KeyEventArgs klawisz)
    {
        if (Walka_GUI.IsVisible)
        {
            return;
        }
        double wartosc_gora = Canvas.GetTop(Gracz);
        double wartosc_lewa = Canvas.GetLeft(Gracz);
        
        if (klawisz.Key == Key.W)
        {
            wartosc_gora=wartosc_gora-3;
            Canvas.SetTop(Gracz, wartosc_gora);
            Gracz.Source = new Bitmap(AssetLoader.Open(new Uri($"avares://Statki/Assets/north{klatka_gracz}.png")));
            klatka_gracz++;
            if(klatka_gracz > 6)
            {
                klatka_gracz = 1;
            }
        }
        if (klawisz.Key == Key.A)
        {
            wartosc_lewa=wartosc_lewa-3;
            Canvas.SetLeft(Gracz, wartosc_lewa);
            Gracz.Source = new Bitmap(AssetLoader.Open(new Uri($"avares://Statki/Assets/west{klatka_gracz}.png")));
            klatka_gracz++;
            if(klatka_gracz > 6)
            {
                klatka_gracz = 1;
            }
        }
        if (klawisz.Key == Key.S)
        {
            wartosc_gora=wartosc_gora+3;
            Canvas.SetTop(Gracz, wartosc_gora);
            Gracz.Source = new Bitmap(AssetLoader.Open(new Uri($"avares://Statki/Assets/south{klatka_gracz}.png")));
            klatka_gracz++;
            if(klatka_gracz > 6)
            {
                klatka_gracz = 1;
            }
        }
        if (klawisz.Key == Key.D)
        {
            wartosc_lewa=wartosc_lewa+3;
            Canvas.SetLeft(Gracz, wartosc_lewa);
            Gracz.Source = new Bitmap(AssetLoader.Open(new Uri($"avares://Statki/Assets/east{klatka_gracz}.png")));
            klatka_gracz++;
            if(klatka_gracz > 6)
            {
                klatka_gracz = 1;
            }        
        }
        //Console.Clear();
        Console.WriteLine(wartosc_gora);
        Console.WriteLine(wartosc_lewa);
    }
}