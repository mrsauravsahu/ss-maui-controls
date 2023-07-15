using System.Windows.Input;

namespace SS.Maui.Controls;

public partial class RatingInput : ContentView
{
    private readonly RatingInputViewModel vm = new();

    public RatingInput()
    {
        InitializeComponent();
        BindingContext = vm;
    }

    public static readonly BindableProperty CurrentRatingProperty =
        BindableProperty.Create(
            nameof(CurrentRating),
            typeof(int),
            typeof(RatingInput),
            0,
            BindingMode.OneWay);

        public int CurrentRating {
            get => (int)GetValue(CurrentRatingProperty);
            set => SetValue(CurrentRatingProperty, value);
        }

    public static readonly BindableProperty RatingChangedCommandProperty =
        BindableProperty.Create(
            nameof(RatingChangedCommand),
            typeof(ICommand),
            typeof(RatingInput),
            null,
            BindingMode.TwoWay,
            propertyChanged: (b, _, value) =>
            {
                var vm = b.BindingContext as RatingInputViewModel;
                vm.RatingChangedCommandFunc = value as ICommand;
            });

    public ICommand RatingChangedCommand {
        get => (ICommand)GetValue(RatingChangedCommandProperty);
        set => SetValue(RatingChangedCommandProperty, value);
    }
}
