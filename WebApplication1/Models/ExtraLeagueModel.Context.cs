﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ExtraLeagueEntities1 : DbContext
    {
        public ExtraLeagueEntities1()
            : base("name=ExtraLeagueEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DRUZYNY> DRUZYNY { get; set; }
        public virtual DbSet<KARY> KARY { get; set; }
        public virtual DbSet<MIASTA> MIASTA { get; set; }
        public virtual DbSet<PILKARZE> PILKARZE { get; set; }
        public virtual DbSet<SEDZIOWIE> SEDZIOWIE { get; set; }
        public virtual DbSet<SPOTKANIA> SPOTKANIA { get; set; }
        public virtual DbSet<TRENERZY> TRENERZY { get; set; }
        public virtual DbSet<WYNIK> WYNIK { get; set; }
    }
}
