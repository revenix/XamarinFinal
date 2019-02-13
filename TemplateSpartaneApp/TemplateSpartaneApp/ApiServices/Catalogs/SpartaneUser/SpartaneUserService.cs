using Newtonsoft.Json;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.Catalogs;
using TemplateSpartaneApp.Settings;

namespace TemplateSpartaneApp.ApiServices.Catalogs.SpartaneUser
{
    public class SpartaneUserService : ISpartaneUserService
    {

        private readonly ISpartaneUserService services;

        public SpartaneUserService()
        {
            services = RestService.For<ISpartaneUserService>(new HttpClient(new HttpLoggingHandler(TokenManager.GetToken)) { BaseAddress = new Uri(AppConfiguration.Values.BaseUrl) }, new RefitSettings
            {
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CustomResolver()
                }
            });
        }

        public Task<SpartanUserListModel> AuthUser(string username, string password)
        {
            return services.AuthUser(username, HelperEncrypt.EncryptPassword(password));
        }
    }
}
