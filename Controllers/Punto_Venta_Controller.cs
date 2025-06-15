using Microsoft.AspNetCore.Mvc;
using EQUIPO_LINCES_BACKEND.Models;
using EQUIPO_LINCES_BACKEND.Services;
using EQUIPO_LINCES_BACKEND.Helpers;
using System.Net;

namespace EQUIPO_LINCES_BACKEND.Controllers
{
    [Route("api")]
    public class TiendaController : ControllerBase
    {
        private readonly TiendaService _service;

        public TiendaController(TiendaService service)
        {
            _service = service;
        }

        [HttpGet("tiendas")]
        public IActionResult GetTiendas()
        {
            var res = Helper.GetStructResponse();
            try
            {
                res.success = true;
                res.StatusCode = (int)HttpStatusCode.OK;
                res.response = _service.GetTiendas();
                res.message = "Tiendas cargadas";
            }
            catch (Exception ex)
            {
                res.success = false;
                res.StatusCode = (int)HttpStatusCode.InternalServerError;
                res.message = ex.Message;
            }

            return new JsonResult(res);
        }

        [HttpGet("tiendas/{id}")]
        public IActionResult GetTiendaById(int id)
        {
            var res = Helper.GetStructResponse();
            try
            {
                var tienda = _service.GetTiendaById(id);
                if (tienda == null)
                {
                    res.success = false;
                    res.StatusCode = (int)HttpStatusCode.NotFound;
                    res.message = "Tienda no encontrada";
                }
                else
                {
                    res.success = true;
                    res.StatusCode = (int)HttpStatusCode.OK;
                    res.response = tienda;
                    res.message = "Tienda encontrada";
                }
            }
            catch (Exception ex)
            {
                res.success = false;
                res.StatusCode = (int)HttpStatusCode.InternalServerError;
                res.message = ex.Message;
            }

            return new JsonResult(res);
        }

        [HttpPost("tiendas")]
        public IActionResult InsertTienda([FromBody] InsertTiendaModel model)
        {
            var res = Helper.GetStructResponse();
            try
            {
                _service.InsertTienda(model);
                res.success = true;
                res.StatusCode = (int)HttpStatusCode.Created;
                res.message = "Tienda creada";
            }
            catch (Exception ex)
            {
                res.success = false;
                res.StatusCode = (int)HttpStatusCode.BadRequest;
                res.message = ex.Message;
            }

            return new JsonResult(res);
        }

        [HttpPut("tiendas/{id}")]
        public IActionResult UpdateTienda(int id, [FromBody] InsertTiendaModel model)
        {
            var res = Helper.GetStructResponse();
            try
            {
                _service.UpdateTienda(id, model);
                res.success = true;
                res.StatusCode = (int)HttpStatusCode.OK;
                res.message = "Tienda actualizada";
            }
            catch (Exception ex)
            {
                res.success = false;
                res.StatusCode = (int)HttpStatusCode.BadRequest;
                res.message = ex.Message;
            }

            return new JsonResult(res);
        }

        [HttpDelete("tiendas/{id}")]
        public IActionResult DeleteTienda(int id)
        {
            var res = Helper.GetStructResponse();
            try
            {
                _service.DeleteTienda(id);
                res.success = true;
                res.StatusCode = (int)HttpStatusCode.OK;
                res.message = "Tienda eliminada";
            }
            catch (Exception ex)
            {
                res.success = false;
                res.StatusCode = (int)HttpStatusCode.BadRequest;
                res.message = ex.Message;
            }

            return new JsonResult(res);
        }

        [HttpPost("tiendas/{id}/imagenes")]
        public IActionResult UploadImagenes(int id, [FromBody] List<string> imagenes)
        {
            var res = Helper.GetStructResponse();
            try
            {
                _service.UploadImagenes(id, imagenes);
                res.success = true;
                res.StatusCode = (int)HttpStatusCode.OK;
                res.message = "Imágenes cargadas";
            }
            catch (Exception ex)
            {
                res.success = false;
                res.StatusCode = (int)HttpStatusCode.BadRequest;
                res.message = ex.Message;
            }

            return new JsonResult(res);
        }

        [HttpGet("tiendas/{id}/resumen")]
        public IActionResult GetResumen(int id)
        {
            var res = Helper.GetStructResponse();
            try
            {
                res.success = true;
                res.StatusCode = (int)HttpStatusCode.OK;
                res.response = _service.GetResumen(id);
                res.message = "Resumen generado";
            }
            catch (Exception ex)
            {
                res.success = false;
                res.StatusCode = (int)HttpStatusCode.InternalServerError;
                res.message = ex.Message;
            }

            return new JsonResult(res);
        }
    }
}
