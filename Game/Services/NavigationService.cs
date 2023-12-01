﻿using System.Windows.Controls;

namespace Game.Services;

public class NavigationService : INavigationService
{
	private static NavigationService _instance;
	private readonly Frame _frame;

	// Private constructor to prevent external instantiation
	private NavigationService(Frame frame)
	{
		_frame = frame;
	}

	public static NavigationService Instance(Frame frame)
	{
		return _instance ??= new NavigationService(frame);
	}

	public static NavigationService GetInstance()
	{
		return _instance;
	}

	public void NavigateToPage<T>() where T : UserControl, new()
	{
		var page = new T();
		_frame.Navigate(page);
	}

	public void GoBack()
	{
		if (_frame.CanGoBack)
		{
			_frame.GoBack();
		}
	}

	public void GoForward()
	{
		if (_frame.CanGoForward)
		{
			_frame.GoForward();
		}
	}

}
