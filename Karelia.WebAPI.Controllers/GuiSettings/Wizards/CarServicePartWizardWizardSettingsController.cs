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
    ///  CarServicePartWizard wizard settings controller
    /// </summary>
    [AllowAnonymous]
	public sealed class CarServicePartWizardWizardSettingsController : GuiSettingsBaseApiController<DomainPermissions>
    {
	    /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="securityService"></param>
        public CarServicePartWizardWizardSettingsController(IRequestStorageInitializer requestInitializer, ISecurityService securityService)
            : base(requestInitializer, securityService)
        {
        }

        /// <summary>
        /// Get settings for 'CarServicePartWizard' wizard
        /// </summary>
        /// <returns></returns>
		public IHttpActionResult Get()
        {
            if(!Security.AuthorizeAny(DomainPermissions.CarServicePart_Read, DomainPermissions.CarServicePart_Create, DomainPermissions.CarServicePart_Update)){ return GetInternalForbiddenResult(@"Car service part.Read(CarServicePart_Read), Car service part.Create(CarServicePart_Create), Car service part.Update(CarServicePart_Update)"); }
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

            #region CarServicePartPage
            {
		        var item = new WizardPage 
                {
				    Name = "carServicePartPage",
					Title = WizardResources.CarServicePartWizard_CarServicePartPage,
                    BannerTitle = WizardResources.CarServicePartWizard_CarServicePartPage_BannerTitle,
					BannerDescription = WizardResources.CarServicePartWizard_CarServicePartPage_BannerDescription,
				    Editors = GetCarServicePartPageEditors(context),
                };
				           
			    if (item.Editors != null)
				{
				    items.Add(item);
				}
            }
			#endregion
	    
            return items.Count == 0 ? null : items.ToArray();
        }
        
		private WizardPageEditor[] GetCarServicePartPageEditors(WizardSettingsContext context)
        {
		    var items = new List<WizardPageEditor>(2);

            // carServicePartPage_Quantity
            items.Add(new NumericWizardPageEditor 
            {
			    Name = "carServicePartPage_Quantity",
			    Title = WizardResources.CarServicePartWizard_CarServicePartPage_Quantity_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "Quantity", Key = DomainObjectPropertyKeys.CarServicePart.Quantity, DataType = FieldDataType.Integer},
                Step = 1,
                Validators = new [] 
				{
                    new Validator {Handler = "Quantity_Required",Type = ValidatorType.Required, Message = ValidationResources.CarServicePart_Quantity_RequiredMsg},
				}
            });
			
            // carServicePartPage_CarModelPartId
            items.Add(new ComboBoxWizardPageEditor 
            {
			    Name = "carServicePartPage_CarModelPartId",
			    Title = WizardResources.CarServicePartWizard_CarServicePartPage_CarModelPartId_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "CarModelPartId", Key = DomainObjectPropertyKeys.CarServicePart.CarModelPartId, DataType = FieldDataType.Integer},
                ValueField = @"Id",
                DisplayField = @"Name",
                Validators = new [] 
				{
                    new Validator {Handler = "CarModelPartId_Required",Type = ValidatorType.Required, Message = ValidationResources.CarServicePart_CarModelPartId_RequiredMsg},
				}
            });
			
	    
            return items.Count == 0 ? null : items.ToArray();
        }

    }
}
