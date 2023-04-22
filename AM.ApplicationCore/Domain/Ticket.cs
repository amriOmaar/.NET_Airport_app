using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        public double Prix { get; set; }
        public int Siege { get; set; }
        public Boolean Vip { get; set; }
        public virtual Passenger Passenger { get; set; }
        public virtual Flight Flight { get; set; }
        //[ForeignKey("PassengerFK")] car déja dans ticketConfig
        public int FlightFk { get; set; }
        public string PassengerFk { get; set; }
    }
}
