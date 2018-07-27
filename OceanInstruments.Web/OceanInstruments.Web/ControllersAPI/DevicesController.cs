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
using System.Security.Principal;
using System.Security.Claims;

namespace OceanInstruments.Web.ControllersAPI
{
    [RoutePrefix("api/devices")]
    //Note by default only allows Admin access
    //Can change individual action methods by adding [OverrideAuthorization] [Authorize(Roles = "Admin, DesktopClient")] or [AllowAnonymous]
    [OverrideAuthorization]
    [Authorize(Roles = "Admin, DesktopClient")]
    public class DevicesController : ApiController
    {
        private OceanInstrumentsEntities db = new OceanInstrumentsEntities();

        // GET: api/Devices
        public IQueryable<Device> GetDevices()
        {
            return db.Devices;
        }

        // GET: api/Devices/5
        [ResponseType(typeof(Device))]
        public async Task<IHttpActionResult> GetDevice(int id)
        {
            Device device = await db.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            return Ok(device);
        }

        // GET: api/Devices/Search/123...
        [HttpGet, Route("search/{serialNo}")]
        [AllowAnonymous]
        public IQueryable<object> SearchDevicesBySerialNo(string serialNo)
        {
            if (serialNo.Length < 3)
                return null;

            return from d in db.Devices
                   where d.SerialNo.StartsWith(serialNo)
                   orderby d.SerialNo
                   select new { d.DeviceId, d.SerialNo, d.ModelId, ModelName = d.Model.FullDesc };
        }

        // PUT: api/Devices/5
        [OverrideAuthorization]
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDevice(int id, Device device)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != device.DeviceId)
            {
                return BadRequest();
            }

            db.Entry(device).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(id))
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

        // POST: api/Devices
        [ResponseType(typeof(Device))]
        public async Task<IHttpActionResult> PostDevice(Device device)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            device.DateCreated = DateTime.Now;  //TODO: probably want to use UtcNow on azure

            db.Devices.Add(device);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = device.DeviceId }, device);
        }

        // DELETE: api/Devices/5
        [OverrideAuthorization]
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(Device))]
        public async Task<IHttpActionResult> DeleteDevice(int id)
        {
            Device device = await db.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            db.Devices.Remove(device);
            await db.SaveChangesAsync();

            return Ok(device);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeviceExists(int id)
        {
            return db.Devices.Count(e => e.DeviceId == id) > 0;
        }
    }
}