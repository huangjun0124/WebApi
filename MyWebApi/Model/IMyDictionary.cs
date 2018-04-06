using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    public interface IMyDictionary
    {
        bool HasKey(string key);

        bool AddIfKeyNotExist(string key, string value);

        string GetValueByKey(string key);

        bool Remove(string key);

        bool Update(string key, string value);
    }
}
