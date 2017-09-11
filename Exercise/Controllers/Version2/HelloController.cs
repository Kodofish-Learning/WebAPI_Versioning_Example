using System.Web.Http;

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
            return new AnotherMessage {NewToken = "Joey-v2", NewSignature = "91"};
        }
    }

    public class AnotherMessage
    {
        public string NewToken { get; set; }

        public string NewSignature { get; set; }
    }
}