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
    ///  Office screen settings controller
    /// </summary>
    public sealed class OfficeSettingsController : GuiSettingsBaseApiController<DomainPermissions>
    {
	    /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="securityService"></param>
        public OfficeSettingsController(IRequestStorageInitializer requestInitializer, ISecurityService securityService)
            : base(requestInitializer, securityService)
        {
        }

        /// <summary>
        /// Get settings for 'Office' screen
        /// </summary>
        /// <returns></returns>		
        public IHttpActionResult Get()
        {            
            if (!(Security.AuthorizeAll(DomainPermissions.Office_Read)))
            {
                return GetInternalForbiddenResult();
            }

		    var context = new ScreenSettingsContext();
            var result = new Screen
            {
                Name = "office",
				Title = ScreenResources.Office_DisplayName,

                Content = GetScreenChildren(context)
            };

            return Json(result, GuiSettingsJsonSettings.WriteSettings);
        }
        
		private ScreenItem GetScreenChildren(ScreenSettingsContext context)
        {
		        var item = new SplitContainer 
                {
				    Name = "splitContainer5",
                    Orientation = SplitContainerOrientation.Vertical,
                    CollapsingPanel = SplitContainerPanel.Panel2,
                    FixedPanel = SplitContainerPanel.None,
                    PanelsRatio =0.5d,
                    Panel1 = GetSplitContainer5_Panel1Children(context),
		            Panel2 = GetSplitContainer5_Panel2Children(context),
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
        
		private ScreenItem GetSplitContainer5_Panel1Children(ScreenSettingsContext context)
        {
		        var item = new DataBlock 
                {
				    Name = "officeDataGrid",
                    Actions = GetOfficeDataGridActions(),
				    Controller = "Office",
				    Content = GetOfficeDataGridContent(context),
                };
				           
			    if (item.Content != null)
				{
				    return item;
				}
            return null;
	    
        }
		private DataBlockContent GetOfficeDataGridContent(ScreenSettingsContext context)
        {
		    
            if (!(Security.AuthorizeAll(DomainPermissions.Office_Read)))
            {
			    return null;
			}
            var fields = new List<GridDataBlockContentField>(1);            

            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "Adress", Key = DomainObjectPropertyKeys.Office.Adress, DataType = FieldDataType.String},
				Title = ScreenResources.Office_OfficeDataGrid_Adress,                
				Sortable = true,
				Width = 244.5,
			});

		    return new GridDataBlockContent
			{
			    HasQuickFilter = true,
			    PagingEnabled = true,
                ItemsOnPage = 100,
                Fields = fields.ToArray()

			};

        }
        
		private ScreenItem GetSplitContainer5_Panel2Children(ScreenSettingsContext context)
        {
		        var item = new TabLayout 
                {
				    Name = "orgTabs",
				    Children = GetOrgTabsChildren(context),
                };
				           
			    if (item.Children != null)
				{
				    return item;
				}
            return null;
	    
        }
        
		private ScreenItem[] GetOrgTabsChildren(ScreenSettingsContext context)
        {
		    var items = new List<ScreenItem>(2);

            #region OfficeEquipment
            {
		        var item = new Tab 
                {
				    Name = "officeEquipment",
				    Content = GetOfficeEquipmentChildren(context),
				    Title = ScreenResources.Office_OfficeEquipment,
                };
				           
			    if (item.Content != null)
				{
				    items.Add(item);
				}
            }
			#endregion
            #region Employees
            {
		        var item = new Tab 
                {
				    Name = "employees",
				    Content = GetEmployeesChildren(context),
				    Title = ScreenResources.Office_Employees,
                };
				           
			    if (item.Content != null)
				{
				    items.Add(item);
				}
            }
			#endregion
            return items.Count == 0 ? null : items.ToArray();
	    
        }
        
		private ScreenItem GetOfficeEquipmentChildren(ScreenSettingsContext context)
        {
		        var item = new DataBlock 
                {
				    Name = "officeEquipmentGridBlock",
                    Actions = GetOfficeEquipmentGridBlockActions(),
				    Controller = "OfficeEquipmentQuery",
				    Content = GetOfficeEquipmentGridBlockContent(context),
                    Depends = new[]
                    {
                        new DataBlockDepend {Parent = "officeDataGrid", ParentFields = new[] {"Id"}, Fields = new[] {"OfficeId"}},
                    },
                };
				           
			    if (item.Content != null)
				{
				    return item;
				}
            return null;
	    
        }
		private DataBlockContent GetOfficeEquipmentGridBlockContent(ScreenSettingsContext context)
        {
		    
            if (!(Security.AuthorizeAll(DomainPermissions.OfficeEquipmentQuery_Read) && Security.AuthorizeAll(DomainPermissions.Office_Read)))
            {
			    return null;
			}
            var fields = new List<GridDataBlockContentField>(5);            

            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "InventoryNumber", Key = DomainObjectPropertyKeys.OfficeEquipmentQuery.InventoryNumber, DataType = FieldDataType.String},
				Title = ScreenResources.Office_OfficeEquipmentGridBlock_InventoryNumber,                
				Sortable = true,
				Width = 126.5,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "OfficeEquipmentModel_Name", Key = DomainObjectPropertyKeys.OfficeEquipmentQuery.OfficeEquipmentModel_Name, DataType = FieldDataType.String},
				Title = ScreenResources.Office_OfficeEquipmentGridBlock_OfficeEquipmentModel_Name,                
				Sortable = true,
				Width = 151.2,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "PlacementDate", Key = DomainObjectPropertyKeys.OfficeEquipmentQuery.PlacementDate, DataType = FieldDataType.DateTime},
				Title = ScreenResources.Office_OfficeEquipmentGridBlock_PlacementDate,                
				Format = 2,
				Sortable = true,
				Width = 145.3,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "Quontity", Key = DomainObjectPropertyKeys.OfficeEquipmentQuery.Quontity, DataType = FieldDataType.Integer},
				Title = ScreenResources.Office_OfficeEquipmentGridBlock_Quontity,                
				Sortable = true,
				Width = 57.2,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "OfiiceEmployee_Name", Key = DomainObjectPropertyKeys.OfficeEquipmentQuery.OfiiceEmployee_Name, DataType = FieldDataType.String},
				Title = ScreenResources.Office_OfficeEquipmentGridBlock_OfiiceEmployee_Name,                
				Sortable = true,
				Width = 176.0,
			});

		    return new GridDataBlockContent
			{
			    HasQuickFilter = true,
			    PagingEnabled = true,
                ItemsOnPage = 100,
                Fields = fields.ToArray()

			};

        }
        
		private ScreenItem GetEmployeesChildren(ScreenSettingsContext context)
        {
		        var item = new DataBlock 
                {
				    Name = "officeEmployees",
                    Actions = GetOfficeEmployeesActions(),
				    Controller = "OfiiceEmployee",
				    Content = GetOfficeEmployeesContent(context),
                    Depends = new[]
                    {
                        new DataBlockDepend {Parent = "officeDataGrid", ParentFields = new[] {"Id"}, Fields = new[] {"OfficeId"}},
                    },
                };
				           
			    if (item.Content != null)
				{
				    return item;
				}
            return null;
	    
        }
		private DataBlockContent GetOfficeEmployeesContent(ScreenSettingsContext context)
        {
		    
            if (!(Security.AuthorizeAll(DomainPermissions.OfiiceEmployee_Read) && Security.AuthorizeAll(DomainPermissions.Office_Read)))
            {
			    return null;
			}
            var fields = new List<GridDataBlockContentField>(1);            

            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "Name", Key = DomainObjectPropertyKeys.OfiiceEmployee.Name, DataType = FieldDataType.String},
				Title = ScreenResources.Office_OfficeEmployees_Name,                
				Sortable = true,
				Width = 323.1,
			});

		    return new GridDataBlockContent
			{
			    HasQuickFilter = true,
			    PagingEnabled = true,
                ItemsOnPage = 100,
                Fields = fields.ToArray()

			};

        }
        
		private WorkActionItem[] GetOfficeDataGridActions()
        {
		    var actions = new List<WorkActionItem>(4);
            if (Security.AuthorizeAll(DomainPermissions.Office_Create))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Office_OfficeDataGrid_CreateAdress,
    			    Image = "action-create-new",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "officeDataGridCreateAdress",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.Office_Update))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Office_OfficeDataGrid_EditAdress,
    			    Image = "action-edit",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "officeDataGridEditAdress",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.Office_Delete))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Office_OfficeDataGrid_DeleteAdress,
    			    Image = "action-delete",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "officeDataGridDeleteAdress",
                });
            }
		    actions.Add(new WorkAction
            {
			    Title = ActionsResources.Office_OfficeDataGrid_RefreshAdress,
			    Image = "action-refresh",
				ClassName = "default",
			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                ActionName = "officeDataGridRefreshAdress",
            });
            return actions.Count != 0 ? actions.ToArray() : null;
        }

        
		private WorkActionItem[] GetOfficeEquipmentGridBlockActions()
        {
		    var actions = new List<WorkActionItem>(4);
            if (Security.AuthorizeAll(DomainPermissions.OfficeEquipment_Create))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Office_OfficeEquipmentGridBlock_CreateOfficeEquipment,
    			    Image = "action-create-new",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "officeEquipmentGridBlockCreateOfficeEquipment",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.OfficeEquipment_Update))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Office_OfficeEquipmentGridBlock_EditOfficeEquipment,
    			    Image = "action-edit",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "officeEquipmentGridBlockEditOfficeEquipment",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.OfficeEquipment_Delete))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Office_OfficeEquipmentGridBlock_DeleteOfficeEquipment,
    			    Image = "action-delete",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "officeEquipmentGridBlockDeleteOfficeEquipment",
                });
            }
		    actions.Add(new WorkAction
            {
			    Title = ActionsResources.Office_OfficeEquipmentGridBlock_RefreshOfficeEquipment,
			    Image = "action-refresh",
				ClassName = "default",
			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                ActionName = "officeEquipmentGridBlockRefreshOfficeEquipment",
            });
            return actions.Count != 0 ? actions.ToArray() : null;
        }

        
		private WorkActionItem[] GetOfficeEmployeesActions()
        {
		    var actions = new List<WorkActionItem>(4);
            if (Security.AuthorizeAll(DomainPermissions.OfiiceEmployee_Create))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Office_OfficeEmployees_CreateOfficeEmployee,
    			    Image = "action-create-new",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "officeEmployeesCreateOfficeEmployee",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.OfiiceEmployee_Update))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Office_OfficeEmployees_EditOfficeEmployee,
    			    Image = "action-edit",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "officeEmployeesEditOfficeEmployee",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.OfiiceEmployee_Delete))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Office_OfficeEmployees_DeleteOfficeEmployee,
    			    Image = "action-delete",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "officeEmployeesDeleteOfficeEmployee",
                });
            }
		    actions.Add(new WorkAction
            {
			    Title = ActionsResources.Office_OfficeEmployees_RefreshOfficeEmployee,
			    Image = "action-refresh",
				ClassName = "default",
			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                ActionName = "officeEmployeesRefreshOfficeEmployee",
            });
            return actions.Count != 0 ? actions.ToArray() : null;
        }

    }
}
