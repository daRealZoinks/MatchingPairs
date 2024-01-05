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
            var vm = new MainContentViewModel();
            NavigationService.GetInstance().NavigateToPage<MainContentView>(vm);
        }
    }
}