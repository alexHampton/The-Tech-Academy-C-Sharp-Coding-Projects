using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPracticeBaseballTeam
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseballTeam sm = new BaseballTeam("Seattle Mariners", "Safeco Field");
            sm.PlayGame(6, 3);

            

            Console.WriteLine(sm.ToString());
            Console.Read();
        }

        
    }
}
