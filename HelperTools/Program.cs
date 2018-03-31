using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperTools
{
    class Program
    {
        static void Main(string[] args)
        {
            var lat1 = double.Parse(Console.ReadLine());
            var long1 = double.Parse(Console.ReadLine());
            var lat2 = double.Parse(Console.ReadLine());
            var long2 = double.Parse(Console.ReadLine());
            var distance =DistanceCalculator.getDistanceFromLatLonInKm(lat1, long1, lat2, long2);
            Console.WriteLine(distance);
            Console.ReadLine();
        }


    }
}
