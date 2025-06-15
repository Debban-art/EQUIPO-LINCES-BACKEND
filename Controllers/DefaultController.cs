// using System;
// using System.Net.Http;
// using EQUIPO_LINCES_BACKEND.Models;
// using EQUIPO_LINCES_BACKEND.Services;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Components;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

// namespace EQUIPO_LINCES_BACKEND.Controllers
// {
//     [Route("api")]
//     public class DefaultController : ControllerBase
//     {
//         private readonly ILogger<DefaultController> _logger;
//         private readonly IJWAuthenticationService _authService;
//         private readonly IHttpClientFactory _clientFactory;

//         public DefaultController(ILogger<DefaultController> logger, IJWAuthenticationService authService, IHttpClientFactory clientFactory)
//         {
//             _logger = logger ?? throw new ArgumentNullException(nameof(logger));
//             _authService = authService;
//             _clientFactory = clientFactory;
//         }

//         [AllowAnonymous]
//         [HttpPost("authenticate")]

//         // public JsonResult Authenticate([FromBody] AuthInfo user)
//         // {
//         //     var token = _authService.Authenticate(user.Username, user.IdUsername);

//         //     if (token == null)
//         //     {
//         //         return new JsonResult(new { data = (string)null });
//         //     }

//         //     return new JsonResult(new { data = token });
//         // }
//     }
// }