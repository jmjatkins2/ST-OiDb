﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OceanInstrumentsEntities : DbContext
    {
        public OceanInstrumentsEntities()
            : base("name=OceanInstrumentsEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Calibration> Calibrations { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Model> Models { get; set; }
    }
}
