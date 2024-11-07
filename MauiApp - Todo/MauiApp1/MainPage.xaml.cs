using MauiApp1.ViewModel;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	MainPageViewmodel vm = new();

	public MainPage()
	{
		InitializeComponent();

		BindingContext = vm;

	}
}

