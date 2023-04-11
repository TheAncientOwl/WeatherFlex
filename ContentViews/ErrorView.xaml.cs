namespace WeatherFlex.ContentViews;

public partial class ErrorView : ContentView
{
	public string ErrorText { get; set; }
	public ErrorView(string text)
	{
		InitializeComponent();

		ErrorText = text;

		BindingContext = this;
	}
}