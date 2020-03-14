using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator {
    class CarPark {

        private int _currentSpaces;
        private int MaxSpace = 5;

        private TicketMachine ticketMachine;
        private TicketValidator ticketValidator;
        private FullSign fullSign;
        private Barrier entryBarrier;
        private Barrier exitBarrier;

        public int CurrentSpaces {
            get => _currentSpaces;
        }

        public CarPark(TicketMachine ticketMachine, TicketValidator ticketValidator, FullSign fullSign, Barrier entryBarrier, Barrier exitBarrier) {
            _currentSpaces = MaxSpace;
            this.ticketMachine = ticketMachine;
            this.ticketValidator = ticketValidator;
            this.fullSign = fullSign;
            this.entryBarrier = entryBarrier;
            this.exitBarrier = exitBarrier;
        }

        public void CarArrivedAtEntrance() {
            ticketMachine.CarArrived();
        }

        public void TicketDispensed() {
            entryBarrier.Raise();
            ticketMachine.PrintTicket();
        }

        public void CarEnteredCarPark() {
            entryBarrier.Lower();
            ticketMachine.ClearMessage();
            --_currentSpaces;
            fullSign.Lit = IsFull();
        }

        public void CarArrivedAtExit() {
            ticketValidator.CarArrived();
        }

        public void TicketValidated() {
            ticketValidator.TicketEntered();
            exitBarrier.Raise();
        }

        public void CarExitedCarPar() {
            exitBarrier.Lower();
            ticketValidator.ClearMessage();
            ++_currentSpaces;
            fullSign.Lit = false;
        }

        public bool IsFull() {
            return CurrentSpaces == 0;
        }

        public bool IsEmpty() {
            return CurrentSpaces == 5;
        }

        public bool HasSpace() {
            return CurrentSpaces > 0;
        }

    }
}
