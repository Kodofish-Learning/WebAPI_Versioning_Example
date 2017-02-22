using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Exercise.Controllers.Version1
{
    public class HelloController : ApiController
    {
        public Message Get()
        {
            return new Message { Token = "Joey-v1", Signature = "91" };
        }
    }

    public class Message
    {
        public string Signature { get; set; }
        public string Token { get; set; }
    }
}