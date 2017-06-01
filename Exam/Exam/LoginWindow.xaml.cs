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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Exam
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary> 

    public partial class LoginWindow : Window
    {
        private string login;
        private string pass;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            if (login == textBox.Text && pass == passwordBox.Password)
            {
                DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль!");
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        public void ShowDialog(string login, string pass)
        {
            this.login = login;
            this.pass = pass;
            this.ShowDialog();
        }
    }
}
