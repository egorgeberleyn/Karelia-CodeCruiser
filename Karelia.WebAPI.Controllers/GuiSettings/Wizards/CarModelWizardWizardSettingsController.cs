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
    ///  CarModelWizard wizard settings controller
    /// </summary>
    [AllowAnonymous]
	public sealed class CarModelWizardWizardSettingsController : GuiSettingsBaseApiController<DomainPermissions>
    {
	    /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="securityService"></param>
        public CarModelWizardWizardSettingsController(IRequestStorageInitializer requestInitializer, ISecurityService securityService)
            : base(requestInitializer, securityService)
        {
        }

        /// <summary>
        /// Get settings for 'CarModelWizard' wizard
        /// </summary>
        /// <returns></returns>
		public IHttpActionResult Get()
        {
            if(!Security.AuthorizeAny(DomainPermissions.CarModel_Read, DomainPermissions.CarModel_Create, DomainPermissions.CarModel_Update)){ return GetInternalForbiddenResult(@"Car model.Read(CarModel_Read), Car model.Create(CarModel_Create), Car model.Update(CarModel_Update)"); }
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

            #region CarModelPage
            {
		        var item = new WizardPage 
                {
				    Name = "carModelPage",
					Title = WizardResources.CarModelWizard_CarModelPage,
                    BannerTitle = WizardResources.CarModelWizard_CarModelPage_BannerTitle,
					BannerDescription = WizardResources.CarModelWizard_CarModelPage_BannerDescription,
				    Editors = GetCarModelPageEditors(context),
                };
				           
			    if (item.Editors != null)
				{
				    items.Add(item);
				}
            }
			#endregion
	    
            return items.Count == 0 ? null : items.ToArray();
        }
        
		private WizardPageEditor[] GetCarModelPageEditors(WizardSettingsContext context)
        {
		    var items = new List<WizardPageEditor>(2);

            // carModelPage_Name
            items.Add(new TextWizardPageEditor 
            {
			    Name = "carModelPage_Name",
			    Title = WizardResources.CarModelWizard_CarModelPage_Name_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "Name", Key = DomainObjectPropertyKeys.CarModel.Name, DataType = FieldDataType.String},
                MaxLength = null,
                Validators = new [] 
				{
                    new Validator {Handler = "Name_Required",Type = ValidatorType.Required, Message = ValidationResources.CarModel_Name_RequiredMsg},
				}
            });
			
            // carModelPage_FuelConsumption
            items.Add(new NumericWizardPageEditor 
            {
			    Name = "carModelPage_FuelConsumption",
			    Title = WizardResources.CarModelWizard_CarModelPage_FuelConsumption_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "FuelConsumption", Key = DomainObjectPropertyKeys.CarModel.FuelConsumption, DataType = FieldDataType.Float},
                Step = 1,
            });
			
	    
            return items.Count == 0 ? null : items.ToArray();
        }

    }
}
