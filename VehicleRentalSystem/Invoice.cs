using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem
{
    // Class to generate and display invoice
    internal class Invoice
    {
        public DateTime Date { get; set; } // Current date
        public string CustomerName { get; set; } // Customer name
        public Vehicle RentedVehicle { get; set; } // Rented vehicle
        public DateTime ReservationStartDate { get; set; } // Start date of reservation
        public DateTime ReservationEndDate { get; set; } // End date of reservation
        public DateTime ActualReturnDate { get; set; } // Actual return date

        // Generate the invoice
        public void GenerateInvoice()
        {
            int reservedDays = (ReservationEndDate - ReservationStartDate).Days;
            int actualDays = (ActualReturnDate - ReservationStartDate).Days;
            if (actualDays < 0) // Ensure actualDays is non-negative
            {
                Console.WriteLine("ActualDays cannot be negative");
                actualDays = 0;
            }

            decimal dailyRentalCost = RentedVehicle.GetDailyRentalCost(reservedDays);
            decimal dailyBaseInsurance = RentedVehicle.GetBaseInsurance(reservedDays);
            decimal dailyInsuranceDiscount = 0;
            decimal dailyInsuranceCost = RentedVehicle.GetDailyInsuranceCost(reservedDays);
            if (dailyBaseInsurance > dailyInsuranceCost)
            {
                dailyInsuranceDiscount = dailyBaseInsurance - dailyInsuranceCost;
            }
            else
            {
                dailyInsuranceDiscount = dailyInsuranceCost - dailyBaseInsurance;
            }

            decimal totalRentalCost = 0;
            decimal totalInsuranceCost = 0;

            // Calculate cost for actual rental days
            for (int i = 0; i < actualDays; i++)
            {
                totalRentalCost += dailyRentalCost;
                totalInsuranceCost += dailyInsuranceCost;
            }

            decimal discountRent = 0;
            decimal discountInsurance = 0;
            // Calculate cost for remaining days if returned early
            int remainingDays = reservedDays - actualDays;
            if (remainingDays > 0)
            {
                totalRentalCost += remainingDays * dailyRentalCost / 2; // Half price for the remaining days
                discountRent += remainingDays * dailyRentalCost / 2;
                discountInsurance += remainingDays * dailyInsuranceCost;
            }

            decimal totalCost = totalRentalCost + totalInsuranceCost;
            CultureInfo usCulture = new CultureInfo("en-US");

            // Display the invoice
            Console.WriteLine("XXXXXXXXXX");
            Console.WriteLine($"Date: {Date:yyyy-MM-dd}");
            Console.WriteLine($"Customer Name: {CustomerName}");
            Console.WriteLine($"Rented Vehicle: {RentedVehicle.Brand} {RentedVehicle.Model}");
            Console.WriteLine("");
            Console.WriteLine($"Reservation start date: {ReservationStartDate:yyyy-MM-dd}");
            Console.WriteLine($"Reservation end date: {ReservationEndDate:yyyy-MM-dd}");
            Console.WriteLine($"Reservation rental days: {reservedDays} days");
            Console.WriteLine("");
            Console.WriteLine($"Actural return date: {ActualReturnDate:yyyy-MM-dd}");
            Console.WriteLine($"Actual rental days: {actualDays} days");
            Console.WriteLine("");
            Console.WriteLine($"Rental cost per day: {dailyRentalCost.ToString("C", usCulture)}");
            if (dailyBaseInsurance == dailyInsuranceCost){}
            else 
            {
                Console.WriteLine($"Initial insurance per day: {dailyBaseInsurance.ToString("C", usCulture)}");
                if (dailyBaseInsurance > dailyInsuranceCost)
                {
                    Console.WriteLine($"Insurance discount per day: {dailyInsuranceDiscount.ToString("C", usCulture)}");
                }
                else
                {
                    Console.WriteLine($"Insurance addition per day: {dailyInsuranceDiscount.ToString("C", usCulture)}");
                }
            }
            Console.WriteLine($"Insurance per day: {dailyInsuranceCost.ToString("C", usCulture)}");
            Console.WriteLine("");
            if (remainingDays > 0) 
            {
                Console.WriteLine($"Early return discount for rent: {discountRent.ToString("C", usCulture)}");
                Console.WriteLine($"Early return discount for insurance: {discountInsurance.ToString("C", usCulture)}");
                Console.WriteLine("");
            }
            Console.WriteLine($"Total rent: {totalRentalCost.ToString("C", usCulture)}");
            Console.WriteLine($"Total insurance: {totalInsuranceCost.ToString("C", usCulture)}");
            Console.WriteLine($"Total: {totalCost.ToString("C", usCulture)}");
            Console.WriteLine("XXXXXXXXXX");
            Console.WriteLine("");
        }
    }
}
