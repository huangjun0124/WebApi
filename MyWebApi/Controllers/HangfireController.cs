using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Model;

namespace MyWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Hangfire")]
    public class HangfireController : Controller
    {
        private IBackgroundJobClient m_BackgroundJobClient;
        private IMyDictionary _dictionary;

        public HangfireController(IBackgroundJobClient backgroundJobClient, IMyDictionary dictionary)
        {
            m_BackgroundJobClient = backgroundJobClient;
            _dictionary = dictionary;
        }

        [HttpPost("EnqueueSchedule--Calling methods with delay")]
        public bool EnqueueSchedule(string msgToSend, int seconds)
        {
            m_BackgroundJobClient.Schedule(() => Debug.WriteLine(msgToSend), TimeSpan.FromSeconds(seconds));
            return true;
        }

        [HttpPost("EnqueSendMail--Add mail to maillist")]
        public void EnqueSendMail(string mailTo, string content)
        {
            m_BackgroundJobClient.Enqueue<ISendMessage>(x => x.QueueMessage(mailTo, content));
        }

        [HttpPost("RecuringToSend")]
        public string RecuringToSend(string mailTo)
        {
            if (_dictionary.HasKey(mailTo))
            {
                _dictionary.Update(mailTo, DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
                return "this person is already scheduled";
            }
            _dictionary.AddIfKeyNotExist(mailTo, DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
            // run every 5 minutes
            RecurringJob.AddOrUpdate<ISendMessage>(mailTo, x=>x.SendOneMessage(mailTo), "*/5 * * * *");
            return "success";
        }
    }
}