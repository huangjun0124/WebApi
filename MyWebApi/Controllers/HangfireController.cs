using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Hangfire")]
    public class HangfireController : Controller
    {
        private IBackgroundJobClient m_BackgroundJobClient;

        public HangfireController(IBackgroundJobClient backgroundJobClient)
        {
            m_BackgroundJobClient = backgroundJobClient;
        }

        [HttpPost("EnqueueOneTime")]
        public bool EnqueueOneTime(string msgToSend)
        {
            m_BackgroundJobClient.Enqueue(() => Debug.WriteLine(msgToSend));
            return true;
        }

        [HttpPost("EnqueueSchedule")]
        public bool EnqueueSchedule(string msgToSend, int seconds)
        {
            m_BackgroundJobClient.Schedule(() => Debug.WriteLine(msgToSend), TimeSpan.FromSeconds(seconds));
            return true;
        }
    }
}