using System.Web.Http;
using WebActivatorEx;
using Exercise;
using Swashbuckle.Application;
using System.Linq;
using System;
using System.Web.Http.Description;
using Exercise.SwaggerExtensions;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Exercise
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        // If your API has multiple versions, use "MultipleApiVersions" instead of "SingleApiVersion".
                        // In this case, you must provide a lambda that tells Swashbuckle which actions should be
                        // included in the docs for a given API version. Like "SingleApiVersion", each call to "Version"
                        // returns an "Info" builder so you can provide additional metadata per API version.
                        //
                        c.MultipleApiVersions(
                            (apiDesc, targetApiVersion) => ResolveVersionSupportByRouteConstraint(apiDesc, targetApiVersion),
                            (vc) =>
                            {
                                vc.Version("Version2", "Swashbuckle Dummy API V2");
                                vc.Version("Version1_1", "Swashbuckle Dummy API V1.1");
                                vc.Version("Version1", "Swashbuckle Dummy API V1");
                            });
                        
                        c.OperationFilter<AddAcceptVersionInHeader>();
                        
                    })
                .EnableSwaggerUi(c =>
                    {
                        // Use the CustomAsset option to provide your own version of assets used in the swagger-ui.
                        // It's typically used to instruct Swashbuckle to return your version instead of the default
                        // when a request is made for "index.html". As with all custom content, the file must be included
                        // in your project as an "Embedded Resource", and then the resource's "Logical Name" is passed to
                        // the method as shown below.
                        //
                        var exercise = thisAssembly;
                        c.CustomAsset("index2", exercise, "Exercise.SwaggerExtensions.index.html");

                        // If your API has multiple versions and you've applied the MultipleApiVersions setting
                        // as described above, you can also enable a select box in the swagger-ui, that displays
                        // a discovery URL for each version. This provides a convenient way for users to browse documentation
                        // for different API versions.
                        //
                        c.EnableDiscoveryUrlSelector();
                    });
        }

        /// <summary>
        /// Resolves the version support by route constraint.
        /// </summary>
        /// <param name="apiDesc">The API desc.</param>
        /// <param name="targetApiVersion">The target API version.</param>
        /// <returns></returns>
        private static bool ResolveVersionSupportByRouteConstraint(ApiDescription apiDesc, string targetApiVersion)
        {
            return apiDesc.ActionDescriptor.ControllerDescriptor.ControllerType.FullName.Contains(targetApiVersion);
        }
    }
}
