using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlParser_DB.Globel_Classes.Basic_Data;

namespace XmlParser_DB.Globel_Classes.Header_Data
{
    public class TestJobDefinition
    {
        public double TestJobId { get; set; }
        public string TestJobName { get; set; }
        public string TestJobCreationDate { get; set; }
        public string VDSName { get; set; }
        public double VehicleConfigurationId { get; set; }


        public TestLocation TestLocationRef { get; set; }
        public VPProductionSchedules VPProductionScheduleRef { get; set; }
        public Person testJobCreator { get; set; }
        public TestJobDefinition()
        {
            testJobCreator = new Person();
            TestLocationRef = new TestLocation();
            VPProductionScheduleRef = new VPProductionSchedules();
        }
       
    }
}
