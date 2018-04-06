using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Model;

namespace MyWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/MailList")]
    public class MailListController : Controller
    {
        private IMailListRepository _repository;

        public MailListController(IMailListRepository repository)
        {
            this._repository = repository;
        }

        [HttpPost("AddMail")]
        public bool AddMail(string mailTo, string mailContent)
        {
            var mail = new MailList()
            {
                MailTo = mailTo,
                MailContent = mailContent,
                SendStatus = (int)MailListStatus.Default,
                MailListId = new Guid()
            };
            _repository.InsertMailList(new MailList[]{mail});
            return true;
        }

        [HttpGet("GetMailListByStatus")]
        public IList<MailList> GetMailListByStatus(int status)
        {
            var find = _repository.GetMailLists((MailListStatus) status);
            return find.ToList();
        }
    }
}