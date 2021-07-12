using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convert_xlsxtopdf.Models.ExcuteDatabase
{
   public class DatabaseEcuteSQLModels : TransSqlServerModels, IDisposable
    {
        OutputOnDbProperty resultData = new OutputOnDbProperty();

        protected OutputOnDbProperty SearchBySqlList(List<string> sqlList)
        {
            try
            {
                resultData = base.TransConnection();

                if (resultData.StatusOnDb == true)
                {
                    resultData = base.TransSelectCommand(sqlList[0]);

                    string totalCount = resultData.ResultOnDb.Rows[0]["TOTAL_COUNT"].ToString();

                    resultData = base.TransSelectCommand(sqlList[1]);

                    resultData.TotalCountOnDb = totalCount;
                }
            }
            finally
            {
                base.TransClose();
            }

            return resultData;
        }

        protected OutputOnDbProperty SearchBySql(string sql)
        {
            try
            {
                resultData = base.TransConnection();

                if (resultData.StatusOnDb == true)
                {
                    resultData = base.TransSelectCommand(sql);
                }
            }
            finally
            {
                base.TransClose();
            }

            return resultData;
        }
        public void Dispose()
        {
            try
            {
                base.TransClose();
            }
            finally
            {
                GC.SuppressFinalize(this);
            }

        }

    }
}
