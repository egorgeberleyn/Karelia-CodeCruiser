using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using BusinessFramework.Contracts.GuiSettings.Actions;
using BusinessFramework.Contracts.GuiSettings.Fields;
using BusinessFramework.Contracts.GuiSettings.Json;
using BusinessFramework.Contracts.GuiSettings.Screens;
using BusinessFramework.Contracts.GuiSettings.Screens.DataBlocks;
using BusinessFramework.WebAPI.Common.GuiSettings;
using BusinessFramework.WebAPI.Common.Request;
using BusinessFramework.WebAPI.Common.Security;
using BusinessFramework.WebAPI.Contracts.Security;
using BusinessFramework.WebAPI.GuiSettingsControllers;
using Karelia.Contracts;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Controllers.Properties;

// ReSharper disable UnusedParameter.Local

namespace Karelia.WebAPI.Controllers.GuiSettings.Screens
{
    /// <summary>
    ///  ModelEquipments screen settings controller
    /// </summary>
    public sealed class ModelEquipmentsSettingsController : GuiSettingsBaseApiController<DomainPermissions>
    {
	    /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="securityService"></param>
        public ModelEquipmentsSettingsController(IRequestStorageInitializer requestInitializer, ISecurityService securityService)
            : base(requestInitializer, securityService)
        {
        }

        /// <summary>
        /// Get settings for 'ModelEquipments' screen
        /// </summary>
        /// <returns></returns>		
        public IHttpActionResult Get()
        {            
            if (!(Security.AuthorizeAll(DomainPermissions.OfficeEquipmentModel_Read)))
            {
                return GetInternalForbiddenResult();
            }

		    var context = new ScreenSettingsContext();
            var result = new Screen
            {
                Name = "modelEquipments",
				Title = ScreenResources.ModelEquipments_DisplayName,

                Content = GetScreenChildren(context)
            };

            return Json(result, GuiSettingsJsonSettings.WriteSettings);
        }
        
		private ScreenItem GetScreenChildren(ScreenSettingsContext context)
        {
		        var item = new DataBlock 
                {
				    Name = "modelEquipmentGrid",
                    Actions = GetModelEquipmentGridActions(),
				    Controller = "OfficeEquipmentModel",
				    Content = GetModelEquipmentGridContent(context),
                };
				           
			    if (item.Content != null)
				{
				    return item;
				}
            return null;
	    
        }
		private DataBlockContent GetModelEquipmentGridContent(ScreenSettingsContext context)
        {
		    
            if (!(Security.AuthorizeAll(DomainPermissions.OfficeEquipmentModel_Read)))
            {
			    return null;
			}
            var fields = new List<GridDataBlockContentField>(1);            

            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "Name", Key = DomainObjectPropertyKeys.OfficeEquipmentModel.Name, DataType = FieldDataType.String},
				Title = ScreenResources.ModelEquipments_ModelEquipmentGrid_Name,                
				Sortable = true,
				Width = 330.4,
			});

		    return new GridDataBlockContent
			{
			    HasQuickFilter = true,
			    PagingEnabled = true,
                ItemsOnPage = 100,
                Fields = fields.ToArray()

			};

        }
        
		private WorkActionItem[] GetModelEquipmentGridActions()
        {
		    var actions = new List<WorkActionItem>(4);
            if (Security.AuthorizeAll(DomainPermissions.OfficeEquipmentModel_Create))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.ModelEquipments_ModelEquipmentGrid_CreateEquipmentModel,
    			    Image = "action-create-new",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "modelEquipmentGridCreateEquipmentModel",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.OfficeEquipmentModel_Update))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.ModelEquipments_ModelEquipmentGrid_EditEquipmentModel,
    			    Image = "action-edit",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "modelEquipmentGridEditEquipmentModel",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.OfficeEquipmentModel_Delete))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.ModelEquipments_ModelEquipmentGrid_DeleteEquipmentModel,
    			    Image = "action-delete",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "modelEquipmentGridDeleteEquipmentModel",
                });
            }
		    actions.Add(new WorkAction
            {
			    Title = ActionsResources.ModelEquipments_ModelEquipmentGrid_RefreshEquipmentModel,
			    Image = "action-refresh",
				ClassName = "default",
			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                ActionName = "modelEquipmentGridRefreshEquipmentModel",
            });
            return actions.Count != 0 ? actions.ToArray() : null;
        }

    }
}
