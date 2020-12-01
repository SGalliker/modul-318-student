using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwissTransport;

namespace MyTransportApp
{
    class DepartureBoard
    {
        public static List<Departure> getDepartureBoard(Station station)
        {
            List<Departure> departures = new List<Departure>();
            Transport transport = new Transport();
            StationBoardRoot connections;
            connections = transport.GetStationBoard(station.Name);
            // gets the next 5 departures and adds them to a list
            for (int i = 0; i < 5; i++)
            {
                departures.Add(new Departure(connections.Entries.ElementAt(i)));
            }
            return departures;
        }
        public static String[] getFormattedBoard(Departure departure,Station station)
        {
            return new[]
             {
            station.Name,
            departure.endStation,
            // 11 is the index in the DateTime, where the time starts. Format 12:00 has length of 5
            departure.departure.ToString().Substring(11, 5),
            "",
            departure.platform
            };
        }
    }
}
