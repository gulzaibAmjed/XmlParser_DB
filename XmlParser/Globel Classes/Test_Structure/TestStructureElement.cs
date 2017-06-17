using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlParser_DB.Globel_Classes.Basic_Data;

namespace XmlParser_DB.Globel_Classes.Test_Structure
{
    class TestStructureElement
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string T42ElementId { get; set; }
        FunctionHierarchies ObjectRef { get; set; }
        public string TestResults{get; set;}
        public string Evaluations{get; set;}
        public string VDSEvaluation{get; set;}

    }
}

