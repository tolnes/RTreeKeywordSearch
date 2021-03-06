﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCodeApproach
{
    static class Distance
    {
        const double PI = 3.141592653589793;
        const double Radius = 6371;
        static int distanceCalculated;

        static public double Radians(double x)
        {
            return x * PI / 180;
        }

        static public double DistanceBetweenObjects(double lng1, double lat1, double lng2, double lat2)
        {
            double dlng = Radians(lng2 - lng1);
            double dlat = Radians(lat2 - lat1);

            double a = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) + Math.Cos(Radians(lat1)) * Math.Cos(Radians(lat2)) * (Math.Sin(dlng / 2) * Math.Sin(dlng / 2));
            double angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return Math.Round(angle * Radius, 1);
        }

        static public List<Restaurant> CalculateDistance(List<Restaurant> listOfAllObjects, double userLocationLng, double userLocationLat)
        {
            var calculatedObjects = new List<Restaurant>();            

            foreach (var obj in listOfAllObjects)
            {
                var distance = DistanceBetweenObjects(userLocationLng, userLocationLat, obj.Longitude, obj.Latitude);                
                obj.Distance = distance;
                calculatedObjects.Add(obj);
                distanceCalculated++;
            }

            Console.WriteLine(distanceCalculated);
            return calculatedObjects;
        }
    }
}
