using System.Windows.Input;

namespace SS.Maui.Controls;

public partial class RatingInput : ContentView
{
    public RatingInputViewModel ViewModel { get; set; }

    public RatingInput()
    {
        InitializeComponent();
        this.ViewModel = new RatingInputViewModel();
    }

    public static readonly BindableProperty CurrentRatingProperty =
        BindableProperty.Create(
            "CurrentRating",
            typeof(int),
            typeof(RatingInput),
            0,
            propertyChanged: (BindableObject bindable, object oldValue, object newValue) =>
            {
                {
                    if (bindable is RatingInput ratingInput)
                    {
                        ratingInput.ViewModel.CurrentRating = (int)newValue;
                    }
                }
            });

    public static readonly BindableProperty RatingChangedCommandProperty =
        BindableProperty.Create(
            "RatingChangedCommand",
            typeof(ICommand),
            typeof(RatingInput),
            null,
            BindingMode.TwoWay,
            propertyChanged: (BindableObject bindable, object oldValue, object newValue) =>
            {
                {
                    if (bindable is RatingInput ratingInput)
                    {
                        Console.WriteLine($"assigning EXternalRatingChangeCommand {newValue}");
                        ratingInput.ViewModel.ExternalRatingChangedCommand = (ICommand)newValue;
                    }
                }
            });

}
