using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabOne
{
    public class VideoGame : IComparable<VideoGame>
    {

        public string name;
        public string platform;
        public int year;
        public string genre;
        public string publisher;
        public string NA_sales;
        public string EU_sales;
        public string JP_sales;
        public string other_sales;
        public string global_sales;



        public static VideoGame FromFile(string line)
        {

            //read first line bc it doesnt have real info
            //read values to array
            string[] info = line.Split(',');
            VideoGame reader = new VideoGame();
            //set values in array
            reader.name = Convert.ToString(info[0]);
            reader.platform = Convert.ToString(info[1]);
            reader.year = Convert.ToInt32(info[2]);
            reader.genre = Convert.ToString(info[3]);
            reader.publisher = Convert.ToString(info[4]);
            reader.NA_sales = Convert.ToString(info[5]);
            reader.EU_sales = Convert.ToString(info[6]);
            reader.JP_sales = Convert.ToString(info[7]);
            reader.other_sales = Convert.ToString(info[8]);
            reader.global_sales = Convert.ToString(info[9]);
            return reader;

        }

        public static string ToString(VideoGame videogame)
        {
            return videogame.name;
        }

        public int CompareTo(VideoGame other)
        {
            if (other == null) return 1; // Current instance is greater than a null reference.

            return string.Compare(this.name, other.name, StringComparison.OrdinalIgnoreCase);
        }

        public static void PublisherStatistics(List<VideoGame> list, string publisher)
        {
            int total = list.Count;
            int publisherGameCount = list.Count(game => game.publisher == publisher);

            double percentage = ((double)publisherGameCount / total) * 100;
            percentage = (double)System.Math.Round(percentage, 2);
            Console.WriteLine("Out of " + total + " games, " + publisherGameCount + " are made by " + publisher + ", which is " + percentage + "%.");
        }

        public static void GenreStatistics(List<VideoGame> list, string genre)
        {
            int total = list.Count;
            int genreGameCount = list.Count(game => game.genre == genre);
            double percentage = ((double)genreGameCount / total) * 100;
            //rounding
            percentage = (double)System.Math.Round(percentage, 2);
            Console.WriteLine("Out of " + total + " games, " + genreGameCount + " are of the genre " + genre + ", which is " + percentage + "%.");
        }

        public static void PublisherData(List<VideoGame> list, string publisher)
        {
            
            var pubGames = list.Where(videogame => videogame.publisher.Contains(publisher)).Select(videogame => videogame.name).ToList();
            pubGames.Sort();
            foreach (var name in pubGames)
            {
                Console.WriteLine(name);
            }
        }
        public static void GenreData(List<VideoGame> list, string genre)
        {
            var genreGames = list.Where(videogame => videogame.genre.Contains(genre)).Select(videogame => videogame.name).ToList();
            genreGames.Sort();
            foreach (var name in genreGames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
