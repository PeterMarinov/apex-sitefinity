using System;
using ApexWeb.App_Start;
using Telerik.Sitefinity.Abstractions;

namespace ApexWeb
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Bootstrapper.Bootstrapped -= OnBootstrapped;
            Bootstrapper.Bootstrapped += OnBootstrapped;
        }

        private void OnBootstrapped(object sender, EventArgs e)
        {
            SitefinityConfig.RegisterDevModeActionInvoker(ObjectFactory.Container);
        }
    }
}