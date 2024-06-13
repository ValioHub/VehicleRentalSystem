using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem
{
    // Car class
    internal class Car : Vehicle
    {
        public int SafetyRating { get; set; } // Safety rating for car

        // Calculate daily rental cost
        public override decimal GetDailyRentalCost(int rentalDays)
        {
            if (rentalDays <= 7)
            {
                return 20m;
            }
            else 
            {
                return 15m;
            }
        }

        // Calculate daily insurance cost
        public override decimal GetDailyInsuranceCost(int rentalDays)
        {
            decimal baseInsurance = 0.01m * Value / 100; // 0.01 %
            if (SafetyRating >= 4) 
            {
                return baseInsurance * 0.9m; // Reduced by 10%
            }
            else
            {
                return baseInsurance;
            }
        }

        public override decimal GetBaseInsurance(int rentalDays)
        {
            decimal baseInsurance = 0.01m * Value / 100; // 0.01 %
            return baseInsurance;
        }
    }
}
