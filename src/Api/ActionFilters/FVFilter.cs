using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace Api.ActionFilters
{
    public class FVFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Select(x =>
                    new ResponseError 
                    { 
                        Key = JsonNamingPolicy.CamelCase.ConvertName(x.Key), 
                        Messages = x.Value.Errors.Select(err => err.ErrorMessage) 
                    }
                );

                context.Result = new JsonResult(ApiResponse.Failure(errors, 400))
                {
                    StatusCode = 400
                };
            }
        }
    }
}
