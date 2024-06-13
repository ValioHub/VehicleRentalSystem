using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem
{
    // Cargo Van class
    internal class CargoVan : Vehicle
    {
        public int DriverExperience { get; set; } // Experience of the driver in years
        
        // Calculate daily rental cost 
        public override decimal GetDailyRentalCost(int rentalDays)
        {
            if (rentalDays <= 7)
            {
                return 50m;
            }
            else
            {
                return 40m;
            }
        }

        // Calculate daily insurance cost
        public override decimal GetDailyInsuranceCost(int rentalDays)
        {
            decimal baseInsurance = 0.03m * Value / 100; // 0.03 %
            if (DriverExperience > 5)
            {
                return baseInsurance * 0.85m; // Reduced by 15%
            }
            else
            {
                return baseInsurance;
            }
        }
        public override decimal GetBaseInsurance(int rentalDays)
        {
            decimal baseInsurance = 0.03m * Value / 100; // 0.01 %
            return baseInsurance;
        }
    }
}
