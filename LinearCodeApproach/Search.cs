using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCodeApproach
{
    public class Search
    {
        int distanceCalculated;

        private List<Restaurant> LoadData()
        {
            var allRest = new List<Restaurant>();

            using (var reader = new StreamReader(@"C:\Users\Tolnes\Documents\Sync\Infomations teknologi\6. Semester\Bachelor\500k.csv"))
            {
                int i = 0;
                while (!reader.EndOfStream)
                {
                    i++;
                    var line = reader.ReadLine();
                    var values = line.Split('|');
                    if (values.Length == 6)
                    {
                        var kw = values[5].Split(';');
                        allRest.Add(new Restaurant(values[4], kw.ToList(), Convert.ToDouble(values[2]), Convert.ToDouble(values[3])));
                    }
                    else
                    {
                        Console.WriteLine(i.ToString());
                        Console.WriteLine(values[1]);
                    }
                }
                return allRest;
            }
        }

        /// <summary>
        /// Linear Search 
        /// </summary>
        /// <param name="lat">Users Latitude</param>
        /// <param name="lng">Users Longitude</param>
        /// <param name="all">List of All restaurants</param>
        /// <param name="k">The desired number of results</param>
        /// <param name="keywords">User defined keywords</param>
        /// <param name="result">List to store the results</param>
        private void LinearSearch(double lat, double lng, List<Restaurant> all, int k, List<string> keywords, out List<Restaurant> result)
        {
            result = new List<Restaurant>();
            var nearby = new List<Restaurant>();

            nearby = Distance.CalculateDistance(all, lat, lng).ToList();

            nearby = nearby.OrderBy(r => r.Distance).ToList();

            foreach (var rest in nearby)
            {
                /*** search for all keywords ***/
                //if (keywords.All(kw => rest.Keywords.Contains(kw)))
                //    result.Add(rest);

                /*** search for any keywords ***/
                if (keywords.Any(kw => rest.Keywords.Contains(kw)))
                    result.Add(rest);

                if (result.Count == k)
                {
                    break;
                }
            }
        }

        //Initializes and invokes the linear search algorithm
        public void SearchWithLinearSearch()
        {
            var lat = 57.04;
            var lng = 9.92;

            var allRest = new List<Restaurant>();
            allRest = LoadData();

            //Initializes the list of keywords to search for
            var keywords = new List<string>();
            keywords.Add("Italian");
            keywords.Add("Pizza");
            keywords.Add("Pasta");
            //keywords.Add("Burger");
            //keywords.Add("American");
            //keywords.Add("Pie");
            //keywords.Add("Milkshake");
            //keywords.Add("Fried chicken");

            var result = new List<Restaurant>();

            var sw = new Stopwatch();
            var timeList = new List<string>();

            for (int i = 1; i <= 100; i++)
            {
                sw.Start();
                LinearSearch(lng, lat, allRest, 10, keywords, out result);
                sw.Stop();
                var time = sw.Elapsed.TotalMilliseconds;
                timeList.Add(Convert.ToString(time));
                Console.WriteLine(time);
                sw.Reset();
            }

            foreach (var rest in result)
            {
                Console.WriteLine(rest);
            }

            Console.WriteLine(distanceCalculated);

            Console.ReadLine();
        }
    }
}
