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
using System.Security.Cryptography;

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

        

        List<Asignaciones> IPersona.ObtenerEmpleado()
        {
            List<Asignaciones> empleados = new List<Asignaciones>();
            try
            {
                empleados = personaRepositorio.ObtenerEmpleados();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return empleados;
        }
        public List<Asignaciones> ObtenerEmpleadosById(int id)
        {
            List<Asignaciones> empleados = new List<Asignaciones>();
            try
            {
                empleados = personaRepositorio.ObtenerEmpleadosById(id);
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
                string pass = empleado.password;
                string hashPass= HashPassword(pass);
                empleado.password = hashPass;
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

        public void SetStatusItem(bool status, int id_item)
        {
            try
            {
                personaRepositorio.SetStatusItem(status, id_item);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        public List<string> sendMessageRemember(string email, string secret, string destination)
        {
            List<string> emails = new List<string>();
            try
            {
                personaRepositorio.sedEmail(email, secret, destination);
                emails.Add("Correo enviado a :" + destination);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return emails;
        }
        // aqui logica para encryp la constraseña
        public string login(string email, string password)
        {
            try {
                Persona p = personaRepositorio.GetPersona(email);
                if (p.Id ==0) { return "Correo no encontrado"; }
                bool auth = VerifyPassword(password, p.password);
                if (!auth) return "contraseña incorrecta";

                return "login exitoso!!!";
            }
            catch(Exception e) {
                return "Erro en login"; 
            }
        }
        // hash password:
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                string hash = Convert.ToBase64String(hashedBytes);
                return hash;
            }
        }

        // Verify password
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            string hashedInput = HashPassword(password);
            return hashedInput == hashedPassword;
        }
    }
    
}
