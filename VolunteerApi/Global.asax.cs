using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebApplication4
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)

        {


            if (Context.Request.Path.Contains("api/") && Context.Request.HttpMethod == "OPTIONS")

            {

                Context.Response.AddHeader("Access-Control-Allow-Origin", "*");

                Context.Response.AddHeader("Access-Control-Allow-Headers", "*");

                Context.Response.AddHeader("Access-Control-Allow-Methods", "*");

                Context.Response.AddHeader("Access-Control-Allow-Credentials", "true");

                Context.Response.End();

            }
            if (Context.Request.Path.Contains("api/") && Context.Request.HttpMethod == "POST")
            {
                Context.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:4200");
            }
            if (Context.Request.Path.Contains("api/") && Context.Request.HttpMethod == "GET")
            {
                Context.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:4200");
            }
            if (Context.Request.Path.Contains("api/") && Context.Request.HttpMethod == "DELETE")
            {
                Context.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:4200");
            }
            if (Context.Request.Path.Contains("api/") && Context.Request.HttpMethod == "PUT")
            {
                Context.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:4200");
            }

        }




    }
}
