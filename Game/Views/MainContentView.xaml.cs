using Game.Models;
using Game.ViewModels;
using System.Windows.Controls;

namespace Game.Views;

/// <summary>
/// Interaction logic for MainContent.xaml
/// </summary>
public partial class MainContentView : UserControl
{
	public MainContentView(MainContentViewModel mainContentViewModel)
	{
		InitializeComponent();
		DataContext = mainContentViewModel;

    }
}
