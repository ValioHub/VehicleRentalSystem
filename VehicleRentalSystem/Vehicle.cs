using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem
{
    // Base class
    abstract class Vehicle
    {
        public string Brand {  get; set; } // Vehicle brand
        public string Model { get; set; } // Vehicle model
        public decimal Value { get; set; } // Vehicle value

        // Abstract methods for derived classes to be implemented
        public abstract decimal GetDailyRentalCost(int rentalDays);
        public abstract decimal GetBaseInsurance(int rentalDays);
        public abstract decimal GetDailyInsuranceCost(int rentalDays);
    }
}
