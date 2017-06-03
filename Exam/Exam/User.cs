using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Exam
{
    public class User
    {
        private string name;
        private ObservableCollection<Message> messages;

        public User(string name)
        {
            this.name = name;
            messages = new ObservableCollection<Message>();
        }

        public string Name
        {
            get { return name; }
        }

        public ObservableCollection<Message> Messages
        {
            get { return messages; }
            set
            {
                if (messages != value)
                    messages = value;
            }
        }
    }
}
