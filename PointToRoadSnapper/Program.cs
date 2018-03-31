using RoadScanner.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PointToRoadSnapper
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("(1) snap point    (2) snap Trip   (3)snap Range");
            string choiceText= Console.ReadLine();
            while (choiceText != "x") {
                int choice =int.Parse(choiceText);
                int affectedRowsNum = 0;
                switch (choice)
                {
                    case 1:
                        SnapPointToRoad();
                        break;
                    case 2:
                        Console.WriteLine("Enter tripID:");
                        string tripId = Console.ReadLine();
                       
                        int id = int.Parse(tripId);
                        affectedRowsNum = SnapTripToRoad(id);
                        Console.WriteLine("affected Rows :" + affectedRowsNum);
                        
                        break;
                    case 3:
                        Console.WriteLine("Enter startID:");
                        int startId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter endID:");
                        int endId = int.Parse(Console.ReadLine());

                        
                        affectedRowsNum =  SnapSampleRangeToRoad(startId, endId);
                        Console.WriteLine("affected Rows :" + affectedRowsNum);

                        break;
                        
                    default:
                        break;
                }

                Console.WriteLine("(1) snap point    (2) snap Trip   (3)snap Range");
                choiceText = Console.ReadLine();
            }
           


        }

        public static int SnapTripToRoad(int tripId)
        {
            TripPathService service = new TripPathService();
            var measurements = service.GetTripMeasuremnts(tripId);

            measurements.MapToSnappedLocations();
            return service.SaveChanges();
        }

        public static int SnapSampleRangeToRoad(int FromSampleId ,int ToSampleId)
        {
            TripPathService service = new TripPathService();
            var measurements = service.GetTripMeasuremnts(FromSampleId,ToSampleId);

            measurements.MapToSnappedLocations();
            return service.SaveChanges();
        }

        public static void SnapPointToRoad()
        {
            string locationPoints = Console.ReadLine();
            while (locationPoints != "x")
            {
                string result = "";
                using (var client = new HttpClient())
                {
                    string path = String.Format("https://roads.googleapis.com/v1/snapToRoads?path={0}&key={1}", locationPoints, Constants.GoogleMapsRoadsAPIKey);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        SnappedPath snappedPath = response.Content.ReadAsAsync<SnappedPath>().Result;

                        if (snappedPath != null && snappedPath.snappedPoints != null && snappedPath.snappedPoints.Count() > 0)
                        {
                            for (int j = 0; j < snappedPath.snappedPoints.Count(); j++)
                            {
                                result += snappedPath.snappedPoints.ElementAt(j).location.latitude + "," + snappedPath.snappedPoints.ElementAt(j).location.longitude + " ";
                            }
                        }

                    }
                }
                Console.WriteLine(result);
                locationPoints = Console.ReadLine();
            }
        }
    }
}
