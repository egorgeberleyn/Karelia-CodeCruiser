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
    ///  OfficeEquipmentWizard wizard settings controller
    /// </summary>
    [AllowAnonymous]
	public sealed class OfficeEquipmentWizardWizardSettingsController : GuiSettingsBaseApiController<DomainPermissions>
    {
	    /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="securityService"></param>
        public OfficeEquipmentWizardWizardSettingsController(IRequestStorageInitializer requestInitializer, ISecurityService securityService)
            : base(requestInitializer, securityService)
        {
        }

        /// <summary>
        /// Get settings for 'OfficeEquipmentWizard' wizard
        /// </summary>
        /// <returns></returns>
		public IHttpActionResult Get()
        {
            if(!Security.AuthorizeAny(DomainPermissions.OfficeEquipment_Read, DomainPermissions.OfficeEquipment_Create, DomainPermissions.OfficeEquipment_Update)){ return GetInternalForbiddenResult(@"Office equipment.Read(OfficeEquipment_Read), Office equipment.Create(OfficeEquipment_Create), Office equipment.Update(OfficeEquipment_Update)"); }
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

            #region OfficeEquipmentPage
            {
		        var item = new WizardPage 
                {
				    Name = "officeEquipmentPage",
					Title = WizardResources.OfficeEquipmentWizard_OfficeEquipmentPage,
                    BannerTitle = WizardResources.OfficeEquipmentWizard_OfficeEquipmentPage_BannerTitle,
					BannerDescription = WizardResources.OfficeEquipmentWizard_OfficeEquipmentPage_BannerDescription,
				    Editors = GetOfficeEquipmentPageEditors(context),
                };
				           
			    if (item.Editors != null)
				{
				    items.Add(item);
				}
            }
			#endregion
	    
            return items.Count == 0 ? null : items.ToArray();
        }
        
		private WizardPageEditor[] GetOfficeEquipmentPageEditors(WizardSettingsContext context)
        {
		    var items = new List<WizardPageEditor>(6);

            // officeEquipmentPage_OfficeEquipmentModelId
            items.Add(new ComboBoxWizardPageEditor 
            {
			    Name = "officeEquipmentPage_OfficeEquipmentModelId",
			    Title = WizardResources.OfficeEquipmentWizard_OfficeEquipmentPage_OfficeEquipmentModelId_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "OfficeEquipmentModelId", Key = DomainObjectPropertyKeys.OfficeEquipment.OfficeEquipmentModelId, DataType = FieldDataType.Integer},
                ValueField = @"Id",
                DisplayField = @"Name",
                Validators = new [] 
				{
                    new Validator {Handler = "OfficeEquipmentModelId_Required",Type = ValidatorType.Required, Message = ValidationResources.OfficeEquipment_OfficeEquipmentModelId_RequiredMsg},
				}
            });
			
            // officeEquipmentPage_InventoryNumber
            items.Add(new TextWizardPageEditor 
            {
			    Name = "officeEquipmentPage_InventoryNumber",
			    Title = WizardResources.OfficeEquipmentWizard_OfficeEquipmentPage_InventoryNumber_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "InventoryNumber", Key = DomainObjectPropertyKeys.OfficeEquipment.InventoryNumber, DataType = FieldDataType.String},
                MaxLength = null,
                Validators = new [] 
				{
                    new Validator {Handler = "InventoryNumber_Required",Type = ValidatorType.Required, Message = ValidationResources.OfficeEquipment_InventoryNumber_RequiredMsg},
				}
            });
			
            // officeEquipmentPage_PlacementDate
            items.Add(new DateTimeWizardPageEditor 
            {
			    Name = "officeEquipmentPage_PlacementDate",
			    Title = WizardResources.OfficeEquipmentWizard_OfficeEquipmentPage_PlacementDate_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "PlacementDate", Key = DomainObjectPropertyKeys.OfficeEquipment.PlacementDate, DataType = FieldDataType.DateTime},
                EditType = DateTimeWizardPageEditorType.Date,
            });
			
            // officeEquipmentPage_Description
            items.Add(new TextWizardPageEditor 
            {
			    Name = "officeEquipmentPage_Description",
			    Title = WizardResources.OfficeEquipmentWizard_OfficeEquipmentPage_Description_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "Description", Key = DomainObjectPropertyKeys.OfficeEquipment.Description, DataType = FieldDataType.String},
                MaxLength = null,
            });
			
            // officeEquipmentPage_Quontity
            items.Add(new NumericWizardPageEditor 
            {
			    Name = "officeEquipmentPage_Quontity",
			    Title = WizardResources.OfficeEquipmentWizard_OfficeEquipmentPage_Quontity_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "Quontity", Key = DomainObjectPropertyKeys.OfficeEquipment.Quontity, DataType = FieldDataType.Integer},
                Step = 1,
            });
			
            // officeEquipmentPage_OfficeEmployeeId
            items.Add(new ComboBoxWizardPageEditor 
            {
			    Name = "officeEquipmentPage_OfficeEmployeeId",
			    Title = WizardResources.OfficeEquipmentWizard_OfficeEquipmentPage_OfficeEmployeeId_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "OfficeEmployeeId", Key = DomainObjectPropertyKeys.OfficeEquipment.OfficeEmployeeId, DataType = FieldDataType.Integer},
                ValueField = @"Id",
                DisplayField = @"Name",
                Validators = new [] 
				{
                    new Validator {Handler = "OfficeEmployeeId_Required",Type = ValidatorType.Required, Message = ValidationResources.OfficeEquipment_OfficeEmployeeId_RequiredMsg},
				}
            });
			
	    
            return items.Count == 0 ? null : items.ToArray();
        }

    }
}
