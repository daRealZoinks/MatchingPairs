using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Game.Models;
using Game.Services;
using System.Text;

namespace Game.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private Card? _selectedCard1;
        private Card? _selectedCard2;

        public Board Board { get; set; }

        public Grid Grid { get; set; }

        public ICommand CardClickCommand { get; }

        public GameViewModel()
        {
            CardClickCommand = new RelayCommand<Card>(Card_Click);
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

            // Add pairs to the list
            for (var i = 0; i < width * height / 2; i++)
            {
                var card1 = new Card { Content = $"{i + 1}" };
                var card2 = new Card { Content = $"{i + 1}" };
                Board.Pairs.Add(new Pair { Card1 = card1, Card2 = card2 });
            }

            // Create a list for all cards in the board pairs, but shuffled
            var cards = new List<Card>();
            foreach (var pair in Board.Pairs)
            {
                cards.Add(pair.Card1);
                cards.Add(pair.Card2);
            }

            var rng = new Random();
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
                Margin = new Thickness(10)
                // Set other properties as needed
            };

            card.Button = button;

            button.Click += (sender, args) => CardClickCommand.Execute(card);

            return button;
        }

        private void Card_Click(Card clickedCard)
        {
            if (_selectedCard1 != null && _selectedCard2 != null)
            {
                _selectedCard1.Button.Content = "";
                _selectedCard1 = null;
                _selectedCard2.Button.Content = "";
                _selectedCard2 = null;
            }

            if (_selectedCard1 == null)
            {
                // Flip the cards face down

                _selectedCard1 = clickedCard;
                _selectedCard1.Button.Content = _selectedCard1.Content;
            }
            else if (_selectedCard2 == null)
            {
                _selectedCard2 = clickedCard;
                _selectedCard2.Button.Content = _selectedCard2.Content;

                if (_selectedCard1.Equals(_selectedCard2))
                {
                    _selectedCard2 = null;
                    return;
                }

                var pair = Board.Pairs.Find(p =>
                {
                    return (p.Card1.Equals(_selectedCard1) && p.Card2.Equals(_selectedCard2)) ||
                           (p.Card1.Equals(_selectedCard2) && p.Card2.Equals(_selectedCard1));
                });

                if (pair != null)
                {
                    // Match

                    pair.IsMatched = true;
                    Board.Pairs.Remove(pair);
                    _selectedCard1.Button.Content = "";
                    _selectedCard2.Button.Content = "";
                    _selectedCard1.Button.IsEnabled = false;
                    _selectedCard2.Button.IsEnabled = false;
                }
                else
                {
                    // No match

                    _selectedCard1.Button.Content = _selectedCard1.Content;
                    _selectedCard2.Button.Content = _selectedCard2.Content;
                }
            }

            if (Board.Pairs.Count == 0)
            {
                MessageBox.Show("You won!");
            }
        }
    }
}