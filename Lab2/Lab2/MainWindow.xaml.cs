using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            progress.Visibility = Visibility.Hidden;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    string path = dialog.SelectedPath;
                    string[] pathFiles = Directory.GetFiles(path);
                    progress.Minimum = 0;
                    progress.Maximum = pathFiles.Length;
                    progress.Value = 0;
                    progress.Visibility = Visibility.Visible;
                    for (int i = 0; i < pathFiles.Length; i++)
                    {
                        if (System.IO.Path.GetExtension(pathFiles[i]).CompareTo(".jpg") == 0 ||
                            System.IO.Path.GetExtension(pathFiles[i]).CompareTo(".jpeg") == 0 ||
                            System.IO.Path.GetExtension(pathFiles[i]).CompareTo(".bmp") == 0)
                        {
                            comboBox.Items.Add(new BitmapImage(new Uri(pathFiles[i])));
                        }
                        progress.Value++;
                    }
                    comboBox.SelectedIndex = 0;
                }
            }
            progress.Visibility = Visibility.Hidden;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedIndex != comboBox.Items.Count - 1)
                comboBox.SelectedIndex++;
            else
                comboBox.SelectedIndex = 0;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedIndex != 0)
                comboBox.SelectedIndex--;
            else
                comboBox.SelectedIndex = comboBox.Items.Count - 1;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BitmapImage image = comboBox.SelectedItem as BitmapImage;
            runName.Text = image.ToString();
            runSize.Text = image.PixelHeight + " x " + image.PixelWidth;
        }
    }
}
