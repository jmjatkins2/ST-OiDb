using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanInstruments.ApiProxy.Models
{
    public class Calibration
    {
        public virtual Int32 CalibrationId { get; set; }
        public virtual Int32 DeviceId { get; set; }
        public virtual Double LowFreq { get; set; }
        public virtual Double HighFreq { get; set; }
        public virtual Double Tone { get; set; }
        public virtual Double RefLevel { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual Device Device { get; set; }
    }
}
