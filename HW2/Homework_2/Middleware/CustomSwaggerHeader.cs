using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Homework_2.Middleware
{
    public class CustomSwaggerHeader : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var parameters = operation.Parameters ?? new List<OpenApiParameter>();
            parameters.Add(
                new OpenApiParameter()
                {
                    Name = "version",
                    In = ParameterLocation.Header,
                    Required = true,
                    Schema = new OpenApiSchema
                    {
                        Type = "String"
                    }
                });
        }
    }
}
