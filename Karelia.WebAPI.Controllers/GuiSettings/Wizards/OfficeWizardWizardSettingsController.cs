﻿using System.Collections.Generic;
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
    ///  OfficeWizard wizard settings controller
    /// </summary>
    [AllowAnonymous]
	public sealed class OfficeWizardWizardSettingsController : GuiSettingsBaseApiController<DomainPermissions>
    {
	    /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="securityService"></param>
        public OfficeWizardWizardSettingsController(IRequestStorageInitializer requestInitializer, ISecurityService securityService)
            : base(requestInitializer, securityService)
        {
        }

        /// <summary>
        /// Get settings for 'OfficeWizard' wizard
        /// </summary>
        /// <returns></returns>
		public IHttpActionResult Get()
        {
            if(!Security.AuthorizeAny(DomainPermissions.Office_Read, DomainPermissions.Office_Create, DomainPermissions.Office_Update)){ return GetInternalForbiddenResult(@"Office.Read(Office_Read), Office.Create(Office_Create), Office.Update(Office_Update)"); }
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

            #region OfficePage
            {
		        var item = new WizardPage 
                {
				    Name = "officePage",
					Title = WizardResources.OfficeWizard_OfficePage,
                    BannerTitle = WizardResources.OfficeWizard_OfficePage_BannerTitle,
					BannerDescription = WizardResources.OfficeWizard_OfficePage_BannerDescription,
				    Editors = GetOfficePageEditors(context),
                };
				           
			    if (item.Editors != null)
				{
				    items.Add(item);
				}
            }
			#endregion
	    
            return items.Count == 0 ? null : items.ToArray();
        }
        
		private WizardPageEditor[] GetOfficePageEditors(WizardSettingsContext context)
        {
		    var items = new List<WizardPageEditor>(1);

            // officePage_Adress
            items.Add(new TextWizardPageEditor 
            {
			    Name = "officePage_Adress",
			    Title = WizardResources.OfficeWizard_OfficePage_Adress_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "Adress", Key = DomainObjectPropertyKeys.Office.Adress, DataType = FieldDataType.String},
                MaxLength = null,
                Validators = new [] 
				{
                    new Validator {Handler = "Adress_Required",Type = ValidatorType.Required, Message = ValidationResources.Office_Adress_RequiredMsg},
				}
            });
			
	    
            return items.Count == 0 ? null : items.ToArray();
        }

    }
}
