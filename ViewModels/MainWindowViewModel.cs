using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AustraliaCities.Models;

namespace AustraliaCities.ViewModels;

public sealed class MainWindowViewModel : INotifyPropertyChanged
{
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
                "#C47822",
                "#FFF3E4",
                new[]
                {
                    "Kings Park",
                    "Fremantle",
                    "Rottnest Island"
                })
        };

        SelectedCity = Cities[0];
    }

    public ObservableCollection<City> Cities { get; }

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

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
