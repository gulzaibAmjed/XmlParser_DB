﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser_DB.Globel_Classes.Basic_Data
{
    class FunctionHierarchies
    {
        public string id { get; set; }
         VPProductionSchedules VPProductionScheduleRef { get; set; }
        public string name { get; set; }
        public DateTime createdate { get; set; }

    }
}
