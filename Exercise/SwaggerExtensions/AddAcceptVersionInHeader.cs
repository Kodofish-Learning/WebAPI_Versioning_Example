using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace Exercise.SwaggerExtensions
{
    /// <summary>
    ///     實作 依 <see cref="ApiDescription" /> 所屬的 版本號碼, 在 Swagger 的 Response Content Type 上加上版本號碼
    /// </summary>
    /// <seealso cref="Swashbuckle.Swagger.IOperationFilter" />
    public class AddAcceptVersionInHeader : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null) operation.parameters = new List<Parameter>();

            var fullName = apiDescription.ActionDescriptor.ControllerDescriptor.ControllerType.FullName;
            if (fullName == null) return;

            //取得 Api Version Number
            var reg = new Regex(@"Version\d?\.?\d");
            var versionNumber = reg.Match(fullName).Value.Replace("Version", string.Empty);

            //加上 X-Api-Version Header
            operation.parameters.Add(new Parameter
            {
                name = "X-Api-Version",
                @default = versionNumber,
                @in = "header",
                required = false,
                type = "string",
                description = "決定使用那一個API版本, 未帶參數則使用最新版"
            });
        }
    }
}