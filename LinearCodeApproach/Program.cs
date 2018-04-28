using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCodeApproach
{
    class Program
    {
        static void Main(string[] args)
        {
            var lat = 57.017825;
            var lng = 9.993267;

            var restaurant = new Restaurant();
            var allRest = new List<Restaurant>();
            allRest = restaurant.GetAllRestaurants();

            var keywords = new List<string>();
            keywords.Add("pizza");
            keywords.Add("cola");

            var result = new List<Restaurant>();
            LinearSearch(lat, lng, allRest, 2, keywords, out result);

            foreach (var rest in result)
            {
                Console.WriteLine(rest);
            }

            Console.ReadLine();
            
        }
        
        static void LinearSearch(double lat, double lng, List<Restaurant> all, int k, List<string> keywords, out List<Restaurant> result)
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
    }
}
