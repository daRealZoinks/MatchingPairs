namespace Game.Services;

public class NavigationContext
{
	private static readonly NavigationContext _instance = new();

	private object _data;

	public static NavigationContext Instance => _instance;

	public object GetData() => _data;

	public void SetData(object data) => _data = data;
}
