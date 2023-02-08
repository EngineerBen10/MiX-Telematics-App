using VehiclePoisitions.Repositories;
using System.Diagnostics;
namespace VehiclePosition
{
    internal class Program
    {
        private const int VEHICLE_COUNT = 2000000;
        private static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();


            VehicleRepository vehicleRepository = new VehicleRepository(VEHICLE_COUNT);
            var vehicleList = vehicleRepository.GetVehiclesList();
            var vehiclePositionList = vehicleRepository.GetAllVehiclePositions();
            var counter = 0;
            foreach(var position in vehiclePositionList)
            {
                counter++;
                 var nearestPosition = vehicleList.GetNearestNeighbours(new[] { position.Longitude, position.Latitude },1);

                 Console.WriteLine("Position: {0} Nearest Vehicle {1} Latitude: {2} Longitude: {3}",counter, nearestPosition.First().Value, nearestPosition.First().Point[1], nearestPosition.First().Point[0]);
              
            }
            watch.Stop();
            Console.WriteLine("Elapsed time: {0}ms", watch.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}