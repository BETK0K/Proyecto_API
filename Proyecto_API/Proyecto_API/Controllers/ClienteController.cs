using Microsoft.AspNetCore.Mvc;
using Proyecto_API.Models;

namespace Proyecto_API.Controllers
{
    [ApiController] //El atributo [ApiController] se puede aplicar a una clase de controlador para permitir los comportamientos específicos de la API
    [Route("cliente")] //Especifica el patrón de dirección URL de un controlador o una acción.
    public class ClienteController : ControllerBase  //La clase ControllerBase ofrece muchas propiedades y métodos que son útiles para gestionar solicitudes HTTP. 
    {
        [HttpGet] //Identifica una acción que admite el verbo de acción GET HTTP.
        [Route("listar")] //Especifica el patrón de dirección URL de un controlador o una acción.

        public dynamic listarCliente()  //dynamic es un elemento que admite cualquier operación
        {
            List<Clientes> lclientes = new List<Clientes>
            {
                new Clientes
                {
                    id = "1",
                    correo = "r.carlos.010201@gmail.com",
                    edad = "22",
                    nombre = "Roberto Carlos Flores Tapia"
                },
                new Clientes
                {
                    id = "2",
                    correo = "tic270184@gmail.com",
                    edad = "21",
                    nombre = "Roberto Flores"
                },
                new Clientes
                {
                    id = "3",
                    correo = "kokis25.03.16@gmail.com",
                    edad = "23",
                    nombre = "Carlos Tapia"
                }
            };
            return lclientes;
        }

        [HttpGet] //Identifica una acción que admite el verbo de acción GET HTTP.
        [Route("listarPorId")] //Especifica el patrón de dirección URL de un controlador o una acción.

        public dynamic listarClientePorId(int codigo)
        {
            return new Clientes
            {
                id = codigo.ToString(),
                correo = "google@gmail.com",
                edad = "19",
                nombre = "Bernardo Peña"
            };
        }

        [HttpPost] //Identifica una acción que admite el verbo de acción POST HTTP.
        [Route("guardar")] //Especifica el patrón de dirección URL de un controlador o una acción.

        public dynamic guardarCliente(Clientes clientes)
        {
            clientes.id = "3";

            return new
            {
                success = true,
                message = "Cliente Registrado",
                results = clientes
            };
        }

        [HttpPost] //Identifica una acción que admite el verbo de acción POST HTTP.
        [Route("eliminar")] //Especifica el patrón de dirección URL de un controlador o una acción.
        public dynamic eliminarCliente(Clientes cliente)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;

            if (token != "Beto010201")
            if (token != "Beto010201")
            {
                return new
                {
                    success = false,
                    message = "token incorrecto",
                    result = ""
                };
            }

            return new
            {
                success = true,
                message = "cliente eliminado",
                result = cliente
            };
        }
    }
}
