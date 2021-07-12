using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using convert_xlsxtopdf.Models.ExcuteDatabase;
using System.Data;
using convert_xlsxtopdf.Models;

namespace convert_xlsxtopdf.Controller
{
    class PDF_Controller
    {
        public List<PDF_Property> Search (PDF_Property dataItem)
        {
            List<PDF_Property> lResult = new List<PDF_Property>();
            OutputOnDbProperty dbProperty = new OutputOnDbProperty();
            PDF_Model model = new PDF_Model();
            DataTable tDt = new DataTable();
            dbProperty = model.Search(dataItem);
            tDt = dbProperty.ResultOnDb;
            if(tDt!=null)
            {
                foreach(DataRow dr in tDt.Rows)
                {
                    PDF_Property tempPro = new PDF_Property();
                    tempPro.ChecklistFile = (byte[])(dr["ChwcklistFile"]);
                    lResult.Add(tempPro);
                }
            }
            return lResult;
        }
    }
}
