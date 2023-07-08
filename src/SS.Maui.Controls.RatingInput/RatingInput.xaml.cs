namespace SS.Maui.Controls.RatingInput;

public partial class RatingInput : ContentView
{
    private readonly RatingInputViewModel vm = new RatingInputViewModel();

    public RatingInput()
    {
        InitializeComponent();
        BindingContext = vm;
    }

    public readonly BindableProperty CurrentRatingProperty =
        BindableProperty.Create(
            nameof(CurrentRating),
            typeof(int),
            typeof(RatingInput),
            0,
            propertyChanged: (b, _, value) =>
            {
                var vm = b.BindingContext as RatingInputViewModel;
                vm.CurrentRating = (int)value;
            });

    public int CurrentRating
    {
        get { return (int)(GetValue(CurrentRatingProperty)); }
        set { SetValue(CurrentRatingProperty, value); }
    }
}
