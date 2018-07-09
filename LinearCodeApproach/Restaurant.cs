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
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Distance { get; set; }
        public List<string> Keywords { get; set; }
        
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
    }
}
