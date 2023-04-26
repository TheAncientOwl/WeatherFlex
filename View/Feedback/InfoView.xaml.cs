namespace WeatherFlex.View.Feedback;

public partial class InfoView : ContentView
{
	public string InfoText { get; set; }

	public InfoView(string text)
	{
		InitializeComponent();

		InfoText = text;

		BindingContext = this;
	}
}
