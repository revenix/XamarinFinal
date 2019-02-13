using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;
using TemplateSpartaneApp.Models.Catalogs;
using TemplateSpartaneApp.Settings;

namespace TemplateSpartaneApp.ApiServices.Catalogs.SpartanFile
{
    public class SpartanFileService : ISpartaneFileService
    {

        private readonly ISpartaneFileService services;

        public SpartanFileService()
        {
            services = RestService.For<ISpartaneFileService>(new HttpClient(new HttpLoggingHandler(TokenManager.GetToken)) { BaseAddress = new Uri(AppConfiguration.Values.BaseUrl) }, new RefitSettings
            {
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CustomResolver()
                }
            });
        }

        public Task<SpartaneFileModel> Get(int id)
        {
            return services.Get(id);
        }

        public Task<int> Post([Body] SpartaneFileModel body)
        {
            return services.Post(body);
        }
    }
}
