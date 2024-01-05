using Game.Models;
using Game.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        public Card? selectedCard1;
        public Card? selectedCard2;

        public Board Board { get; set; }

        public Grid Grid { get; set; }

        public ICommand CardClickCommand { get; private set; }
        public ICommand SaveBoardCommand { get; private set; }
        public ICommand LoadBoardCommand { get; private set; }

        public GameViewModel()
        {
            CardClickCommand = new RelayCommand<Card>(Card_Click);
            SaveBoardCommand = new RelayCommand(Save);
            LoadBoardCommand = new RelayCommand(Load);
        }

        public void Save()
        {
            GameService.SaveBoard(Board, GameService.filePath);
        }

        public void Load()
        {
            var board = GameService.LoadBoard(GameService.filePath);

            if (board is null)
            {
                return;
            }

            LoadFromBoard(board);
        }

        public void LoadFromBoard(Board board)
        {
            Board = board;

            // Clear any existing rows and columns
            Grid.RowDefinitions.Clear();
            Grid.ColumnDefinitions.Clear();

            // Add rows and columns to the grid
            for (var i = 0; i < Board.Height; i++)
            {
                Grid.RowDefinitions.Add(new RowDefinition());
            }

            for (var i = 0; i < Board.Width; i++)
            {
                Grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            foreach (var pair in Board.Pairs)
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

            Board = new Board
            {
                Width = width,
                Height = height
            };

            // Add rows and columns to the grid
            for (var i = 0; i < Board.Height; i++)
            {
                Grid.RowDefinitions.Add(new RowDefinition());
            }

            for (var i = 0; i < Board.Width; i++)
            {
                Grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            var picturePaths = CardPicturesService.LoadPictures(CardPicturesService.path);

            var rng = new Random();
            // Add pairs to the list
            for (var i = 0; i < width * height / 2; i++)
            {
                var picture = picturePaths[rng.Next(picturePaths.Count)];

                var card1 = new Card { PicturePath = picture };
                var card2 = new Card { PicturePath = picture };

                picturePaths.Remove(picture);
                Board.Pairs.Add(new Pair { Card1 = card1, Card2 = card2 });
            }

            // Create a list for all cards in the board pairs, but shuffled
            var cards = new List<Card>();
            foreach (var pair in Board.Pairs)
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

            if (selectedCard1 != null && selectedCard2 != null)
            {
                selectedCard1.Button.Background = new SolidColorBrush(cardBackColor);
                selectedCard1 = null;
                selectedCard2.Button.Background = new SolidColorBrush(cardBackColor);
                selectedCard2 = null;
            }

            if (selectedCard1 == null)
            {
                // Flip the cards face down

                selectedCard1 = clickedCard;
                selectedCard1.Button.Background = new ImageBrush(new BitmapImage(new Uri(selectedCard1.PicturePath, UriKind.Relative)));
            }
            else if (selectedCard2 == null)
            {
                selectedCard2 = clickedCard;
                selectedCard2.Button.Background = new ImageBrush(new BitmapImage(new Uri(selectedCard2.PicturePath, UriKind.Relative)));

                if (selectedCard1.Equals(selectedCard2))
                {
                    selectedCard2 = null;
                    return;
                }

                var pair = Board.Pairs.Find(p =>
                {
                    return (p.Card1.Equals(selectedCard1) && p.Card2.Equals(selectedCard2)) ||
                           (p.Card1.Equals(selectedCard2) && p.Card2.Equals(selectedCard1));
                });

                if (pair != null)
                {
                    // Match

                    pair.IsMatched = true;
                    Board.Pairs.Remove(pair);
                    selectedCard1.Button.Background = new SolidColorBrush(cardBackColor);
                    selectedCard2.Button.Background = new SolidColorBrush(cardBackColor);
                    selectedCard1.Button.IsEnabled = false;
                    selectedCard2.Button.IsEnabled = false;
                }
                else
                {
                    // No match

                    selectedCard1.Button.Background = new ImageBrush(new BitmapImage(new Uri(selectedCard1.PicturePath, UriKind.Relative)));
                    selectedCard2.Button.Background = new ImageBrush(new BitmapImage(new Uri(selectedCard2.PicturePath, UriKind.Relative)));
                }
            }

            if (Board.Pairs.Count == 0)
            {
                MessageBox.Show("You won!");
            }
        }
    }
}