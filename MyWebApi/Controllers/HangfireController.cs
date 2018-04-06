using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Hangfire")]
    public class HangfireController : Controller
    {

    }
}