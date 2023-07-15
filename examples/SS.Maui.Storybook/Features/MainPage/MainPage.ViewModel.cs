using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SS.Maui.Storybook.Features;

public class MainPageViewModel : INotifyPropertyChanged
{

  public MainPageViewModel()
  {
    this.RatingChangedCommand = new Command(async () =>
    {
        var message = $"Rating updated to {this.CurrentRating}";
        Debug.WriteLine(message);
        await Application.Current.MainPage.DisplayAlert("Rating", message, "OK");
    });
  }

  private int currentRating;
  public int CurrentRating
  {
    get { return currentRating; }
    set
    {
      currentRating = value;
      OnPropertyChanged();
    }
  }

  public Command RatingChangedCommand { get; set; }

  public event PropertyChangedEventHandler PropertyChanged;

  private void OnPropertyChanged([CallerMemberName] string propertyName = null)

  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}