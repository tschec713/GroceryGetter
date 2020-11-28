﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GroceryGetter.PL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class GroceryGetterEntities : DbContext
    {
        public GroceryGetterEntities()
            : base("name=GroceryGetterEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblAisle> tblAisles { get; set; }
        public virtual DbSet<tblAisleProduct> tblAisleProducts { get; set; }
        public virtual DbSet<tblLayout> tblLayouts { get; set; }
        public virtual DbSet<tblProduct> tblProducts { get; set; }
        public virtual DbSet<tblStore> tblStores { get; set; }
        public virtual DbSet<tblUserProduct> tblUserProducts { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
    
        public virtual int ClearGroceryList(Nullable<System.Guid> userid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ClearGroceryList", useridParameter);
        }
    }
}
