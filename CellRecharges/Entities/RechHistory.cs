using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CellRecharges.Entities
{
    public class RechHistory
    {
        public string CellPhoneNumber { get; set; }
        public double Cost { get; set; }
        public System.DateTime Date { get; set; }


        public RechHistory(string celNumber, double cost, DateTime date)
        {
            this.CellPhoneNumber = celNumber;
            this.Cost = cost;
            this.Date = date;
        }
    }



}