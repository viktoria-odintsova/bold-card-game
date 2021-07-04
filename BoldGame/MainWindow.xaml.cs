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

        public MainWindow()
        {
            InitializeComponent();
            DeckOfCards D = new DeckOfCards();
            D.CreateDeck();

            int i = 0;
            int j = 0;
            while (j < 4)
            {

                while (i < 5)
                {
                    x += 100;
                    i++;
                    CreateViewImageDynamically( x ,  y) ;
                }
                i = 0;
                x = 0;
                y += 130;
                j++;
            }
            
        }
        private void CreateViewImageDynamically(int x, int y)
        {
           
            //// Create Image and set its width and height  
            Image dynamicImage = new Image();
            dynamicImage.Width = 150;
            dynamicImage.Height = 100;

            //// Create a BitmapSource  
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"pack://siteoforigin:,,,/Resources/Back.jpg");
            bitmap.EndInit();

            
            //// Set Image.Source  
            dynamicImage.Source = bitmap;
            dynamicImage.HorizontalAlignment = HorizontalAlignment.Left;
            dynamicImage.VerticalAlignment = VerticalAlignment.Top;
            dynamicImage.Margin = new Thickness(x, y, 0, 0);
                    
            

            //dynamicImage.MouseLeftButtonUp += this.DynamicImage_MouseLeftButtonUp;
            //this.X += 70;
            ////Add Image to Window  
            grdMainWindow.Children.Add(dynamicImage);
        }

        


    }
}
