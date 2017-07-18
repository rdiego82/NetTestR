using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CellRecharges.DAL;
using CellRecharges.Entities;

namespace CellRecharges.Controllers
{
    public class InquiriesController : ApiController
    {
        private CellRechargesEntities1 db = new CellRechargesEntities1();

        // GET api/inquiries
        public List<Balance> Get()
        {

            var saldo = from CPS in db.CostPerSeconds
                        from R in db.Processes
                        from C in db.Processes
                        where
                          R.Type == "R" &&
                          C.Type == "C"
                        group new { R, CPS, C } by new
                        {
                            R.CellPhoneNumber,
                            CPS.Cost
                        } into g
                        select new
                        {
                            LINEA = g.Key.CellPhoneNumber,
                            COSTO = (double?)(g.Sum(p => p.R.Cost) - g.Sum(p => p.C.Cost)),
                            SEGUNDOS = (double?)((g.Sum(p => p.R.Cost) - g.Sum(p => p.C.Cost)) / g.Key.Cost)
                        };

            List<Balance> lstBal = new List<Balance>();

            foreach (var item in saldo)
            {
                lstBal.Add(new Balance(Convert.ToString(item.LINEA), Convert.ToDouble(item.COSTO), Convert.ToDouble(item.SEGUNDOS)));
            }

            return lstBal;

        }
    }
}
