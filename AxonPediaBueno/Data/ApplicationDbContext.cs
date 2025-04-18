﻿using Microsoft.EntityFrameworkCore;
using AxonPediaBueno.Models;

namespace AxonPediaBueno.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Paragraphe> Paragraphes { get; set; }


    }
}
