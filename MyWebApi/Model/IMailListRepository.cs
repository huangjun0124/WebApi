using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    public interface IMailListRepository
    {
        List<MailList> GetMailLists(MailListStatus status);

        List<MailList> GetMailListsTop(MailListStatus status, int top);

        MailList GetMailListsTop(string mailTo, MailListStatus status);

        void InsertMailList(MailList[] list);

        void UpdateMailLists(MailList[] list);

        void DeleteMailLists(MailList[] list);
    }
}
