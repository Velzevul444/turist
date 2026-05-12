using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using AustraliaCities.Models;

namespace AustraliaCities.ViewModels;

public sealed class MainWindowViewModel : INotifyPropertyChanged
{
    private string _searchQuery = string.Empty;
    private City? _selectedCity;

    public MainWindowViewModel()
    {
        Cities = new ObservableCollection<City>
        {
            new(
                "Сидней",
                "Новый Южный Уэльс",
                "Гавань, пляжи и самый узнаваемый силуэт страны",
                "Сидней часто выбирают для первого знакомства с Австралией: здесь рядом деловой центр, океанские пляжи, паромы по заливу и архитектурные символы страны.",
                "крупнейший город Австралии",
                "сентябрь - ноябрь, март - май",
                "Сидней вырос на месте первой британской колонии в Австралии, основанной в 1788 году в бухте Порт-Джексон. Со временем портовый поселок стал главным торговым и финансовым центром страны, а в XX веке получил свои самые известные символы: Харбор-Бридж и Сиднейский оперный театр.",
                "avares://AustraliaCities/Assets/Coats/sydney-coat.png",
                "#0B72B9",
                "#E7F4FB",
                new[]
                {
                    "Сиднейский оперный театр",
                    "Харбор-Бридж",
                    "Бонди-Бич"
                }),
            new(
                "Мельбурн",
                "Виктория",
                "Кофейная культура, музеи, спорт и уличные переулки",
                "Мельбурн известен галереями, фестивалями, спокойными кварталами с кафе и насыщенной спортивной жизнью. Город хорош для долгих прогулок и культурной программы.",
                "крупный культурный центр",
                "март - май, сентябрь - ноябрь",
                "Мельбурн был основан в 1835 году на землях народа кулин. Быстрый рост начался во время золотой лихорадки Виктории в 1850-х годах: город разбогател, получил широкие улицы, университеты, театры и долгое время был одним из важнейших центров Австралии.",
                "avares://AustraliaCities/Assets/Coats/melbourne-coat.png",
                "#B53E4F",
                "#FBECEF",
                new[]
                {
                    "Федерашн-сквер",
                    "Королевские ботанические сады",
                    "Национальная галерея Виктории"
                }),
            new(
                "Брисбен",
                "Квинсленд",
                "Солнечный речной город с расслабленным ритмом",
                "Брисбен сочетает теплый климат, набережные реки, зеленые зоны и удобный доступ к побережью Квинсленда. Это мягкая точка входа в тропическую Австралию.",
                "один из самых быстрорастущих городов",
                "апрель - октябрь",
                "Брисбен начинался как удаленное поселение для заключенных в 1820-х годах. Позже, после открытия территории для свободных поселенцев, город стал административным центром Квинсленда и постепенно превратился в крупный речной мегаполис с современными деловыми районами.",
                "avares://AustraliaCities/Assets/Coats/brisbane-coat.jpeg",
                "#0D8B70",
                "#E7F8F3",
                new[]
                {
                    "South Bank Parklands",
                    "Story Bridge",
                    "Lone Pine Koala Sanctuary"
                }),
            new(
                "Перт",
                "Западная Австралия",
                "Индийский океан, просторные парки и закаты",
                "Перт стоит особняком на западном побережье: здесь широкие пляжи, спокойные районы у воды, большой Кингс-парк и поездки к острову Роттнест.",
                "главный город западного побережья",
                "сентябрь - ноябрь, март - май",
                "Перт был основан британскими поселенцами в 1829 году как центр колонии Суон-Ривер. Его развитие ускорили золотые открытия в Западной Австралии в конце XIX века, а в XX веке город стал важной базой для добывающей промышленности и торговли через Индийский океан.",
                "avares://AustraliaCities/Assets/Coats/perth-coat.jpeg",
                "#C47822",
                "#FFF3E4",
                new[]
                {
                    "Kings Park",
                    "Fremantle",
                    "Rottnest Island"
                })
        };

        FilteredCities = new ObservableCollection<City>(Cities);
        SelectedCity = FilteredCities[0];
    }

    public ObservableCollection<City> Cities { get; }

    public ObservableCollection<City> FilteredCities { get; }

    public string SearchQuery
    {
        get => _searchQuery;
        set
        {
            if (_searchQuery == value)
            {
                return;
            }

            _searchQuery = value;
            OnPropertyChanged();
            ApplySearch();
        }
    }

    public City? SelectedCity
    {
        get => _selectedCity;
        set
        {
            if (_selectedCity == value)
            {
                return;
            }

            _selectedCity = value;
            OnPropertyChanged();
        }
    }

    public string SearchSummary => $"Найдено: {FilteredCities.Count}";

    public bool HasNoResults => FilteredCities.Count == 0;

    public event PropertyChangedEventHandler? PropertyChanged;

    private void ApplySearch()
    {
        var query = SearchQuery.Trim();
        var filtered = Cities.Where(city => string.IsNullOrWhiteSpace(query) || Matches(city, query));

        FilteredCities.Clear();

        foreach (var city in filtered)
        {
            FilteredCities.Add(city);
        }

        if (SelectedCity is null || !FilteredCities.Contains(SelectedCity))
        {
            SelectedCity = FilteredCities.FirstOrDefault();
        }

        OnPropertyChanged(nameof(SearchSummary));
        OnPropertyChanged(nameof(HasNoResults));
    }

    private static bool Matches(City city, string query)
    {
        return Contains(city.Name, query)
            || Contains(city.State, query)
            || Contains(city.Tagline, query)
            || Contains(city.Description, query)
            || Contains(city.Population, query)
            || Contains(city.BestSeason, query)
            || Contains(city.History, query)
            || city.Highlights.Any(highlight => Contains(highlight, query));
    }

    private static bool Contains(string value, string query)
    {
        return value.Contains(query, StringComparison.CurrentCultureIgnoreCase);
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
