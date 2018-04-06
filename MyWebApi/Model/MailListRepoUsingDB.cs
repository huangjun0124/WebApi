using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    public class MailListRepoUsingDB : IMailListRepository
    {
        private MyWebApiDbContext _dbContext;

        public MailListRepoUsingDB(MyWebApiDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<MailList> GetMailLists(MailListStatus status)
        {
            return _dbContext.MailLists.Where(l => l.SendStatus == (int) status).ToList();
        }

        public List<MailList> GetMailListsTop(MailListStatus status, int top)
        {
            return _dbContext.MailLists.Where(l => l.SendStatus == (int) status).Take(top).ToList();
        }

        public MailList GetMailListsTop(string mailTo, MailListStatus status)
        {
            return _dbContext.MailLists.FirstOrDefault(m => m.SendStatus == (int) status && m.MailTo == mailTo);
        }

        public void InsertMailList(MailList[] list)
        {
            _dbContext.MailLists.AddRange(list);
            _dbContext.SaveChanges();
        }

        public void UpdateMailLists(MailList[] list)
        {
            _dbContext.MailLists.UpdateRange(list);
            _dbContext.SaveChanges();
        }

        public void DeleteMailLists(MailList[] list)
        {
            _dbContext.RemoveRange(list);
            _dbContext.SaveChanges();
        }
    }
}
