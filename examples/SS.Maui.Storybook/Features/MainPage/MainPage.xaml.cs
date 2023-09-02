namespace SS.Maui.Storybook.Features;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		this.BindingContext = new MainPageViewModel();
	}
}

