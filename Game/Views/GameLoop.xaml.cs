using Game.Models;
using Game.ViewModels;
using System.IO;
using System.Xml.Serialization;

namespace Game.Views;

public partial class GameLoop
{
    GameViewModel viewModel;

    public GameLoop()
    {
        InitializeComponent();

        viewModel = new GameViewModel
        {
            Grid = Grid
        };

        //viewModel.GenerateGame(5, 5);
    }

    private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        const string filePath = "..\\..\\..\\Data\\Board.xml";

        //SaveBoard(filePath);

        var board = LoadBoard(filePath);

        if (board is null)
        {
            return;
        }

        viewModel.LoadFromBoard(board);
    }

    public void SaveBoard(string filePath)
    {
        var serializer = new XmlSerializer(typeof(Board));
        using FileStream fileStream = new(filePath, FileMode.Create);
        serializer.Serialize(fileStream, viewModel.Board);
    }

    public Board? LoadBoard(string filePath)
    {
        var serializer = new XmlSerializer(typeof(Board));
        using FileStream fileStream = new(filePath, FileMode.Open);
        return serializer.Deserialize(fileStream) as Board;
    }
}