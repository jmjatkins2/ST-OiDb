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
    [RoutePrefix("api/calibrations")]
    //Note by default only allows Admin access
    //Can change individual action methods by adding [OverrideAuthorization] [Authorize(Roles = "Admin, DesktopClient")] or [AllowAnonymous]
    [OverrideAuthorization]
    [Authorize(Roles = "Admin, DesktopClient")]
    public class CalibrationsController : ApiController
    {
        private OceanInstrumentsEntities db = new OceanInstrumentsEntities();

        // GET: api/Calibrations
        public IQueryable<Calibration> GetCalibrations()
        {
            return db.Calibrations;
        }

        // GET: api/Calibrations/5
        [ResponseType(typeof(Calibration))]
        public async Task<IHttpActionResult> GetCalibration(int id)
        {
            Calibration calibration = await db.Calibrations.FindAsync(id);
            if (calibration == null)
            {
                return NotFound();
            }

            return Ok(calibration);
        }

        // GET: api/Calibrations/Device/1
        [HttpGet, Route("device/{deviceId}")]
        [AllowAnonymous]
        public IQueryable<object> GetCalibrationsForDevice(int deviceId)
        {
            return from c in db.Calibrations
                   where c.DeviceId == deviceId
                   orderby c.DateCreated descending
                   select c;
        }

        // PUT: api/Calibrations/5
        [OverrideAuthorization]
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCalibration(int id, Calibration calibration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calibration.CalibrationId)
            {
                return BadRequest();
            }

            db.Entry(calibration).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalibrationExists(id))
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

        // POST: api/Calibrations
        [ResponseType(typeof(Calibration))]
        public async Task<IHttpActionResult> PostCalibration(Calibration calibration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            calibration.DateCreated = DateTime.Now;  //TODO: probably want to use UtcNow on azure

            db.Calibrations.Add(calibration);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = calibration.CalibrationId }, calibration);
        }

        // DELETE: api/Calibrations/5
        [OverrideAuthorization]
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(Calibration))]
        public async Task<IHttpActionResult> DeleteCalibration(int id)
        {
            Calibration calibration = await db.Calibrations.FindAsync(id);
            if (calibration == null)
            {
                return NotFound();
            }

            db.Calibrations.Remove(calibration);
            await db.SaveChangesAsync();

            return Ok(calibration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CalibrationExists(int id)
        {
            return db.Calibrations.Count(e => e.CalibrationId == id) > 0;
        }
    }
}