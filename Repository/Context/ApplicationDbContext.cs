﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Repository.Context
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Persona> Personas { get; set; }
       
        public virtual DbSet<Items> Items { get; set; } 
        public virtual DbSet<Asignaciones> Asignaciones { get; set; }
        public ApplicationDbContext(DbContextOptions options): base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
