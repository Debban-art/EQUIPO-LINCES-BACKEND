using System;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using EQUIPO_LINCES_BACKEND.Models;
using EQUIPO_LINCES_BACKEND.Services;
using EQUIPO_LINCES_BACKEND.Helpers;
using EQUIPO_LINCES_BACKEND.Utilities;

namespace EQUIPO_LINCES_BACKEND.Controllers
{
    [Route("api")]
    public class DetalleVentaController: ControllerBase
    {
   
        private readonly DetallePuntoVentaService _DetallePuntoVentaService;
        

        Encrypt enc = new Encrypt();

        public DetalleVentaController(DetallePuntoVentaService detallePuntoVentaService) {
            _DetallePuntoVentaService = detallePuntoVentaService;
           
            // Configura la ruta base donde se almacenan los archivos.
            // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
        }


        [HttpPost("InsertDetallePuntoVenta")]
        public IActionResult InsertDetallePuntoVenta([FromBody] InsertDetalleVentaModel req)
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                objectResponse.message = "data creado con exito";
                _DetallePuntoVentaService.InsertDetallePuntoVenta(req);
            
            }
            catch(Exception ex)
        
            {
                objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("GetDetallePuntoVenta")]
        public IActionResult GetDetallePuntoVenta()
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "datos cargados correctamente";
                objectResponse.response = _DetallePuntoVentaService.GetDetalleVenta();
            
            }
            catch(Exception ex)
        
            {
                objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        
        [HttpPut("UpdateDetallePuntoVenta")]
        public IActionResult UpdateDetallePuntoVenta([FromBody] UpdateDetalleVentaModel req)
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                _DetallePuntoVentaService.UpdateDetalleVenta(req);
            
            }
            catch(Exception ex)
        
            {
                objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }


        [HttpDelete("DeleteDetallePuntoVenta")]
        public IActionResult DeleteRutas([FromQuery] int Id)
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                objectResponse.message = "data eliminado con exito";
                _DetallePuntoVentaService.DeleteDetalleVenta(Id);
            
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
