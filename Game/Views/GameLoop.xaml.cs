using Game.ViewModels;

namespace Game.Views;

public partial class GameLoop
{
    public GameLoop()
    {
        InitializeComponent();
        var viewModel = (GameViewModel)DataContext;
        viewModel.Grid = Grid;
        viewModel.GenerateGame(5, 5);
    }
}