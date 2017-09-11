using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace Exercise.SwaggerExtensions
{
    /// <summary>
    /// 實作 依 <see cref="ApiDescription"/> 所屬的 版本號碼, 在 Swagger 的 Response Content Type 上加上版本號碼
    /// </summary>
    /// <seealso cref="Swashbuckle.Swagger.IOperationFilter" />
    public class AddAcceptVersionInHeader : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null) operation.parameters = new List<Parameter>();

            var fullName = apiDescription.ActionDescriptor.ControllerDescriptor.ControllerType.FullName;
            var reg = new Regex(@"Version\d?\.?\d");
            var result = reg.Match(fullName);

            var p = $"application/json;v={result.Value.Replace("Version", string.Empty)}";

            operation.produces.Insert(0,p);
        }
    }
}