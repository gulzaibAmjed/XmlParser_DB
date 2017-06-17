using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser_DB.Globel_Classes.Basic_Data
{
    class DiagnosticAddress
    {
        public string id { get; set; }
        public int T42DiagnosticAddressId { get; set; }
        public string address { get; set; }
        public string name { get; set; }

        public string MasterRefs { get; set; }
    }
}
