using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Logging;

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

        public List<Asignaciones> ObtenerEmpleados()
        {
            List<Asignaciones> empleados = new List<Asignaciones>();
           
                empleados = (from asignacion in _context.Asignaciones
                             join item in _context.Items on asignacion.id_item equals item.id

                             select new Asignaciones
                             {
                                 id = asignacion.id,
                                 id_persona = asignacion.id_persona,
                                 id_item = asignacion.id_item,
                                 dia_asignacion = asignacion.dia_asignacion,
                                 dia_entrega = asignacion.dia_entrega,
                                 dia_liberacion = asignacion.dia_liberacion,
                                 Persona = asignacion.Persona,
                                 Items = item
                             }).ToList();
            
            return empleados;
        }

        public List<Asignaciones> ObtenerEmpleadosById(int id)
        {
            List<Asignaciones> empleados = new List<Asignaciones>();

            empleados = (from asignacion in _context.Asignaciones
                         join item in _context.Items on asignacion.id_item equals item.id
                         where asignacion.id_persona == id
                         select new Asignaciones
                         {
                             id = asignacion.id,
                             id_persona = asignacion.id_persona,
                             id_item = asignacion.id_item,
                             dia_asignacion = asignacion.dia_asignacion,
                             dia_entrega = asignacion.dia_entrega,
                             dia_liberacion = asignacion.dia_liberacion,
                             Persona = asignacion.Persona,
                             Items = item
                         }).ToList();

            return empleados;
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
            try
            {
                _context.Asignaciones.Add(new Asignaciones
                {
                    id_item = item.ItemId,
                    id_persona = item.id_persona,
                    dia_asignacion = item.dia_asignacion,
                    dia_liberacion = item.dia_liberacion,
                    dia_entrega = item.dia_entrega
                });
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // Manejar la excepción según sea necesario
                throw e;
            }
        }

        public void SetStatusItem(bool status, int id_item)
        {
            var item = _context.Items.Find(id_item);
            if (item == null)
            {
                // Manejar caso de objeto no encontrado
                return;
            }

            item.status = status;
            _context.Items.Update(item);
            _context.SaveChanges();
        }
    }
}
