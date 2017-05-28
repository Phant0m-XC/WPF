using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoginWindow login = new LoginWindow();
            login.ShowDialog();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                User user = (User) listView.SelectedItem;
                TextBlock newTextBlock1 = new TextBlock();
                newTextBlock1.Text = $"From me:\n{textBox.Text}\n{DateTime.Now}\n";
                newTextBlock1.HorizontalAlignment = HorizontalAlignment.Left;
                textBox.Text = "";
                stackPanel.Children.Add(newTextBlock1);
                ////animation
                animation(newTextBlock1);
                ////
                TextBlock newTextBlock2 = new TextBlock();
                newTextBlock2.Text = $"From {user.LoginName}:\nЯ пока просто пишу текст\n{DateTime.Now}\n";
                newTextBlock2.HorizontalAlignment = HorizontalAlignment.Right;
                stackPanel.Children.Add(newTextBlock2);
                ////animation
                animation(newTextBlock2);
                ////
                scrollViewer.ScrollToBottom();
            }
        }

        private void animation(TextBlock block)
        {
            Storyboard storyboard = new Storyboard();
            ScaleTransform scale = new ScaleTransform(1.0, 1.0);
            block.RenderTransformOrigin = new Point(0, 0);
            block.RenderTransform = scale;
            DoubleAnimation growAnimation = new DoubleAnimation();
            growAnimation.Duration = TimeSpan.FromMilliseconds(500);
            growAnimation.From = 0;
            growAnimation.To = 1;
            storyboard.Children.Add(growAnimation);
            Storyboard.SetTargetProperty(growAnimation, new PropertyPath("RenderTransform.ScaleY"));
            Storyboard.SetTarget(growAnimation, block);
            storyboard.Begin();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox.Text == "" || textBox.Text == null)
                button.IsEnabled = false;
            else
                button.IsEnabled = true;
        }
    }

    public class User
    {
        private string loginName;

        public User(string loginName)
        {
            this.loginName = loginName;
        }

        public string LoginName
        {
            get { return loginName; }
        }

        public override string ToString()
        {
            return loginName;
        }
    }

    public class UsersList : ObservableCollection<User>
    {
        public UsersList()
        {
            Add(new User("Denis"));
            Add(new User("Aleksej"));
            Add(new User("Volt"));
            Add(new User("Elena"));
        }
    }
}
