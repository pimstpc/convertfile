using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace convert_xlsxtopdf.Models.ExcuteDatabase
{
    public class OutputOnDbProperty
    {
        public bool StatusOnDb { get; set; }
        public string ClassOnDb { get; set; }
        public string MethodOnDb { get; set; }
        public DataTable ResultOnDb { get; set; }
        public string MessageOnDb { get; set; }
        public string TotalCountOnDb { get; set; }
    }
}
