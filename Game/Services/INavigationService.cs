using System.Windows.Controls;

namespace Game.Services;

public interface INavigationService
{
	void NavigateToPage<T>() where T : UserControl, new();
	void GoBack();
	void GoForward();
}
