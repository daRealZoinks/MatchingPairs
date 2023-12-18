﻿using Game.Models;
using Game.Views;
using System.Windows.Input;
using NavigationService = Game.Services.NavigationService;

namespace Game.ViewModels;

public class MainContentViewModel : ViewModelBase
{
	private User _user;
	public User User
	{
		get
		{ return _user; }

		set
		{
			_user = value;
			OnPropertyChanged();
		}
	}
	public ICommand SwitchToUserControl2Command { get; private set; }
	public ICommand PlayCommand { get; private set; }

	public MainContentViewModel(User user)
	{
		SwitchToUserControl2Command = new RelayCommand(SwitchToUserControl2);
		PlayCommand = new RelayCommand(Play);
		User = user;

	}

    public MainContentViewModel()
    {
        
    }
    private void SwitchToUserControl2()
	{
		NavigationService.GetInstance().NavigateToPage<ChangeUserView>();
	}

	private void Play()
	{
		NavigationService.GetInstance().NavigateToPage<SelectGameView>();
	}

}

