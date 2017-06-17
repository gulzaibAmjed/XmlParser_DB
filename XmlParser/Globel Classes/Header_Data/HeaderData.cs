using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlParser_DB.Globel_Classes.Basic_Data;

namespace XmlParser_DB.Globel_Classes.Header_Data
{
    class HeaderData
    {

        public List<TestJobDefinition> testJobDefinition { get; set; }

        public HeaderData()
        {
            testJobDefinition = new List<TestJobDefinition>();
        }
    }
}
