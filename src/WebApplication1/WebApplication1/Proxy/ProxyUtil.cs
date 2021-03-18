using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.ServiceReference;

namespace WebApplication1.Proxy
{
    public static class ProxyUtil
    {
        public static Service1Client GetProxy()
        {
            return new Service1Client();
        }
    }
}