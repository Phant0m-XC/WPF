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
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                User user = (User)listView.SelectedItem;
                Message message1 = new Message($"{textBox.Text}\n{DateTime.Now}", "me");
                user.addMessage(message1);
                TextBlock newTextBlock1 = new TextBlock();
                newTextBlock1.Text = $"From {message1.From}:\n{message1.Text}\n";
                newTextBlock1.HorizontalAlignment = HorizontalAlignment.Left;
                newTextBlock1.Background = Brushes.Aquamarine;
                textBox.Text = "";
                stackPanel.Children.Add(newTextBlock1);
                ////animation
                animation(newTextBlock1);
                ////
                ////симуляция ответа от пользователя
                Message message2 = new Message($"Я пока просто пишу текст\n{DateTime.Now}", user.Name);
                user.addMessage(message2);
                TextBlock newTextBlock2 = new TextBlock();
                newTextBlock2.Text = $"From {user.Name}:\n{message2.Text}\n";
                newTextBlock2.HorizontalAlignment = HorizontalAlignment.Right;
                newTextBlock2.Background = Brushes.BlanchedAlmond;
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
}
