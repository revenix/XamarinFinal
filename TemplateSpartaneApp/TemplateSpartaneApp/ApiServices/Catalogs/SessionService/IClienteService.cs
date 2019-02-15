using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.Catalogs;

namespace TemplateSpartaneApp.ApiServices.Catalogs.SessionService
{
    public interface IClienteService
    {
        [Get("/Cliente/listaSelAll")]
        [Headers("Authorization: Bearer")]
        Task<ClienteListModel> GetWhereClient(int startRowIndex = 0, int maximumRows = 100, string where = null, string order = null);





    }


}
