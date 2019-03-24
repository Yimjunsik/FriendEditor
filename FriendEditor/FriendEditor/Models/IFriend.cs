using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendEditor.Models
{
    public interface IFriend
    {
        DateTime BirthDate { get; set; }
        string Email { get; set; }
        string Id { get; set; }
        bool IsDeveloper { get; set; }

        string Name { get; set; }
    }
}
