using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom
{
    public interface IUser
    {
        void NotifyUsers();
        //void NotifyUsers(IUser user) what is the difference?
    }
}
