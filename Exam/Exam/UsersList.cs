using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Exam
{
    public class UsersList : ObservableCollection<User>
    {
        public UsersList()
        {
            Add(new User("Alex"));
            Add(new User("Denis"));
            Add(new User("Anton"));
            Add(new User("Elena"));
        }
    }
}
