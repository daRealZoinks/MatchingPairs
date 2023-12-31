﻿using Game.Models;
using Game.Services;
using Game.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using NavigationService = Game.Services.NavigationService;

namespace Game.ViewModels;

public class ChangeUserViewModel : ViewModelBase
{
    private ObservableCollection<User> _users;
    public ObservableCollection<User> Users
    {
        get { return _users; }
        set
        {
            _users = value;
            OnPropertyChanged();
        }
    }

    private User? _selectedUser;
    public User? SelectedUser
    {
        get
        { return _selectedUser; }

        set
        {
            _selectedUser = value;
            OnPropertyChanged();
        }
    }

    private string? _newUserName;
    public string NewUserName
    {
        get
        { return _newUserName; }

        set
        {
            _newUserName = value;
            OnPropertyChanged();
        }
    }

    private string _currentProfilePicture;
    public string CurrentProfilePicture
    {
        get { return _currentProfilePicture; }
        set
        {
            _currentProfilePicture = value;
            OnPropertyChanged();
        }
    }

    private List<string> _profilePictures;

    public string profilePicturesFilePath = ProfilePicturesService.path;
    public string userFilePath = UserService.filePath;

    public ICommand CreateUserCommand { get; private set; }
    public ICommand ChangeUserCommand { get; private set; }
    public ICommand NextImageCommand { get; private set; }
    public ICommand PreviousImageCommand { get; private set; }

    public ChangeUserViewModel()
    {
        CreateUserCommand = new RelayCommand(CreateUser);
        ChangeUserCommand = new RelayCommand(ChangeUser);
        NextImageCommand = new RelayCommand(NextImage);
        PreviousImageCommand = new RelayCommand(PreviousImage);
    }

    public void InitializeLists()
    {
        _users = new ObservableCollection<User>(UserService.GetAllUsers(userFilePath));
        _selectedUser = Users.FirstOrDefault();
        _profilePictures = ProfilePicturesService.LoadPictures(profilePicturesFilePath);
        _currentProfilePicture = _profilePictures[0];
    }

    public void CreateUser()
    {
        if (Users.Any(u => u.Username == NewUserName))
        {
            MessageBox.Show("Username already exists!", "Duplicate Username", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (NewUserName == null)
        {
            MessageBox.Show("Username cannot be null", "Error!", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var newUser = new User(NewUserName, 0, 0, CurrentProfilePicture);

        UserService.AddUser(newUser, userFilePath);
        Users.Add(newUser);
        //SelectedUser = Users[^1];
    }

    public void ChangeUser()
    {
        var vm = new MainContentViewModel(SelectedUser ?? new());
        NavigationService.GetInstance().NavigateToPage<MainContentView>(vm);
    }

    public void NextImage()
    {
        var index = _profilePictures.IndexOf(_currentProfilePicture);

        if (index < _profilePictures.Count - 1)
        {
            CurrentProfilePicture = _profilePictures[index + 1];
        }
    }

    public void PreviousImage()
    {
        var index = _profilePictures.IndexOf(_currentProfilePicture);

        if (index > 0)
        {
            CurrentProfilePicture = _profilePictures[index - 1];
        }
    }
}
