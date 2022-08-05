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
    ///  CarModelPartWizard wizard settings controller
    /// </summary>
    [AllowAnonymous]
	public sealed class CarModelPartWizardWizardSettingsController : GuiSettingsBaseApiController<DomainPermissions>
    {
	    /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="securityService"></param>
        public CarModelPartWizardWizardSettingsController(IRequestStorageInitializer requestInitializer, ISecurityService securityService)
            : base(requestInitializer, securityService)
        {
        }

        /// <summary>
        /// Get settings for 'CarModelPartWizard' wizard
        /// </summary>
        /// <returns></returns>
		public IHttpActionResult Get()
        {
            if(!Security.AuthorizeAny(DomainPermissions.CarModelPart_Read, DomainPermissions.CarModelPart_Create, DomainPermissions.CarModelPart_Update)){ return GetInternalForbiddenResult(@"Car model part.Read(CarModelPart_Read), Car model part.Create(CarModelPart_Create), Car model part.Update(CarModelPart_Update)"); }
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

            #region CarModelPartPage
            {
		        var item = new WizardPage 
                {
				    Name = "carModelPartPage",
					Title = WizardResources.CarModelPartWizard_CarModelPartPage,
                    BannerTitle = WizardResources.CarModelPartWizard_CarModelPartPage_BannerTitle,
					BannerDescription = WizardResources.CarModelPartWizard_CarModelPartPage_BannerDescription,
				    Editors = GetCarModelPartPageEditors(context),
                };
				           
			    if (item.Editors != null)
				{
				    items.Add(item);
				}
            }
			#endregion
	    
            return items.Count == 0 ? null : items.ToArray();
        }
        
		private WizardPageEditor[] GetCarModelPartPageEditors(WizardSettingsContext context)
        {
		    var items = new List<WizardPageEditor>(2);

            // carModelPartPage_Name
            items.Add(new TextWizardPageEditor 
            {
			    Name = "carModelPartPage_Name",
			    Title = WizardResources.CarModelPartWizard_CarModelPartPage_Name_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "Name", Key = DomainObjectPropertyKeys.CarModelPart.Name, DataType = FieldDataType.String},
                MaxLength = null,
                Validators = new [] 
				{
                    new Validator {Handler = "Name_Required",Type = ValidatorType.Required, Message = ValidationResources.CarModelPart_Name_RequiredMsg},
				}
            });
			
            // carModelPartPage_Price
            items.Add(new NumericWizardPageEditor 
            {
			    Name = "carModelPartPage_Price",
			    Title = WizardResources.CarModelPartWizard_CarModelPartPage_Price_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "Price", Key = DomainObjectPropertyKeys.CarModelPart.Price, DataType = FieldDataType.Decimal},
                Step = 1,
            });
			
	    
            return items.Count == 0 ? null : items.ToArray();
        }

    }
}
