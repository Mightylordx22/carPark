using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator {
    class TicketMachine {

        private CarPark Park;
        private ActiveTickets Active;
        private string _message;

        public string Message {
            get => _message;
        }

        public TicketMachine(ActiveTickets activeTickets) {
            Active = activeTickets;
        }

        public void AssignCarPark(CarPark carPark) {
            Park = carPark;
        }

        public void CarArrived() {
            _message = "Please press to get a ticket.";
        }

        public void PrintTicket() {
            Active.AddTicket();
            _message = "Thank you, enjoy your stay.";
        }

        public void ClearMessage() {
            _message = "";
        }

    }
}
