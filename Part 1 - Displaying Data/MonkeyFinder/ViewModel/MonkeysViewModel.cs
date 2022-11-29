using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel {
	public ObservableCollection<Monkey> Monkeys { get; } = new();

	private readonly MonkeyService monkeyService;

	public MonkeysViewModel(MonkeyService monkeyService) {
		this.monkeyService = monkeyService;
	}
	
	private async void GetMonkeys() {

	}
	
	
	private async void FindClosest() {
		
	}
}
