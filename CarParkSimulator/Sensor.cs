using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator {
    class Sensor {

        protected bool CarOnSensor;

        private CarPark CarPark;
        
        public Sensor(CarPark carPark) {
            CarPark = carPark;
        }

        public void CarDeteced() {
            CarOnSensor = true;
        }

        public void CarLeftSensor() {
            CarOnSensor = false;
        }

        public bool IsCarOnSensor() {
            return CarOnSensor;
        }

    }
}
