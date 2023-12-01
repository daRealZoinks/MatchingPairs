using Game.Views;
using System.Windows;
using System.Windows.Navigation;
using NavigationService = Game.Services.NavigationService;

namespace Game
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private readonly NavigationService _navigationService;
        public MainView()
        {
            InitializeComponent();
            _navigationService = NavigationService.Instance(MainFrame);
            _navigationService.NavigateToPage<MainContentView>();
        }
    }
}