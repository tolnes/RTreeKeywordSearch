using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCodeApproach
{
    public class Restaurant
    {
        public string Name { get; set; }        
        public List<string> Keywords { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Distance { get; set; }

        private List<Restaurant> restaurants;

        public Restaurant()
        {

        }
       
        public Restaurant(string name, List<string> keywords, double lat, double lng)
        {
            Name = name;
            Keywords = keywords;
            Latitude = lat;
            Longitude = lng;
        }        

        public override string ToString()
        {
            return Name;
        }

        public void AddRestaurantsToList(List<Restaurant> list)
        {
            //var kw1 = new List<string>();
            //kw1.Add("taco");
            //kw1.Add("cola");
            //kw1.Add("pasta");
            //kw1.Add("pizza");

            //var kw2 = new List<string>();
            //kw2.Add("pizza");
            //kw2.Add("fanta");

            //var kw3 = new List<string>();
            //kw3.Add("indian");
            //kw3.Add("fanta");

            //var kw4 = new List<string>();
            //kw4.Add("steak");
            //kw4.Add("beer");
            //kw4.Add("cola");

            //var kw5 = new List<string>();
            //kw5.Add("pizza");
            //kw5.Add("cola");
            //kw5.Add("pasta");

            //var r1 = new Restaurant("Nordkraft Pizza", "Pizza house", kw1, 9.930827, 57.045484);
            //var r2 = new Restaurant("Fakta cafe", "Cafe", kw1, 9.967332, 57.013513);
            //var r3 = new Restaurant("Indian AAU", "Indian", kw3, 9.985000, 57.015000);
            //var r4 = new Restaurant("Ikea cafe", "Cafe", kw2, 9.864915, 56.995899);

            //var r5 = new Restaurant("Flammen", "SteakHouse", kw4, 9.922040, 57.049943);
            //var r6 = new Restaurant("Malenes", "Pizza house", kw5, 9.988775, 57.017574);
            //var r7 = new Restaurant("McDonalds", "Burgers", kw4, 9.921532, 57.048948);
            //var r8 = new Restaurant("Kantinen Cass", "Kantiene", kw2, 9.988571, 57.012585);           

            //list.Add(r1);
            //list.Add(r2);
            //list.Add(r3);
            //list.Add(r4);
            //list.Add(r5);
            //list.Add(r6);
            //list.Add(r7);
            //list.Add(r8);
        }

        public List<Restaurant> GetAllRestaurants()
        {
            restaurants = new List<Restaurant>();
            AddRestaurantsToList(restaurants);
            return restaurants;
        }
    }
}
