using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem
{
    // Motorcylce class
    internal class Motorcycle : Vehicle
    {
        public int RiderAge { get; set; } // Age of the rider

        // Calculate daily rental cost 
        public override decimal GetDailyRentalCost(int rentalDays)
        {
            if (rentalDays <= 7)
            {
                return 15m;
            }
            else
            {
                return 10m;
            }
        }

        // Calculate daily insurance cost
        public override decimal GetDailyInsuranceCost(int rentalDays)
        {
            decimal baseInsurance = 0.02m * Value / 100; // 0.02 %
            if (RiderAge < 25)
            {
                return baseInsurance * 1.2m; // Increased by 20%
            }
            else
            {
                return baseInsurance;
            }
        }
        public override decimal GetBaseInsurance(int rentalDays)
        {
            decimal baseInsurance = 0.02m * Value / 100; // 0.01 %
            return baseInsurance;
        }
    }
}
