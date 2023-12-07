using Game.ViewModels;
using System.Windows.Controls;

namespace Game.Views;

/// <summary>
/// Interaction logic for LeaderboardView.xaml
/// </summary>
public partial class LeaderboardView : UserControl
{
	public LeaderboardView()
	{
		InitializeComponent();
		DataContext = new LeaderboardViewModel();
	}
}
