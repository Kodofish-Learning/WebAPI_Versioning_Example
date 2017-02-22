using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Exercise.Controllers.Version2
{
    public class HelloController : ApiController
    {
        public AnotherMessage Get()
        {
            return new AnotherMessage { NewToken = "Joey-v2", NewSignature = "91" };
        }
    }

    public class AnotherMessage
    {
        public string NewToken { get; set; }

        public string NewSignature { get; set; }
    }
}
