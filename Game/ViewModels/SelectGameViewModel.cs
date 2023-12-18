using Game.Views;
using System.Windows.Input;
using NavigationService = Game.Services.NavigationService;

namespace Game.ViewModels;

public class SelectGameViewModel
{
	public ICommand SwitchToLeaderboardCommand { get; private set; }
	public ICommand GoBackCommand { get; private set; }

	public SelectGameViewModel()
	{
		SwitchToLeaderboardCommand = new RelayCommand(SwitchToLeaderboard);
		GoBackCommand = new RelayCommand(GoBack);
	}

	private void SwitchToLeaderboard()
	{
		NavigationService.GetInstance().NavigateToPage<LeaderboardView>();
	}

	private void GoBack()
	{
		NavigationService.GetInstance().GoBack();
	}
}
