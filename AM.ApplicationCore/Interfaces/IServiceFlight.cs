using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight
    {
        public IEnumerable<DateTime> GetFlightsDates(string destination);
        public void GetFlights(string filterType, string filterValue);
        public void ShowFlightsDetails(Plane plane);

        public int ProgrammedFlightsNumber(DateTime startDate);

        public double DurationAverage(string destination);
        public IEnumerable<Flight> OrderDurationFlights();
        public IEnumerable<Traveller> SeniorTravellers(Flight flight);
        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights();
    }
}
