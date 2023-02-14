using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.VisualBasic;
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

        public IEnumerable<DateTime> GetFlightsDates(string destination)
        {
            //List<DateTime> Listdates = new List<DateTime>();

            //foreach (var f in Flights)
            //{
              //  if (f.Destination.Equals(destination))
                //{
                  //  Listdates.Add(f.FlightDate);
               // }
           // }

            // return Listdates;

            //IEnumerable<DateTime> req = from f  in Flights
                                      //  where f.Destination.Equals(destination)
                                       // select f.FlightDate;
            //return req;

            IEnumerable<DateTime> queryLambda = Flights
                .Where(f => f.Destination == destination)
                .Select(f => f.FlightDate);
            return queryLambda;

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

        public void ShowFlightsDetails(Plane plane)
        {
            var query = from f in Flights
                        where f.Plane == plane
                        select f;
            foreach (var f in query)
            {
                Console.WriteLine("destination : " + f.Destination + "flight Date :" + f.FlightDate);
            }
        }

        public int ProgrammedFlightsNumber(DateTime startDate)
        {
                var query = from f in Flights
                            where (DateTime.Compare(f.FlightDate, startDate) > 0
                                &&
                                (f.FlightDate - startDate).TotalDays < 7)
                                select f;
                return query.Count();
                
        }



        public double DurationAverage(string destination)
        {

            var req = from f in Flights 
                      where f.Destination.Equals(destination) 
                      select f.EstimatedDuration;

            var reqAverage = TestData.listFlights
                                .Where(f => f.Destination == destination)
                                .Average(f => f.EstimatedDuration);


            return req.Average();
        }

        public IEnumerable<Flight> OrderDurationFlights()
        {
            var req = from f in TestData.listFlights
                      orderby f.EstimatedDuration descending
                      select f;


            return req;

        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {

            var req = from f in flight.Passengers.OfType<Traveller>() 
                      orderby f.BirthDate ascending
                      select f;

            return req.Take(3);

        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var query = from f in Flights
                      group f by f.Destination;
            foreach(var g in query)
            {
                Console.WriteLine("Destination :" + g.Key);
                foreach(var v in g)
                {
                    Console.WriteLine("Decolage :" + v.FlightDate);
                }
            }

            return query;
            

        }

        public Action<Plane> FlightDetailsDel;
        public Func<string, double> DurationAverageDel;

        public ServiceFlight()
        {
            FlightDetailsDel = plane =>
            {
                var query = from f in Flights
                            where f.Plane == plane
                            select f;
                foreach (var f in query)
                {
                    Console.WriteLine("destination : " + f.Destination + "flight Date :" + f.FlightDate);
                }
            };
            DurationAverageDel = destination =>
            {
                var req = from f in Flights
                          where f.Destination.Equals(destination)
                          select f.EstimatedDuration;

                var reqAverage = TestData.listFlights
                                    .Where(f => f.Destination == destination)
                                    .Average(f => f.EstimatedDuration);

                return req.Average();
            };
        }



    }


}
