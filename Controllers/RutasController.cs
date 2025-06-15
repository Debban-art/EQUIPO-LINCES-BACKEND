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
    public class RutasController : ControllerBase
    {
        private readonly RutasService _RutasService;
        Encrypt enc = new Encrypt();

        public RutasController(RutasService rutasService)
        {
            _RutasService = rutasService;

        }

        [HttpPost("InsertRutas")]
        public IActionResult InsertRutas([FromBody] InsertRutasModel req)
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                objectResponse.message = "data creado con exito";
                _RutasService.InsertRutas(req);
            
            }
            catch(Exception ex)
        
            {
                objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("GetRutas")]
        public IActionResult GetRutas()
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "datos cargados correctamente";
                objectResponse.response = _RutasService.GetRutas();
            
            }
            catch(Exception ex)
        
            {
                objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        
        [HttpPut("UpdateRutas")]
        public IActionResult UpdateRutas([FromBody] UpdateRutasModel req)
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                _RutasService.UpdateRutas(req);
            
            }
            catch(Exception ex)
        
            {
                objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }


        [HttpDelete("DeleteRutas")]
        public IActionResult DeleteRutas([FromQuery] int Id)
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                objectResponse.message = "data eliminado con exito";
                _RutasService.DeleteRutas(Id);
            
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

