using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            double distance = Distance(new Location
            {
                Lat = 22.7196,
                Lon = 75.8577
            }, new Location
            {
                Lat = 22.3039,
                Lon = 70.8022
            });

            Console.WriteLine("Distance is {0}", Math.Round(distance));
            Console.ReadLine();
        }

        public static double Distance(Location source, Location destination)
        {
            int radius = 6371; // Radius of earth in Kilometer

            double dlat = MathExtensions.Radians(destination.Lat - source.Lat);
            double dlon = MathExtensions.Radians(destination.Lon - source.Lon);

            double a = Math.Sin(dlat / 2) * Math.Sin(dlat / 2) + Math.Cos(MathExtensions.Radians(source.Lat)) * Math.Cos(MathExtensions.Radians(destination.Lat)) * Math.Sin(dlon / 2) * Math.Sin(dlon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double d = radius * c;
            return d;
        }
    }

    public class Location
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }

    public static class MathExtensions
    {
        public static double Radians(double difference)
        {
            return (Math.PI / 180) * difference;
        }
    }
}
