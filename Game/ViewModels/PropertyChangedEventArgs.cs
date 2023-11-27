namespace Game.ViewModels
{
    public class PropertyChangedEventArgs : EventArgs
    {
        public PropertyChangedEventArgs(string? propertyName)
        {
            PropertyName = propertyName;
        }

        public virtual string? PropertyName { get; }
    }
}
