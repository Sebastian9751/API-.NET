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
using Domain;

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

        public string  CrearPersonService(PersonaVM empleadoData)
        {
            Empleado newEmploye = new();
            newEmploye.Name = empleadoData.Name;
            newEmploye.Lastname = empleadoData.Lastname;
            newEmploye.CURP = empleadoData.CURP;
            newEmploye.RFC = empleadoData.RFC;
            newEmploye.email = empleadoData.email;
            newEmploye.FechaNacimiento = empleadoData.FechaNacimiento;
            newEmploye.SetPassword(empleadoData.Password);
            newEmploye.NumEmpleado = empleadoData.NumEmpleado;
            newEmploye.idArea = empleadoData.idArea;
            newEmploye.nombreEmpleado = empleadoData.nombreEmpleado;
            

            string result = personaRepositorio.CreateEmpleado(newEmploye);
            return result;
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
