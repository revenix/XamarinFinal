using Refit;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.Catalogs;

namespace TemplateSpartaneApp.ApiServices.Catalogs.SpartaneUser
{
    public interface ISpartaneUserService
    {
        [Get("/Spartan_User/ListaSelAll?startRowIndex=1&maximumRows=1&Where=Username='{username}' COLLATE SQL_Latin1_General_CP1_CS_AS And Password='{password}' COLLATE SQL_Latin1_General_CP1_CS_AS")]
        [Headers("Authorization: Bearer")]
        Task<SpartanUserListModel> AuthUser(string username, string password);
    }
}
