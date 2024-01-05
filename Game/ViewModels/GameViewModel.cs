using Game.Models;
using Game.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace Game.ViewModels;

public class GameViewModel : ViewModelBase
{
    private Card? _selectedCard1;
    private Card? _selectedCard2;

    //public Board Board { get; set; }
    //public User User { get; set; }

    GameObject Game { get; set; }
    User User { get; set; } = new();

    public Grid Grid { get; set; }

    public ICommand CardClickCommand { get; private set; }
    public ICommand SaveBoardCommand { get; private set; }
    public ICommand LoadBoardCommand { get; private set; }

    public GameViewModel()
    {
        CardClickCommand = new RelayCommand<Card>(Card_Click);
        SaveBoardCommand = new RelayCommand(Save);
        LoadBoardCommand = new RelayCommand(Load);
		Game = new()
		{
			User = User
		};
	}

    public void Save()
    {
        GameService.SaveGame(Game);
    }

    public void Load()
    {
        var game = GameService.LoadGame(User);

        if (game is null)
        {
            return;
        }

        LoadFromBoard(game);
    }

    public void LoadFromBoard(GameObject game)
    {
        Game = game;

        // Clear any existing rows and columns
        Grid.RowDefinitions.Clear();
        Grid.ColumnDefinitions.Clear();

        // Add rows and columns to the grid
        for (var i = 0; i < Game.Board.Height; i++)
        {
            Grid.RowDefinitions.Add(new RowDefinition());
        }

        for (var i = 0; i < Game.Board.Width; i++)
        {
            Grid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        foreach (var pair in Game.Board.Pairs)
        {
            var button1 = CreateCard(pair.Card1);
            Grid.SetRow(button1, pair.Card1.Row);
            Grid.SetColumn(button1, pair.Card1.Column);
            Grid.Children.Add(button1);

            var button2 = CreateCard(pair.Card2);
            Grid.SetRow(button2, pair.Card2.Row);
            Grid.SetColumn(button2, pair.Card2.Column);
            Grid.Children.Add(button2);
        }
    }

    public void GenerateGame(int width, int height)
    {
        // Clear any existing rows and columns
        Grid.RowDefinitions.Clear();
        Grid.ColumnDefinitions.Clear();

        Game.Board = new Board
        {
            Width = width,
            Height = height
        };

        // Add rows and columns to the grid
        for (var i = 0; i < Game.Board.Height; i++)
        {
            Grid.RowDefinitions.Add(new RowDefinition());
        }

        for (var i = 0; i < Game.Board.Width; i++)
        {
            Grid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        var picturePaths = CardPicturesService.LoadPictures();

        var rng = new Random();
        // Add pairs to the list
        for (var i = 0; i < width * height / 2; i++)
        {
            var picture = picturePaths[rng.Next(picturePaths.Count)];

            var card1 = new Card { PicturePath = picture };
            var card2 = new Card { PicturePath = picture };

            picturePaths.Remove(picture);
            Game.Board.Pairs.Add(new Pair { Card1 = card1, Card2 = card2 });
        }

        // Create a list for all cards in the board pairs, but shuffled
        var cards = new List<Card>();
        foreach (var pair in Game.Board.Pairs)
        {
            cards.Add(pair.Card1);
            cards.Add(pair.Card2);
        }

        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (cards[n], cards[k]) = (cards[k], cards[n]);
        }

        // Add buttons to the list
        var index = 0;
        for (var row = 0; row < height; row++)
        {
            for (var column = 0; column < width; column++)
            {
                // Skip the middle button
                if (row == height / 2 && column == width / 2)
                {
                    continue;
                }

                var card = cards[index];
                card.Row = row;
                card.Column = column;
                cards.Add(card);
                index++;
            }
        }

        foreach (var card in cards)
        {
            var button = CreateCard(card);
            Grid.SetRow(button, card.Row);
            Grid.SetColumn(button, card.Column);
            Grid.Children.Add(button);
        }
    }

    private Button CreateCard(Card card)
    {
        var button = new Button
        {
            Margin = new Thickness(10),
            // Set other properties as needed
        };

        card.Button = button;

        button.Command = CardClickCommand;
        button.CommandParameter = card;

        return button;
    }

    private void Card_Click(Card clickedCard)
    {
        var cardBackColor = new Color
        {
            R = 221,
            G = 221,
            B = 221,
        };

        if (_selectedCard1 != null && _selectedCard2 != null)
        {
            _selectedCard1.Button.Background = new SolidColorBrush(cardBackColor);
            _selectedCard1 = null;
            _selectedCard2.Button.Background = new SolidColorBrush(cardBackColor);
            _selectedCard2 = null;
        }

        if (_selectedCard1 == null)
        {
            // Flip the cards face down

            _selectedCard1 = clickedCard;
            _selectedCard1.Button.Background = new ImageBrush(new BitmapImage(new Uri(_selectedCard1.PicturePath, UriKind.Relative)));
        }
        else if (_selectedCard2 == null)
        {
            _selectedCard2 = clickedCard;
            _selectedCard2.Button.Background = new ImageBrush(new BitmapImage(new Uri(_selectedCard2.PicturePath, UriKind.Relative)));

            if (_selectedCard1.Equals(_selectedCard2))
            {
                _selectedCard2 = null;
                return;
            }

            var pair = Game.Board.Pairs.Find(p =>
            {
                return (p.Card1.Equals(_selectedCard1) && p.Card2.Equals(_selectedCard2)) ||
                       (p.Card1.Equals(_selectedCard2) && p.Card2.Equals(_selectedCard1));
            });

            if (pair != null)
            {
                // Match

                pair.IsMatched = true;
                Game.Board.Pairs.Remove(pair);
                _selectedCard1.Button.Background = new SolidColorBrush(cardBackColor);
                _selectedCard2.Button.Background = new SolidColorBrush(cardBackColor);
                _selectedCard1.Button.IsEnabled = false;
                _selectedCard2.Button.IsEnabled = false;
            }
            else
            {
                // No match

                _selectedCard1.Button.Background = new ImageBrush(new BitmapImage(new Uri(_selectedCard1.PicturePath, UriKind.Relative)));
                _selectedCard2.Button.Background = new ImageBrush(new BitmapImage(new Uri(_selectedCard2.PicturePath, UriKind.Relative)));
            }
        }

        if (Game.Board.Pairs.Count == 0)
        {
            MessageBox.Show("You won!");
        }
    }
}