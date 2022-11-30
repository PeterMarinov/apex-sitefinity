using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ApexWeb.Mvc.Models;
using Progress.Sitefinity.Renderer.Designers.Attributes;
using Progress.Sitefinity.Renderer.Entities.Content;
using Telerik.Sitefinity.Mvc;

namespace ApexWeb.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "ContactInfo", Title = "Contact Info", SectionName = "Apex Widgets")]
    public class ContactInfoController : Controller
    {
        private string _viewName = "Index";

        #region Widget Properties

        [Required]
        [Description("Add title for the widget")]
        public string Title { get; set; } = "Address";

        [Required]
        [Description("Add address for contact info")]
        public string Address { get; set; } = "123 Street, New York, USA";

        [Required]
        [Description("Add phone number for contact info")]
        public string PhoneNumber { get; set; } = "+012 345 67890";

        [TaxonomyContent(Type = KnownContentTypes.Tags)]
        public MixedContentContext Tags { get; set; }


        [Required]
        [Description("Add email address for contact info")]
        [EmailAddress(ErrorMessage = "Enter valid email.")]
        public string Email { get; set; } = "info@example.com";
        #endregion

        public ActionResult Index()
        {
            var model = this.GetModel();
            return View(this._viewName, model);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, nameof(this.Index));
        }

        private ContactInfoModel GetModel()
        {
            return new ContactInfoModel()
            {
                Title = this.Title,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber,
                Address = this.Address
            };
        }
    }
}