using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using convert_xlsxtopdf.SQLFactory;
using convert_xlsxtopdf.Models.ExcuteDatabase;

namespace convert_xlsxtopdf.Models
{
   public class PDF_Model 
    {
        string query = string.Empty;
        PDF_SQL sql = new PDF_SQL();
        OutputOnDbProperty resultData = new OutputOnDbProperty();
        public OutputOnDbProperty Search (PDF_Property dataItem)
        {
            query = sql.Search(dataItem);
            resultData=base.SearchBySql(query);
            return resultData;
        }
    }
}
