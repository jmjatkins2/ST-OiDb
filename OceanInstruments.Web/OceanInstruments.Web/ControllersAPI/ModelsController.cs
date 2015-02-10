using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OceanInstruments.Web;

namespace OceanInstruments.Web.ControllersAPI
{
    [RoutePrefix("api/models")]
    //Note by default only allows Admin access
    //Can change individual action methods by adding [OverrideAuthorization] [Authorize(Roles = "Admin, DesktopClient")] or [AllowAnonymous]
    [OverrideAuthorization]
    [Authorize(Roles = "Admin, DesktopClient")]
    public class ModelsController : ApiController
    {
        private OceanInstrumentsEntities db = new OceanInstrumentsEntities();

        // GET: api/Models
        [OverrideAuthorization]
        [Authorize(Roles = "Admin, DesktopClient")]
        public IQueryable<Model> GetModels()
        {
            return db.Models;
        }

        // GET: api/Models/5
        [ResponseType(typeof(Model))]
        public async Task<IHttpActionResult> GetModel(int id)
        {
            Model model = await db.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // PUT: api/Models/5
        [OverrideAuthorization]
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutModel(int id, Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ModelId)
            {
                return BadRequest();
            }

            db.Entry(model).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
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

        // POST: api/Models
        [ResponseType(typeof(Model))]
        public async Task<IHttpActionResult> PostModel(Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Models.Add(model);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = model.ModelId }, model);
        }

        // DELETE: api/Models/5
        [OverrideAuthorization]
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(Model))]
        public async Task<IHttpActionResult> DeleteModel(int id)
        {
            Model model = await db.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.Models.Remove(model);
            await db.SaveChangesAsync();

            return Ok(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModelExists(int id)
        {
            return db.Models.Count(e => e.ModelId == id) > 0;
        }
    }
}