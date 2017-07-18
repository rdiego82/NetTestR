using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CellRecharges.Entities
{
    public class Balance
    {
        public string CellPhoneNumber { get; set; }
        public double Cost { get; set; }
        public double Seconds { get; set; }

        public Balance(string CellPhoneNumber, double Cost, double Seconds)
        {
            this.CellPhoneNumber = CellPhoneNumber;
            this.Cost = Cost;
            this.Seconds = Seconds;
        }
    }
}