using VehicleRentalSystem;

// Data for car rental
Car rentedCar = new Car
{
    Brand = "Mitsubishi",
    Model = "Mirage",
    Value = 15000m,
    SafetyRating = 3
};

// Data for motorcycle rental
Motorcycle rentedMotorcycle = new Motorcycle
{
    Brand = "Triumph",
    Model = "Tiger Sport 660",
    Value = 10000m,
    RiderAge = 20
};

// Data for cargo van rental
CargoVan rentedCargoVan = new CargoVan
{
    Brand = "Citroen",
    Model = "Jumper",
    Value = 20000m,
    DriverExperience = 8
};

// Invoice generation
Invoice carInvoice = new Invoice
{
    Date = DateTime.Now,
    CustomerName = "John Doe",
    RentedVehicle = rentedCar,
    ReservationStartDate = new DateTime(2024, 6, 3),
    ReservationEndDate = new DateTime(2024, 6, 13),
    ActualReturnDate = new DateTime(2024, 6, 13)
};

Invoice motorcycleInvoice = new Invoice
{
    Date = DateTime.Now,
    CustomerName = "Mary Johnson",
    RentedVehicle = rentedMotorcycle,
    ReservationStartDate = new DateTime(2024, 6, 3),
    ReservationEndDate = new DateTime(2024, 6, 13),
    ActualReturnDate = new DateTime(2024, 6, 13)
};

Invoice cargoVanInvoice = new Invoice
{
    Date = DateTime.Now,
    CustomerName = "John Markson",
    RentedVehicle = rentedCargoVan,
    ReservationStartDate = new DateTime(2024, 6, 3),
    ReservationEndDate = new DateTime(2024, 6, 18),
    ActualReturnDate = new DateTime(2024, 6, 13)
};

// Display invoices
carInvoice.GenerateInvoice();
motorcycleInvoice.GenerateInvoice();
cargoVanInvoice.GenerateInvoice();