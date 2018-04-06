using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApi.Model;

namespace MyWebApi
{
    public class SendMesageByMail : ISendMessage
    {
        private IMailListRepository _repository;
        public SendMesageByMail(IMailListRepository repository)
        {
            this._repository = repository;
        }

        public void SendOneMessage()
        {
            var msg = _repository.GetMailLists(MailListStatus.Default).FirstOrDefault();
            if(msg == null) return;
            msg.SendStatus = (int) MailListStatus.Sent;
            msg.UpdateTime = DateTime.Now;
            _repository.UpdateMailLists(new []{msg});
        }

        public void SendBatchMessage(int messageCount)
        {
            var list = _repository.GetMailListsTop(MailListStatus.Default, messageCount).ToList();
            foreach (var ml in list)
            {
                ml.SendStatus = (int) MailListStatus.Sent;
                ml.UpdateTime = DateTime.Now;
            }
            _repository.UpdateMailLists(list.ToArray());
        }

        public void SendOneMessage(string mailTo)
        {
            var msg = _repository.GetMailListsTop(mailTo, MailListStatus.Default);
            if (msg == null) return;
            msg.SendStatus = (int)MailListStatus.Sent;
            msg.UpdateTime = DateTime.Now;
            _repository.UpdateMailLists(new[] { msg });
        }

        public void QueueMessage(string mailTo, string content)
        {
            var mail = new MailList()
            {
                MailTo = mailTo,
                MailContent = content,
                SendStatus = (int)MailListStatus.Default,
                MailListId = new Guid()
            };
            _repository.InsertMailList(new MailList[] { mail });
        }
    }
}
