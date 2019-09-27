using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{

    public class Player
    {
        public Player() : this("Number 1", 9001) { }
        public Player(string name) : this(name, 100)
        {

        }
        public Player(string name, int beginningBalance) // To construct a Player object, give a name and a beginning balance.
        {
            Hand = new List<Card>();
            Balance = beginningBalance;
            Name = name;
        }
        private List<Card> _hand = new List<Card>();
        public List<Card> Hand { get { return _hand; } set{ _hand = value; } }
        public int Balance { get; set; }
        public string Name { get; set; }
        public bool IsActivelyPlaying { get; set; }
        public bool Stay { get; set; }
        public Guid Id { get; set; }

        public bool Bet(int amount)
        {
            if (Balance - amount < 0)
            {
                Console.WriteLine("You don't have enough to place that bet.");
                return false;
            }
            else
            {
                Balance -= amount;
                return true;
            }
        }

        public static Game operator+ (Game game, Player player) // Overloaded operator
        {
            game.Players.Add(player);
            return game;
        }
        public static Game operator- (Game game, Player player) // Overloaded operator
        {
            game.Players.Remove(player);
            return game;
        }
    }
}
