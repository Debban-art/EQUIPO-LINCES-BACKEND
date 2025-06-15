using System;
using Microsoft.AspNetCore.Mvc;
using EQUIPO_LINCES_BACKEND.Services;
using Microsoft.AspNetCore.Authorization;
using EQUIPO_LINCES_BACKEND.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using EQUIPO_LINCES_BACKEND.Helpers;
using Microsoft.AspNetCore.Hosting;
using System.Security.Cryptography.Xml;
using EQUIPO_LINCES_BACKEND.Utilities;


namespace EQUIPO_LINCES_BACKEND.Controllers
{
    [Route("api")]
    public class NotificacionController : ControllerBase
    {
        private readonly NotificacionService _NotificacionService;
        Encrypt enc = new Encrypt();

        public NotificacionController(NotificacionService notificacionService)
        {
            _NotificacionService = notificacionService;

        }

        [HttpPost("InsertNotificacion")]
        public IActionResult InsertNotificacion([FromBody] InsertNotificacionModel req)
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                objectResponse.message = "data creado con exito";
                _NotificacionService.InsertNotificacion(req);
            
            }
            catch(Exception ex)
        
            {
                objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("GetNotificacion")]
        public IActionResult GetNotificacion(int UsuarioId)
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "datos cargados correctamente";
                objectResponse.response = _NotificacionService.GetNotificacion(UsuarioId);
            
            }
            catch(Exception ex)
        
            {
                objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        
        // [HttpPut("UpdateRutas")]
        // public IActionResult UpdateRutas([FromBody] UpdateRutasModel req)
        // {
        //     var objectResponse = Helper.GetStructResponse();
        //     try{
        //         objectResponse.StatusCode = (int)HttpStatusCode.Created;
        //         objectResponse.success = true;
        //         _RutasService.UpdateRutas(req);
            
        //     }
        //     catch(Exception ex)
        
        //     {
        //         objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
        //         objectResponse.success = false;
        //         objectResponse.message = ex.Message;
        //     }

        //     return new JsonResult(objectResponse);
        // }


        // [HttpDelete("DeleteRutas")]
        // public IActionResult DeleteRutas([FromQuery] int Id)
        // {
        //     var objectResponse = Helper.GetStructResponse();
        //     try{
        //         objectResponse.StatusCode = (int)HttpStatusCode.Created;
        //         objectResponse.success = true;
        //         objectResponse.message = "data eliminado con exito";
        //         _RutasService.DeleteRutas(Id);
            
        //     }
        //     catch(Exception ex)
        
        //     {
        //         objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
        //         objectResponse.success = false;
        //         objectResponse.message = ex.Message;
        //     }

        //     return new JsonResult(objectResponse);
        // }


    }


}

