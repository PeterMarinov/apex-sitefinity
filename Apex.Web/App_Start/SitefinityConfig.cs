using ApexWeb.Sitefinity.Custom;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Mvc;

namespace ApexWeb.App_Start
{
    public static class SitefinityConfig
    {
        public static void RegisterDevModeActionInvoker(IUnityContainer container)
        {
            container.RegisterType<IControllerActionInvoker, DevModeActionInvoker>();
        }
    }
}