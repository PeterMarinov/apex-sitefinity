using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ApexWeb.Mvc.Models;
using Progress.Sitefinity.Renderer.Designers.Attributes;
using Progress.Sitefinity.Renderer.Models;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Renderer;
using Telerik.Sitefinity.Web.Services.Contracts.Operations.Pages.PropertyEditor.AttributeConfigurator.Attributes;

namespace ApexWeb.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "SocialLinks", Title = "Social Links", SectionName = "Apex Widgets")]
    public class SocialLinksController : Controller
    {
        #region Widget Properties

        [Required]
        [DisplayName("Twitter Url")]
        [Description("Select the destination Url for Twitter company account")]
        public LinkModel TwitterUrl { get; set; }

        [Required]
        [DisplayName("Facebook Url")]
        [Description("Select the destination Url for Facebook company page")]
        public LinkModel FacebookUrl { get; set; }

        [Required]
        [DisplayName("LinkedIn Url")]
        [Description("Select the destination Url for the LinkedIn company page")]
        public LinkModel LinkedInUrl { get; set; }

        [DisplayName("YouTube Url")]
        [Description("Select the destination Url for the main YouTube company channel")]
        [ConditionalVisibility("{\"conditions\":[{\"fieldName\":\"ViewName\",\"operator\":\"Equals\",\"value\":\"Footer\"}]}")]
        public LinkModel YouTubeUrl { get; set; }

        [DisplayName("Instagram Url")]
        [Description("Select the destination Url for the main Instagram company page")]
        [ConditionalVisibility("{\"conditions\":[{\"fieldName\":\"ViewName\",\"operator\":\"Equals\",\"value\":\"Header\"}]}")]
        public LinkModel InstagramUrl { get; set; }

        [ViewSelector(ComponentName = "SocialLinks")]
        public string ViewName { get; set; } = "Footer";

        #endregion

        public ActionResult Index()
        {
            var model = this.GetModel();
            return View(this.ViewName, model);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, nameof(this.Index));
        }

        private SocialLinksModel GetModel()
        {
            return new SocialLinksModel()
            {
                FacebookUrl = this.FacebookUrl?.ResolveLink(true) ?? string.Empty,
                TwitterUrl = this.TwitterUrl?.ResolveLink(true) ?? string.Empty,
                LinkedInUrl = this.LinkedInUrl?.ResolveLink(true) ?? string.Empty,
                YouTubeUrl = this.YouTubeUrl?.ResolveLink(true) ?? string.Empty,
                InstagramUrl = this.InstagramUrl?.ResolveLink(true) ?? string.Empty
            };
        }
    }
}