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
    public class ProcessController : ApiController
    {
        private CellRechargesEntities1 db = new CellRechargesEntities1();

        // GET api/Process
        public IQueryable<Process> GetProcesses()
        {
            return db.Processes;
        }

        // GET api/Process/5
        [ResponseType(typeof(Process))]
        public IHttpActionResult GetProcess(int id)
        {
            Process process = db.Processes.Find(id);
            if (process == null)
            {
                return NotFound();
            }

            return Ok(process);
        }

        // PUT api/Process/5
        public IHttpActionResult PutProcess(int id, Process process)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != process.Id)
            {
                return BadRequest();
            }

            db.Entry(process).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcessExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Process
        [ResponseType(typeof(Process))]
        public IHttpActionResult PostProcess(Process process)
        {
            process.Date = System.DateTime.Now;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (process.Type.Equals("C")){

                var costo = from Processes in
                            (from Processes in db.Processes
                            where
                              Processes.CellPhoneNumber == process.CellPhoneNumber &&
                              Processes.Type == "R"
                            select new {
                              Processes.Cost,
                              Dummy = "x"
                            })
                            group Processes by new { Processes.Dummy } into g
                            select new {
                              Column1 = (double?)g.Sum(p => p.Cost)
                            };

                if(costo.Any())
                    foreach (var item in costo)
                    {
                        if (item.Column1.Value < process.Cost)
                            throw new Exception("El valor del consumo excede el valor de la recarga. Por favor verificar");
                    }
                    

            }

            db.Processes.Add(process);

            try
            {
                db.SaveChanges();

            }
            catch (Exception)
            {
                
                throw;
            }
            
            return CreatedAtRoute("DefaultApi", new { id = process.Id }, process);
        }

        // DELETE api/Process/5
        [ResponseType(typeof(Process))]
        public IHttpActionResult DeleteProcess(int id)
        {
            Process process = db.Processes.Find(id);
            if (process == null)
            {
                return NotFound();
            }

            db.Processes.Remove(process);
            db.SaveChanges();

            return Ok(process);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProcessExists(int id)
        {
            return db.Processes.Count(e => e.Id == id) > 0;
        }

       
    }
}