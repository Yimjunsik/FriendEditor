using FriendEditor.Models;
using FriendEditor.Services;
using FriendEditor.EventArgs;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
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

        #region Methods

        private void SaveData()
        {
            if (string.IsNullOrWhiteSpace(CurrentFriend.Name))
            {
                DialogService.Warning("Name is required");
                return;
            }

            bool result = false;
            switch (Args.Type)
            {
                case ActionType.Add:
                    result = DataProvider.Insert(CurrentFriend);
                    break;

                case ActionType.Edit:
                    result = DataProvider.Update(CurrentFriend);
                    break;
            }
            if (result)
            {
                DialogService.ShowMessage($"{Args.Type} friend successfully");

                // Send a message to Close the current View(EditWindow)
                Messenger.Default.Send(new CloseWindowEventArgs());
            }
            else
            {
                DialogService.Warning($"Error occured, save data failed");
            }
        }

        #endregion Methods
    }
}
