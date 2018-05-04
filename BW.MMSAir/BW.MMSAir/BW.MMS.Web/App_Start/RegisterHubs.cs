using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BW.MMS.Web.RegisterHubs), "Start")]
namespace BW.MMS.Web
{
    public class RegisterHubs
    {
        public static void Start()
        {
            // Register the default hubs route: ~/signalr/hubs
            RouteTable.Routes.MapHubs();
        }
    }

}