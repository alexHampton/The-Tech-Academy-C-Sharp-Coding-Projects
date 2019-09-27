using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Deck
    {
        public Deck()
        {
            Cards = new List<Card>(); // Deck class has a Cards Obj, which is a List made up of Card Objects.

            for(int i = 0; i < 13; i++) // For each face value...
            {
                for(int j = 0; j < 4; j++) // For each suit value...
                {
                    Card card = new Card();
                    card.Face = (Face)i; // Convert i to Face enum value.
                    card.Suit = (Suit)j; // Convert j to Suit enum value.
                    Cards.Add(card); // Add card to Deck of Cards.
                }
            }            
        }
        public List<Card> Cards { get; set; }

        // Method used to shuffle the deck
        public void Shuffle(int times = 1) // times is optional, with a default value of 1
        {
            for (int i = 0; i < times; i++)
            {
                List<Card> TempList = new List<Card>();
                Random random = new Random();

                while (Cards.Count > 0)
                {
                    int randomIndex = random.Next(0, Cards.Count);
                    TempList.Add(Cards[randomIndex]);
                    Cards.RemoveAt(randomIndex);
                }
                this.Cards = TempList;
            }
        }
    }
}
