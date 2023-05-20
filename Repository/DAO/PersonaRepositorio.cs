﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAO
{
    public class PersonaRepositorio
    {
        private readonly ApplicationDbContext _context;

        public PersonaRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Persona> ObtenerLista()
        {
            List<Persona> lista = new List<Persona>();
    
            lista = _context.Personas.ToList(); 
            return lista;

        }

        public List<Empleado> ObtenerEmpleados()
        {
            List<Empleado> lis = new List<Empleado>();
            lis = _context.Empleados.Include(x=>x.Area).ToList();
            return lis;
        }

    }
}
