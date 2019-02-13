using Refit;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.Catalogs;

namespace TemplateSpartaneApp.ApiServices.Catalogs.SpartanFile
{
    public interface ISpartaneFileService
    {
        [Get("/Spartan_File/Get?Id={Id}")]
        [Headers("Authorization: Bearer")]
        Task<SpartaneFileModel> Get(int id);

        [Post("/Spartan_File/Post")]
        [Headers("Authorization: Bearer")]
        Task<int> Post([Body] SpartaneFileModel body);
    }
}
