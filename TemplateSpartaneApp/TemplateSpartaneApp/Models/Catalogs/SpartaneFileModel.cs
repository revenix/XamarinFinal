using System;
using System.Collections.Generic;

namespace TemplateSpartaneApp.Models.Catalogs
{
    public class SpartaneFileListModel
    {
        public List<SpartaneFileModel> Spartane_Files { get; set; }
        public int RowCount { get; set; }
    }

    public class SpartaneFileModel
    {
        public int File_Id { get; set; }
        public string Description { get; set; }
        public int? File1 { get; set; }
        public int? File_Size { get; set; }
        public int? Object { get; set; }
        public int? User_Id { get; set; }
        public DateTime? Date_Time { get; set; }
        public byte[] File { set; get; }
    }
}
