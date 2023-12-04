namespace Game.Services
{
    public interface INotifyPropertyChanged
    {
        event PropertyChangedEventHandler? PropertyChanged;
    }
}