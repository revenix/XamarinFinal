using Newtonsoft.Json;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.Catalogs;
using TemplateSpartaneApp.Settings;

namespace TemplateSpartaneApp.ApiServices.Catalogs.ProgressReport
{
    public class ProgressReportService : IProgressReportService
    {

        private readonly IProgressReportService services;

        public ProgressReportService()
        {
            services = RestService.For<IProgressReportService>(new HttpClient(new HttpLoggingHandler(TokenManager.GetToken)) { BaseAddress = new Uri(AppConfiguration.Values.BaseUrl) }, new RefitSettings
            {
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CustomResolver()
                }
            });
        }

        public Task<bool> Delete(int id)
        {
            return services.Delete(id);
        }

        public Task<ProgressReportModel> Get(int id)
        {
            return services.Get(id);
        }

        public Task<ProgressReportListModel> GetAll()
        {
            return services.GetAll();
        }

        public Task<ProgressReportListModel> ListaSelAll(int startRowIndex = 0, int maximumRows = 100, string where = null, string order = null)
        {
            return services.ListaSelAll(startRowIndex, maximumRows, where, order);
        }

        public Task<int> Post([Body] ProgressReportModel item)
        {
            return services.Post(item);
        }

        public Task<int> Put(int id, [Body] ProgressReportModel item)
        {
            return services.Put(id, item);
        }
    }
}
