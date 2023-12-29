using Game.Models;
using Game.ViewModels;
using Game.Views;
using System.Windows;
using NavigationService = Game.Services.NavigationService;

namespace Game
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            _ = NavigationService.Instance(MainFrame);
            var vm = new MainContentViewModel(new User("hkdkqh", 0, 0, "hgdjhygj")); //TODO: Load the last user from games list
            NavigationService.GetInstance().NavigateToPage<MainContentView>(vm);
        }
    }
}