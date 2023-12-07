using Game.ViewModels;
using System.Windows.Controls;

namespace Game.Views;

/// <summary>
/// Interaction logic for SelectGameView.xaml
/// </summary>
public partial class SelectGameView : UserControl
{
	public SelectGameView()
	{
		InitializeComponent();
		DataContext = new SelectGameViewModel();
	}
}
