﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SwissTransport
{
    [TestClass]
    public class TransportTest
    {
        private ITransport testee;

        [TestMethod]
        public void Locations()
        {
            testee = new Transport();
            var stations = testee.GetStations("Sursee,");

            Assert.AreEqual(10, stations.StationList.Count);
        }

        [TestMethod]
        public void StationBoard()
        {
            testee = new Transport();
            var stationBoard = testee.GetStationBoard("Sursee");

            Assert.IsNotNull(stationBoard);
        }

        [TestMethod]
        public void Connections()
        {
            testee = new Transport();
            var connections = testee.GetConnections("Sursee", "Luzern", "", "");

            Assert.IsNotNull(connections);
        }

        [TestMethod]
        public void ConnectionsWithDateTimeFilterTest()
        {
            testee = new Transport();
            var connections = testee.GetConnections("Sursee", "Luzern", "2020-12-02", "12:00");

            Assert.IsNotNull(connections);
        }
    }
}
