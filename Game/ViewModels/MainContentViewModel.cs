﻿using Game.Views;
using System.Windows.Input;
using NavigationService = Game.Services.NavigationService;

namespace Game.ViewModels;

public class MainContentViewModel
{
	public ICommand SwitchToUserControl2Command { get; private set; }

	public MainContentViewModel()
	{
		SwitchToUserControl2Command = new RelayCommand(SwitchToUserControl2);
	}

	private void SwitchToUserControl2()
	{
		NavigationService.GetInstance().NavigateToPage<ChangeUserView>();
	}
}

