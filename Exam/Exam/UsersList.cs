using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace Exam
{
    public class UsersList : INotifyPropertyChanged
    {
        private ObservableCollection<User> users;

        public UsersList()
        {
            users = new ObservableCollection<User>();
            users.Add(new User("Alex"));
            users.Add(new User("Denis"));
            users.Add(new User("Anton"));
            users.Add(new User("Elena"));
        }

        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }

        private ObservableCollection<Message> usersMessages;
        public ObservableCollection<Message> UsersMessages
        {
            get { return usersMessages; }
            set
            {
                usersMessages = value;
                OnPropertyChanged("UsersMessages");
            }
        }

        private User selectedUser = null;

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                UsersMessages = selectedUser.Messages;
                OnPropertyChanged("SelectedUser");
            }
        }

        private SentMessageCommand addCommand;
        public SentMessageCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new SentMessageCommand(obj =>
                  {
                      if (selectedUser != null)
                      {
                          string text = obj as string;
                          Message message1 = new Message($"{text}\n{DateTime.Now}", "me");
                          selectedUser.Messages.Add(message1);
                          //имитация отправки ообщения от собеседника
                          Message message2 = new Message($"Я пока просто пишу текст\n{DateTime.Now}", selectedUser.Name);
                          selectedUser.Messages.Add(message2);
                      }
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
