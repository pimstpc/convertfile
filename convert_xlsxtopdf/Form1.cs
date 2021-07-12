using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Pdf;
using Syncfusion.XlsIO;
using Syncfusion.ExcelToPdfConverter;
using convert_xlsxtopdf.Models.ExcuteDatabase;
using System.Data.SqlClient;
using System.Configuration;
using convert_xlsxtopdf.SQLFactory;
namespace convert_xlsxtopdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;
                IWorkbook workbook = application.Workbooks.Open("Sample.xlsx", ExcelOpenType.Automatic);
                //Open the Excel document to convert
                ExcelToPdfConverter converter = new ExcelToPdfConverter(workbook);
                //Initialize PDF document
                PdfDocument pdfDocument = new PdfDocument();
                //Convert Excel document into PDF document
                pdfDocument = converter.Convert();
                //Save the PDF file
                pdfDocument.Save("ExcelToPDF.pdf");
                //This will open the PDF file so, the result will be seen in default PDF viewer
                System.Diagnostics.Process.Start("ExcelToPDF.pdf");
            }
            string pdfFilePath = @"D:\App\convert_xlsxtopdf\convert_xlsxtopdf\bin\Debug\ExcelToPDF.pdf";
            byte[] bytes = System.IO.File.ReadAllBytes(pdfFilePath);
            PDF_Property PDF_Pro = new PDF_Property();
            PDF_Pro.EnPMupload = "800326";
            PDF_Pro.PMNameupload = "Sutthiporn";
            PDF_Pro.ChecklistFile = bytes;
            PDF_Pro.Site = "UTL1";            
            ConnectDatabase connectDB = new ConnectDatabase();
            connectDB.insert(bytes, PDF_Pro);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionStrSqlServer"]);
                int valor = 2;
                //  in it line of code is Of template 2XH
                using (SqlConnection cn = new SqlConnection(constr))
                {
                    string sPathToSaveFileTo = @"D:\App\convert_xlsxtopdf\convert_xlsxtopdf\bin\Debug\test.pdf";
                    string contenttype = String.Empty;
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.OEEMaintChkList", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", valor);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        // read in using GetValue and cast to byte array
                        byte[] fileData = (byte[])dr.GetValue(0);
                        // write bytes to disk as file
                        using (System.IO.FileStream fs = new System.IO.FileStream(sPathToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                        {
                            // use a binary writer to write the bytes to disk
                            using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                            {
                                bw.Write(fileData);
                                bw.Close();
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
    }


    }
    

