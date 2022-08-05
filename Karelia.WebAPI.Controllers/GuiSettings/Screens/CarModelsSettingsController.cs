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
    ///  CarModels screen settings controller
    /// </summary>
    public sealed class CarModelsSettingsController : GuiSettingsBaseApiController<DomainPermissions>
    {
	    /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="securityService"></param>
        public CarModelsSettingsController(IRequestStorageInitializer requestInitializer, ISecurityService securityService)
            : base(requestInitializer, securityService)
        {
        }

        /// <summary>
        /// Get settings for 'CarModels' screen
        /// </summary>
        /// <returns></returns>		
        public IHttpActionResult Get()
        {            
            if (!(Security.AuthorizeAll(DomainPermissions.CarModel_Read)))
            {
                return GetInternalForbiddenResult();
            }

		    var context = new ScreenSettingsContext();
            var result = new Screen
            {
                Name = "carModels",
				Title = ScreenResources.CarModels_DisplayName,

                Content = GetScreenChildren(context)
            };

            return Json(result, GuiSettingsJsonSettings.WriteSettings);
        }
        
		private ScreenItem GetScreenChildren(ScreenSettingsContext context)
        {
		        var item = new SplitContainer 
                {
				    Name = "splitContainer",
                    Orientation = SplitContainerOrientation.Vertical,
                    CollapsingPanel = SplitContainerPanel.Panel2,
                    FixedPanel = SplitContainerPanel.None,
                    PanelsRatio =0.5d,
                    Panel1 = GetSplitContainer_Panel1Children(context),
		            Panel2 = GetSplitContainer_Panel2Children(context),
                };
				           
			    if (item.Panel1 != null && item.Panel2 != null)
				{
				    return item;
				}
                else if (item.Panel1 != null)
				{
				    return item.Panel1;
				}
				else if (item.Panel2 != null)
				{
				    return item.Panel2;
				}
            return null;
	    
        }
        
		private ScreenItem GetSplitContainer_Panel1Children(ScreenSettingsContext context)
        {
		        var item = new DataBlock 
                {
				    Name = "carModels",
                    Actions = GetCarModelsActions(),
				    Controller = "CarModel",
				    Content = GetCarModelsContent(context),
                };
				           
			    if (item.Content != null)
				{
				    return item;
				}
            return null;
	    
        }
		private DataBlockContent GetCarModelsContent(ScreenSettingsContext context)
        {
		    
            if (!(Security.AuthorizeAll(DomainPermissions.CarModel_Read)))
            {
			    return null;
			}
            var fields = new List<GridDataBlockContentField>(2);            

            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "Name", Key = DomainObjectPropertyKeys.CarModel.Name, DataType = FieldDataType.String},
				Title = ScreenResources.CarModels_CarModels_Name,                
				Sortable = true,
				Width = 236.8,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "FuelConsumption", Key = DomainObjectPropertyKeys.CarModel.FuelConsumption, DataType = FieldDataType.Float},
				Title = ScreenResources.CarModels_CarModels_FuelConsumption,                
				Sortable = true,
				Width = 135.2,
			});

		    return new GridDataBlockContent
			{
			    HasQuickFilter = true,
			    PagingEnabled = true,
                ItemsOnPage = 100,
                Fields = fields.ToArray()

			};

        }
        
		private ScreenItem GetSplitContainer_Panel2Children(ScreenSettingsContext context)
        {
		        var item = new TabLayout 
                {
				    Name = "carDetails",
				    Children = GetCarDetailsChildren(context),
                };
				           
			    if (item.Children != null)
				{
				    return item;
				}
            return null;
	    
        }
        
		private ScreenItem[] GetCarDetailsChildren(ScreenSettingsContext context)
        {
		        var item = new Tab 
                {
				    Name = "carModelParts",
				    Content = GetCarModelPartsChildren(context),
				    Title = ScreenResources.CarModels_CarModelParts,
                };
				           
			    if (item.Content != null)
				{
				    return new ScreenItem[]{item};
				}
            return null;
	    
        }
        
		private ScreenItem GetCarModelPartsChildren(ScreenSettingsContext context)
        {
		        var item = new DataBlock 
                {
				    Name = "carModelPart",
                    Actions = GetCarModelPartActions(),
				    Controller = "CarModelPart",
				    Content = GetCarModelPartContent(context),
                    Depends = new[]
                    {
                        new DataBlockDepend {Parent = "carModels", ParentFields = new[] {"Id"}, Fields = new[] {"CarModelId"}},
                    },
                };
				           
			    if (item.Content != null)
				{
				    return item;
				}
            return null;
	    
        }
		private DataBlockContent GetCarModelPartContent(ScreenSettingsContext context)
        {
		    
            if (!(Security.AuthorizeAll(DomainPermissions.CarModelPart_Read) && Security.AuthorizeAll(DomainPermissions.CarModel_Read)))
            {
			    return null;
			}
            var fields = new List<GridDataBlockContentField>(2);            

            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "Name", Key = DomainObjectPropertyKeys.CarModelPart.Name, DataType = FieldDataType.String},
				Title = ScreenResources.CarModels_CarModelPart_Name,                
				Sortable = true,
				Width = 214.4,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "Price", Key = DomainObjectPropertyKeys.CarModelPart.Price, DataType = FieldDataType.Decimal},
				Title = ScreenResources.CarModels_CarModelPart_Price,                
				Sortable = true,
				Width = 104.0,
			});

		    return new GridDataBlockContent
			{
			    HasQuickFilter = true,
			    PagingEnabled = true,
                ItemsOnPage = 100,
                Fields = fields.ToArray()

			};

        }
        
		private WorkActionItem[] GetCarModelsActions()
        {
		    var actions = new List<WorkActionItem>(4);
            if (Security.AuthorizeAll(DomainPermissions.CarModel_Create))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.CarModels_CarModels_CreateCarModel,
    			    Image = "action-create-new",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carModelsCreateCarModel",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.CarModel_Update))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.CarModels_CarModels_EditCarModel,
    			    Image = "action-edit",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carModelsEditCarModel",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.CarModel_Delete))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.CarModels_CarModels_DeleteCarModel,
    			    Image = "action-delete",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carModelsDeleteCarModel",
                });
            }
		    actions.Add(new WorkAction
            {
			    Title = ActionsResources.CarModels_CarModels_RefreshCarModel,
			    Image = "action-refresh",
				ClassName = "default",
			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                ActionName = "carModelsRefreshCarModel",
            });
            return actions.Count != 0 ? actions.ToArray() : null;
        }

        
		private WorkActionItem[] GetCarModelPartActions()
        {
		    var actions = new List<WorkActionItem>(4);
            if (Security.AuthorizeAll(DomainPermissions.CarModelPart_Create))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.CarModels_CarModelPart_CreateCarModelPart,
    			    Image = "action-create-new",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carModelPartCreateCarModelPart",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.CarModelPart_Update))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.CarModels_CarModelPart_EditCarModelPart,
    			    Image = "action-edit",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carModelPartEditCarModelPart",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.CarModelPart_Delete))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.CarModels_CarModelPart_DeleteCarModelPart,
    			    Image = "action-delete",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carModelPartDeleteCarModelPart",
                });
            }
		    actions.Add(new WorkAction
            {
			    Title = ActionsResources.CarModels_CarModelPart_RefreshCarModelPart,
			    Image = "action-refresh",
				ClassName = "default",
			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                ActionName = "carModelPartRefreshCarModelPart",
            });
            return actions.Count != 0 ? actions.ToArray() : null;
        }

    }
}
