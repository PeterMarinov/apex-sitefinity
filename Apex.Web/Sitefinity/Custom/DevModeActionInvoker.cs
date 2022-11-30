using System;
using System.Web.Configuration;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Routing;

namespace ApexWeb.Sitefinity.Custom
{
    public class DevModeActionInvoker : FeatherActionInvoker
    {
        protected override void HandleControllerException(Exception err)
        {
            if (IsApplicationInDebugMode())
            {
                throw err;
            }

            base.HandleControllerException(err);
        }

        protected bool IsApplicationInDebugMode()
        {
            var result = false;

            var configuration = WebConfigurationManager.OpenWebConfiguration("~/Web.config");
            CompilationSection compilationSection = (CompilationSection)configuration.GetSection("system.web/compilation");

            if (compilationSection?.Debug != null)
                result = compilationSection.Debug;

            return result;
        }
    }
}