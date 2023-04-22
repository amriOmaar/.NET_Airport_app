using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        private IUnitOfWork unitOfWork;

        public readonly IGenericRepository<Plane> _repo;
        //public ServicePlane(IGenericRepository<Plane> repo) { _repo = repo; }
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

            // this.unitOfWork = unitOfWork;
        }

        public IList<Passenger> GetPassengers(Plane plane)
        {
            return GetById(plane.PlaneId).Flights.SelectMany(f => f.Tickets.Select(t => t.Passenger)).ToList();
        }

        public IList<Flight> GetFlights(int n)
        {
            return GetAll().OrderByDescending(p => p.PlaneId).Take(n).SelectMany(p => p.Flights).OrderBy(f => f.FlightDate).ToList();
        }

        public bool IsAvailablePlane(Flight flight, int n)
        {
            int planeCapacity = flight.Plane.capacity;
            int nbrTickets = flight.Tickets.Count;
            return planeCapacity >= nbrTickets + n;
        }

        public void DeletePlanes()
        {
            //Delete(p => p.ManufactureDate.AddYears(10).Year < DateTime.Now.Year);
            Delete(p => DateTime.Now.Year - p.ManufactureDate.Year > 10);
        }
        //public void Add(Plane plane)
        //{
        //    //_repo.Add(plane);
        //    unitOfWork.Repository<Plane>().Add(plane);
        //}

        //public void Update(Plane plane)
        //{
        //    unitOfWork.Repository<Plane>().Update(plane);                   
        //}

        //public IList<Plane> GetAll()
        //{
        //    //return _repo.GetAll().ToList();
        //    return unitOfWork.Repository<Plane>().GetAll().ToList();
        //}

        //public void Remove(Plane plane)
        //{
        //    //_repo.Delete(plane);
        //    unitOfWork.Repository<Plane>().Delete(plane);
        //}
    }
}