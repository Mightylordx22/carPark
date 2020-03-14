using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator {
    class ActiveTickets {

        private List<Ticket> tickets;

        public ActiveTickets() {
            tickets = new List<Ticket>();
        }

        public string[] GetTickets() {
            return tickets.Select(x=>String.Format("#{0}: {1}",x.GetHashCode(),x.Paid.ToString())).ToArray();
        } 

        public void AddTicket() {
            tickets.Add(new Ticket());
        }

        public void RemoveTicket() {
            tickets.RemoveAt(0);
        }

    }
}
