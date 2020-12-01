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
        List<SwissTransport.Station> stations = new List<SwissTransport.Station>();
        Station station = new Station();
        public MainForm()
        {
            InitializeComponent();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvSearchResults.Rows.Clear();
            stations = station.getPossibleStations(txtStartStation.Text);
            foreach(SwissTransport.Station station in stations)
            {
                dgvSearchResults.Rows.Add(station.Name);
            }        
        }

        private void searchForDeparturesOrConnections()
        {
            List<Departure> departures;
            try
            {
                dgvSearchResults.Rows.Clear();
                stations = station.getPossibleStations(txtStartStation.Text);
                // If Endstation is empty we look for the DepartureBoard
                if (txtStartStation.Text != "" && txtEndStation.Text == "")
                {
                    foreach (SwissTransport.Station station in stations)
                    {
                        // Checking if the ID is empty to just get valid stations
                        if (station.Id != null)
                        {
                            departures = DepartureBoard.getDepartureBoard(station);
                            foreach (Departure departure in departures)
                            {
                                dgvSearchResults.Rows.Add(DepartureBoard.getFormattedBoard(departure, station));
                            }
                        }
                    }
                }
                else
                {
                    //Connection.getConnections();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Zu dieser Station konnten keine Daten gefunden werden");
            }
        }
        // puts selected station in grid into the startstation textfield
        private void dgvSearchResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvSearchResults.Rows)
            {
                if(dgvSearchResults.Rows.IndexOf(row) == e.RowIndex)
                {
                    txtStartStation.Text = row.DataGridView.CurrentCell.Value.ToString();
                }
            }
            dgvSearchResults.Rows.Clear();
            searchForDeparturesOrConnections();
        }
    }
}
