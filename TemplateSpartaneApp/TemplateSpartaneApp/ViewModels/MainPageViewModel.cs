using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Navigation;
using System;
using System.Diagnostics;
using TemplateSpartaneApp.ApiServices.Catalogs.ProgressReport;
using TemplateSpartaneApp.ApiServices.Catalogs.SpartaneUser;
using TemplateSpartaneApp.ApiServices.Catalogs.SpartanFile;
using TemplateSpartaneApp.Models.Catalogs;

namespace TemplateSpartaneApp.ViewModels
{
    public class MainPageViewModel : ViewModelAbstraction
    {

        #region Vars
        private static readonly string TAG = nameof(MainPageViewModel);
        private readonly ISpartaneFileService spartaneFileService;
        private readonly IProgressReportService progressReportService;
        private readonly ISpartaneUserService spartaneUserService;
        #endregion

        #region Constructor
        public MainPageViewModel(ISpartaneFileService spartaneFileService,
                                 IProgressReportService progressReportService,
                                 ISpartaneUserService spartaneUserService,
                                 INavigationService navigationService,
                                 IUserDialogs userDialogsService,
                                 IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            this.spartaneUserService = spartaneUserService;
            this.progressReportService = progressReportService;
            this.spartaneFileService = spartaneFileService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Example Login
        /// </summary>
        private async void ExmapleLoginUserSpartane()
        {
            var resultUser = await RunSafeApi(spartaneUserService.AuthUser("test", "test"));
            if(resultUser.Status == TypeReponse.Ok)
            {
                if(resultUser.Response.SpartanUsers != null && resultUser.Response.RowCount > 0)
                {
                    Debug.WriteLine("Success", TAG);
                }
                else
                {
                    Debug.WriteLine("User does not exist ", TAG);
                }
            }
            else
            {
                Debug.WriteLine("Error request", TAG);
            }
        }

        /// <summary>
        /// Example Crud
        /// </summary>
        private async void ExampleCRUD()
        {
            var item = new Models.Catalogs.ProgressReportModel { Description = "insert exmaple" };

            // Insert Example
            var resultInsert = await RunSafeApi(progressReportService.Post(item));
            if(resultInsert.Status == TypeReponse.Ok)
            {
                if(resultInsert.Response > 0)
                {
                    item.ReportId = resultInsert.Response;
                    Debug.WriteLine("Success", TAG);
                }
                else
                {
                    Debug.WriteLine("Error insert", TAG);
                }
            }
            else
            {
                Debug.WriteLine("Error request", TAG);
            }
            // Update Exmaple
            item.Description = "Update Exmaple";
            var resultUpdate = await RunSafeApi(progressReportService.Put(item.ReportId, item));
            if(resultUpdate.Status == TypeReponse.Ok)
            {
                if(resultUpdate.Response >= 0)
                {
                    Debug.WriteLine("Success", TAG);
                }
                else
                {
                    Debug.WriteLine("Error update", TAG);
                }
            }
            else
            {
                Debug.WriteLine("Error request", TAG);
            }
            // ListSell Example
            var resultListSell = await RunSafeApi(progressReportService.ListaSelAll());
            if(resultListSell.Status == TypeReponse.Ok)
            {
                if(resultListSell.Response.ProgressReports != null && resultListSell.Response.RowCount > 0)
                {
                    Debug.WriteLine("Success", TAG);
                }
                else
                {
                    Debug.WriteLine("No items", TAG);
                }
            }
            else
            {
                Debug.WriteLine("Error request", TAG);
            }
            // Delete Example
            var resultDelete = await RunSafeApi(progressReportService.Delete(item.ReportId));
            if(resultDelete.Status == TypeReponse.Ok)
            {
                if (resultDelete.Response)
                {
                    Debug.WriteLine("Success", TAG);
                }
                else
                {
                    Debug.WriteLine("Error delete", TAG);
                }
            }
            else
            {
                Debug.WriteLine("Error request", TAG);
            }
        }

        /// <summary>
        /// Example Spartane files
        /// </summary>
        private async void ExmapleSpartaneFile()
        {
            var item = new SpartaneFileModel
            {
                Date_Time = DateTime.Now,
                Description = "test.txt",
                File = new byte[] {12,13,45,34},
                User_Id = 1
            };

            //Example insert file
            var resultInsertFile = await RunSafeApi(spartaneFileService.Post(item));
            if(resultInsertFile.Status == TypeReponse.Ok)
            {
                if(resultInsertFile.Response > 0)
                {
                    item.File_Id = resultInsertFile.Response;
                    Debug.WriteLine("Success", TAG);
                }
                else
                {
                    Debug.WriteLine("Error insert file", TAG);
                }
            }
            else
            {
                Debug.WriteLine("Error request", TAG);
            }

            //Example Get file
            var resultGetFile = await RunSafeApi(spartaneFileService.Get(item.File_Id));
            if(resultGetFile.Status == TypeReponse.Ok)
            {
                if(resultGetFile.Response != null)
                {
                    item = resultGetFile.Response;
                    Debug.WriteLine("Success", TAG);
                }
                else
                {
                    Debug.WriteLine("Error get", TAG);
                }
            }
            else
            {
                Debug.WriteLine("Error request", TAG);
            }
        }
        #endregion

    }
}
