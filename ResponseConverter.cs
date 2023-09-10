using backend_stage_one.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace backend_stage_one
{
    public class ResponseConverter :ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                if (objectResult.Value != null)
                {
                    var propertiesToRemove = new[]
                    {
                        "isCompleted",
                        "isCanceled",
                        "isCompletedSuccessfully",
                        "creationOptions",
                        "asyncState",
                        "isFaulted",
                        "id",
                        "exception",
                        "status"
                    };

                    var valueType = objectResult.Value.GetType();
                    var properties = valueType.GetProperties()
                        .Where(p => !propertiesToRemove.Contains(p.Name))
                        .ToDictionary(p => p.Name, p => p.GetValue(objectResult.Value));
                    var response = new Response();
                    foreach (var property in properties)
                    {
                        var responseProperty = response.GetType().GetProperty(property.Key);
                        responseProperty?.SetValue(response, property.Value);
                    }

                    context.Result = new OkObjectResult(response);
                }
            }
        }
    }
}
