using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwissTransport;

namespace MyTransportApp
{
    class Board
    {
        static Transport transport = new Transport();
        public static List<Departure> getDepartureBoard(Station station)
        {
            List<Departure> departures = new List<Departure>();
            StationBoardRoot stationBoard;
            stationBoard = transport.GetStationBoard(station.Name);
            // gets the next 5 departures and adds them to a list
            for (int i = 0; i < 5; i++)
            {
                departures.Add(new Departure(stationBoard.Entries.ElementAt(i)));
            }
            return departures;
        }
        public static String[] getFormattedDepartureBoard(Departure departure, Station station)
        {
            return new[]
             {
            station.Name,
            departure.endStation,
            // 11 is the index in the DateTime String, where the time starts. Format 12:00 has length of 5
            departure.departure.ToString().Substring(11, 5),
            "",
            departure.platform
            };
        }
        public static String[] getFormattedConnectionBoard(Connection connection)
        {
            return new[]
                         {
            connection.From.Station.Name,
            connection.To.Station.Name,
            connection.From.Departure.Substring(11, 5),
            connection.To.Arrival.Substring(11,5),
            connection.From.Platform
            };
        }
    }
}
