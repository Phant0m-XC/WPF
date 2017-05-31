using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class User
    {
        private string name;
        private List<Message> messageList;

        public User(string name)
        {
            this.name = name;
            messageList = new List<Message>();
        }

        public string Name
        {
            get { return name; }
        }

        public void addMessage(Message message)
        {
            messageList.Add(message);
        }

        public List<Message> getListMessage()
        {
            return messageList;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
