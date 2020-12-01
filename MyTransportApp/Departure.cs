using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwissTransport;

namespace MyTransportApp
{
    class Departure
    {
        public string stationName;
        public DateTime departure;
        public string platform;
        public string endStation;
        public Departure(StationBoard stationBoard)
        {
            stationName = stationBoard.Name;
            departure = stationBoard.Stop.Departure;
            platform = stationBoard.Stop.Platform;
            endStation = stationBoard.To;
        }
    }
}
