using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using FriendEditor.Models;
using FriendEditor.Services;


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
    }
}
