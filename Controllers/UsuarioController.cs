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
using EQUIPO_LINCES_BACKEND.Models;
using EQUIPO_LINCES_BACKEND.Utilities;


namespace EQUIPO_LINCES_BACKEND.Controllers
{
    [Route("api")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        Encrypt enc = new Encrypt();

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;

        }

        [HttpPost("InsertUsuario")]
        public IActionResult InsertUsuario([FromBody] InsertUsuarioModel req)
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                objectResponse.message = "Usuario creado con exito";
                string cryptedPass = enc.GetSHA256(req.ContrasenaHash);
                req.ContrasenaHash = cryptedPass;
                _usuarioService.InsertUsuario(req);
            
            }
            catch(Exception ex)
        
            {
                objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("GetUsuarios")]
        public IActionResult GetUsuarios()
        {
            var objectResponse = Helper.GetStructResponse();
            try{
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Usuarios cargados correctamente";
                objectResponse.response = _usuarioService.GetUsuarios();
            
            }
            catch(Exception ex)
        
            {
                objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        //  [HttpGet("GetUsuariosById")]
        // public IActionResult GetUsuariosById([FromQuery] int Id)
        // {
        //     var objectResponse = Helper.GetStructResponse();

        //     try
        //     {
        //         objectResponse.StatusCode = (int)HttpStatusCode.OK;
        //         objectResponse.success = true;
        //         objectResponse.message = "Usuario cargado con exito";
        //         var resultado = _usuarioService.GetUsuariosById(Id);
                
                

        //         // Llamando a la función y recibiendo los dos valores.
                
        //          objectResponse.response = resultado;
        //     }

        //     catch (System.Exception ex)
        //     {
        //         objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
        //         objectResponse.success = false;
        //         objectResponse.message = ex.Message;
        //     }

        //     return new JsonResult(objectResponse);
        // }

        
        // [HttpPut("UpdateUsuario")]
        // public IActionResult UpdateUsuario([FromBody] UpdateUsuarioModel req)
        // {
        //     var objectResponse = Helper.GetStructResponse();
        //     try{
        //         objectResponse.StatusCode = (int)HttpStatusCode.Created;
        //         objectResponse.success = true;
        //         string cryptedPass = enc.GetSHA256(req.Password);
        //         req.Password = cryptedPass;
        //         objectResponse.message = "Usuario actualizado con exito";
        //         _usuarioService.UpdateUsuario(req);
            
        //     }
        //     catch(Exception ex)
        
        //     {
        //         objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
        //         objectResponse.success = false;
        //         objectResponse.message = ex.Message;
        //     }

        //     return new JsonResult(objectResponse);
        // }


        // [HttpDelete("DeleteUsuario")]
        // public IActionResult DeleteUsuario([FromQuery] int Id)
        // {
        //     var objectResponse = Helper.GetStructResponse();
        //     try{
        //         objectResponse.StatusCode = (int)HttpStatusCode.Created;
        //         objectResponse.success = true;
        //         objectResponse.message = "Usuario eliminado con exito";
        //         _usuarioService.DeleteUsuario(Id);
            
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

