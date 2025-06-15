using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using EQUIPO_LINCES_BACKEND.Models;
using EQUIPO_LINCES_BACKEND.Services;
using EQUIPO_LINCES_BACKEND.Helpers;

namespace EQUIPO_LINCES_BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackService _feedbackService;

        public FeedbackController(FeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost]
        public IActionResult InsertFeedback([FromBody] InsertFeedbackModel model)
        {
            var response = Helper.GetStructResponse();
            try
            {
                _feedbackService.InsertFeedback(model);
                response.StatusCode = (int)HttpStatusCode.Created;
                response.success = true;
                response.message = "Feedback creado exitosamente";
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.success = false;
                response.message = ex.Message;
            }

            return new JsonResult(response);
        }

        [HttpGet]
        public IActionResult GetFeedbacksByTienda([FromQuery] int tiendaId)
        {
            var response = Helper.GetStructResponse();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.success = true;
                response.response = _feedbackService.GetFeedbacksByTienda(tiendaId);
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.success = false;
                response.message = ex.Message;
            }

            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetFeedbackById(int id)
        {
            var response = Helper.GetStructResponse();
            try
            {
                var feedback = _feedbackService.GetFeedbackById(id);
                if (feedback == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.success = false;
                    response.message = "Feedback no encontrado";
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.OK;
                    response.success = true;
                    response.response = feedback;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.success = false;
                response.message = ex.Message;
            }

            return new JsonResult(response);
        }

        [HttpPost("{id}/analizar")]
        public IActionResult AnalizarFeedback(int id, [FromBody] AnalisisFeedbackModel model)
        {
            var response = Helper.GetStructResponse();
            try
            {
                _feedbackService.AnalizarFeedback(id, model.AnalisisIA);
                response.StatusCode = (int)HttpStatusCode.OK;
                response.success = true;
                response.message = "Feedback analizado correctamente";
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
