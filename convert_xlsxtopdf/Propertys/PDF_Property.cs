using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convert_xlsxtopdf
{
    class PDF_Property
    {
        public DateTime Dateforupload { get; set; }              
        public string EnPMupload { get; set; }
        public string PMNameupload { get; set; }
        public byte[] ChecklistFile { get; set; }
        public string Site { get; set; }
    }
}
