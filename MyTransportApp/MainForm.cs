using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwissTransport;

namespace MyTransportApp
{
    public partial class MainForm : Form
    {
        ITransport transport = new Transport();
        Station station = new Station();
        List<Station> startStations = new List<Station>();
        List<Station> endStations = new List<Station>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clearBoard();
            startStations = station.getPossibleStations(txtStartStation.Text);
            endStations = station.getPossibleStations(txtEndStation.Text);
            int i = 0;
            foreach (Station startStation in startStations)
            {
                dgvSearchResults.Rows.Add(startStation.Name, endStations.ElementAt(i).Name);
                i++;
            }
        }

        private void searchForDepartures()
        {
            List<Departure> departures;
            clearBoard();
            startStations = station.getPossibleStations(txtStartStation.Text);
            // If Endstation is empty we look for the DepartureBoard
            foreach (Station station in startStations)
            {
                // Checking if the ID is not empty to just get valid stations
                if (isValidStation(station))
                {
                    departures = Board.getDepartureBoard(station);
                    foreach (Departure departure in departures)
                    {
                        dgvSearchResults.Rows.Add(Board.getFormattedDepartureBoard(departure, station));
                    }
                }
            }
        }
        private void searchForConnections()
        {
            List<Connection> connections;
            clearBoard();
            startStations = station.getPossibleStations(txtStartStation.Text);
            endStations = station.getPossibleStations(txtEndStation.Text);
            connections = transport.GetConnections(txtStartStation.Text, txtEndStation.Text).ConnectionList;
            foreach (Connection connection in connections)
            {
                dgvSearchResults.Rows.Add(Board.getFormattedConnectionBoard(connection));
            }

        }
        // puts selected station in grid into the startstation textfield
        private void dgvSearchResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // If the station was picked out of the Startstation Column, it gets set as Startstation, otherwhise as Enstation
            if (e.ColumnIndex == 0)
            {
                foreach (DataGridViewRow row in dgvSearchResults.Rows)
                {
                    if (dgvSearchResults.Rows.IndexOf(row) == e.RowIndex)
                    {
                        txtStartStation.Text = row.DataGridView.CurrentCell.Value.ToString();
                    }
                }
            }
            else if (e.ColumnIndex == 1)
            {
                foreach (DataGridViewRow row in dgvSearchResults.Rows)
                {
                    if (dgvSearchResults.Rows.IndexOf(row) == e.RowIndex)
                    {
                        txtEndStation.Text = row.DataGridView.CurrentCell.Value.ToString();
                    }
                }
            }

        }

        private void txtStartStation_TextChanged(object sender, EventArgs e)
        {
            // Search and Departure board buttons are enabled when Startstation isnt empty. Connection button if both TextBoxes have content
            btnSearch.Enabled = !string.IsNullOrWhiteSpace(txtStartStation.Text) || !string.IsNullOrWhiteSpace(txtEndStation.Text);
            btnDepartureBoard.Enabled = !string.IsNullOrWhiteSpace(txtStartStation.Text);
            btnConnections.Enabled = !string.IsNullOrWhiteSpace(txtStartStation.Text) && !string.IsNullOrWhiteSpace(txtEndStation.Text);
        }

        private void btnDepartureBoard_Click(object sender, EventArgs e)
        {
            searchForDepartures();
        }
        private void btnConnections_Click(object sender, EventArgs e)
        {
            searchForConnections();
        }
        private void clearBoard()
        {
            dgvSearchResults.Rows.Clear();
        }
        private bool isValidStation(Station station)
        {
            return station.Id != null;
        }
    }
}
