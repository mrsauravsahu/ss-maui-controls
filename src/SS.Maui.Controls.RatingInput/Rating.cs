using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SS.Maui.Controls.RatingInput
{
	public partial class Rating : ObservableObject
	{
		[ObservableProperty]
		private int value;

		[ObservableProperty]
		private bool isRated;
	}
}

