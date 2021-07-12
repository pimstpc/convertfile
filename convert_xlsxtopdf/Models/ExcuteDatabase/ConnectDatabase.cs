using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convert_xlsxtopdf.Models.ExcuteDatabase
{
    class ConnectDatabase
    {
        public void insert(byte[] bytes, PDF_Property dataItem)
        {
            try
            {
                string constr = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionStrSqlServer"]);
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "Update [CIM_CONTROL_BACKUP].[dbo].[OEEMaintChkList] SET [TimeEntry] = Getdate() , [ChecklistFile] = @Data WHERE [Status] = 'DOWNLOAD' AND[EnPMDownload] = '394903' AND[PMNameDownload] = 'Warunya'AND[Site] = 'UTL1' AND[EquipOpn] = 'BACKGRIND' AND[EquipModel] = 'PG300RM' AND[MachineType] = 'Automotive' AND[SchType] = '48_WEEKLY' ";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Data", bytes);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        
    }

}
