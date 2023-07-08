using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MvvmHelpers;

namespace SS.Maui.Controls.RatingInput
{
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

				currentRating = stars.Count;

				Stars.Clear();
				Stars.AddRange(starsList);

				OnPropertyChanged(nameof(Stars));
				OnPropertyChanged(nameof(CurrentRating));
			}
		}
	}
}
