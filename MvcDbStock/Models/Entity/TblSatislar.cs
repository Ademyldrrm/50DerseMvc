//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcDbStock.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblSatislar
    {
        public int SATISID { get; set; }
        public Nullable<int> URUN { get; set; }
        public Nullable<int> MÜSTERİ { get; set; }
        public Nullable<byte> ADET { get; set; }
        public Nullable<decimal> FİYAT { get; set; }
    
        public virtual TblMüsteri TblMüsteri { get; set; }
        public virtual TblUrunler TblUrunler { get; set; }
    }
}
