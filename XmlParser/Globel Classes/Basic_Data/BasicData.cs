using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace XmlParser_DB.Globel_Classes.Basic_Data
{
    class BasicData{
    
        List<Person> person {get; set;}

        List<TestLocation> testlocation { get; set; }
        List<Brands> brand { get; set; }
        List<VehicleProjects> vehicleProjects { get; set; }
        List<VPProductionSchedules> vpproductionSchedules{get; set;}
        
       
        List< DiagnosticAddress> diagonsticaddress{get; set;}
        List<FunctionHierarchies> functionHierarchies {get; set;}
        List<Document> document {get; set;}
    }


}
