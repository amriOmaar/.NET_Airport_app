using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {

        //public int Id { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.DateTime)]
        public DateTime  BirthDate{ get; set; }
        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }

        //[EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string EmailAdresse { get; set; }


        public FullName Fullname { get; set; }

        //[DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]{8}$", 
            ErrorMessage = "Invalid Phone Number!")]
        public string TelNumber { get; set; }

        public virtual List<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "Nom: " +this.Fullname.FirstName + "Prenom: " +this.Fullname.LastName;
        }
        //public bool checkprofile(string firstname, string lastname,string mail)
        //{
        //    return firstname == this.FirstName && lastname == this.LastName && mail ==this.EmailAdresse;
        //}
        public bool checkprofile(string firstname, string lastname, string mail=null)
        {
            if (mail == null)
            {
                return firstname == this.Fullname.FirstName && lastname == this.Fullname.LastName;
            }
            else
            {
                return firstname == this.Fullname.FirstName && lastname == this.Fullname.LastName && mail == this.EmailAdresse;
            }
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a PASSENGER");
        }

    }
}
