using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoldGame
{
    public class DeckOfCards : Card
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
            foreach(Shape shape in Enum.GetValues(typeof(Shape)))
            {
                foreach(Size size in Enum.GetValues(typeof(Size)))
                {
                    foreach(Color color in Enum.GetValues(typeof(Color)))
                    {
                        foreach(Pattern pattern in Enum.GetValues(typeof(Pattern)))
                        {
                            Deck[i] = new Card(shape, size, color, pattern, "imagepath");

                            Console.WriteLine(Deck[i].ToString());
                            i++;
                            
                        }
                    }
                }
            }
            Shuffle();

        }

        public void Shuffle()
        {

        }
    }
}
