using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Casino;
using Casino.TwentyOne;

namespace TwentyOne_ClassesAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            //  VAR, CONST, CONSTRUCTION CHAIN PRACTICE
            //var playerNum1 = new Player();
            //const string theGreatestPlayerEver = "Number 1";
            //var newPlayer = new Player("Alex");
            //var newDictionary = new Dictionary<string, string>();



            const string casinoName = "Grand Hotel and Casino";
            Console.WriteLine("Welcome to the {0}. Let's start by telling me your name.", casinoName);
            string playerName = Console.ReadLine(); // Used to create instance of player class.
            if (playerName.ToLower() == "admin")
            {
                List<ExceptionEntity> Exceptions = ReadExceptions();
                foreach (var exception in Exceptions)
                {
                    Console.Write(exception.Id + " | ");
                    Console.Write(exception.ExceptionType + " | ");
                    Console.Write(exception.ExceptionMessage + " | ");
                    Console.Write(exception.TimeStamp + " | ");
                    Console.WriteLine();
                }
                Console.Read();
                return;
            }

            // Handles Format Exception
            bool validAnswer = false;
            int bank = 0;
            while (!validAnswer || bank <= 0) 
            {
                Console.WriteLine("And how much money did you bring today?");
                validAnswer = Int32.TryParse(Console.ReadLine(), out bank); // output only happens if TryParse succeeds.
                if (!validAnswer || bank <= 0) Console.WriteLine("Please enter digits greater than 0 only, no decimals.");
            }

            Console.WriteLine("Hello, {0}. Would you like to join a game of 21 right now?", playerName);
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "yeah" || answer == "sure" || answer == "y" || answer == "ya")
            {
                Player player = new Player(playerName, bank); // Create a new Player Object using the name and money the user inputted.
                player.Id = Guid.NewGuid();
                using (StreamWriter file = new StreamWriter(@"C:\Users\alext\OneDrive\Documents\GitHub\The-Tech-Academy-Basic-C-Sharp-Projects\Logs\log.txt", true))
                {
                    file.WriteLine(player.Id);
                }
                Game game = new TwentyOneGame(); // polymorphism so that we can use those overloaded operation properties.
                game += player;
                player.IsActivelyPlaying = true;
                while (player.IsActivelyPlaying && player.Balance > 0)
                {
                    try
                    {
                        game.Play(); // Set this to play one hand. After that, check to see if the player wants to continue playing. If so, continue While loop.
                    }
                    catch (FraudException ex)
                    {
                        Console.WriteLine(ex.Message);
                        UpdateDbWithException(ex);
                        Console.ReadLine();
                        return;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred. Please contact your System Administrator.");
                        UpdateDbWithException(ex);
                        Console.ReadLine();
                        return;
                    }
                }
                game -= player;
                Console.WriteLine("Thank you for playing!");
            }
            Console.WriteLine("Feel free to look around the casino. Bye for now.");
            Console.Read();



            /* LAMBDA EXPRESSION PRACTICE */

            //int count = deck.Cards.Count(x => x.Face == Face.Ace); // .Count Lambda function.
            //Console.WriteLine(count);
            //List<Card> newList = deck.Cards.Where(x => x.Face == Face.King).ToList();
            //List<int> numberList = new List<int> { 1, 2, 3, 4365, 234, 34 };
            //int sum = numberList.Sum();
            //int y = numberList.Sum(x => x += 5);
            //int max = numberList.Max();
            //int min = numberList.Min();
            //int chain = numberList.Where(x => x > 20).Sum();

            //foreach (Card card in newList)
            //{
            //    Console.WriteLine(card.Face + " of " + card.Suit);
            //}

            //Game game = new TwentyOneGame();
            //game.Players = new List<Player>();
            //    Player player = new Player() { Name = "Alex" };
            //game += player;
            //    game -= player;


            //// Overload method
            //public static Deck Shuffle(Deck deck, int times)
            //{
            //    for (int i = 0; i < times; i++)
            //    {
            //        deck = Shuffle(deck);
            //    }
            //    return deck;
            //}

            //// DateTime Practice
            //DateTime yearOfBirth = new DateTime(1995, 5, 23, 8, 32, 45); // Multiple overloads
            //DateTime yearOfGraduation = new DateTime(2013, 6, 1, 16, 34, 22);

            //TimeSpan ageAtGraduation = yearOfGraduation - yearOfBirth;
            //Console.WriteLine(yearOfGraduation <= yearOfBirth);
        }

        private static void UpdateDbWithException(Exception ex)
        {
            string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=TwentyOneGame;
                                        Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                        TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                                        MultiSubnetFailover=False";
            string queryString = @"INSERT INTO Exceptions (ExceptionType, ExceptionMessage, TimeStamp) VALUES
                                    (@ExceptionType, @ExceptionMessage, @TimeStamp)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@ExceptionType", SqlDbType.VarChar);
                command.Parameters.Add("@ExceptionMessage", SqlDbType.VarChar);
                command.Parameters.Add("@TimeStamp", SqlDbType.DateTime);

                command.Parameters["@ExceptionType"].Value = ex.GetType().ToString();
                command.Parameters["@ExceptionMessage"].Value = ex.Message;
                command.Parameters["@TimeStamp"].Value = DateTime.Now;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private static List<ExceptionEntity> ReadExceptions()
        {
            string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=TwentyOneGame;
                                        Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                        TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                                        MultiSubnetFailover=False";
            string queryString = @"SELECT Id, ExceptionType, ExceptionMessage, TimeStamp FROM Exceptions";

            List<ExceptionEntity> Exceptions = new List<ExceptionEntity>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ExceptionEntity exception = new ExceptionEntity();
                    exception.Id = Convert.ToInt32(reader["Id"]);
                    exception.ExceptionType = reader["ExceptionType"].ToString();
                    exception.ExceptionMessage = reader["ExceptionMessage"].ToString();
                    exception.TimeStamp = Convert.ToDateTime(reader["TimeStamp"]);
                    Exceptions.Add(exception);
                }
                connection.Close();
            }
            return Exceptions;
        }

        //public enum DaysOfTheWeek
        //{
        //    Monday,
        //    Tuesday,
        //    Wednesday,
        //    Thursday,
        //    Friday,
        //    Saturday,
        //    Sunday
        //}
    }
}
