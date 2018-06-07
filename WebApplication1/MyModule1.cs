using System;
using System.IO;
using System.Web;

namespace WebApplication1
{
    public class MyModule1 : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication objApplication)
        {
            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
            //context.LogRequest += new EventHandler(OnLogRequest);

            // Register event handler of the pipe line
           
            objApplication.BeginRequest += new EventHandler(this.context_BeginRequest);
            objApplication.EndRequest += new EventHandler(this.context_EndRequest);
        }

        public void context_EndRequest(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"K:\requestLog.txt", true);
            sw.WriteLine("HttpModule: End Request called at " + DateTime.Now.ToString()); sw.Close();
        }
        public void context_BeginRequest(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"K:\requestLog.txt", true);
            sw.WriteLine("HttpModule: Begin request called at " + DateTime.Now.ToString()); sw.Close();
        }
        #endregion

        public void OnLogRequest(Object source, EventArgs e)
        {
            //custom logging logic can go here
        }
    }
}
