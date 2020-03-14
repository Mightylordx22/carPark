using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarParkSimulator {
    public partial class SimulatorInterface : Form {
        // Attributes ///        
        private TicketMachine ticketMachine;
        private ActiveTickets activeTickets;
        private TicketValidator ticketValidator;
        private Barrier entryBarrier;
        private Barrier exitBarrier;
        private FullSign fullSign;
        private CarPark carPark;
        private EntrySensor entrySensor;
        private ExitSensor exitSensor;


        // Constructor //
        public SimulatorInterface() {
            InitializeComponent();
        }


        // Operations ///
        private void ResetSystem(object sender, EventArgs e) {
            // STUDENTS:
            ///// Class contructors are not defined so there will be errors
            ///// This code is correct for the basic version though!
            activeTickets = new ActiveTickets();
            ticketMachine = new TicketMachine(activeTickets);
            ticketValidator = new TicketValidator(activeTickets);
            entryBarrier = new Barrier();
            exitBarrier = new Barrier();
            fullSign = new FullSign();
            carPark = new CarPark(ticketMachine, ticketValidator, fullSign, entryBarrier, exitBarrier);
            entrySensor = new EntrySensor(carPark);
            exitSensor = new ExitSensor(carPark);

            ticketMachine.AssignCarPark(carPark);
            ticketValidator.AssignCarPark(carPark);

            /////////////////////////////////////////

            btnCarArrivesAtEntrance.Visible = true;
            btnDriverPressesForTicket.Visible = false;
            btnCarEntersCarPark.Visible = false;
            btnCarArrivesAtExit.Visible = false;
            btnDriverEntersTicket.Visible = false;
            btnCarExitsCarPark.Visible = false;

            UpdateDisplay();
        }

        private void CarArrivesAtEntrance(object sender, EventArgs e) {

            carPark.CarArrivedAtEntrance();
            entrySensor.CarDeteced();

            btnCarArrivesAtEntrance.Visible = false;
            btnDriverPressesForTicket.Visible = true;

            UpdateDisplay();
        }

        private void DriverPressesForTicket(object sender, EventArgs e) {

            carPark.TicketDispensed();

            btnDriverPressesForTicket.Visible = false;
            btnCarEntersCarPark.Visible = true;

            UpdateDisplay();
        }

        private void CarEntersCarPark(object sender, EventArgs e) {

            carPark.CarEnteredCarPark();
            entrySensor.CarLeftSensor();

            btnCarEntersCarPark.Visible = false;
            btnCarArrivesAtEntrance.Visible = carPark.HasSpace();
            btnCarArrivesAtExit.Visible = !btnCarEntersCarPark.Visible && !btnDriverPressesForTicket.Visible;
            btnCarArrivesAtExit.Visible = true;

            UpdateDisplay();
        }

        private void CarArrivesAtExit(object sender, EventArgs e) {

            exitSensor.CarDeteced();
            carPark.CarArrivedAtExit();

            btnCarArrivesAtExit.Visible = false;
            btnDriverEntersTicket.Visible = true;

            UpdateDisplay();
        }

        private void DriverEntersTicket(object sender, EventArgs e) {

            carPark.TicketValidated();

            btnDriverEntersTicket.Visible = false;
            btnCarExitsCarPark.Visible = true;

            UpdateDisplay();

        }

        private void CarExitsCarPark(object sender, EventArgs e) {

            carPark.CarExitedCarPar();
            exitSensor.CarLeftSensor();

            btnCarExitsCarPark.Visible = false;
            btnCarArrivesAtEntrance.Visible = !btnCarEntersCarPark.Visible && !btnDriverPressesForTicket.Visible;
            btnCarArrivesAtExit.Visible = !carPark.IsEmpty();

            UpdateDisplay();
        }

        private void UpdateDisplay() {

            lblEntrySensor.Text = entrySensor.IsCarOnSensor().ToString();
            lblTicketMachine.Text = ticketMachine.Message;
            lblEntryBarrier.Text = entryBarrier.IsLifted().ToString();

            lblExitSensor.Text = exitSensor.IsCarOnSensor().ToString();
            lblTicketValidator.Text = ticketValidator.Message;
            lblExitBarrier.Text = exitBarrier.IsLifted().ToString();

            lblFullSign.Text = fullSign.Lit.ToString();
            lblSpaces.Text = carPark.CurrentSpaces.ToString();

            lstActiveTickets.Items.Clear();
            lstActiveTickets.Items.AddRange(activeTickets.GetTickets());
        }
    }
}
