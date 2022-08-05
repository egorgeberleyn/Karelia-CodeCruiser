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
    ///  SubTaskWizard wizard settings controller
    /// </summary>
    [AllowAnonymous]
	public sealed class SubTaskWizardWizardSettingsController : GuiSettingsBaseApiController<DomainPermissions>
    {
	    /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="securityService"></param>
        public SubTaskWizardWizardSettingsController(IRequestStorageInitializer requestInitializer, ISecurityService securityService)
            : base(requestInitializer, securityService)
        {
        }

        /// <summary>
        /// Get settings for 'SubTaskWizard' wizard
        /// </summary>
        /// <returns></returns>
		public IHttpActionResult Get()
        {
            if(!Security.AuthorizeAny(DomainPermissions.SubTask_Read, DomainPermissions.SubTask_Create, DomainPermissions.SubTask_Update)){ return GetInternalForbiddenResult(@"Sub task.Read(SubTask_Read), Sub task.Create(SubTask_Create), Sub task.Update(SubTask_Update)"); }
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

            #region SubTaskPage
            {
		        var item = new WizardPage 
                {
				    Name = "subTaskPage",
					Title = WizardResources.SubTaskWizard_SubTaskPage,
                    BannerTitle = WizardResources.SubTaskWizard_SubTaskPage_BannerTitle,
					BannerDescription = WizardResources.SubTaskWizard_SubTaskPage_BannerDescription,
				    Editors = GetSubTaskPageEditors(context),
                };
				           
			    if (item.Editors != null)
				{
				    items.Add(item);
				}
            }
			#endregion
	    
            return items.Count == 0 ? null : items.ToArray();
        }
        
		private WizardPageEditor[] GetSubTaskPageEditors(WizardSettingsContext context)
        {
		    var items = new List<WizardPageEditor>(3);

            // subTaskPage_Name
            items.Add(new TextWizardPageEditor 
            {
			    Name = "subTaskPage_Name",
			    Title = WizardResources.SubTaskWizard_SubTaskPage_Name_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "Name", Key = DomainObjectPropertyKeys.SubTask.Name, DataType = FieldDataType.String},
                MaxLength = null,
                Validators = new [] 
				{
                    new Validator {Handler = "Name_Required",Type = ValidatorType.Required, Message = ValidationResources.SubTask_Name_RequiredMsg},
				}
            });
			
            // subTaskPage_Sequence
            items.Add(new NumericWizardPageEditor 
            {
			    Name = "subTaskPage_Sequence",
			    Title = WizardResources.SubTaskWizard_SubTaskPage_Sequence_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "Sequence", Key = DomainObjectPropertyKeys.SubTask.Sequence, DataType = FieldDataType.Integer},
                Step = 1,
            });
			
            // subTaskPage_Description
            items.Add(new TextWizardPageEditor 
            {
			    Name = "subTaskPage_Description",
			    Title = WizardResources.SubTaskWizard_SubTaskPage_Description_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "Description", Key = DomainObjectPropertyKeys.SubTask.Description, DataType = FieldDataType.String},
                MaxLength = null,
            });
			
	    
            return items.Count == 0 ? null : items.ToArray();
        }

    }
}
