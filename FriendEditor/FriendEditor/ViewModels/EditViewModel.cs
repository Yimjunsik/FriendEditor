using FriendEditor.Models;
using FriendEditor.Services;
using FriendEditor.EventArgs;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;

namespace FriendEditor.ViewModels
{
    public class EditViewModel : ViewModelBase
    {
        #region Properties

        public Friend CurrentFriend { get; set; }
        public IDataProvider DataProvider { get; }
        public IDialogService DialogService { get; set; }
        public RelayCommand SaveDataCommand { get; set; }
        protected OpenEditWindowArgs Args { get; }

        #endregion Properties
    }
}
