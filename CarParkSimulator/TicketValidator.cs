using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator {
    class TicketValidator {

        private CarPark Park;
        private ActiveTickets tickets;
        private string _message;

        public string Message {
            get => _message;
        }

        public TicketValidator(ActiveTickets activeTickets) {
            tickets = activeTickets;
        }

        public void AssignCarPark(CarPark carPark) {
            Park = carPark;
        }

        public void CarArrived() {
            _message = "Please insert your ticket";
        }

        public void TicketEntered() {
            _message = "Thank you, drive safely";
            tickets.RemoveTicket();
        }

        public void ClearMessage() {
            _message = "";
        }

    }
}
