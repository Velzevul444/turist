using System.Collections.Generic;
using Avalonia.Media;

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

    public IBrush AccentBrush { get; }

    public IBrush SoftBrush { get; }

    public IReadOnlyList<string> Highlights { get; }
}
