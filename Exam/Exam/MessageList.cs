using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Exam
{
    public class MessageList : ObservableCollection<Message>
    {
        public MessageList(string text, string from)
        {
            Add(new Message(text, from));
        }
    }
}
