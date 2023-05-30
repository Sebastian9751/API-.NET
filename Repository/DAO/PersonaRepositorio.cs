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

        static string ObtenerContenidoHTML()
        {
            string contenidoHTML = @"
                <!DOCTYPE html>
                <html lang=""en"">
                  <head>
                    <meta charset=""UTF-8"" />
                    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
                  </head>
                  <body>
                    <div class=""fixed-top"">
                      <header>
                        <img
                          src=""https://plataformaeducativa.upqroo.edu.mx/pluginfile.php/1/theme_lambda/logo/1661184096/upqroo_logo.png"" class=""header img""
                        />
                      </header>
                    </div>
                    <div class=""card"">
                      <div class=""card-content"">
                        <div class=""card-title"">
                          <h1>Bienvenido nuevo usuario</h1>
                          <p>Correo auto-generado favor de no responder</p>
                          <h3>
                            Al usted recibir este correo se le hace acredor al acceso a la
                            plataforma educativa por lo cual esta sujeto a los siguientes
                            lineamientos:
                          </h3>
                          <ul class=""card-content"">
                            <li>Ya no tiene derechos humanos</li>
                            <li>
                              Sera acusado por crimenes contra la humanidad por decir que las
                              quesadillas van sin queso
                            </li>
                            <li>Debera pasar una hora programando sin parar</li>
                            <li>
                              Sera acredor de la habilidad de no poser ser creativo y diseñar
                              interfaces feas
                            </li>
                            <li>Si es PM, su unica obligacion sera preguntar '¿como van?'</li>
                          </ul>
                          <div class=""card-buttom"">
                            <button type=""submit"" class=""boton"">Aceptar terminos</button>
                          </div>
                        </div>
                      </div>
                    </div>
                    <div class=""fixed-bottom"">
                      <p>@Universidad Politecnica de quintana roo derechos reservados</p>
                    </div>
                  </body>
                  <style>
                    .boton {
                      color: #fff !important;
                      font-size: 20px;
                      font-weight: 500;
                      padding: 0.5em 1.2em;
                      background: #318aac;
                      border: 2px solid;
                      border-color: #318aac;
                      position: relative;
                    }
    
                    .boton:before {
                      content: """";
                      position: absolute;
                      top: 0px;
                      left: 0px;
                      width: 0px;
                      height: 100%;
                      background: rgba(255, 255, 255, 0.1);
                      transition: all 1s ease;
                    }
    
                    .boton:hover:before {
                      width: 100%;
                    }
    
                    /* Estilos para dispositivos móviles */
                    @media (max-width: 768px) {
                      .boton {
                        font-size: 16px;
                        padding: 0.3em 0.8em;
                      }
                    }

                    html,
                    body {
                      height: 100%;
                      margin: 0;
                      padding: 0;
                    }

                    body {
                      display: flex;
                      flex-direction: column;
                    }

                    .container-md {
                      flex: 1;
                    }

                    .fixed-bottom {
                      margin-top: auto;
                      text-align: center;
                    }

                    .fixed-top {
                      margin-bottom: auto;
                      text-align: center;
                    }
    
                    header img {
                      max-width: 100%;
                      height: auto;
                    }
    
                    @media (max-width: 768px) {
                      header img {
                        max-width: 50%;
                      }
                    }

                    .card {
                      border: 1px solid #ccc;
                      border-radius: 4px;
                      box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
                      width: 500px;
                      max-width: 100%;
                      margin: 0 auto;
                      background-color: #fff;
                    }
    
                    .card-image {
                      width: 100%;
                      height: auto;
                      border-top-left-radius: 4px;
                      border-top-right-radius: 4px;
                    }
    
                    .card-content {
                      padding: 16px;
                    }
    
                    .card-title {
                      margin-top: 0;
                    }
    
                    .card-description {
                      margin-bottom: 16px;
                    }
    
                    .card-link {
                      display: inline-block;
                      padding: 8px 16px;
                      background-color: #318aac;
                      color: #fff;
                      text-decoration: none;
                      border-radius: 4px;
                    }
                    .card-buttom{
                      text-align: center;
                    }
                  </style>
                </html>

                ";
            return contenidoHTML;
        }


        public string sedEmail(string email,string secret, string detination)
        {
            
            string status = "";
            MailMessage message = new MailMessage(email, detination, "Hello", ObtenerContenidoHTML());
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
