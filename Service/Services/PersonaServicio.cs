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

        public string SendMail()
        {
            Boolean result;
            string status = "";


            string fromE = "stevewarz97@gmail.com";
            string toE = "stevewarz97@gmail.com";
            string secret = "mdwvabkxltfbwqdz";
            MailMessage message = new MailMessage(fromE, toE, "Hello", "World");
            message.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(fromE, secret);

            try
            {
                smtpClient.Send(message);
                result = true;
                status = "Email sent successfully = " + result;
            
            }
            catch (SmtpException e)
            {
                _logger.LogError(e.Message);
                
            }

            smtpClient.Dispose();



            return status;
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
