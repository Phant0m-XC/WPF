using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Threading;

namespace DZ2_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<PictureBlock> list = new List<PictureBlock>();
        private bool isChange;
        private bool isGame;
        private Rectangle changeRectangle;
        public MainWindow()
        {
            CroppedBitmap a = new CroppedBitmap();
            isChange = false;
            isGame = true;

            InitializeComponent();
            string img = @"K:\MyProjects\GitRepo\WPF\DZ2\DZ2-3\image.jpg";
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(img, UriKind.Relative);
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();
            int index = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    list.Add(new PictureBlock(new CroppedBitmap(src, new Int32Rect(j * 100, i * 100, 100, 100)), index++));

            Shuffle(list);

            rectangle0.Tag = list[0];
            rectangle0.Fill = new ImageBrush(list[0].getCroppedBitmap());
            rectangle1.Tag = list[1];
            rectangle1.Fill = new ImageBrush(list[1].getCroppedBitmap());
            rectangle2.Tag = list[2];
            rectangle2.Fill = new ImageBrush(list[2].getCroppedBitmap());
            rectangle3.Tag = list[3];
            rectangle3.Fill = new ImageBrush(list[3].getCroppedBitmap());
            rectangle4.Tag = list[4];
            rectangle4.Fill = new ImageBrush(list[4].getCroppedBitmap());
            rectangle5.Tag = list[5];
            rectangle5.Fill = new ImageBrush(list[5].getCroppedBitmap());
            rectangle6.Tag = list[6];
            rectangle6.Fill = new ImageBrush(list[6].getCroppedBitmap());
            rectangle7.Tag = list[7];
            rectangle7.Fill = new ImageBrush(list[7].getCroppedBitmap());
            rectangle8.Tag = list[8];
            rectangle8.Fill = new ImageBrush(list[8].getCroppedBitmap());
        }

        private void Shuffle(List<PictureBlock> list)
        {
            Random random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                PictureBlock value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (isGame)
            {
                Rectangle rectangle = sender as Rectangle;

                if (isChange)
                {
                    PictureBlock tempPictBlock = rectangle.Tag as PictureBlock;
                    rectangle.Tag = changeRectangle.Tag;
                    rectangle.Fill = new ImageBrush(((PictureBlock)changeRectangle.Tag).getCroppedBitmap());
                    changeRectangle.Tag = tempPictBlock;
                    changeRectangle.Fill = new ImageBrush(tempPictBlock.getCroppedBitmap());

                    var animation1 = new ThicknessAnimation();
                    animation1.From = new Thickness(0);
                    animation1.To = new Thickness(50);
                    animation1.Duration = TimeSpan.FromSeconds(1);
                    animation1.AutoReverse = true;
                    Storyboard.SetTarget(animation1, rectangle);
                    Storyboard.SetTargetProperty(animation1, new PropertyPath(MarginProperty));

                    var animation2 = new ThicknessAnimation();
                    animation2.From = new Thickness(0);
                    animation2.To = new Thickness(50);
                    animation2.Duration = TimeSpan.FromSeconds(1);
                    animation2.AutoReverse = true;
                    Storyboard.SetTarget(animation2, changeRectangle);
                    Storyboard.SetTargetProperty(animation2, new PropertyPath(MarginProperty));

                    var storyboard = new Storyboard();
                    storyboard.Children = new TimelineCollection { animation1, animation2 };

                    storyboard.Begin();
                    checkState();
                }
                else
                    changeRectangle = rectangle;

                isChange = !isChange;
            }
        }

        private void checkState()
        {
            UIElementCollection collection = grid.Children;
            int index = 0;
            foreach(var item in collection)
            {
                if(item is Rectangle)
                {
                    if (((PictureBlock)((Rectangle)item).Tag).getNumber() == index++)
                        continue;
                    else
                        break;
                }
            }
            if (index == 9)
            {
                System.Windows.Forms.MessageBox.Show("You WON!");
                isGame = false;
            }
        }
    }
}
