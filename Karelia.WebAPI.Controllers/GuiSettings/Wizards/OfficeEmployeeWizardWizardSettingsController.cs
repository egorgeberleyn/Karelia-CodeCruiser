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
    ///  OfficeEmployeeWizard wizard settings controller
    /// </summary>
    [AllowAnonymous]
	public sealed class OfficeEmployeeWizardWizardSettingsController : GuiSettingsBaseApiController<DomainPermissions>
    {
	    /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="securityService"></param>
        public OfficeEmployeeWizardWizardSettingsController(IRequestStorageInitializer requestInitializer, ISecurityService securityService)
            : base(requestInitializer, securityService)
        {
        }

        /// <summary>
        /// Get settings for 'OfficeEmployeeWizard' wizard
        /// </summary>
        /// <returns></returns>
		public IHttpActionResult Get()
        {
            if(!Security.AuthorizeAny(DomainPermissions.OfiiceEmployee_Read, DomainPermissions.OfiiceEmployee_Create, DomainPermissions.OfiiceEmployee_Update)){ return GetInternalForbiddenResult(@"OfficeEmployee.Read(OfiiceEmployee_Read), OfficeEmployee.Create(OfiiceEmployee_Create), OfficeEmployee.Update(OfiiceEmployee_Update)"); }
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

            #region OfficeEmployeePage
            {
		        var item = new WizardPage 
                {
				    Name = "officeEmployeePage",
					Title = WizardResources.OfficeEmployeeWizard_OfficeEmployeePage,
                    BannerTitle = WizardResources.OfficeEmployeeWizard_OfficeEmployeePage_BannerTitle,
					BannerDescription = WizardResources.OfficeEmployeeWizard_OfficeEmployeePage_BannerDescription,
				    Editors = GetOfficeEmployeePageEditors(context),
                };
				           
			    if (item.Editors != null)
				{
				    items.Add(item);
				}
            }
			#endregion
	    
            return items.Count == 0 ? null : items.ToArray();
        }
        
		private WizardPageEditor[] GetOfficeEmployeePageEditors(WizardSettingsContext context)
        {
		    var items = new List<WizardPageEditor>(1);

            // officeEmployeePage_Name
            items.Add(new TextWizardPageEditor 
            {
			    Name = "officeEmployeePage_Name",
			    Title = WizardResources.OfficeEmployeeWizard_OfficeEmployeePage_Name_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "Name", Key = DomainObjectPropertyKeys.OfiiceEmployee.Name, DataType = FieldDataType.String},
                MaxLength = null,
                Validators = new [] 
				{
                    new Validator {Handler = "Name_Required",Type = ValidatorType.Required, Message = ValidationResources.OfiiceEmployee_Name_RequiredMsg},
				}
            });
			
	    
            return items.Count == 0 ? null : items.ToArray();
        }

    }
}
