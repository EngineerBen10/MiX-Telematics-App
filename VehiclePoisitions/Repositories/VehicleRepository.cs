using System;
using VehiclePoisitions.Models;
using KdTree.Math;
using KdTree;

namespace VehiclePoisitions.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private int _vehicleCount;
        

        public VehicleRepository(int vehicleCount)
        {
            _vehicleCount = vehicleCount;
        }

        public List<Coordinate> GetAllVehiclePositions()
        {



            var tempList = new List<Coordinate>
            {
                //Position 1
                new Coordinate()
                {
                    Latitude = 34.544909f,
                    Longitude = -102.100843f
                },

                //Position 2
                new Coordinate()
                {
                    Latitude = 32.345544f,
                    Longitude =  -99.123124f
                },


                //Position 3
                new Coordinate()
                {
                    Latitude = 33.234235f,
                    Longitude = -100.214124f
                },

             
                //Position 4
                new Coordinate()
                {
                    Latitude = 35.195739f,
                    Longitude = -95.348899f
                },

               //Position 5
                new Coordinate()
                {
                    Latitude = 31.895839f,
                    Longitude = -97.789573f
                },

              
                //Position 6
                new Coordinate()
                {
                    Latitude =  32.895839f,
                    Longitude = -101.789573f
                },


                //Position 7

                new Coordinate()
                {
                    Latitude = 34.115839f,
                    Longitude = -100.225732f
                },

                //Position 8
                new Coordinate()
                {
                    Latitude = 32.335839f,
                    Longitude = -99.992232f
                },
                 //Position 9
                new Coordinate()
                {
                    Latitude = 33.535339f,
                    Longitude = -94.792232f
                },

                 //Position 10
                new Coordinate()
                {
                    Latitude =  32.234235f,
                    Longitude =  -100.222222f
                }


            };

           
            return tempList;
        }

        public KdTree<float, string> GetVehiclesList()
        {
            var bytes = ReadFile();
            var vehicleList = new KdTree<float, string>(2, new FloatMath());
            try
            {

                if (bytes != null)
                {
                    using (var ms = new MemoryStream(bytes))
                    {
                        using (var br = new BinaryReader(ms))
                        {
                         
                            for (var i = 0; i < _vehicleCount; i++)
                            {
                                var vehicle = new Vehicle()
                                {
                                    PositionId = br.ReadInt32(),

                                    VehicleRegistration = ReadNullTerminated(br),
                                    Coord = new Coordinate()
                                    {
                                        Latitude = br.ReadSingle(),
                                        Longitude = br.ReadSingle(),                                     
                                    },

                                    RecordedTimeUTC = GetDTCTime(br.ReadUInt64())
                                };

                                vehicleList.Add(new[] { vehicle.Coord.Longitude, vehicle.Coord.Latitude }, string.Format("Registration: {0}",vehicle.VehicleRegistration));
                            }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
           
            return vehicleList;
        }

        static DateTime GetDTCTime(ulong nanoseconds, ulong ticksPerNanosecond)
        {
            DateTime pointOfReference = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long ticks = (long)(nanoseconds / ticksPerNanosecond);
            
            return pointOfReference.AddTicks(ticks);
        }

        static DateTime GetDTCTime(ulong nanoseconds)
        {
            return GetDTCTime(nanoseconds, 100);
        }

        private string ReadNullTerminated(BinaryReader br)
        {
            string value = "";
            char c;
            while ((c = br.ReadChar()) != '\0')
            {
                value += c;
            }
            return value;
        }
        private byte[]? ReadFile()
        {
            var path = Path.GetFullPath("VehiclePositions.dat");

            if (File.Exists(path))
            {
                return File.ReadAllBytes(path);
            }
            else
            {
                Console.WriteLine("Data file was not found");

                return null;
            }
          

        }


    }
}
