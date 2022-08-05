using System.Collections.Generic;
using System.Web.Http.Results;
using BusinessFramework.Contracts.GuiSettings.Actions;
using BusinessFramework.Contracts.GuiSettings.Fields;
using BusinessFramework.Contracts.GuiSettings.Json;
using BusinessFramework.Contracts.GuiSettings.MainMenu;
using BusinessFramework.Contracts.GuiSettings.Screens;
using BusinessFramework.WebAPI.Common.Request;
using BusinessFramework.WebAPI.Contracts.Security;
using BusinessFramework.WebAPI.GuiSettingsControllers;
using Karelia.Contracts;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Controllers.Properties;


namespace Karelia.WebAPI.Controllers.GuiSettings
{
    /// <summary>
    ///  Main menu gui settings controller
    /// </summary>
    public sealed class MainMenuSettingsController : GuiSettingsBaseApiController<DomainPermissions>
    {
	    /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="securityService"></param>
        public MainMenuSettingsController(IRequestStorageInitializer requestInitializer, ISecurityService securityService)
            : base(requestInitializer, securityService)
        {
        }

        /// <summary>
        /// Get settings for main menu
        /// </summary>
        /// <returns></returns>
        public JsonResult<MainMenuSettings> Get()
        {
            var result = new MainMenuSettings();
            var groups = new List<MainMenuScreenGroupSettings>(3);
            var screens = new List<MainMenuScreenSettings>();
			           
            #region CarPark
            if (Security.AuthorizeAll(DomainPermissions.CarModel_Read))
            {
                screens.Add(new MainMenuScreenSettings 
				            { 
							    Name = "CarModels",
								Title = ScreenResources.CarModels_DisplayName,
								Controller = "CarModelsSettings",
                                Hidden = false,
								Image = "CarModel"
							});
            }
            if (Security.AuthorizeAll(DomainPermissions.CarQuery_Read))
            {
                screens.Add(new MainMenuScreenSettings 
				            { 
							    Name = "Cars",
								Title = ScreenResources.Cars_DisplayName,
								Controller = "CarsSettings",
                                Hidden = false,
								Image = "Car"
							});
            }
            if (Security.AuthorizeAll(DomainPermissions.CarQuery_Read) || Security.AuthorizeAll(DomainPermissions.CarServiceQuery_Read))
            {
                screens.Add(new MainMenuScreenSettings 
				            { 
							    Name = "Works",
								Title = ScreenResources.Works_DisplayName,
								Controller = "WorksSettings",
                                Hidden = false,
								Image = "Car"
							});
            }
            if (screens.Count != 0)
            {
                groups.Add(new MainMenuScreenGroupSettings
                {
				    Name = "CarPark",
                    Title = ScreenGroupResources.CarPark_DisplayName,
                    Color = new byte[] {100, 149, 237},
                    Screens = screens.ToArray()
                });
            }
            screens.Clear();
            #endregion
            #region TaskManager
            if (Security.AuthorizeAll(DomainPermissions.MainTaskQuery_Read))
            {
                screens.Add(new MainMenuScreenSettings 
				            { 
							    Name = "Tasks",
								Title = ScreenResources.Tasks_DisplayName,
								Controller = "TasksSettings",
                                Hidden = false,
								Image = "MainTask"
							});
            }
            if (screens.Count != 0)
            {
                groups.Add(new MainMenuScreenGroupSettings
                {
				    Name = "TaskManager",
                    Title = ScreenGroupResources.TaskManager_DisplayName,
                    Color = new byte[] {100, 149, 237},
                    Screens = screens.ToArray()
                });
            }
            screens.Clear();
            #endregion
            #region Office
            if (Security.AuthorizeAll(DomainPermissions.OfficeEquipmentModel_Read))
            {
                screens.Add(new MainMenuScreenSettings 
				            { 
							    Name = "ModelEquipments",
								Title = ScreenResources.ModelEquipments_DisplayName,
								Controller = "ModelEquipmentsSettings",
                                Hidden = false,
								Image = "OfficeEquipmentModel"
							});
            }
            if (Security.AuthorizeAll(DomainPermissions.Office_Read))
            {
                screens.Add(new MainMenuScreenSettings 
				            { 
							    Name = "Office",
								Title = ScreenResources.Office_DisplayName,
								Controller = "OfficeSettings",
                                Hidden = false,
								Image = "Office"
							});
            }
            if (screens.Count != 0)
            {
                groups.Add(new MainMenuScreenGroupSettings
                {
				    Name = "Office",
                    Title = ScreenGroupResources.Office_DisplayName,
                    Color = new byte[] {100, 149, 237},
                    Screens = screens.ToArray()
                });
            }
            screens.Clear();
            #endregion
            result.Groups = groups.ToArray();

            return Json(result, GuiSettingsJsonSettings.WriteSettings);
        }

    }
}