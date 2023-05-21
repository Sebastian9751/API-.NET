using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System.Net.Mail;
using System.Net;


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

        public string sedEmail(string email,string secret, string detination)
        {
            
            string status = "";
            string rutaabsoluta = "C:/Users/Glover E S C/Source/Repos/Sebastian9751/API-.NET/SOAP1-29AV";
            string rutarelativa = "/assets/cuerpoCorreo.txt";
            string ruta = rutaabsoluta+rutarelativa;
            string html = File.ReadAllText(ruta);
            MailMessage message = new MailMessage(email, detination, "Hello", html);
            message.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(email, secret);

            try
            {
                smtpClient.Send(message);
                status = "Envio de correo realizado con exito staus : OK ";

            }
            catch (SmtpException e)
            {
               
                status = "Parece que hubo un error en la solicitud: \n" + e.Message;

            }

            smtpClient.Dispose();



            return status;

        }
            
    }
}
