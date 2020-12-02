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
            dtpDate.MinDate = DateTime.Today;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clearBoard();
            if (station.checkStations(txtStartStation.Text))
            {
                startStations = station.getPossibleStations(txtStartStation.Text);
                endStations = station.getPossibleStations(txtEndStation.Text);
                int i = 0;
                foreach (Station startStation in startStations)
                {
                    if (isValidStation(startStation))
                    {
                        dgvSearchResults.Rows.Add(startStation.Name, endStations.ElementAt(i).Name);
                        i++;
                    }           
                }
            }
            else
            {
                printNoStationsFound();
            }
        }

        private void searchForDepartures()
        {
            clearBoard();
            if (station.checkStations(txtStartStation.Text))
            {
                DateTime userInputDateTime = new DateTime(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day, dtpTime.Value.Hour, dtpTime.Value.Minute, 0);
                List<Departure> departures;
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
                            if (userInputDateTime.CompareTo(departure.departure) < 0)
                            {
                                dgvSearchResults.Rows.Add(Board.getFormattedDepartureBoard(departure, station));
                            }
                        }
                    }
                }
            }
            else
            {
                printNoStationsFound();
            }
        }

        private void searchForConnections()
        {
            List<Connection> connections;
            String[] formattedDate = formatDate(dtpDate.Value, dtpTime.Value);
            if (station.checkStations(txtStartStation.Text) && station.checkStations(txtEndStation.Text))
            {
                connections = transport.GetConnections(txtStartStation.Text, txtEndStation.Text, formattedDate[0], formattedDate[1]).ConnectionList;
                clearBoard();
                startStations = station.getPossibleStations(txtStartStation.Text);
                endStations = station.getPossibleStations(txtEndStation.Text);
                foreach (Connection connection in connections)
                {
                    if (isValidStation(connection.From.Station))
                    {
                        dgvSearchResults.Rows.Add(Board.getFormattedConnectionBoard(connection));
                    }
                }
                if (dgvSearchResults.Rows.Count == 0)
                {
                    printNoConnectionsFound();
                }
            }
            else
            {
                printNoStationsFound();
            }

        }
        // formats the date for the query
        private string[] formatDate(DateTime date, DateTime time)
        {
            String[] formattedStrings = new string[2];
            formattedStrings[0] = date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day.ToString();
            formattedStrings[1] = time.ToShortTimeString();
            return formattedStrings;
        }
        // puts selected station in grid into the startstation textfield
        private void dgvSearchResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // If the station was picked out of the Startstation Column (0), it gets set as Startstation, otherwhise as Enstation (1)
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
        private void printNoStationsFound()
        {
            MessageBox.Show("Zu den gesuchten Stationen konnten keine Daten gefunden werden!");
            txtStartStation.Clear();
            txtEndStation.Clear();
        }
        private void printNoConnectionsFound()
        {
            MessageBox.Show("Zu dem gewünschten Zeitpunkt wurden keine Verbindungen gefunden!");
        }
    }
}
