using Game.ViewModels;

namespace Game.Views;

public partial class GameLoop
{
    public GameLoop()
    {
        InitializeComponent();

        (LayoutRoot.DataContext as GameViewModel).Grid = Grid;
    }
}