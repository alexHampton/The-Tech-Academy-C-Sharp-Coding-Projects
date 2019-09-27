using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public struct Card
    {
        public Suit Suit { get; set; } // Each card has a state of Suit and Face, both of which are enumerables as defined below.
        public Face Face { get; set; }
        public override string ToString() // Override ToString() for Card class.
        {
            return string.Format("{0} of {1}", Face, Suit);
        }
    }
    public enum Suit
    {
        Clubs, // Enums have underlying values, which can be manually changed.
        Diamonds,
        Hearts,
        Spades
    }

    public enum Face
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
}
