//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFSecond.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KARY
    {
        public int ID_SPOTKANIA { get; set; }
        public int ID_DRUZYNY { get; set; }
        public int ID_PILKARZA { get; set; }
        public Nullable<int> MINUTA_KARY { get; set; }
        public string KARA { get; set; }
    }
}