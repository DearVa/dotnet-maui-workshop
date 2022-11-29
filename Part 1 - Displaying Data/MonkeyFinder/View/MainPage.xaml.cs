namespace MonkeyFinder.View;

public partial class MainPage {
	public MainPage(MonkeysViewModel monkeysViewModel) {
		InitializeComponent();

		BindingContext = monkeysViewModel;
	}
}

