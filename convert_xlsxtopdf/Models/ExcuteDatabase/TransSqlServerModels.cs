using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convert_xlsxtopdf.Models.ExcuteDatabase
{
    class TransSqlServerModels
    {
        private SqlConnection conTrans;
        private SqlCommand userCommand = new SqlCommand();
        private SqlTransaction trans;
        public string strConnection = "";
        private OutputOnDbProperty dataOutPut;


        protected TransSqlServerModels()
        {
            //strConnection = ConfigurationManager.ConnectionStrings["ConnectionStrSqlServer"].ConnectionString;          
            strConnection = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionStrSqlServer"]);
        }

        protected OutputOnDbProperty TransConnection()
        {
            try
            {
                conTrans = new SqlConnection(strConnection);
                conTrans.Open();
                trans = conTrans.BeginTransaction(IsolationLevel.ReadCommitted);     //*** Start  
                userCommand.Connection = conTrans;
                userCommand.Transaction = trans;  //*** Command & Transaction ***// 

                dataOutPut = new OutputOnDbProperty
                {
                    StatusOnDb = true,
                    MessageOnDb = "Connect Database Success",
                    ClassOnDb = "Class Name: TransSqlServerModels",
                    MethodOnDb = "Method Name: TransConnection",
                    ResultOnDb = null
                };
            }
            catch (Exception er)
            {
                dataOutPut = new OutputOnDbProperty
                {
                    StatusOnDb = false,
                    ClassOnDb = "Class Name: TransSqlServerModels",
                    MethodOnDb = "Method Name: TransConnection",
                    MessageOnDb = "Connect Database Error ==> " + er.ToString(),
                    ResultOnDb = null
                };
            }

            return dataOutPut;
        }

        protected OutputOnDbProperty TransSelectCommand(string sql)
        {
            SqlConnection connecter = new SqlConnection(strConnection);
            DataTable tableResult = new DataTable();

            try
            {
                connecter.Open();

                SqlDataAdapter userDataAdaptor = new SqlDataAdapter(sql, connecter);

                userDataAdaptor.Fill(tableResult);

                connecter.Close();
                connecter.Dispose();

                dataOutPut = new OutputOnDbProperty
                {
                    StatusOnDb = true,
                    ClassOnDb = "Class Name: TransSqlServerModels",
                    MethodOnDb = "Method Name: TransSelectCommand",
                    MessageOnDb = "",
                    ResultOnDb = tableResult
                };

            }
            catch (Exception er)
            {
                dataOutPut = new OutputOnDbProperty
                {
                    StatusOnDb = false,
                    ClassOnDb = "Class Name: TransSqlServerModels",
                    MethodOnDb = "Method Name: TransSelectCommand",
                    MessageOnDb = "Select SQL Error ==> " + er.ToString() + "==>>" + sql,
                    ResultOnDb = null
                };
            }

            return dataOutPut;
        }

        protected OutputOnDbProperty TransExecuteCommand(string sql)
        {
            try
            {
                userCommand.CommandText = sql;
                userCommand.CommandType = CommandType.Text;
                userCommand.ExecuteNonQuery();

                dataOutPut = new OutputOnDbProperty
                {
                    StatusOnDb = true,
                    ClassOnDb = "Class Name: TransSqlServerModels",
                    MethodOnDb = "Method Name: TransExecuteCommand",
                    MessageOnDb = "",
                    ResultOnDb = null
                };
            }
            catch (Exception er)
            {
                dataOutPut = new OutputOnDbProperty
                {
                    StatusOnDb = false,
                    ClassOnDb = "Class Name: TransSqlServerModels",
                    MethodOnDb = "Method Name: TransExecuteCommand",
                    MessageOnDb = "Execute SQL Command Error ==> " + er.ToString() + "==>>" + sql,
                    ResultOnDb = null
                };
            }

            return dataOutPut;
        }

        protected void TransCommit()
        {
            trans.Commit();
            conTrans.Close();
            conTrans.Dispose();
        }

        protected void TransRolback()
        {
            trans.Rollback();
            conTrans.Close();
            conTrans.Dispose();
        }

        protected void TransClose()
        {

            conTrans.Close();
            conTrans.Dispose();
        }

        protected string GetDBName()
        {
            string result = "";
            if (conTrans != null)
            {
                result = conTrans.DataSource;
            }
            return result;
        }
    }
}
