using System;
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
            return new Message {Token = "API-v1", Description = "This is version1."};
        }
    }

    public class Message
    {
        public string Token { get; set; }
        public String Description { get; set; }
    }
}