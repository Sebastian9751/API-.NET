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

        public List<Items> ObtenerItemsDisponibles()
        {
            List<Items> items = new List<Items>();

            try
            {
                items = personaRepositorio.ObtenerItemsDis().Where(x => x.status == true).ToList();

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return items;
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
                    
                    Email = x.email,
                    NumEmpleado = x.numero_empleado,
                    ItemId= x.ItemId,
                    ItemName = x.Item.NombreItem,
                    ItemDesc = x.Item.Description,

                    
                }).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return empleados;
        }

       

        public void GuardarEmpleados(Persona empleado)
        {
            try
            {
                personaRepositorio.GuardarEmpleados(empleado);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        public void GuardarItem(Items item)
        {
            try
            {
                personaRepositorio.GuardarItem(item);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        public void AsignarItem(ItemsVM item)
        {
            try
            {
                personaRepositorio.Asignacion(item);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}
