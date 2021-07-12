using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convert_xlsxtopdf.SQLFactory
{
    class PDF_SQL
    {
        string query = string.Empty;
        public string Search(PDF_Property dataitem)
        {
            query = "SELECT [TimeEntry],[EquipOpn],[EquipID],[SchType],[Category],[ChkListID],[UserIDDone],[UserIDVerify1],[UserIDVerify2],[ChkListData],[AttachFileName],[AttachFileBin],[SyncStatus],[UpdateTime],[CreateTime],[UserIDVerify3],[Serialnumber],[UserIDVerify4],[UserIDVerify5],[Status],[Status_UserIDVerify1],[Status_UserIDVerify2],[Status_UserIDVerify3],[Status_UserIDVerify4],[Status_UserIDVerify5],[DateforSentmali],[DateforDownload],[DateforUpload],[Version],[EnEEAddFile],[NameEEAddFile],[EnEEEditFile],[NameEEEditFile],[EnPMDownload],[PMNameDownload],[EnPMUpload],[PMNameUpload],[ChecklistFile],[Site],[Add_Number],[MachineType],[EquipModel] FROM[CIM_CONTROL_BACKUP].[dbo].[OEEMaintChkList] WHERE [Status] = 'DOWNLOAD' AND[EnPMDownload] = '394903' AND[PMNameDownload] = 'Warunya'AND[Site] = 'UTL1' AND[EquipOpn] = 'BACKGRIND' AND[EquipModel] = 'PG300RM' AND[MachineType] = 'Automotive' AND[SchType] = '48_WEEKLY'";
            return query;
        }
    }
}
