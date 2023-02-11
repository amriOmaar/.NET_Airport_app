// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using System.Reflection.Metadata.Ecma335;

//Console.WriteLine("Hello, World!");
//Plane Plane1 = new Plane();
//Plane1.Capacity = 120;
//Plane1.ManufactureDate = new DateTime(2023, 02, 01);
//Plane1.PlaneType = PlaneType.Boing;

//Plane Plane2 = new Plane(PlaneType.Boing, 100, new DateTime(2023, 02, 02));


Plane p3 = new Plane()
{
    Capacity = 120,
    ManufactureDate = new DateTime(2023, 02, 01),
    PlaneType = PlaneType.Boing
};

Passenger p = new Passenger
{
    FirstName = "omar",
    LastName = "amri",
    EmailAdresse="omar@esprit.tn"

};
Console.WriteLine(p.checkprofile("omar", "amri","omar@esprit.tn"));

Traveller Traveller1 = new Traveller
{
    FirstName = "name1",
    LastName = "name2",
    Nationality = "Tunisienne"


};
Console.WriteLine("---------------------------------");
Traveller1.PassengerType();

Staff staff1 = new Staff
{
    FirstName = "test",
    LastName = "test",
    Function = "DEV WEB"

};
Console.WriteLine("---------------------------------");
staff1.PassengerType();


ServiceFlight flight = new ServiceFlight();
flight.Flights = TestData.listFlights;

Console.WriteLine(" flights dates ");
foreach (var listFlights in flight.GetFlightsDates("Paris"))
{

    Console.WriteLine(listFlights);

}

Console.WriteLine(" get flights ");
flight.GetFlights("Destination", "Paris");
flight.GetFlights("EstimatedDuration", "105");