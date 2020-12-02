using System.Collections.Generic;
using Newtonsoft.Json;

namespace SwissTransport
{
    public class Coordinate
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("x")]
        public double XCoordinate { get; set; }

        [JsonProperty("y")]
        public double YCoordinate { get; set; }
    }

    public class Station
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("score")]
        public int? Score { get; set; }

        [JsonProperty("coordinate")]
        public Coordinate Coordinate { get; set; }

        [JsonProperty("distance")]
        public double? Distance { get; set; }

        // gets possible stations for the input
        public List<Station> getPossibleStations(string station)
        {
            List<Station> possibleStations;
            ITransport transport = new Transport();

            possibleStations = transport.GetStations(station).StationList;
            return possibleStations;
        }
        // checks if there are stations 
        public bool checkStations(string station)
        {
            List<Station> possibleStations = getPossibleStations(station);
            if (possibleStations.Count == 0)
            {
                return false;
            }
            return true;
        }
    }

    public class Stations
    {
        [JsonProperty("stations")]
        public List<Station> StationList { get; set; }
    }
}