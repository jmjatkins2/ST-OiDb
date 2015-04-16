//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OceanInstruments.Web
{
    using System;
    using System.Collections.Generic;
    
    public partial class Device
    {
        public Device()
        {
            this.Calibrations = new HashSet<Calibration>();
            this.ProdTestResults = new HashSet<ProdTestResult>();
        }
    
        public int DeviceId { get; set; }
        public string SerialNo { get; set; }
        public int ModelId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    
        public virtual ICollection<Calibration> Calibrations { get; set; }
        public virtual Model Model { get; set; }
        public virtual ICollection<ProdTestResult> ProdTestResults { get; set; }
    }
}
