using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class Message
    {
        private string text;
        private string from;

        public Message(string text, string from)
        {
            this.text = text;
            this.from = from;
        }

        public string Text
        {
            get { return text; }
        }

        public string From
        {
            get { return from; }
        }
    }
}