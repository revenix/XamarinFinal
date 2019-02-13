using Refit;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.Catalogs;

namespace TemplateSpartaneApp.ApiServices.Catalogs.ProgressReport
{
    public interface IProgressReportService
    {
        [Get("/Progress_Report/Get")]
        [Headers("Authorization: Bearer")]
        Task<ProgressReportModel> Get(int id);

        [Get("/Progress_Report/GetAll")]
        [Headers("Authorization: Bearer")]
        Task<ProgressReportListModel> GetAll();

        [Get("/Progress_Report/ListaSelAll")]
        [Headers("Authorization: Bearer")]
        Task<ProgressReportListModel> ListaSelAll(int startRowIndex = 0, int maximumRows = 100, string where = null, string order = null);

        [Post("/Progress_Report/Post")]
        [Headers("Authorization: Bearer")]
        Task<int> Post([Body] ProgressReportModel item);

        [Put("/Progress_Report/Put")]
        [Headers("Authorization: Bearer")]
        Task<int> Put(int id, [Body] ProgressReportModel item);

        [Delete("/Progress_Report/Delete")]
        [Headers("Authorization: Bearer")]
        Task<bool> Delete(int id);
    }
}
