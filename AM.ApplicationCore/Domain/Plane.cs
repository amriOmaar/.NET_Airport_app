﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType
    {
        Boing,
        Airbus
    }
    public class Plane
    {

        public int Id { get; set; }

        [Range(0,int.MaxValue)]
        public int Capacity { get; set; }

        public DateTime ManufactureDate { get; set; }


        public PlaneType PlaneType { get; set;}


        public virtual List<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "ManufacturerDate: " + this.ManufactureDate;
        }
        public Plane() { }
        //public Plane(PlaneType pt, int capacity, DateTime date)
        //{
        //    this.Capacity = capacity;
        //    this.ManufactureDate = date;
        //    this.PlaneType = pt;
        //}
    }
}
