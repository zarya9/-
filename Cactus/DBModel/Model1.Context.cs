﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cactus.DBModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class cactusEntities : DbContext
    {
        public cactusEntities()
            : base("name=cactusEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cactus> Cactus { get; set; }
        public virtual DbSet<Cactus_Vistavka> Cactus_Vistavka { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vistavka> Vistavka { get; set; }
    }
}