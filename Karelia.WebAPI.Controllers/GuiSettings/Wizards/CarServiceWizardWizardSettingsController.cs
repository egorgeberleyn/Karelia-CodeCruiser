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
    ///  CarServiceWizard wizard settings controller
    /// </summary>
    [AllowAnonymous]
	public sealed class CarServiceWizardWizardSettingsController : GuiSettingsBaseApiController<DomainPermissions>
    {
	    /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="securityService"></param>
        public CarServiceWizardWizardSettingsController(IRequestStorageInitializer requestInitializer, ISecurityService securityService)
            : base(requestInitializer, securityService)
        {
        }

        /// <summary>
        /// Get settings for 'CarServiceWizard' wizard
        /// </summary>
        /// <returns></returns>
		public IHttpActionResult Get()
        {
            if(!Security.AuthorizeAny(DomainPermissions.CarService_Read, DomainPermissions.CarService_Create, DomainPermissions.CarService_Update)){ return GetInternalForbiddenResult(@"Car service.Read(CarService_Read), Car service.Create(CarService_Create), Car service.Update(CarService_Update)"); }
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

            #region CarServicePage
            {
		        var item = new WizardPage 
                {
				    Name = "carServicePage",
					Title = WizardResources.CarServiceWizard_CarServicePage,
                    BannerTitle = WizardResources.CarServiceWizard_CarServicePage_BannerTitle,
					BannerDescription = WizardResources.CarServiceWizard_CarServicePage_BannerDescription,
				    Editors = GetCarServicePageEditors(context),
                };
				           
			    if (item.Editors != null)
				{
				    items.Add(item);
				}
            }
			#endregion
	    
            return items.Count == 0 ? null : items.ToArray();
        }
        
		private WizardPageEditor[] GetCarServicePageEditors(WizardSettingsContext context)
        {
		    var items = new List<WizardPageEditor>(6);

            // carServicePage_StartDate
            items.Add(new DateTimeWizardPageEditor 
            {
			    Name = "carServicePage_StartDate",
			    Title = WizardResources.CarServiceWizard_CarServicePage_StartDate_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "StartDate", Key = DomainObjectPropertyKeys.CarService.StartDate, DataType = FieldDataType.DateTime},
                EditType = DateTimeWizardPageEditorType.Date,
            });
			
            // carServicePage_EndDate
            items.Add(new DateTimeWizardPageEditor 
            {
			    Name = "carServicePage_EndDate",
			    Title = WizardResources.CarServiceWizard_CarServicePage_EndDate_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "EndDate", Key = DomainObjectPropertyKeys.CarService.EndDate, DataType = FieldDataType.DateTime},
                EditType = DateTimeWizardPageEditorType.Date,
            });
			
            // carServicePage_Odometer
            items.Add(new NumericWizardPageEditor 
            {
			    Name = "carServicePage_Odometer",
			    Title = WizardResources.CarServiceWizard_CarServicePage_Odometer_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "Odometer", Key = DomainObjectPropertyKeys.CarService.Odometer, DataType = FieldDataType.Integer},
                Step = 1,
            });
			
            // carServicePage_Defect
            items.Add(new TextWizardPageEditor 
            {
			    Name = "carServicePage_Defect",
			    Title = WizardResources.CarServiceWizard_CarServicePage_Defect_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "Defect", Key = DomainObjectPropertyKeys.CarService.Defect, DataType = FieldDataType.String},
                MaxLength = null,
            });
			
            // carServicePage_Conclusion
            items.Add(new TextWizardPageEditor 
            {
			    Name = "carServicePage_Conclusion",
			    Title = WizardResources.CarServiceWizard_CarServicePage_Conclusion_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "Conclusion", Key = DomainObjectPropertyKeys.CarService.Conclusion, DataType = FieldDataType.String},
                MaxLength = null,
            });
			
            // carServicePage_CarArrivalReasonTypeId
            items.Add(new ComboBoxWizardPageEditor 
            {
			    Name = "carServicePage_CarArrivalReasonTypeId",
			    Title = WizardResources.CarServiceWizard_CarServicePage_CarArrivalReasonTypeId_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "CarArrivalReasonTypeId", Key = DomainObjectPropertyKeys.CarService.CarArrivalReasonTypeId, DataType = FieldDataType.Integer},
                ValueField = @"Id",
                DisplayField = @"Name",
            });
			
	    
            return items.Count == 0 ? null : items.ToArray();
        }

    }
}
