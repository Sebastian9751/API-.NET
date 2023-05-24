using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Context;
using Repository.DAO;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PersonaServicio : IPersona
    {
        private readonly ILogger<PersonaServicio> _logger;
        private readonly PersonaRepositorio personaRepositorio;


        public PersonaServicio(ILogger<PersonaServicio> logger, ApplicationDbContext context)
        {
            _logger = logger;
            personaRepositorio = new PersonaRepositorio(context);
        }

        public bool IsAuthenticated(LoginVM data) 
        {
            Empleado empleado = personaRepositorio.Login(data.email);
            if (empleado == null) { return false; }
            return empleado.VerifyPassword(data.password);
        }

        public string  CrearPersonService()
        {
            Empleado persona = new();
            persona.Name = "manuel";
            persona.Lastname = "garcia";
            persona.CURP = "dfvdf46v5";
            persona.RFC = "fd55454ed";
            persona.email = "langelxobl@gmail.com";
            persona.FechaNacimiento = DateTime.Now;
            persona.SetPassword("password");
            persona.NumEmpleado = 3;
            persona.idArea = 1;
            persona.nombreEmpleado = "sdcsdq amsk";
            

            personaRepositorio.CreateEmpleado(persona);
            return "usuario creado";
        }

        public List<Persona> ObtenerLista()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                personas = personaRepositorio.ObtenerLista();

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return personas;
        }

        public List<string> sendMessage(string email, string secret)
        {
            List<string> emails = new List<string>();
            

            try
            {
                List<Persona> personas = personaRepositorio.ObtenerLista();

                foreach (Persona persona in personas)
                {
                    personaRepositorio.sedEmail(email, secret, persona.email);
                    emails.Add("Correo enviado a :"+persona.email);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return emails;
        }

        

        List<EmpleadosVM> IPersona.ObtenerEmpleado()
        {
            List<EmpleadosVM> empleados = new List<EmpleadosVM>();
            try
            {
                empleados = personaRepositorio.ObtenerEmpleados().Select(x => new EmpleadosVM()
                {
                    Nombre = x.Name,
                    Apellidos = x.Lastname,
                    Area = x.Area.Nombre,
                    Email = x.email,
                    NumEmpleado = x.NumEmpleado
                }).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return empleados;
        }
    }
}
