﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using FriendEditor.Models;
using FriendEditor.Services;
using FriendEditor.EventArgs;
using System.Linq;

namespace FriendEditor.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Variables

        private ObservableCollection<Friend> _allFriends;
        private Friend _selectedFriend;

        #endregion

        #region Constructors

        public MainViewModel(IDataProvider dataProvider, IEditWindowController editWindowController, IDialogService dialogService)
        {
            DataProvider = dataProvider;
            EditWindowController = editWindowController;
            DialogService = dialogService;

            AddFriendCommand = new RelayCommand(AddFriend);

        }
        #endregion

        #region Properties

        public RelayCommand AddFriendCommand { get; set; }

        /// <summary>
        /// Get or set AllFriends value
        /// </summary>
        public ObservableCollection<Friend> AllFriends
        {
            get { return _allFriends; }
            set { Set(ref _allFriends, value); }
        }

        public IDataProvider DataProvider { get; }
        public RelayCommand<Friend> DeleteFriendCommand { get; set; }
        public IDialogService DialogService { get; }
        public RelayCommand<Friend> EditFriendCommand { get; set; }
        public IEditWindowController EditWindowController { get; }

        /// <summary>
        /// Get or set SelectedFriend value
        /// </summary>
        public Friend SelectedFriend
        {
            get { return _selectedFriend; }
            set
            {
                Set(ref _selectedFriend, value);

                // If SelectedFriend property changed, check if Edit & Delete commands can execute
                DeleteFriendCommand.RaiseCanExecuteChanged();
                EditFriendCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion Properties

        #region Methods

        private void AddFriend()
        {
            var result = EditWindowController.ShowDialog(new EventArgs.OpenEditWindowArgs { Type = ActionType.Add });
            if (result.HasValue && result.Value)
            {
                AllFriends = new ObservableCollection<Friend>(DataProvider.GetAllFriends().OfType<Friend>());
            }
        }
    }
}
