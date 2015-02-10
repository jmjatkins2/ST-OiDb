using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OceanInstruments.ApiProxy.Models
{
    public class Device
    {
        public virtual Int32 DeviceId { get; set; }
        public virtual String SerialNo { get; set; }
        public virtual Int32 ModelId { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual Nullable<DateTime> DateUpdated { get; set; }
        public virtual ICollection<Calibration> Calibrations { get; set; }
        public virtual Model Model { get; set; }
    }
}
