using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
