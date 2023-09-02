using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SS.Maui.Controls;

namespace SS.Maui.Storybook.Features;

public class MainPageViewModel : INotifyPropertyChanged
{

  public MainPageViewModel()
  {
    this.RatingChangedCommand = new Command(async (object rating) =>
    {
      if (rating is not Rating)
        await Application.Current.MainPage.DisplayAlert("Rating", "rating isn't of Rating type", "OK");
      else
      {
        var message = $"Rating updated to {(rating as Rating).Value}";
        Debug.WriteLine(message);
        await Application.Current.MainPage.DisplayAlert("Rating", message, "OK");
      }
    });
  }

  public Command RatingChangedCommand { get; set; }

  public event PropertyChangedEventHandler PropertyChanged;

  private void onPropertyChanged([CallerMemberName] string propertyName = null)

  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}