using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight: IServiceFlight
    {

        public List<Flight> Flights { get; set; } = new List<Flight>();

        public List<DateTime> GetFlightsDates(string destination)
        {
            List<DateTime> Listdates = new List<DateTime>();

            foreach (var f in Flights)
            {
                if (f.Destination.Equals(destination))
                {
                    Listdates.Add(f.FlightDate);
                }
            }

            return Listdates;

            //IEnumerable<DateTime> req = from f  in Flights
                                      //  where f.Destination.Equals(destination)
                                       // select f.FlightDate;
            //return req;

        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.Destination.Equals(filterValue))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "Departure":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.Departure.Equals(filterValue))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "FlightDate":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.FlightDate == DateTime.Parse(filterValue))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "EstimatedDuration":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.EstimatedDuration.Equals(int.Parse(filterValue)))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;

            }
        }
    }

    
}
