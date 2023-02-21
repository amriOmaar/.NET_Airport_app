using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {

        public int Id { get; set; }

        public DateTime  BirthDate{ get; set; }

        public int PassportNumber { get; set; }

        public string EmailAdresse { get; set; }

        public string FirstName { get; set; }

        public string LastName  { get; set; }

        public string TelNumber { get; set; }

        public virtual List<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "Nom: " +this.FirstName + "Prenom: " +this.LastName;
        }
        //public bool checkprofile(string firstname, string lastname,string mail)
        //{
        //    return firstname == this.FirstName && lastname == this.LastName && mail ==this.EmailAdresse;
        //}
        public bool checkprofile(string firstname, string lastname, string mail=null)
        {
            if (mail == null)
            {
                return firstname == this.FirstName && lastname == this.LastName;
            }
            else
            {
                return firstname == this.FirstName && lastname == this.LastName && mail == this.EmailAdresse;
            }
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a PASSENGER");
        }

    }
}
