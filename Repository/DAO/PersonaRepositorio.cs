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
            
    }
}
