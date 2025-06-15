// Controlador para ImagenesVisita
using System;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using EQUIPO_LINCES_BACKEND.Models;
using EQUIPO_LINCES_BACKEND.Services;
using EQUIPO_LINCES_BACKEND.Helpers;

namespace EQUIPO_LINCES_BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenesVisitaController : ControllerBase
    {
        private readonly ImagenesVisitaService _service;

        public ImagenesVisitaController(ImagenesVisitaService service)
        {
            _service = service;
        }

        [HttpGet("obtener")]
        public IActionResult GetImagenesPorVisita()
        {
            var response = Helper.GetStructResponse();
            try
            {
                var data = _service.GetImagenesPorVisita();
                response.StatusCode = (int)HttpStatusCode.OK;
                response.success = true;
                response.message = "Imágenes obtenidas correctamente";
                response.response = data;
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.success = false;
                response.message = ex.Message;
            }
            return new JsonResult(response);
        }

        [HttpPost("registrar")]
        public IActionResult RegistrarImagenVisita([FromBody] RegistrarImagenVisita req)
        {
            var response = Helper.GetStructResponse();
            try
            {
                _service.RegistrarImagenVisita(req);
                response.StatusCode = (int)HttpStatusCode.Created;
                response.success = true;
                response.message = "Imagen registrada correctamente";
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.success = false;
                response.message = ex.Message;
            }
            return new JsonResult(response);
        }

        [HttpPut("actualizar-analisis")]
        public IActionResult ActualizarAnalisisImagen([FromBody] ActualizarAnalisisImagen req)
        {
            var response = Helper.GetStructResponse();
            try
            {
                _service.ActualizarAnalisisImagen(req);
                response.StatusCode = (int)HttpStatusCode.OK;
                response.success = true;
                response.message = "Análisis actualizado correctamente";
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.success = false;
                response.message = ex.Message;
            }
            return new JsonResult(response);
        }

        [HttpDelete("eliminar")]
        public IActionResult EliminarImagenVisita([FromQuery] int id)
        {
            var response = Helper.GetStructResponse();
            try
            {
                _service.EliminarImagenVisita(id);
                response.StatusCode = (int)HttpStatusCode.OK;
                response.success = true;
                response.message = "Imagen eliminada correctamente";
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.success = false;
                response.message = ex.Message;
            }
            return new JsonResult(response);
        }
    }
}