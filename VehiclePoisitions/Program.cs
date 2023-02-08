﻿using VehiclePoisitions.Repositories;
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

            foreach(var position in vehiclePositionList)
            {
                 var nearestPosition = vehicleList.GetNearestNeighbours(new[] { position.Longitude, position.Latitude },1);

                 Console.WriteLine("Possition (Longitude: {0} Lattitude: {1} ) Nearest Coords: {2}",position.Longitude,position.Latitude, nearestPosition.First());
              
            }
            watch.Stop();
            Console.WriteLine("Elapsed time: {0}ms", watch.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}