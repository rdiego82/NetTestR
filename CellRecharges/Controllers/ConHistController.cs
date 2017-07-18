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
    public class ConHistController : ApiController
    {
        private CellRechargesEntities1 db = new CellRechargesEntities1();

        // GET api/ConHist
        public List<RechHistory> Get()
        {
            var process = from Processes in db.Processes
                          where
                            Processes.Type == "C"
                          orderby
                            Processes.CellPhoneNumber descending,
                            Processes.Date descending
                          select new
                          {
                              Linea = Processes.CellPhoneNumber,
                              Costo = Processes.Cost,
                              Fecha = Processes.Date
                          };

            List<RechHistory> lstConHistory = new List<RechHistory>();

            foreach (var item in process)
            {
                lstConHistory.Add(new RechHistory(Convert.ToString(item.Linea), Convert.ToDouble(item.Costo), Convert.ToDateTime(item.Fecha)));
            }

            return lstConHistory;

        }
    }
}
