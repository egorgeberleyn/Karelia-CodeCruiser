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
    ///  OfficeEquipmentModelWizard wizard settings controller
    /// </summary>
    [AllowAnonymous]
	public sealed class OfficeEquipmentModelWizardWizardSettingsController : GuiSettingsBaseApiController<DomainPermissions>
    {
	    /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="securityService"></param>
        public OfficeEquipmentModelWizardWizardSettingsController(IRequestStorageInitializer requestInitializer, ISecurityService securityService)
            : base(requestInitializer, securityService)
        {
        }

        /// <summary>
        /// Get settings for 'OfficeEquipmentModelWizard' wizard
        /// </summary>
        /// <returns></returns>
		public IHttpActionResult Get()
        {
            if(!Security.AuthorizeAny(DomainPermissions.OfficeEquipmentModel_Read, DomainPermissions.OfficeEquipmentModel_Create, DomainPermissions.OfficeEquipmentModel_Update)){ return GetInternalForbiddenResult(@"Office equipment model.Read(OfficeEquipmentModel_Read), Office equipment model.Create(OfficeEquipmentModel_Create), Office equipment model.Update(OfficeEquipmentModel_Update)"); }
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

            #region EquipmentModelPage
            {
		        var item = new WizardPage 
                {
				    Name = "equipmentModelPage",
					Title = WizardResources.OfficeEquipmentModelWizard_EquipmentModelPage,
                    BannerTitle = WizardResources.OfficeEquipmentModelWizard_EquipmentModelPage_BannerTitle,
					BannerDescription = WizardResources.OfficeEquipmentModelWizard_EquipmentModelPage_BannerDescription,
				    Editors = GetEquipmentModelPageEditors(context),
                };
				           
			    if (item.Editors != null)
				{
				    items.Add(item);
				}
            }
			#endregion
	    
            return items.Count == 0 ? null : items.ToArray();
        }
        
		private WizardPageEditor[] GetEquipmentModelPageEditors(WizardSettingsContext context)
        {
		    var items = new List<WizardPageEditor>(1);

            // equipmentModelPage_Name
            items.Add(new TextWizardPageEditor 
            {
			    Name = "equipmentModelPage_Name",
			    Title = WizardResources.OfficeEquipmentModelWizard_EquipmentModelPage_Name_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "Name", Key = DomainObjectPropertyKeys.OfficeEquipmentModel.Name, DataType = FieldDataType.String},
                MaxLength = null,
            });
			
	    
            return items.Count == 0 ? null : items.ToArray();
        }

    }
}
