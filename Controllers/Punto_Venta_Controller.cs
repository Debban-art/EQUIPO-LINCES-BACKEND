using Microsoft.AspNetCore.Mvc;
using EQUIPO_LINCES_BACKEND.Models;
using EQUIPO_LINCES_BACKEND.Services;
using EQUIPO_LINCES_BACKEND.Helpers;
using System.Net;
using EQUIPO_LINCES_BACKEND.Utilities;

namespace EQUIPO_LINCES_BACKEND.Controllers
{
    [Route("api")]
    public class Punto_Venta_Controller: ControllerBase
    {
   
        private readonly Punto_Venta_Service _Punto_Venta_Service;


        Encrypt enc = new Encrypt();

        public Punto_Venta_Controller(Punto_Venta_Service punto_Venta_Service) {
            _Punto_Venta_Service = punto_Venta_Service;
           
            // Configura la ruta base donde se almacenan los archivos.
            // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
        }


        [HttpPost("insert_pv")]
        public IActionResult insert_pv([FromBody] insert_pv req)
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                objectResponse.message = "data creado con exito";
                _Punto_Venta_Service.insert_pv(req);
            
            }
            catch(Exception ex)
        
            {
                objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("get_pv")]
        public IActionResult get_pv()
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "datos cargados correctamente";
                objectResponse.response = _Punto_Venta_Service.get_pv();
            
            }
            catch(Exception ex)
        
            {
                objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        
        [HttpPut("update_pv")]
        public IActionResult update_pv([FromBody] update_pv req)
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                _Punto_Venta_Service.update_pv(req);
            
            }
            catch(Exception ex)
        
            {
                objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }


        [HttpDelete("delete_pv")]
        public IActionResult delete_pv([FromQuery] int Id)
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                objectResponse.message = "data eliminado con exito";
                _Punto_Venta_Service.delete_pv(Id);
            
            }
            catch(Exception ex)
        
            {
                objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }
    }
}
