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
    ///  Tasks screen settings controller
    /// </summary>
    public sealed class TasksSettingsController : GuiSettingsBaseApiController<DomainPermissions>
    {
	    /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="securityService"></param>
        public TasksSettingsController(IRequestStorageInitializer requestInitializer, ISecurityService securityService)
            : base(requestInitializer, securityService)
        {
        }

        /// <summary>
        /// Get settings for 'Tasks' screen
        /// </summary>
        /// <returns></returns>		
        public IHttpActionResult Get()
        {            
            if (!(Security.AuthorizeAll(DomainPermissions.MainTaskQuery_Read)))
            {
                return GetInternalForbiddenResult();
            }

		    var context = new ScreenSettingsContext();
            var result = new Screen
            {
                Name = "tasks",
				Title = ScreenResources.Tasks_DisplayName,

                Content = GetScreenChildren(context)
            };

            return Json(result, GuiSettingsJsonSettings.WriteSettings);
        }
        
		private ScreenItem GetScreenChildren(ScreenSettingsContext context)
        {
		        var item = new SplitContainer 
                {
				    Name = "splitContainer2",
                    Orientation = SplitContainerOrientation.Vertical,
                    CollapsingPanel = SplitContainerPanel.Panel2,
                    FixedPanel = SplitContainerPanel.None,
                    PanelsRatio =0.5d,
                    Panel1 = GetSplitContainer2_Panel1Children(context),
		            Panel2 = GetSplitContainer2_Panel2Children(context),
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
        
		private ScreenItem GetSplitContainer2_Panel1Children(ScreenSettingsContext context)
        {
		        var item = new DataBlock 
                {
				    Name = "mainTaskGrid",
                    Actions = GetMainTaskGridActions(),
				    Controller = "MainTaskQuery",
				    Content = GetMainTaskGridContent(context),
                };
				           
			    if (item.Content != null)
				{
				    return item;
				}
            return null;
	    
        }
		private DataBlockContent GetMainTaskGridContent(ScreenSettingsContext context)
        {
		    
            if (!(Security.AuthorizeAll(DomainPermissions.MainTaskQuery_Read)))
            {
			    return null;
			}
            var fields = new List<GridDataBlockContentField>(5);            

            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "IsCompleted", Key = DomainObjectPropertyKeys.MainTaskQuery.IsCompleted, DataType = FieldDataType.Bool},
				Title = ScreenResources.Tasks_MainTaskGrid_IsCompleted,                
				Sortable = true,
				Width = 75.1,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "Name", Key = DomainObjectPropertyKeys.MainTaskQuery.Name, DataType = FieldDataType.String},
				Title = ScreenResources.Tasks_MainTaskGrid_Name,                
				Sortable = true,
				Width = 216.9,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "CreationDate", Key = DomainObjectPropertyKeys.MainTaskQuery.CreationDate, DataType = FieldDataType.DateTime},
				Title = ScreenResources.Tasks_MainTaskGrid_CreationDate,                
				Format = 2,
				Sortable = true,
				Width = 105.5,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "EndDate", Key = DomainObjectPropertyKeys.MainTaskQuery.EndDate, DataType = FieldDataType.DateTime},
				Title = ScreenResources.Tasks_MainTaskGrid_EndDate,                
				Format = 2,
				Sortable = true,
				Width = 118.0,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "Employee_Name", Key = DomainObjectPropertyKeys.MainTaskQuery.Employee_Name, DataType = FieldDataType.String},
				Title = ScreenResources.Tasks_MainTaskGrid_Employee_Name,                
				Sortable = true,
				Width = 155.3,
			});

		    return new GridDataBlockContent
			{
			    HasQuickFilter = true,
			    PagingEnabled = true,
                ItemsOnPage = 100,
                Fields = fields.ToArray()

			};

        }
        
		private ScreenItem GetSplitContainer2_Panel2Children(ScreenSettingsContext context)
        {
		        var item = new DataBlock 
                {
				    Name = "subTaskGrid",
                    Actions = GetSubTaskGridActions(),
				    Controller = "SubTaskQuery",
				    Content = GetSubTaskGridContent(context),
                    Depends = new[]
                    {
                        new DataBlockDepend {Parent = "mainTaskGrid", ParentFields = new[] {"Id"}, Fields = new[] {"TaskId"}},
                    },
                };
				           
			    if (item.Content != null)
				{
				    return item;
				}
            return null;
	    
        }
		private DataBlockContent GetSubTaskGridContent(ScreenSettingsContext context)
        {
		    
            if (!(Security.AuthorizeAll(DomainPermissions.SubTaskQuery_Read) && Security.AuthorizeAll(DomainPermissions.MainTaskQuery_Read)))
            {
			    return null;
			}
            var fields = new List<GridDataBlockContentField>(2);            

            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "Sequence", Key = DomainObjectPropertyKeys.SubTaskQuery.Sequence, DataType = FieldDataType.Integer},
				Title = ScreenResources.Tasks_SubTaskGrid_Sequence,                
				Sortable = true,
				Width = 59.5,
			});
            fields.Add(new GridDataBlockContentField
			{
			    Field = new Field {Name = "Name", Key = DomainObjectPropertyKeys.SubTaskQuery.Name, DataType = FieldDataType.String},
				Title = ScreenResources.Tasks_SubTaskGrid_Name,                
				Sortable = true,
				Width = 337.5,
			});

		    return new GridDataBlockContent
			{
			    HasQuickFilter = true,
			    PagingEnabled = true,
                ItemsOnPage = 100,
                Fields = fields.ToArray()

			};

        }
        
		private WorkActionItem[] GetMainTaskGridActions()
        {
		    var actions = new List<WorkActionItem>(4);
            if (Security.AuthorizeAll(DomainPermissions.MainTask_Create))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Tasks_MainTaskGrid_CreateMainTask,
    			    Image = "action-create-new",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "mainTaskGridCreateMainTask",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.MainTask_Update))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Tasks_MainTaskGrid_EditMainTask,
    			    Image = "action-edit",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "mainTaskGridEditMainTask",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.MainTask_Delete))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Tasks_MainTaskGrid_DeleteMainTask,
    			    Image = "action-delete",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "mainTaskGridDeleteMainTask",
                });
            }
		    actions.Add(new WorkAction
            {
			    Title = ActionsResources.Tasks_MainTaskGrid_RefreshMainTask,
			    Image = "action-refresh",
				ClassName = "default",
			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                ActionName = "mainTaskGridRefreshMainTask",
            });
            return actions.Count != 0 ? actions.ToArray() : null;
        }

        
		private WorkActionItem[] GetSubTaskGridActions()
        {
		    var actions = new List<WorkActionItem>(4);
            if (Security.AuthorizeAll(DomainPermissions.SubTask_Create))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Tasks_SubTaskGrid_CreateSubTask,
    			    Image = "action-create-new",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "subTaskGridCreateSubTask",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.SubTask_Update))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Tasks_SubTaskGrid_EditSubTask,
    			    Image = "action-edit",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "subTaskGridEditSubTask",
                });
            }
            if (Security.AuthorizeAll(DomainPermissions.SubTask_Delete))
		    {
    		    actions.Add(new WorkAction
                {
    			    Title = ActionsResources.Tasks_SubTaskGrid_DeleteSubTask,
    			    Image = "action-delete",
    				ClassName = "default",
    			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
    			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                    ActionName = "subTaskGridDeleteSubTask",
                });
            }
		    actions.Add(new WorkAction
            {
			    Title = ActionsResources.Tasks_SubTaskGrid_RefreshSubTask,
			    Image = "action-refresh",
				ClassName = "default",
			    Position = WorkActionPosition.None | WorkActionPosition.Context | WorkActionPosition.Toolbar,
			    ToolbarAlligement = WorkActionToolbarAlligement.Left,
                ActionName = "subTaskGridRefreshSubTask",
            });
            return actions.Count != 0 ? actions.ToArray() : null;
        }

    }
}
