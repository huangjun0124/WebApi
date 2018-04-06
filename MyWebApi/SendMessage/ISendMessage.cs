using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi
{
    interface ISendMessage
    {
        void SendOneMessage(string mailTo);

        void QueueMessage(string mailTo, string content);
    }
}
