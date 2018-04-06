using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    public class MyDictionaryRepository : IMyDictionary
    {
        private MyWebApiDbContext _dbContext;

        public MyDictionaryRepository(MyWebApiDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public bool HasKey(string key)
        {
            return _dbContext.Dictionary.Select(d => d.Key.Equals(key)).FirstOrDefault();
        }

        public bool AddIfKeyNotExist(string key, string value)
        {
            if (!HasKey(key))
            {
                var dicItem = new MyDictionary()
                {
                    Key = key,
                    Value = value
                };
                _dbContext.Dictionary.Add(dicItem);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public string GetValueByKey(string key)
        {
            var d =_dbContext.Dictionary.FirstOrDefault(dc => dc.Key == key);
            return d?.Value;
        }

        public bool Remove(string key)
        {
            var d = _dbContext.Dictionary.FirstOrDefault(dc => dc.Key == key);
            if (d == null)
                return false;
            _dbContext.Dictionary.Remove(d);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Update(string key, string value)
        {
            var d = _dbContext.Dictionary.FirstOrDefault(dc => dc.Key == key);
            d.Value = value;
            _dbContext.SaveChanges();
            return true;
        }
    }
}
