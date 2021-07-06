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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoldGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int x = 0;
        int y = 0;
        Game game;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateViewImageDynamically(int x, int y, Card tagCard)
        {
           
            //// Create Image and set its width and height  
            Image dynamicImage = new Image();
            dynamicImage.Width = 150;
            dynamicImage.Height = 100;

            //// Create a BitmapSource  
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"pack://siteoforigin:,,,/Resources/back.jpg");
            bitmap.EndInit();

            
            //// Set Image.Source  
            dynamicImage.Source = bitmap;
            dynamicImage.HorizontalAlignment = HorizontalAlignment.Left;
            dynamicImage.VerticalAlignment = VerticalAlignment.Top;
            dynamicImage.Margin = new Thickness(x, y, 0, 0);
            dynamicImage.Tag = tagCard;
            dynamicImage.MouseLeftButtonUp += DynamicImage_MouseLeftButtonUp;



            //dynamicImage.MouseLeftButtonUp += this.DynamicImage_MouseLeftButtonUp;
            //this.X += 70;
            ////Add Image to Window  
            grdBoard.Children.Add(dynamicImage);
        }

        private void DynamicImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            
            Card card = image.Tag as Card;
            Console.WriteLine(card);

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"pack://siteoforigin:,,,/Resources/" + card.ImagePath);
            bitmap.EndInit();
            image.Source = bitmap; 
        }

     
        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            y = 0;
            DeleteImages();
            game = new Game();
            Console.WriteLine(game.Deck);
            int i = 0;
            int j = 0;
            while (j < 4)
            {
                while (i < 5)
                {
                    x += 100;
                    CreateViewImageDynamically(x, y, game.Board[j, i]);
                    i++;
                }
                i = 0;
                x = 0;
                y += 130;
                j++;
            }
        }

        private void DeleteImages()
        {
            grdBoard.Children.Clear();
        }
    }
}
