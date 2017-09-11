using System.Web.Http;
using Swashbuckle.Swagger;


namespace Exercise.Controllers.Version2
{
    
    public class HelloController : ApiController
    {
        /// <summary>
        /// Gets this instance. Version 2
        /// </summary>
        /// <returns></returns>
        
        [HttpGet]
        public AnotherMessage Get()
        {
            return new AnotherMessage {NewToken = "WebApi-v2", NewDescription = "This is new Description V2"};
        }
    }

    public class AnotherMessage
    {
        public string NewToken { get; set; }

        public string NewDescription { get; set; }
    }
}