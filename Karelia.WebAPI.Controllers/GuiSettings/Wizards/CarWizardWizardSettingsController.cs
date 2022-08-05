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
    ///  CarWizard wizard settings controller
    /// </summary>
    [AllowAnonymous]
	public sealed class CarWizardWizardSettingsController : GuiSettingsBaseApiController<DomainPermissions>
    {
	    /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="securityService"></param>
        public CarWizardWizardSettingsController(IRequestStorageInitializer requestInitializer, ISecurityService securityService)
            : base(requestInitializer, securityService)
        {
        }

        /// <summary>
        /// Get settings for 'CarWizard' wizard
        /// </summary>
        /// <returns></returns>
		public IHttpActionResult Get()
        {
            if(!Security.AuthorizeAny(DomainPermissions.Car_Read, DomainPermissions.Car_Create, DomainPermissions.Car_Update)){ return GetInternalForbiddenResult(@"Car.Read(Car_Read), Car.Create(Car_Create), Car.Update(Car_Update)"); }
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

            #region CarPage
            {
		        var item = new WizardPage 
                {
				    Name = "carPage",
					Title = WizardResources.CarWizard_CarPage,
                    BannerTitle = WizardResources.CarWizard_CarPage_BannerTitle,
					BannerDescription = WizardResources.CarWizard_CarPage_BannerDescription,
				    Editors = GetCarPageEditors(context),
                };
				           
			    if (item.Editors != null)
				{
				    items.Add(item);
				}
            }
			#endregion
	    
            return items.Count == 0 ? null : items.ToArray();
        }
        
		private WizardPageEditor[] GetCarPageEditors(WizardSettingsContext context)
        {
		    var items = new List<WizardPageEditor>(3);

            // carPage_Number
            items.Add(new TextWizardPageEditor 
            {
			    Name = "carPage_Number",
			    Title = WizardResources.CarWizard_CarPage_Number_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "Number", Key = DomainObjectPropertyKeys.Car.Number, DataType = FieldDataType.String},
                MaxLength = null,
                Validators = new [] 
				{
                    new Validator {Handler = "Number_Required",Type = ValidatorType.Required, Message = ValidationResources.Car_Number_RequiredMsg},
				}
            });
			
            // carPage_Description
            items.Add(new TextWizardPageEditor 
            {
			    Name = "carPage_Description",
			    Title = WizardResources.CarWizard_CarPage_Description_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "Description", Key = DomainObjectPropertyKeys.Car.Description, DataType = FieldDataType.String},
                MaxLength = null,
            });
			
            // carPage_CarModelId
            items.Add(new ComboBoxWizardPageEditor 
            {
			    Name = "carPage_CarModelId",
			    Title = WizardResources.CarWizard_CarPage_CarModelId_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "CarModelId", Key = DomainObjectPropertyKeys.Car.CarModelId, DataType = FieldDataType.Integer},
                ValueField = @"Id",
                DisplayField = @"Name",
                Validators = new [] 
				{
                    new Validator {Handler = "CarModelId_Required",Type = ValidatorType.Required, Message = ValidationResources.Car_CarModelId_RequiredMsg},
				}
            });
			
	    
            return items.Count == 0 ? null : items.ToArray();
        }

    }
}
