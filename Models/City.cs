using System;
using System.Collections.Generic;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace AustraliaCities.Models;

public sealed class City
{
    public City(
        string name,
        string state,
        string tagline,
        string description,
        string population,
        string bestSeason,
        string history,
        string coatOfArmsPath,
        string accentColor,
        string softColor,
        IReadOnlyList<string> highlights)
    {
        Name = name;
        State = state;
        Tagline = tagline;
        Description = description;
        Population = population;
        BestSeason = bestSeason;
        History = history;
        using var coatOfArmsStream = AssetLoader.Open(new Uri(coatOfArmsPath));
        CoatOfArms = new Bitmap(coatOfArmsStream);
        AccentBrush = SolidColorBrush.Parse(accentColor);
        SoftBrush = SolidColorBrush.Parse(softColor);
        Highlights = highlights;
    }

    public string Name { get; }

    public string State { get; }

    public string Tagline { get; }

    public string Description { get; }

    public string Population { get; }

    public string BestSeason { get; }

    public string History { get; }

    public Bitmap CoatOfArms { get; }

    public IBrush AccentBrush { get; }

    public IBrush SoftBrush { get; }

    public IReadOnlyList<string> Highlights { get; }
}
