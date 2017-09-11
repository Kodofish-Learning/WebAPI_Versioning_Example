using System.Web.Http;

namespace Exercise.Controllers.Version1
{
    public class HelloController : ApiController
    {
        /// <summary>
        /// Gets this instance. Version 1
        /// </summary>
        /// <returns></returns>
        public Message Get()
        {
            return new Message {Token = "Joey-v1", Signature = "91"};
        }
    }

    public class Message
    {
        public string Signature { get; set; }
        public string Token { get; set; }
    }
}