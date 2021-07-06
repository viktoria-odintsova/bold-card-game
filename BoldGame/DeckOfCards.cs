using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoldGame
{
    public class DeckOfCards 
    {
        public const int NumOfCards = 81;

        public Card[] Deck;

        public DeckOfCards()
        {
            this.Deck = new Card[NumOfCards];
        }

        public void CreateDeck()
        {
            int i = 0;
            foreach(Card.Shape shape in Enum.GetValues(typeof(Card.Shape)))
            {
                foreach(Card.Size size in Enum.GetValues(typeof(Card.Size)))
                {
                    foreach(Card.Color color in Enum.GetValues(typeof(Card.Color)))
                    {
                        foreach(Card.Pattern pattern in Enum.GetValues(typeof(Card.Pattern)))
                        {
                            string path = shape.ToString().Substring(0, 1) + size.ToString().Substring(0, 1) + color.ToString().Substring(0, 1) + pattern.ToString().Substring(0,1);
                            Deck[i] = new Card(shape, size, color, pattern, path);

                            Console.WriteLine(Deck[i].ToString().ToLower());
                            i++;
                            
                        }
                    }
                }
            }
            Shuffle();

        }

        public void Shuffle()
        {
            Random rand = new Random();
            Card x;
            for (int shuffletimes = 0; shuffletimes < 100; shuffletimes++)
            {
                for (int i = 0; i < NumOfCards; i++)
                {
                    int secondCardIndex = rand.Next(80);
                    x = this.Deck[i];
                    this.Deck[i] = this.Deck[secondCardIndex];
                    this.Deck[secondCardIndex] = x;
                }
            }
        }
    }
}
