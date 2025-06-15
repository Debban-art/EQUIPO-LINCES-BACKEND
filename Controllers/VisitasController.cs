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
    public class VisitasController : ControllerBase
    {
        private readonly VisitasService _VisitasService;
        Encrypt enc = new Encrypt();

        public VisitasController(VisitasService visitasService)
        {
            _VisitasService = visitasService;

        }

        [HttpPost("InsertVisitas")]
        public IActionResult InsertVisitas([FromBody] InsertVisitasModel req)
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                objectResponse.message = "data creado con exito";
                _VisitasService.InsertVisitas(req);
            
            }
            catch(Exception ex)
        
            {
                objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("GetVisitas")]
        public IActionResult GetVisitas()
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "datos cargados correctamente";
                objectResponse.response = _VisitasService.GetVisitas();
            
            }
            catch(Exception ex)
        
            {
                objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        
        [HttpPut("UpdateVisitas")]
        public IActionResult UpdateVisitas([FromBody] UpdateVisitasModel req)
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                _VisitasService.UpdateVisitas(req);
            
            }
            catch(Exception ex)
        
            {
                objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }


        [HttpDelete("DeleteVisitas")]
        public IActionResult DeleteRutas([FromQuery] int Id)
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                objectResponse.message = "data eliminado con exito";
                _VisitasService.DeleteVisitas(Id);
            
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

