using Game.ViewModels;

namespace Game.Views;

public partial class GameLoop
{
    public GameLoop()
    {
        InitializeComponent();
    }

    public GameLoop(GameViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
        viewModel.Grid = Grid;
        SaveButton.Command = viewModel.SaveBoardCommand;
    }
}