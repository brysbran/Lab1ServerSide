namespace LabOne
{
    using System.IO;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    public class Program
    {

        static void Main(string[] args)
        {
            List<VideoGame> videogame = File.ReadAllLines("F:\\ETSU_Fall_23\\Server_Side\\Labs\\LabOne\\LabOne\\videogames.csv").Skip(1).Select(v => VideoGame.FromFile(v)).ToList();

            //the Sort(); method checks if VideoGame implements IComparable and internally calls the CompareTo method
            videogame.Sort();
            Console.WriteLine("Titles in Alphabetical Order:");
            for (int i = 121; i < 140; i++)
            {
                {
                    Console.WriteLine(videogame[i].name);
                }
            }
            Console.WriteLine("\n----------------------------------------------------------------------------------------------------------");
            //isolate and print ubisoft games, part 3
            Console.WriteLine("Ubisoft Games: ");
            var ubisoftGames = videogame.Where(videogame => videogame.publisher.Contains("Ubisoft")).Select(videogame => videogame.name).ToList();
            ubisoftGames.Sort();
            foreach(var name in  ubisoftGames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("\n------------------------------------------------------------------------------------------------------------");
            //part 4
            VideoGame.PublisherStatistics(videogame, "Ubisoft");
            Console.WriteLine("\n-------------------------------------------------------------------------------------------------------------");
            //part 5
            Console.WriteLine("List of Adventure Games: ");
            var adventureGames = videogame.Where(videogame => videogame.genre.Contains("Adventure")).Select(videogame => videogame.name).ToList();
            adventureGames.Sort();
            foreach(var name in adventureGames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("\n-------------------------------------------------------------------------------------------------------------");
            //part 6
            Console.WriteLine("ADVENTURE GAME STATS: ");
            VideoGame.GenreStatistics(videogame, "Adventure");

            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Hello! Please type the name of a video game publisher you would like statistics on!");
            string publisher = Console.ReadLine();
            VideoGame.PublisherData(videogame, publisher);
            VideoGame.PublisherStatistics(videogame, publisher);

            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Hello! Please type the name of a video game genre you would like statistics on!");
            string genre = Console.ReadLine();
            VideoGame.GenreData(videogame, genre);
            VideoGame.GenreStatistics(videogame, genre);
        }
    }
}
