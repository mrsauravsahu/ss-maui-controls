using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;

namespace SS.Maui.Controls;

public partial class RatingInputViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
{
private ObservableRangeCollection<Rating> stars;

public ObservableRangeCollection<Rating> Stars
{
  get
  {
    if (stars is not null) return stars;

    var starsList = Enumerable.Range(1, 5)
                .Select(p => new Rating
                {
                  Value = p,
                  IsRated = false
                });

    stars = new();
    stars.AddRange(starsList);

    return stars;
  }
}

private int currentRating = 0;
public int CurrentRating
{
  get => Stars.Count;
  set
  {
    if (value == currentRating) return;

    var starsList = Enumerable.Range(1, 5)
      .Select(p => new Rating
      {
        Value = p,
        IsRated = (p <= value)
      });

    currentRating = value;

    Stars.Clear();
    Stars.AddRange(starsList);

    OnPropertyChanged(nameof(Stars));
    OnPropertyChanged(nameof(CurrentRating));
  }
}

[ObservableProperty]
private ICommand ratingChangedCommandFunc;

[RelayCommand]
private void RatingChanged(Rating rating)
{
        this.CurrentRating = rating.Value;
        RatingChangedCommandFunc.Execute(rating.Value);
}
    
}