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

namespace BoldGame
{
    /// <summary>
    /// Interaction logic for InputNames.xaml
    /// </summary>
    public partial class InputNames : Window
    {
        private Game game;
        public InputNames(Game g)
        {
            InitializeComponent();
            game = g;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            game.Player1.Name = txtPlayer1Name.Text;
            game.Player2.Name = txtPLayer2Name.Text;
            this.Close();
        }
    }
}
