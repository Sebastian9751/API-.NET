﻿using Domain.Entities;
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
                    <link
                      href=""https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css""
                      rel=""stylesheet""
                      integrity=""sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ""
                      crossorigin=""anonymous""
                    />
                    <script
                      src=""https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js""
                      integrity=""sha384-ENjdO4Dr2bkBIFxQpeoTz1HIcje39Wm4jDKdf19U8gI4ddQ3GYNS7NTKfAdVQSZe""
                      crossorigin=""anonymous""
                    ></script>
                  </head>
                  <body class=""p-1"">
                    <div class=""fixed-top bg-warning py-2"">
                      <br>
                    </div>
                    <header class=""p-5 d-flex"">
                      <img src=""https://plataformaeducativa.upqroo.edu.mx/pluginfile.php/1/theme_lambda/logo/1661184096/upqroo_logo.png"">
                    </header>
                    <div class=""container-md text-center pb-1"">
                      <div class=""justify-content-center align-items-center "">
                        <h1>Bienvenido nuevo usuario</h1>
                        <p>Correo auto-generado favor de no responder</p>
                        <h3>Al usted recibir este correo se le hace acredor al acceso a la plataforma educativa por lo cual esta sujeto a los siguientes lineamientos:</h3>
                        <ul class=""fst-italic py-2"">
                          <li>Ya no tiene derechos humanos</li>
                          <li>Sera acusado por crimenes contra la humanidad por decir que las quesadillas van sin queso</li>
                          <li>Debera pasar una hora programando sin parar</li>
                          <li>Sera acredor de la habilidad de no poser ser creativo y diseñar interfaces feas</li>
                          <li>Si es PM, su unica obligacion sera preguntar '¿como van?'</li>
                        </ul>
                        <button type=""submit"" class=""p-2 btn btn-lg btn-warning"">Aceptar terminos</button>
                      </div>
                    </div>
                    <div class=""fixed-bottom bg-warning py-2"">
                      <p>@Universidad Politecnica de quintana roo derechos reservados </p>
                    </div>
                  </body>
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
