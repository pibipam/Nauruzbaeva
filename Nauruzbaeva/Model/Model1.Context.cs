﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nauruzbaeva.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class user23Entities : DbContext
    {
        public user23Entities()
            : base("name=user23Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Activity> Activity { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Direction> Direction { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<EventParticipant> EventParticipant { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Jury> Jury { get; set; }
        public DbSet<Moderator> Moderator { get; set; }
        public DbSet<Organizer> Organizer { get; set; }
        public DbSet<Participant> Participant { get; set; }
    }
}
