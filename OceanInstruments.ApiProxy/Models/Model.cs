using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanInstruments.ApiProxy.Models
{
    public class Model
    {
        public virtual Int32 ModelId { get; set; }
        public virtual String Code { get; set; }
        public virtual String FullDesc { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
    }
}
