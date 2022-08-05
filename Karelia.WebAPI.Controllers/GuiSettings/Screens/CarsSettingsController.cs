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
    ///  Cars screen settings controller
    /// </summary>
    public sealed class CarsSettingsController : GuiSettingsBaseApiController<DomainPermissions>
    {
	    /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="securityService"></param>
        public CarsSettingsController(IRequestStorageInitializer requestInitializer, ISecurityService securityService)
            : base(requestInitializer, securityService)
        {
        }

        /// <summary>
        /// Get settings for 'Cars' screen
        /// </summary>
        /// <returns></returns>		
        public IHttpActionResult Get()
        {            
            if (!(Security.AuthorizeAll(DomainPermissions.CarQuery_Read)))
            {
                return GetInternalForbiddenResult();
            }

		    var context = new ScreenSettingsContext();
            var result = new Screen
            {
                Name = "cars",
				Title = ScreenResources.Cars_DisplayName,

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
				    Name = "carsGridBlock",
                    Actions = GetCarsGridBlockActions(),
				    Controller = "CarQuery",
				    Content = GetCarsGridBlockContent(context),
                };
				           
			    if (item.Content != null)
				{
				    return item;
				}
            return null;
	    
        }
		private DataBlockContent GetCarsGridBlockContent(ScreenSettingsContext context)
        {
		    
            if (!(Security.AuthorizeAll(DomainPermissions.CarQuery_Read)))
            {
			    return null;
			}
            var fields = new List<GridDataBlockContentField>(4);            

            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "CarModel_Name", Key = DomainObjectPropertyKeys.CarQuery.CarModel_Name, DataType = FieldDataType.String},
				Title = ScreenResources.Cars_CarsGridBlock_CarModel_Name,                
				Sortable = true,
				Width = 140.8,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "Number", Key = DomainObjectPropertyKeys.CarQuery.Number, DataType = FieldDataType.String},
				Title = ScreenResources.Cars_CarsGridBlock_Number,                
				Sortable = true,
				Width = 106.4,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "Description", Key = DomainObjectPropertyKeys.CarQuery.Description, DataType = FieldDataType.String},
				Title = ScreenResources.Cars_CarsGridBlock_Description,                
				Sortable = true,
				Width = 386.4,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "CarModel_FuelConsumption", Key = DomainObjectPropertyKeys.CarQuery.CarModel_FuelConsumption, DataType = FieldDataType.Float},
				Title = ScreenResources.Cars_CarsGridBlock_CarModel_FuelConsumption,                
				Sortable = true,
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
				    Name = "serviceTabPanel",
				    Children = GetServiceTabPanelChildren(context),
                };
				           
			    if (item.Children != null)
				{
				    return item;
				}
            return null;
	    
        }
        
		private ScreenItem[] GetServiceTabPanelChildren(ScreenSettingsContext context)
        {
		        var item = new Tab 
                {
				    Name = "visits",
				    Content = GetVisitsChildren(context),
				    Title = ScreenResources.Cars_Visits,
                };
				           
			    if (item.Content != null)
				{
				    return new ScreenItem[]{item};
				}
            return null;
	    
        }
        
		private ScreenItem GetVisitsChildren(ScreenSettingsContext context)
        {
		        var item = new SplitContainer 
                {
				    Name = "splitContainer3",
                    Orientation = SplitContainerOrientation.Horizontal,
                    CollapsingPanel = SplitContainerPanel.Panel2,
                    FixedPanel = SplitContainerPanel.None,
                    PanelsRatio =0.5d,
                    Panel1 = GetSplitContainer3_Panel1Children(context),
		            Panel2 = GetSplitContainer3_Panel2Children(context),
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
        
		private ScreenItem GetSplitContainer3_Panel1Children(ScreenSettingsContext context)
        {
		        var item = new DataBlock 
                {
				    Name = "carServiceDataGrid",
                    Actions = GetCarServiceDataGridActions(),
				    Controller = "CarServiceQuery",
				    Content = GetCarServiceDataGridContent(context),
                    Depends = new[]
                    {
                        new DataBlockDepend {Parent = "carsGridBlock", ParentFields = new[] {"Id"}, Fields = new[] {"CarId"}},
                    },
                };
				           
			    if (item.Content != null)
				{
				    return item;
				}
            return null;
	    
        }
		private DataBlockContent GetCarServiceDataGridContent(ScreenSettingsContext context)
        {
		    
            if (!(Security.AuthorizeAll(DomainPermissions.CarServiceQuery_Read) && Security.AuthorizeAll(DomainPermissions.CarQuery_Read)))
            {
			    return null;
			}
            var fields = new List<GridDataBlockContentField>(4);            

            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "StartDate", Key = DomainObjectPropertyKeys.CarServiceQuery.StartDate, DataType = FieldDataType.DateTime},
				Title = ScreenResources.Cars_CarServiceDataGrid_StartDate,                
				Format = 2,
				Sortable = true,
				Width = 85.6,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "EndDate", Key = DomainObjectPropertyKeys.CarServiceQuery.EndDate, DataType = FieldDataType.DateTime},
				Title = ScreenResources.Cars_CarServiceDataGrid_EndDate,                
				Format = 2,
				Sortable = true,
				Width = 96.8,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "Odometer", Key = DomainObjectPropertyKeys.CarServiceQuery.Odometer, DataType = FieldDataType.Integer},
				Title = ScreenResources.Cars_CarServiceDataGrid_Odometer,                
				Sortable = true,
				Width = 57.6,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "CarArrivalReasonType_Name", Key = DomainObjectPropertyKeys.CarServiceQuery.CarArrivalReasonType_Name, DataType = FieldDataType.String},
				Title = ScreenResources.Cars_CarServiceDataGrid_CarArrivalReasonType_Name,                
				Sortable = true,
				Width = 119.2,
			});

		    return new GridDataBlockContent
			{
			    PagingEnabled = true,
                ItemsOnPage = 100,
                Fields = fields.ToArray()

			};

        }
        
		private ScreenItem GetSplitContainer3_Panel2Children(ScreenSettingsContext context)
        {
		        var item = new SplitContainer 
                {
				    Name = "splitContainer1",
                    Orientation = SplitContainerOrientation.Horizontal,
                    CollapsingPanel = SplitContainerPanel.Panel2,
                    FixedPanel = SplitContainerPanel.None,
                    PanelsRatio =0.6d,
                    Panel1 = GetSplitContainer1_Panel1Children(context),
		            Panel2 = GetSplitContainer1_Panel2Children(context),
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
        
		private ScreenItem GetSplitContainer1_Panel1Children(ScreenSettingsContext context)
        {
		        var item = new DataBlock 
                {
				    Name = "carServicePart",
                    Actions = GetCarServicePartActions(),
				    Controller = "CarServicePartQuery",
				    Content = GetCarServicePartContent(context),
                    Depends = new[]
                    {
                        new DataBlockDepend {Parent = "carServiceDataGrid", ParentFields = new[] {"Id"}, Fields = new[] {"CarServiceId"}},
                    },
                };
				           
			    if (item.Content != null)
				{
				    return item;
				}
            return null;
	    
        }
		private DataBlockContent GetCarServicePartContent(ScreenSettingsContext context)
        {
		    
            if (!(Security.AuthorizeAll(DomainPermissions.CarServicePartQuery_Read) && Security.AuthorizeAll(DomainPermissions.CarServiceQuery_Read)))
            {
			    return null;
			}
            var fields = new List<GridDataBlockContentField>(3);            

            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "CarModelPart_Name", Key = DomainObjectPropertyKeys.CarServicePartQuery.CarModelPart_Name, DataType = FieldDataType.String},
				Title = ScreenResources.Cars_CarServicePart_CarModelPart_Name,                
				Sortable = true,
				Width = 100.8,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "CarModelPart_Price", Key = DomainObjectPropertyKeys.CarServicePartQuery.CarModelPart_Price, DataType = FieldDataType.Decimal},
				Title = ScreenResources.Cars_CarServicePart_CarModelPart_Price,                
				Sortable = true,
				Width = 55.2,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "Quantity", Key = DomainObjectPropertyKeys.CarServicePartQuery.Quantity, DataType = FieldDataType.Integer},
				Title = ScreenResources.Cars_CarServicePart_Quantity,                
				Sortable = true,
				Width = 55.2,
			});

		    return new GridDataBlockContent
			{
			    PagingEnabled = true,
                ItemsOnPage = 100,
                Fields = fields.ToArray()

			};

        }
        
		private ScreenItem GetSplitContainer1_Panel2Children(ScreenSettingsContext context)
        {
		        var item = new DataBlock 
                {
				    Name = "carServiceWork",
                    Actions = GetCarServiceWorkActions(),
				    Controller = "CarServiceWorkQuery",
				    Content = GetCarServiceWorkContent(context),
                    Depends = new[]
                    {
                        new DataBlockDepend {Parent = "carServiceDataGrid", ParentFields = new[] {"Id"}, Fields = new[] {"CarServiceId"}},
                    },
                };
				           
			    if (item.Content != null)
				{
				    return item;
				}
            return null;
	    
        }
		private DataBlockContent GetCarServiceWorkContent(ScreenSettingsContext context)
        {
		    
            if (!(Security.AuthorizeAll(DomainPermissions.CarServiceWorkQuery_Read) && Security.AuthorizeAll(DomainPermissions.CarServiceQuery_Read)))
            {
			    return null;
			}
            var fields = new List<GridDataBlockContentField>(1);            

            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "CarWorkType_Name", Key = DomainObjectPropertyKeys.CarServiceWorkQuery.CarWorkType_Name, DataType = FieldDataType.String},
				Title = ScreenResources.Cars_CarServiceWork_CarWorkType_Name,                
				Sortable = true,
				Width = 155.2,
			});

		    return new GridDataBlockContent
			{
			    PagingEnabled = true,
                ItemsOnPage = 100,
                Fields = fields.ToArray()

			};

        }
        
		private WorkActionItem[] GetCarsGridBlockActions()
        {
		    var actions = new List<WorkActionItem>(4);
            if (Security.AuthorizeAll(DomainPermissions.Car_Create))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Cars_CarsGridBlock_CreateCar,
    			    Image = "action-create-new",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carsGridBlockCreateCar",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.Car_Update))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Cars_CarsGridBlock_EditCar,
    			    Image = "action-edit",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carsGridBlockEditCar",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.Car_Delete))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Cars_CarsGridBlock_DeleteCar,
    			    Image = "action-delete",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carsGridBlockDeleteCar",
                });
            }
		    actions.Add(new WorkAction
            {
			    Title = ActionsResources.Cars_CarsGridBlock_RefreshCar,
			    Image = "action-refresh",
				ClassName = "default",
			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                ActionName = "carsGridBlockRefreshCar",
            });
            return actions.Count != 0 ? actions.ToArray() : null;
        }

        
		private WorkActionItem[] GetCarServiceDataGridActions()
        {
		    var actions = new List<WorkActionItem>(4);
            if (Security.AuthorizeAll(DomainPermissions.CarService_Create))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Cars_CarServiceDataGrid_CreateCarService,
    			    Image = "action-create-new",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carServiceDataGridCreateCarService",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.CarService_Update))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Cars_CarServiceDataGrid_EditCarService,
    			    Image = "action-edit",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carServiceDataGridEditCarService",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.CarService_Delete))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Cars_CarServiceDataGrid_DeleteCarService,
    			    Image = "action-delete",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carServiceDataGridDeleteCarService",
                });
            }
		    actions.Add(new WorkAction
            {
			    Title = ActionsResources.Cars_CarServiceDataGrid_RefreshCarService,
			    Image = "action-refresh",
				ClassName = "default",
			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                ActionName = "carServiceDataGridRefreshCarService",
            });
            return actions.Count != 0 ? actions.ToArray() : null;
        }

        
		private WorkActionItem[] GetCarServicePartActions()
        {
		    var actions = new List<WorkActionItem>(4);
            if (Security.AuthorizeAll(DomainPermissions.CarServicePart_Create))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Cars_CarServicePart_CreateCarServicePart,
    			    Image = "action-create-new",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carServicePartCreateCarServicePart",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.CarServicePart_Update))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Cars_CarServicePart_EditCarServicePart,
    			    Image = "action-edit",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carServicePartEditCarServicePart",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.CarServicePart_Delete))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Cars_CarServicePart_DeleteCarServicePart,
    			    Image = "action-delete",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carServicePartDeleteCarServicePart",
                });
            }
		    actions.Add(new WorkAction
            {
			    Title = ActionsResources.Cars_CarServicePart_RefreshCarServicePart,
			    Image = "action-refresh",
				ClassName = "default",
			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                ActionName = "carServicePartRefreshCarServicePart",
            });
            return actions.Count != 0 ? actions.ToArray() : null;
        }

        
		private WorkActionItem[] GetCarServiceWorkActions()
        {
		    var actions = new List<WorkActionItem>(4);
            if (Security.AuthorizeAll(DomainPermissions.CarServiceWork_Create))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Cars_CarServiceWork_CreateCarServiceWork,
    			    Image = "action-create-new",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carServiceWorkCreateCarServiceWork",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.CarServiceWork_Update))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Cars_CarServiceWork_EditCarServiceWork,
    			    Image = "action-edit",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carServiceWorkEditCarServiceWork",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.CarServiceWork_Delete))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Cars_CarServiceWork_DeleteCarServiceWork,
    			    Image = "action-delete",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carServiceWorkDeleteCarServiceWork",
                });
            }
		    actions.Add(new WorkAction
            {
			    Title = ActionsResources.Cars_CarServiceWork_RefreshCarServiceWork,
			    Image = "action-refresh",
				ClassName = "default",
			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                ActionName = "carServiceWorkRefreshCarServiceWork",
            });
            return actions.Count != 0 ? actions.ToArray() : null;
        }

    }
}
