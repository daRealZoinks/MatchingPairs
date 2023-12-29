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

    public SelectGameViewModel()
    {
        SwitchToLeaderboardCommand = new RelayCommand(SwitchToLeaderboard);
        GoBackCommand = new RelayCommand(GoBack);
        NewGameCommand = new RelayCommand(NewGame);
        OpenGameCommand = new RelayCommand(OpenGame);
    }

    private void SwitchToLeaderboard()
    {
        NavigationService.GetInstance().NavigateToPage<LeaderboardView>();
    }

    private void GoBack()
    {
        NavigationService.GetInstance().GoBack();
    }

    private void NewGame()
    {
        var viewModel = new GameViewModel();
        NavigationService.GetInstance().NavigateToPage<GameLoop>(viewModel);

        viewModel.GenerateGame(5, 5);
    }

    private void OpenGame()
    {
        var viewModel = new GameViewModel();
        NavigationService.GetInstance().NavigateToPage<GameLoop>(viewModel);

        viewModel.Load();
    }
}
