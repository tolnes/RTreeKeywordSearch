using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTreeCodeApproach
{
    public class Search
    {
        //Calculates the minimum distance from a point to a minimum bounding rectangle
        double MinDistance(double objLng, double objLat, double mbrMinY, double mbrMaxY, double mbrMinX, double mbrMaxX)
        {
            var objBounds = new double[4];
            objBounds[0] = objLng;
            objBounds[1] = objLat;
            objBounds[2] = objLng;
            objBounds[3] = objLat;

            var MBR = new double[4];
            MBR[0] = mbrMinY;
            MBR[1] = mbrMaxY;
            MBR[2] = mbrMinX;
            MBR[3] = mbrMaxX;

            double sum = 0.0;
            double r;
            int i;

            for (i = 0; i < 2; i++)
            {
                if (objBounds[i] < MBR[2 * i])
                    r = MBR[2 * i];
                else
                {
                    if (objBounds[i] > MBR[2 * i + 1])
                        r = MBR[2 * i + 1];
                    else
                        r = objBounds[i];
                }

                sum += Math.Pow(objBounds[i] - r, 2);
            }
            return (Math.Sqrt(sum));
        }

        /// <summary>
        /// Incremental nearest neighbor
        /// </summary>
        /// <param name="lat">Users latitude</param>
        /// <param name="lng">Users longitude</param>
        /// <param name="tree">R tree</param>
        /// <param name="k">Desired number of results</param>
        /// <param name="keywords">User defined keywords</param>
        /// <param name="result">List to store results</param>
        public void IncNearest(double lat, double lng, RBush<Restaurant> tree, int k,
            List<string> keywords, out List<ISpatialData> result)
        {
            PriorityQueue<ISpatialData> queue = new PriorityQueue<ISpatialData>();
            queue.Add(0, tree.root);
            result = new List<ISpatialData>();
            bool kFound = false;

            while (queue.Count != 0)
            {
                if (kFound)
                    break;

                var element = queue.RemoveMin();

                if (element.Height >= 2) //non leaf node
                {
                    foreach (var child in element.Children)
                    {
                        double priority = MinDistance(lng, lat, child.Envelope.MinY, child.Envelope.MaxY, child.Envelope.MinX, child.Envelope.MaxX);
                        queue.Add(priority, child);
                        child.Distance = priority;

                    }
                }
                else if (element.IsLeaf) //leaf node
                {
                    foreach (var obj in element.Children)
                    {
                        double priority = MinDistance(lng, lat, obj.Envelope.MinY, obj.Envelope.MaxY, obj.Envelope.MinX, obj.Envelope.MaxX);
                        queue.Add(priority, obj);
                        obj.Distance = priority;
                    }
                }
                else //object
                {
                    /*** search for all keywords ***/
                    //if(keywords.All(kw => element.Keywords.Contains(kw)))
                    //    result.Add(element);

                    /*** search for any keywords ***/
                    if (keywords.Any(kw => element.Keywords.Contains(kw)))
                        result.Add(element);

                    if (result.Count == k)
                    {
                        kFound = true;
                    }
                }
            }
        }


        //Use this to initalize the R tree and invoke the INN algorithm
        public void SearchWithINN()
        {
            var tree = new RBush<Restaurant>(maxEntries: 4);

            var restaurant = new Restaurant();
            var allRest = new List<Restaurant>();
            allRest = restaurant.GetAllRestaurants();

            tree.BulkLoad(allRest);

            var result = new List<ISpatialData>();
            var keywords = new List<string>();
            //keywords.Add("pizza");
            keywords.Add("fanta");
            keywords.Add("beer");

            IncNearest(9.993267, 57.017825, tree, 5, keywords, out result); //query location Føtex Aalborg Øst

            foreach (var rest in result)
            {
                Console.WriteLine(rest);
            }
        }
    }
}
