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
    ///  Works screen settings controller
    /// </summary>
    public sealed class WorksSettingsController : GuiSettingsBaseApiController<DomainPermissions>
    {
	    /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="securityService"></param>
        public WorksSettingsController(IRequestStorageInitializer requestInitializer, ISecurityService securityService)
            : base(requestInitializer, securityService)
        {
        }

        /// <summary>
        /// Get settings for 'Works' screen
        /// </summary>
        /// <returns></returns>		
        public IHttpActionResult Get()
        {            
            if (!(Security.AuthorizeAll(DomainPermissions.CarQuery_Read) || Security.AuthorizeAll(DomainPermissions.CarServiceQuery_Read)))
            {
                return GetInternalForbiddenResult();
            }

		    var context = new ScreenSettingsContext();
            var result = new Screen
            {
                Name = "works",
				Title = ScreenResources.Works_DisplayName,

                Content = GetScreenChildren(context)
            };

            return Json(result, GuiSettingsJsonSettings.WriteSettings);
        }
        
		private ScreenItem GetScreenChildren(ScreenSettingsContext context)
        {
		        var item = new SplitContainer 
                {
				    Name = "splitContainer4",
                    Orientation = SplitContainerOrientation.Vertical,
                    CollapsingPanel = SplitContainerPanel.Panel2,
                    FixedPanel = SplitContainerPanel.None,
                    PanelsRatio =0.5d,
                    Panel1 = GetSplitContainer4_Panel1Children(context),
		            Panel2 = GetSplitContainer4_Panel2Children(context),
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
        
		private ScreenItem GetSplitContainer4_Panel1Children(ScreenSettingsContext context)
        {
		        var item = new DataBlock 
                {
				    Name = "cars",
                    Actions = GetCarsActions(),
				    Controller = "CarQuery",
				    Content = GetCarsContent(context),
                };
				           
			    if (item.Content != null)
				{
				    return item;
				}
            return null;
	    
        }
		private DataBlockContent GetCarsContent(ScreenSettingsContext context)
        {
		    
            if (!(Security.AuthorizeAll(DomainPermissions.CarQuery_Read)))
            {
			    return null;
			}
            var fields = new List<GridDataBlockContentField>(4);            

            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "CarModel_Name", Key = DomainObjectPropertyKeys.CarQuery.CarModel_Name, DataType = FieldDataType.String},
				Title = ScreenResources.Works_Cars_CarModel_Name,                
				Sortable = true,
				Width = 148.8,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "Number", Key = DomainObjectPropertyKeys.CarQuery.Number, DataType = FieldDataType.String},
				Title = ScreenResources.Works_Cars_Number,                
				Sortable = true,
				Width = 148.0,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "Description", Key = DomainObjectPropertyKeys.CarQuery.Description, DataType = FieldDataType.String},
				Title = ScreenResources.Works_Cars_Description,                
				Sortable = true,
				Width = 338.4,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "CarModel_FuelConsumption", Key = DomainObjectPropertyKeys.CarQuery.CarModel_FuelConsumption, DataType = FieldDataType.Float},
				Title = ScreenResources.Works_Cars_CarModel_FuelConsumption,                
				Sortable = true,
				Width = 92.8,
			});

		    return new GridDataBlockContent
			{
			    HasQuickFilter = true,
			    PagingEnabled = true,
                ItemsOnPage = 100,
                Fields = fields.ToArray()

			};

        }
        
		private ScreenItem GetSplitContainer4_Panel2Children(ScreenSettingsContext context)
        {
		        var item = new DataBlock 
                {
				    Name = "services",
                    Actions = GetServicesActions(),
				    Controller = "CarServiceQuery",
				    Content = GetServicesContent(context),
                };
				           
			    if (item.Content != null)
				{
				    return item;
				}
            return null;
	    
        }
		private DataBlockContent GetServicesContent(ScreenSettingsContext context)
        {
		    
            if (!(Security.AuthorizeAll(DomainPermissions.CarServiceQuery_Read)))
            {
			    return null;
			}
            var fields = new List<GridDataBlockContentField>(6);            

            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "StartDate", Key = DomainObjectPropertyKeys.CarServiceQuery.StartDate, DataType = FieldDataType.DateTime},
				Title = ScreenResources.Works_Services_StartDate,                
				Format = 2,
				Sortable = true,
				Width = 84.8,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "EndDate", Key = DomainObjectPropertyKeys.CarServiceQuery.EndDate, DataType = FieldDataType.DateTime},
				Title = ScreenResources.Works_Services_EndDate,                
				Format = 2,
				Sortable = true,
				Width = 94.4,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "CarArrivalReasonType_Name", Key = DomainObjectPropertyKeys.CarServiceQuery.CarArrivalReasonType_Name, DataType = FieldDataType.String},
				Title = ScreenResources.Works_Services_CarArrivalReasonType_Name,                
				Sortable = true,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "Odometer", Key = DomainObjectPropertyKeys.CarServiceQuery.Odometer, DataType = FieldDataType.Integer},
				Title = ScreenResources.Works_Services_Odometer,                
				Sortable = true,
				Width = 58.4,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "Defect", Key = DomainObjectPropertyKeys.CarServiceQuery.Defect, DataType = FieldDataType.String},
				Title = ScreenResources.Works_Services_Defect,                
				Sortable = true,
				Width = 184.8,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "Conclusion", Key = DomainObjectPropertyKeys.CarServiceQuery.Conclusion, DataType = FieldDataType.String},
				Title = ScreenResources.Works_Services_Conclusion,                
				Sortable = true,
				Width = 197.6,
			});

		    return new GridDataBlockContent
			{
			    HasQuickFilter = true,
			    PagingEnabled = true,
                ItemsOnPage = 100,
                Fields = fields.ToArray()

			};

        }
        
		private WorkActionItem[] GetCarsActions()
        {
		    var actions = new List<WorkActionItem>(4);
            if (Security.AuthorizeAll(DomainPermissions.Car_Create))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Works_Cars_CreateCar,
    			    Image = "action-create-new",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carsCreateCar",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.Car_Update))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Works_Cars_EditCar,
    			    Image = "action-edit",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carsEditCar",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.Car_Delete))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Works_Cars_DeleteCar,
    			    Image = "action-delete",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "carsDeleteCar",
                });
            }
		    actions.Add(new WorkAction
            {
			    Title = ActionsResources.Works_Cars_RefreshCar,
			    Image = "action-refresh",
				ClassName = "default",
			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                ActionName = "carsRefreshCar",
            });
            return actions.Count != 0 ? actions.ToArray() : null;
        }

        
		private WorkActionItem[] GetServicesActions()
        {
		    var actions = new List<WorkActionItem>(4);
            if (Security.AuthorizeAll(DomainPermissions.CarService_Create))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Works_Services_CreateService,
    			    Image = "action-create-new",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "servicesCreateService",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.CarService_Update))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Works_Services_EditService,
    			    Image = "action-edit",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "servicesEditService",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.CarService_Delete))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Works_Services_DeleteService,
    			    Image = "action-delete",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "servicesDeleteService",
                });
            }
		    actions.Add(new WorkAction
            {
			    Title = ActionsResources.Works_Services_RefreshService,
			    Image = "action-refresh",
				ClassName = "default",
			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                ActionName = "servicesRefreshService",
            });
            return actions.Count != 0 ? actions.ToArray() : null;
        }

    }
}
