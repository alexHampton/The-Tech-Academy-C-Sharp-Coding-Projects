using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPracticeBaseballTeam
{
    class BaseballTeam
    {
        public BaseballTeam(string n, string s)
        {
            this.name = n;
            this.stadium = s;
        }

        public void PlayGame(int runsFor, int runsAgainst)
        {
            if (runsFor > runsAgainst)
            {
                this.wins++;
            }
            else
            {
                this.defeats++;
            }
        }

        public override string ToString()
        {
            return this.name + ", play at " + this.stadium + ": " +
                " W" + this.wins + " L" + this.defeats;
        }

        public string name;
        public string stadium;
        public int wins = 0;
        public int defeats = 0;

    }
}
