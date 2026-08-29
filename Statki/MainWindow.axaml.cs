using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Platform;
using Avalonia.Media.Imaging;

namespace Statki;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void Sterowanie_Ludkiem(object? sender, KeyEventArgs klawisz)
    {
        double wartosc_gora = Canvas.GetTop(ZiomekSouth);
        double wartosc_lewa = Canvas.GetLeft(ZiomekSouth);
        
        if (klawisz.Key == Key.W)
        {
            wartosc_gora=wartosc_gora-3;
            Canvas.SetTop(ZiomekSouth, wartosc_gora);
            ZiomekSouth.Source = new Bitmap(AssetLoader.Open(new Uri("avares://Statki/Assets/north.png")));
        }
        if (klawisz.Key == Key.A)
        {
            wartosc_lewa=wartosc_lewa-3;
            Canvas.SetLeft(ZiomekSouth, wartosc_lewa);
            ZiomekSouth.Source = new Bitmap(AssetLoader.Open(new Uri("avares://Statki/Assets/west.png")));
        }
        if (klawisz.Key == Key.S)
        {
            wartosc_gora=wartosc_gora+3;
            Canvas.SetTop(ZiomekSouth, wartosc_gora);
            ZiomekSouth.Source = new Bitmap(AssetLoader.Open(new Uri("avares://Statki/Assets/south.png")));
        }
        if (klawisz.Key == Key.D)
        {
            wartosc_lewa=wartosc_lewa+3;
            Canvas.SetLeft(ZiomekSouth, wartosc_lewa);
            ZiomekSouth.Source = new Bitmap(AssetLoader.Open(new Uri("avares://Statki/Assets/east.png")));
        }
        Console.Clear();
        Console.WriteLine(wartosc_gora);
        Console.WriteLine(wartosc_lewa);
    }
}