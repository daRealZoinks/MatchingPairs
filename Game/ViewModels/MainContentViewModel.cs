using Game.Services;
using Game.Views;
using System.Windows;
using System.Windows.Input;

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
		var userControl2 = new ChangeUserView();

		//TODO: We need a navigation service 
		if (Application.Current.MainWindow is MainView mainWindow)
		{
			mainWindow.Content = userControl2;
		}
	}
}

