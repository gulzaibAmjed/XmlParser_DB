using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser_DB.Globel_Classes.Basic_Data
{
    class VehicleProjects
    {
        public string id { get; set; }
       
        Brands brandRef { get; set; }
        public int T42VehicleProjectId { get; set; }
        public string name { get; set; }

        public string ProductKey { get; set; }
    }
}
