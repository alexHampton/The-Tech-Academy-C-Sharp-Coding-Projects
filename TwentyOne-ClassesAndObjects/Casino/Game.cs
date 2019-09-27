using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public abstract class Game //Abstract class: Would never be instantiated. Makes it impossible for class to be used as an object.
    {
        private List<Player> _players = new List<Player>();
        private Dictionary<Player, int> _bets = new Dictionary<Player, int>();
        public List<Player> Players { get { return _players; } set { _players = value; } }
        public string Name { get; set; }
        public Dictionary<Player, int> Bets { get { return _bets; } set { _bets = value; } } // Used to keep track of all bets per game.
        

        // Abstract method.
        public abstract void Play(); // Any class inheriting this class (Game) must implement this method.
        public virtual void ListPlayers() // virtual: this method is inherited, but has the ability to override it.
        {
            foreach (Player player in Players)
            {
                Console.WriteLine(player.Name);
            }
        }
    }
}
