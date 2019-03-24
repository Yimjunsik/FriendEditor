using System.Collections.Generic;
using FriendEditor.Models;

namespace FriendEditor.Services
{
    public interface IDataProvider
    {
        bool Delete(IFriend friend);

        List<IFriend> GetAllFriends();

        IFriend GetFriendById(string id);

        bool Insert(IFriend friend);

        bool Update(IFriend friend);
    }
}
