using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        bool isTurnActive;
        Game game;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            DeleteImages();
            game = new Game();
            Console.WriteLine(game.Deck);
            new InputNames(game).ShowDialog();
            Console.WriteLine(game.Player1.Name + ", " + game.Player2.Name);
            DisplayBacks();
            DisplayTurn();
            lblPlayer1Name.Content = game.Player1.Name;
            lblPlayer2Name.Content = game.Player2.Name;
            lblPlayer1Points.Content = game.Player1.Score.ToString();
            lblPlayer2Points.Content = game.Player2.Score.ToString();
            
            isTurnActive = true;
            BtnGetPoints.IsEnabled = false;
        }

        private void DisplayTurn()
        {
            if(game.PlayerTurn == 1)
            {
                lblPlayerTurn.Content = game.Player1.Name + "'s Turn";
            }
            else
            {
                lblPlayerTurn.Content = game.Player2.Name + "'s Turn";
            }
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

        private void DisplayBacks()
        {
            y = 30;
            for(int i = 0; i < 4; i++)
            { 
                for(int j = 0; j < 5; j++)
                {
                    x += 100;
                    CreateViewImageDynamically(x, y, game.Board[i, j]);
                }
                x = 0;
                y += 130;
            }
        }

        private async void DynamicImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isTurnActive)
            {
                Image image = sender as Image;

                Card card = image.Tag as Card;
                Console.WriteLine(card);

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(@"pack://siteoforigin:,,,/Resources/" + card.ImagePath);
                bitmap.EndInit();
                image.Source = bitmap;

                game.OpenedCards.Add(card);
                if (game.OpenedCards.Count > 1)
                {
                    bool isMatch = game.CompareCards();
                    Console.WriteLine(isMatch);
                    if (!isMatch)
                    {

                        BtnGetPoints.IsEnabled = false;
                        game.PlayerTurn = game.PlayerTurn % 2 + 1;
                        DisplayTurn();
                        game.OpenedCards.Clear();
                        isTurnActive = false;
                        await Task.Delay(2000);
                        isTurnActive = true;
                        DeleteImages();
                        DisplayBacks();
                    }
                    else
                    {
                        BtnGetPoints.IsEnabled = true;
                    }
                }
            }
        }

        private void DeleteImages()
        {
            grdBoard.Children.Clear();
        }

        private void BtnGetPoints_Click(object sender, RoutedEventArgs e)
        {
            game.GivePoints();
            lblPlayer1Points.Content = game.Player1.Score.ToString();
            lblPlayer2Points.Content = game.Player2.Score.ToString();
            if (!game.UpdateBoard())
            {
                isTurnActive = false;
                BtnGetPoints.IsEnabled = false;
                Player winner = game.EndGame();
                MessageBox.Show("The game is over. The winner is " + winner.Name + "with the score: " + winner.Score.ToString());
                DeleteImages();

            }
            else
            {
                game.PlayerTurn = game.PlayerTurn % 2 + 1;
                DisplayTurn();
                DeleteImages();
                DisplayBacks();
            }
        }

        
    }
}
