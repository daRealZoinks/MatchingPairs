using Game.ViewModels;
using System.Windows.Controls;

namespace Game.Views;

/// <summary>
/// Interaction logic for ChangeUserView.xaml
/// </summary>
public partial class ChangeUserView : UserControl
{
	public ChangeUserView(ChangeUserViewModel changeUserViewModel)
	{
		InitializeComponent();
		DataContext = changeUserViewModel;
	}
}
