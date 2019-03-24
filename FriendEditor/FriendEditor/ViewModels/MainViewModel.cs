using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using FriendEditor.Models;


namespace FriendEditor.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Variables

        private ObservableCollection<Friend> _allFriends;
        private Friend _selectedFriend;

        #endregion
    }
}
