using System;
using System.IO;
using System.Web;

namespace WebApplication1
{
    public class IISHandler1 : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.Write("The page request is " + context.Request.RawUrl.ToString());
            //StreamWriter sw = new StreamWriter(@"K:\requestLog.txt", true);
            //sw.WriteLine("HttpHandler: Page requested at " + DateTime.Now.ToString() + context.Request.RawUrl); sw.Close();

            context.Response.Redirect("info.html");

            //write your handler implementation here.
        }

        #endregion
    }
}
