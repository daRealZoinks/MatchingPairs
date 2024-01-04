using Game.Models;
using Game.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NavigationService = Game.Services.NavigationService;

namespace Game.ViewModels;


public class LeaderboardViewModel:ViewModelBase
{
	public ICommand GoBackCommand { get; private set; }
	private ObservableCollection<User> _users;
	public ObservableCollection<User> Users
	{
		get { return _users; }
		set
		{
			_users = value;
			OnPropertyChanged();
		}
	}

	public LeaderboardViewModel()
    {
		GoBackCommand = new RelayCommand(GoBack);
		SetLeaderboard();
	}

	private void GoBack()
	{
		NavigationService.GetInstance().GoBack();
	}

	private void SetLeaderboard()
	{
		var x = UserService.GetAllUsers(UserService.filePath);
		x = x.OrderByDescending(order => order.GamesWon).ThenBy(oreder => oreder.Username).ToList();
		_users = new(x);
	}
}


