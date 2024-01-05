using Game.Models;
using Game.Services;
using Game.Views;
using System.Windows.Input;

namespace Game.ViewModels;

public class SelectGameViewModel
{
    public ICommand NewGameCommand { get; set; }
    public ICommand OpenGameCommand { get; set; }
    public ICommand SwitchToLeaderboardCommand { get; private set; }
    public ICommand GoBackCommand { get; private set; }
    
    public User User { get; private set; }

    public SelectGameViewModel(User user)
    {
		SwitchToLeaderboardCommand = new RelayCommand(SwitchToLeaderboard);
		GoBackCommand = new RelayCommand(GoBack);
		NewGameCommand = new RelayCommand(NewGame);
		OpenGameCommand = new RelayCommand(OpenGame);
		User = user;
    }
    public SelectGameViewModel()
    {
        SwitchToLeaderboardCommand = new RelayCommand(SwitchToLeaderboard);
        GoBackCommand = new RelayCommand(GoBack);
        NewGameCommand = new RelayCommand(NewGame);
        OpenGameCommand = new RelayCommand(OpenGame);
    }

    public void SwitchToLeaderboard()
    {
        NavigationService.GetInstance().NavigateToPage<LeaderboardView>();
    }

    public void GoBack()
    {
        NavigationService.GetInstance().GoBack();
    }

    public void NewGame()
    {
        var viewModel = new GameViewModel(User);
        NavigationService.GetInstance().NavigateToPage<GameLoop>(viewModel);

        viewModel.GenerateGame(5, 5);
    }

    public void OpenGame()
    {
        var viewModel = new GameViewModel(User);
        NavigationService.GetInstance().NavigateToPage<GameLoop>(viewModel);

        viewModel.Load();
    }
}
