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
    public class VisitaProgramadaController : ControllerBase
    {
        private readonly VisitaProgramdaService _VisitaProgramdaService;
        Encrypt enc = new Encrypt();

        public VisitaProgramadaController(VisitaProgramdaService VisitaProgramdaService)
        {
            _VisitaProgramdaService = VisitaProgramdaService;

        }

        [HttpPost("InsertVisitasProgramada")]
        public IActionResult InsertVisitasProgramad([FromBody] InsertVisitasProgramadaModel req)
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                objectResponse.message = "data creado con exito";
                _VisitaProgramdaService.InsertVisitasProgramadas(req);
            
            }
            catch(Exception ex)
        
            {
                objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("GetVisitasProgramdas")]
        public IActionResult GetVisitasProgramada()
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "datos cargados correctamente";
                objectResponse.response = _VisitaProgramdaService.GetVisitasProgramadas();
            
            }
            catch(Exception ex)
        
            {
                objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        
        [HttpPut("UpdateVisitasProgramadas")]
        public IActionResult UpdateVisitasProgramadas([FromBody] UpdateVisitasProgramadasModel req)
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                _VisitaProgramdaService.UpdateVisitasProgramadas(req);
            
            }
            catch(Exception ex)
        
            {
                objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }


        [HttpDelete("DeleteVisitasProgramdas")]
        public IActionResult DeleteRutas([FromQuery] int Id)
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                objectResponse.message = "data eliminado con exito";
                _VisitaProgramdaService.DeleteVisitasProgramadas(Id);
            
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

