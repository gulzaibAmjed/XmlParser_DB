using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser_DB.Globel_Classes.Basic_Data
{
    public class VPProductionSchedules
    {
        public string id { get; set; }
        VehicleProjects  VehicleProjectRef { get; set; }
        public string name { get; set; }
        public string FzgBlockId { get; set; }


    }
}
