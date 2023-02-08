using KdTree;
using VehiclePoisitions.Models;

namespace VehiclePoisitions
{
    public  interface IVehicleRepository
    {     
       List<Coordinate> GetAllVehiclePositions();
        KdTree<float, string> GetVehiclesList();
    }
}
