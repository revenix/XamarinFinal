using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.Catalogs;
using TemplateSpartaneApp.Settings;

namespace TemplateSpartaneApp.ApiServices.Catalogs.SessionService
{
    public class ClientService : IClienteService
    {
        private readonly IClienteService services;
        public ClientService(){

            services = RestService.For<IClienteService>(new HttpClient(new HttpLoggingHandler(TokenManager.GetToken)) { BaseAddress = new Uri(AppConfiguration.Values.BaseUrl) }, new RefitSettings
            {
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CustomResolver()
                }
            });

        }

        public Task<ClienteListModel> GetWhereClient(int startRowIndex = 0, int maximumRows = 100, string where = null, string order = null)
        {
            return services.GetWhereClient(startRowIndex , maximumRows  , where , order );
        }

       
    }
}
