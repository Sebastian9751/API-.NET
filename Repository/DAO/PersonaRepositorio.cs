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


        public List<Items> ObtenerItemsDis()
        {
            List<Items> lista = new List<Items>();

            lista = _context.Items.ToList();
            return lista;

        }

        public List<Empleado> ObtenerEmpleados()
        {
            List<Empleado> lis = new List<Empleado>();
            lis = _context.Empleados.Include(x=>x.Item).ToList();
            return lis;
        }

        public string sedEmail(string email,string secret, string detination)
        {
            
            string status = "";

            MailMessage message = new MailMessage(email, detination, "Hello", "World");
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

        public void GuardarEmpleados(Persona empleados)
        {
            try
            {
                _context.Personas.AddRange(empleados);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // Manejar la excepción según sea necesario
                throw e;
            }
        }

        public void GuardarItem(Items item)
        {
            try
            {
                _context.Items.AddRange(item);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // Manejar la excepción según sea necesario
                throw e;
            }
        }

        public void Asignacion(ItemsVM item)
        {
            throw new NotImplementedException();
        }
    }
}
