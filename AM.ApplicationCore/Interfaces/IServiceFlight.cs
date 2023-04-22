using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight : IService<Flight>
    {
        //public void Add(Flight flight);
        //public void Remove(Flight flight);
        //public IList<Flight> GetAll();
        IEnumerable<DateTime> GetFlightDates(string destination);
        void GetFlights(string filterType, string filterValue);
        void ShowFlightDetails(Plane plane);
        int ProgrammedFlightNumber(DateTime startDate);
        double DurationAverage(string destination);
        public IEnumerable<Flight> OrderedDurationFlights();
        IEnumerable<Passenger> SeniorTravellers(Flight flight);
        IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights();
    }
}