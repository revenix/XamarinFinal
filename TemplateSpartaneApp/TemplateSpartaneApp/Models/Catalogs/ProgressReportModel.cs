using Newtonsoft.Json;
using System.Collections.Generic;

namespace TemplateSpartaneApp.Models.Catalogs
{
    public partial class ProgressReportListModel
    {
        [JsonProperty("Progress_Reports")]
        public List<ProgressReportModel> ProgressReports { get; set; }

        [JsonProperty("RowCount")]
        public int RowCount { get; set; }
    }

    public partial class ProgressReportModel
    {
        [JsonProperty("ReportId")]
        public int ReportId { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }
    }
}
