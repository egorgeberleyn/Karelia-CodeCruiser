using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using BusinessFramework.Contracts.GuiSettings.Fields;
using BusinessFramework.Contracts.GuiSettings.Json;
using BusinessFramework.Contracts.GuiSettings.Wizards;
using BusinessFramework.Contracts.GuiSettings.Wizards.Editors;
using BusinessFramework.WebAPI.Common.GuiSettings;
using BusinessFramework.WebAPI.Common.Request;
using BusinessFramework.WebAPI.Common.Security;
using BusinessFramework.WebAPI.Contracts.Security;
using BusinessFramework.WebAPI.GuiSettingsControllers;
using Karelia.Contracts;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Controllers.Properties;

// ReSharper disable UnusedParameter.Local

namespace Karelia.WebAPI.Controllers.GuiSettings.Wizards
{
    /// <summary>
    ///  CarServiceWorkWizard wizard settings controller
    /// </summary>
    [AllowAnonymous]
	public sealed class CarServiceWorkWizardWizardSettingsController : GuiSettingsBaseApiController<DomainPermissions>
    {
	    /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="securityService"></param>
        public CarServiceWorkWizardWizardSettingsController(IRequestStorageInitializer requestInitializer, ISecurityService securityService)
            : base(requestInitializer, securityService)
        {
        }

        /// <summary>
        /// Get settings for 'CarServiceWorkWizard' wizard
        /// </summary>
        /// <returns></returns>
		public IHttpActionResult Get()
        {
            if(!Security.AuthorizeAny(DomainPermissions.CarServiceWork_Read, DomainPermissions.CarServiceWork_Create, DomainPermissions.CarServiceWork_Update)){ return GetInternalForbiddenResult(@"Car service work.Read(CarServiceWork_Read), Car service work.Create(CarServiceWork_Create), Car service work.Update(CarServiceWork_Update)"); }
		    var context = new WizardSettingsContext();
            var result = new Wizard
            {
			    Items = GetWizardItems(context)
            };

            return Json(result, GuiSettingsJsonSettings.WriteSettings);
        }
        
		private WizardItem[] GetWizardItems(WizardSettingsContext context)
        {
		    var items = new List<WizardItem>(1);

            #region CarServiceWorkPage
            {
		        var item = new WizardPage 
                {
				    Name = "carServiceWorkPage",
					Title = WizardResources.CarServiceWorkWizard_CarServiceWorkPage,
                    BannerTitle = WizardResources.CarServiceWorkWizard_CarServiceWorkPage_BannerTitle,
					BannerDescription = WizardResources.CarServiceWorkWizard_CarServiceWorkPage_BannerDescription,
				    Editors = GetCarServiceWorkPageEditors(context),
                };
				           
			    if (item.Editors != null)
				{
				    items.Add(item);
				}
            }
			#endregion
	    
            return items.Count == 0 ? null : items.ToArray();
        }
        
		private WizardPageEditor[] GetCarServiceWorkPageEditors(WizardSettingsContext context)
        {
		    var items = new List<WizardPageEditor>(2);

            // carServiceWorkPage_Comments
            items.Add(new TextWizardPageEditor 
            {
			    Name = "carServiceWorkPage_Comments",
			    Title = WizardResources.CarServiceWorkWizard_CarServiceWorkPage_Comments_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "Comments", Key = DomainObjectPropertyKeys.CarServiceWork.Comments, DataType = FieldDataType.String},
                MaxLength = null,
            });
			
            // carServiceWorkPage_CarWorkTypeId
            items.Add(new ComboBoxWizardPageEditor 
            {
			    Name = "carServiceWorkPage_CarWorkTypeId",
			    Title = WizardResources.CarServiceWorkWizard_CarServiceWorkPage_CarWorkTypeId_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "CarWorkTypeId", Key = DomainObjectPropertyKeys.CarServiceWork.CarWorkTypeId, DataType = FieldDataType.Integer},
                ValueField = @"Id",
                DisplayField = @"Name",
                Validators = new [] 
				{
                    new Validator {Handler = "CarWorkTypeId_Required",Type = ValidatorType.Required, Message = ValidationResources.CarServiceWork_CarWorkTypeId_RequiredMsg},
				}
            });
			
	    
            return items.Count == 0 ? null : items.ToArray();
        }

    }
}
