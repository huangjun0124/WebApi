using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyWebApi
{
    public class CustomAuthorizeFilter : IDashboardAuthorizationFilter
    {

        public bool Authorize(DashboardContext context)
        {
            return true;
        }
    }
}
