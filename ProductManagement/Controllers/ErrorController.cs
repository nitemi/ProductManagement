﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProductManagement.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;
        public ErrorController(ILogger<ErrorController> logger)
        {

        }
        [Route("Error/statusCode")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch(statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found";

                    logger.LogWarning($"404 Error Occured. Path = {statusCodeResult.OriginalPath} " +
                        $" and QueryString = {statusCodeResult.OriginalQueryString}");
                        break;
            }
            return View("Not Found");
        }

        [Route("Error")]
        [AllowAnonymous] 
        public IActionResult Error() 
        { 
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerFeature>();

            logger.LogError($"The path {exceptionDetails} threw an exception " +
                $"{exceptionDetails.Error}");
            return View("Error");
        }
    }
}
