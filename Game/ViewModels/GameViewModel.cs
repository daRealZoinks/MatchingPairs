using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Game.Models;
using Game.Services;

namespace Game.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<Pair> _pairs = [];
        private Card? _selectedCard;

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

            // Add rows and columns to the grid
            for (var i = 0; i < height; i++)
            {
                Grid.RowDefinitions.Add(new RowDefinition());
            }

            for (var i = 0; i < width; i++)
            {
                Grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            // Add pairs to the list
            for (var i = 0; i < (width * height) / 2; i++)
            {
                var card1 = new Card { Content = $"{i + 1}" };
                var card2 = new Card { Content = $"{i + 1}" };
                _pairs.Add(new Pair(card1, card2));
            }

            // Shuffle the pairs
            var rng = new Random();
            var n = _pairs.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                (_pairs[k], _pairs[n]) = (_pairs[n], _pairs[k]);
            }

            // Create a list of buttons
            var buttons = new List<Button>();

            // Add buttons to the list
            var index = 0;
            for (var row = 0; row < height; row++)
            {
                for (var col = 0; col < width; col++)
                {
                    // Skip the middle button
                    if (row == height / 2 && col == width / 2)
                    {
                        continue;
                    }

                    var button = CreateCard(index % 2 == 0 ? _pairs[index / 2].Card1 : _pairs[index / 2].Card2);
                    buttons.Add(button);
                    index++;
                }
            }

            // Shuffle the buttons
            n = buttons.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                (buttons[k], buttons[n]) = (buttons[n], buttons[k]);
            }

            // Add buttons to the grid
            index = 0;
            for (var row = 0; row < height; row++)
            {
                for (var col = 0; col < width; col++)
                {
                    // Skip the middle button
                    if (row == height / 2 && col == width / 2)
                    {
                        continue;
                    }

                    var button = buttons[index];
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                    Grid.Children.Add(button);
                    index++;
                }
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

            button.SetBinding(Button.CommandProperty, new Binding("CardClickCommand"));

            return button;
        }

        private void Card_Click(Card clickedCard)
        {
            if (_selectedCard == null)
            {
                _selectedCard = clickedCard;
                _selectedCard.Button.Content = _selectedCard.Content;
            }
            else
            {
                var pair = _pairs.Find(p => Equals(p, new Pair(_selectedCard, clickedCard)));

                if (pair != null)
                {
                    // Match

                    pair.IsMatched = true;
                    _pairs.Remove(pair);
                    _selectedCard.Button.Content = _selectedCard.Content;
                    clickedCard.Button.Content = clickedCard.Content;
                    _selectedCard.Button.IsEnabled = false;
                    clickedCard.Button.IsEnabled = false;

                    _selectedCard = null;
                }
                else
                {
                    // No match

                    _selectedCard.Button.Content = null;
                    _selectedCard = null;
                }
            }
        }

        // Implement the INotifyPropertyChanged interface...
    }
}