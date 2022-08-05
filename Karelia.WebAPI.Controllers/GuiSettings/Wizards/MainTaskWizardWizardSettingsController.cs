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
    ///  MainTaskWizard wizard settings controller
    /// </summary>
    [AllowAnonymous]
	public sealed class MainTaskWizardWizardSettingsController : GuiSettingsBaseApiController<DomainPermissions>
    {
	    /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="securityService"></param>
        public MainTaskWizardWizardSettingsController(IRequestStorageInitializer requestInitializer, ISecurityService securityService)
            : base(requestInitializer, securityService)
        {
        }

        /// <summary>
        /// Get settings for 'MainTaskWizard' wizard
        /// </summary>
        /// <returns></returns>
		public IHttpActionResult Get()
        {
            if(!Security.AuthorizeAny(DomainPermissions.MainTask_Read, DomainPermissions.MainTask_Create, DomainPermissions.MainTask_Update)){ return GetInternalForbiddenResult(@"Main task.Read(MainTask_Read), Main task.Create(MainTask_Create), Main task.Update(MainTask_Update)"); }
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

            #region MainTaskPage
            {
		        var item = new WizardPage 
                {
				    Name = "mainTaskPage",
					Title = WizardResources.MainTaskWizard_MainTaskPage,
                    BannerTitle = WizardResources.MainTaskWizard_MainTaskPage_BannerTitle,
					BannerDescription = WizardResources.MainTaskWizard_MainTaskPage_BannerDescription,
				    Editors = GetMainTaskPageEditors(context),
                };
				           
			    if (item.Editors != null)
				{
				    items.Add(item);
				}
            }
			#endregion
	    
            return items.Count == 0 ? null : items.ToArray();
        }
        
		private WizardPageEditor[] GetMainTaskPageEditors(WizardSettingsContext context)
        {
		    var items = new List<WizardPageEditor>(6);

            // mainTaskPage_Name
            items.Add(new TextWizardPageEditor 
            {
			    Name = "mainTaskPage_Name",
			    Title = WizardResources.MainTaskWizard_MainTaskPage_Name_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "Name", Key = DomainObjectPropertyKeys.MainTask.Name, DataType = FieldDataType.String},
                MaxLength = null,
                Validators = new [] 
				{
                    new Validator {Handler = "Name_Required",Type = ValidatorType.Required, Message = ValidationResources.MainTask_Name_RequiredMsg},
				}
            });
			
            // mainTaskPage_EmployeeId
            items.Add(new ComboBoxWizardPageEditor 
            {
			    Name = "mainTaskPage_EmployeeId",
			    Title = WizardResources.MainTaskWizard_MainTaskPage_EmployeeId_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "EmployeeId", Key = DomainObjectPropertyKeys.MainTask.EmployeeId, DataType = FieldDataType.Integer},
                ValueField = @"Id",
                DisplayField = @"Name",
                Validators = new [] 
				{
                    new Validator {Handler = "EmployeeId_Required",Type = ValidatorType.Required, Message = ValidationResources.MainTask_EmployeeId_RequiredMsg},
				}
            });
			
            // mainTaskPage_CreationDate
            items.Add(new DateTimeWizardPageEditor 
            {
			    Name = "mainTaskPage_CreationDate",
			    Title = WizardResources.MainTaskWizard_MainTaskPage_CreationDate_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "CreationDate", Key = DomainObjectPropertyKeys.MainTask.CreationDate, DataType = FieldDataType.DateTime},
                EditType = DateTimeWizardPageEditorType.Date,
            });
			
            // mainTaskPage_EndDate
            items.Add(new DateTimeWizardPageEditor 
            {
			    Name = "mainTaskPage_EndDate",
			    Title = WizardResources.MainTaskWizard_MainTaskPage_EndDate_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "EndDate", Key = DomainObjectPropertyKeys.MainTask.EndDate, DataType = FieldDataType.DateTime},
                EditType = DateTimeWizardPageEditorType.Date,
            });
			
            // mainTaskPage_Comments
            items.Add(new TextWizardPageEditor 
            {
			    Name = "mainTaskPage_Comments",
			    Title = WizardResources.MainTaskWizard_MainTaskPage_Comments_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "Comments", Key = DomainObjectPropertyKeys.MainTask.Comments, DataType = FieldDataType.String},
                MaxLength = null,
            });
			
            // mainTaskPage_IsCompleted
            items.Add(new CheckWizardPageEditor 
            {
			    Name = "mainTaskPage_IsCompleted",
			    Title = WizardResources.MainTaskWizard_MainTaskPage_IsCompleted_DisplayName,
				ReadOnly = false,
				IsEndLine = true,
                Field = new Field {Name = "IsCompleted", Key = DomainObjectPropertyKeys.MainTask.IsCompleted, DataType = FieldDataType.Bool},
                IsThreeState = false,
                Validators = new [] 
				{
                    new Validator {Handler = "IsCompleted_Required",Type = ValidatorType.Required, Message = ValidationResources.MainTask_IsCompleted_RequiredMsg},
				}
            });
			
	    
            return items.Count == 0 ? null : items.ToArray();
        }

    }
}
