using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTreeCodeApproach
{
    public class Restaurant : ISpatialData, IComparable<Restaurant>
    {
        public string Name { get; set; }       
        public List<string> Keywords { get; set; }
        private Envelope _envelope;
        public bool IsLeaf { get; set; }
        public int Height { get; set; }
        public List<ISpatialData> Children { get; }
        public double Distance { get; set; }

        private List<Restaurant> restaurants;

        public Restaurant()
        {

        }

        public Restaurant(double minX, double minY, double maxX, double maxY)
        {
            _envelope = new Envelope(
                minX: minX,
                minY: minY,
                maxX: maxX,
                maxY: maxY);
        }

        public Restaurant(string name, List<string> keywords, double minX, double minY, double maxX, double maxY)
        {
            Name = name;           
            Keywords = keywords;
            IsLeaf = false;
            Height = 0;
            Children = new List<ISpatialData>();

            _envelope = new Envelope(
                minX: minX,
                minY: minY,
                maxX: maxX,
                maxY: maxY);
        }

        public ref readonly Envelope Envelope => ref _envelope;

        public IEnumerator<ISpatialData> GetEnumerator()
        {
            foreach (var rest in restaurants)
            {
                yield return rest;
            }
        }

        public int CompareTo(Restaurant other)
        {
            if (this.Envelope.MinX != other.Envelope.MinX)
                return this.Envelope.MinX.CompareTo(other.Envelope.MinX);
            if (this.Envelope.MinY != other.Envelope.MinY)
                return this.Envelope.MinY.CompareTo(other.Envelope.MinY);
            if (this.Envelope.MaxX != other.Envelope.MaxX)
                return this.Envelope.MaxX.CompareTo(other.Envelope.MaxX);
            if (this.Envelope.MaxY != other.Envelope.MaxY)
                return this.Envelope.MaxY.CompareTo(other.Envelope.MaxY);
            return 0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
