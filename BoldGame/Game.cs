using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoldGame
{
    public class Game
    {
        private int numOfCards = 81;

        public Card[,] Board { get; set; }
        public Card[] Deck { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public int PlayerTurn { get; set; }
        public List<Card> OpenedCards { get; set; }

        public Game()
        {
            PlayerTurn = 1;
            Board = new Card[4, 5];
            OpenedCards = new List<Card>();
            Player1 = new Player();
            Player2 = new Player();
            Deck = new Card[numOfCards];
            CreateDeck();
            CreateBoard();
        }

        private void CreateDeck()
        {
            int i = 0;
            foreach (Card.Shape shape in Enum.GetValues(typeof(Card.Shape)))
            {
                foreach (Card.Size size in Enum.GetValues(typeof(Card.Size)))
                {
                    foreach (Card.Color color in Enum.GetValues(typeof(Card.Color)))
                    {
                        foreach (Card.Pattern pattern in Enum.GetValues(typeof(Card.Pattern)))
                        {
                            string path = shape.ToString().Substring(0, 1) + size.ToString().Substring(0, 1) + color.ToString().Substring(0, 1) + pattern.ToString().Substring(0, 1) + ".jpg";
                            Deck[i] = new Card(shape, size, color, pattern, path.ToLower());

                            Console.WriteLine(Deck[i].ToString());
                            i++;

                        }
                    }
                }
            }
            Shuffle();

        }

        private void CreateBoard()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Board[i, j] = Deck[0];
                    Console.WriteLine(i + ":" + j + " - " + Deck[0].ToString());
                    Deck = Deck.Skip(1).ToArray();
                }
            }
        }

        private void Shuffle()
        {
            Random rand = new Random();
            Card x;
            for (int shuffletimes = 0; shuffletimes < 100; shuffletimes++)
            {
                for (int i = 0; i < numOfCards; i++)
                {
                    int secondCardIndex = rand.Next(80);
                    x = this.Deck[i];
                    this.Deck[i] = this.Deck[secondCardIndex];
                    this.Deck[secondCardIndex] = x;
                }
            }
        }

        public bool CompareCards()
        {
            bool isColorMatch = true;
            bool isShapeMatch = true;
            bool isSizeMatch = true;
            bool isPatternMatch = true;

            Card initialCard = OpenedCards.First();
            foreach (Card checkCard in OpenedCards.Skip(1))
            {
                if (initialCard.MyColor != checkCard.MyColor)
                {
                    isColorMatch = false;
                }
            }
            foreach (Card checkCard in OpenedCards.Skip(1))
            {
                if (initialCard.MyPattern != checkCard.MyPattern)
                {
                    isPatternMatch = false;
                }
            }
            foreach (Card checkCard in OpenedCards.Skip(1))
            {
                if (initialCard.MySize != checkCard.MySize)
                {
                    isSizeMatch = false;
                }
            }
            foreach (Card checkCard in OpenedCards.Skip(1))
            {
                if (initialCard.MyShape != checkCard.MyShape)
                {
                    isShapeMatch = false;
                }
            }
            return isColorMatch || isShapeMatch || isSizeMatch || isPatternMatch;
        }

        public bool UpdateBoard()
        {
            if (Deck.Length >= OpenedCards.Count)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (OpenedCards.Contains(Board[i, j]))
                        {
                            Board[i, j] = Deck[0];
                            Deck = Deck.Skip(1).ToArray();
                        }
                    }
                }
                OpenedCards.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GivePoints()
        {
            int score = (int)Math.Pow(OpenedCards.Count, 2);
            if (PlayerTurn == 1)
            {
                Player1.Score += score;
            }
            else
            {
                Player2.Score += score;
            }
        }

        public Player EndGame()
        {
            if(Player1.Score > Player2.Score)
            {
                return Player1;
            }
            return Player2;
        }
    }
}
