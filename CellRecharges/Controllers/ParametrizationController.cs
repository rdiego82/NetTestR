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

namespace CellRecharges.Controllers
{
    public class ParametrizationController : ApiController
    {
        private CellRechargesEntities1 db = new CellRechargesEntities1();

        // GET api/Parametrization
        public IQueryable<CostPerSecond> GetCostPerSeconds()
        {
            return db.CostPerSeconds;
        }

        // GET api/Parametrization/5
        [ResponseType(typeof(CostPerSecond))]
        public IHttpActionResult GetCostPerSecond(int id)
        {
            CostPerSecond costpersecond = db.CostPerSeconds.Find(id);
            if (costpersecond == null)
            {
                return NotFound();
            }

            return Ok(costpersecond);
        }

        // PUT api/Parametrization/5
        public IHttpActionResult PutCostPerSecond(int id, CostPerSecond costpersecond)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != costpersecond.Id)
            {
                return BadRequest();
            }

            db.Entry(costpersecond).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CostPerSecondExists(id))
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

        // POST api/Parametrization
        [ResponseType(typeof(CostPerSecond))]
        public IHttpActionResult PostCostPerSecond(CostPerSecond costpersecond)
        {
            costpersecond.Date = System.DateTime.Now;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            db.CostPerSeconds.Add(costpersecond);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = costpersecond.Id }, costpersecond);
        }

        // DELETE api/Parametrization/5
        [ResponseType(typeof(CostPerSecond))]
        public IHttpActionResult DeleteCostPerSecond(int id)
        {
            CostPerSecond costpersecond = db.CostPerSeconds.Find(id);
            if (costpersecond == null)
            {
                return NotFound();
            }

            db.CostPerSeconds.Remove(costpersecond);
            db.SaveChanges();

            return Ok(costpersecond);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CostPerSecondExists(int id)
        {
            return db.CostPerSeconds.Count(e => e.Id == id) > 0;
        }
    }
}