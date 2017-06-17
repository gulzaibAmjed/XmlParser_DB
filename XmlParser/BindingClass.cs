using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using XmlParser_DB.Globel_Classes.Header_Data;
using XmlParser_DB.Globel_Classes;
using System.Xml.Serialization;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
using System.Data.SqlClient;

namespace XmlParser_DB
{
    public class BindingClass
    {
        static XmlDocument xmldoc = new XmlDocument();
        public BindingClass()
        {
            string FILENAME = "TCM_Test.xml";
            readXmlFile(FILENAME);
            var metadat = metaDataTag();

            using (var dbContext = new AppDbContext())
            {
                try
                {
                    ParsingDemoEntities entity = new ParsingDemoEntities();
                    Tool tool = new Tool();
                    MetaData metaDatas = new MetaData();
                    Person person = new Person();
                    CreationInfo creationInfo = new CreationInfo();
                    tool = metadat.CreationInfo.Tool;
                    person = metadat.CreationInfo.Person;
                    creationInfo = metadat.CreationInfo;
                    metaDatas = metadat;

                    entity.Tools.Add(tool);
                    entity.People.Add(person);
                    entity.CreationInfoes.Add(creationInfo);
                    entity.MetaDatas.Add(metaDatas);
                    entity.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    SqlException sqlException = (SqlException)updateException.InnerException;

                    foreach (SqlError error in sqlException.Errors)
                    {

                    }
                }

            }


        }

        public void readXmlFile(string FILENAME)
        {

            string xmlFile = File.ReadAllText(FILENAME);
            HeaderData headerdata = new HeaderData();
            xmldoc.LoadXml(xmlFile);
        }

        public MetaData metaDataTag()
        {
            MetaData metadata = new MetaData();
            XmlNodeList MetaDataList = xmldoc.GetElementsByTagName(MetaTags.MetaData.ToString());
            foreach (XmlNode MetaDataNode in MetaDataList)
            {
                metadata.Schemaversion = MetaDataNode.FirstChild.InnerText;
                metadata.SchemaType = MetaDataNode[MetaTags.SchemaType.ToString()].InnerText;

                XmlNodeList CreationInfoList = xmldoc.GetElementsByTagName(MetaTags.CreationInfo.ToString());
                foreach (XmlNode CreationInfoNode in CreationInfoList)
                {
                    //metadata.CreationInfo.CreationDate = CreationInfoNode.FirstChild.InnerText;
                    if (String.IsNullOrEmpty(CreationInfoNode[MetaTags.User.ToString()].InnerText))
                    {
                        metadata.CreationInfo.User_ID = (CreationInfoNode[MetaTags.User.ToString()].Attributes[MetaTagsAttribute.PersonRef.ToString()].Value).ToString();
                        metadata.CreationInfo.Person.Id = metadata.CreationInfo.User_ID;
                    }
                    else
                    {
                        metadata.CreationInfo.User_ID = null;
                        metadata.CreationInfo.Person.Id = null;
                    }

                    XmlNodeList ToolList = xmldoc.GetElementsByTagName(MetaTags.Tool.ToString());
                    foreach (XmlNode toolNode in ToolList)
                    {
                        metadata.CreationInfo.Tool.Id = 1;
                        metadata.CreationInfo.Tool.name = toolNode[MetaTags.Name.ToString()].InnerText;
                        metadata.CreationInfo.Tool.version = toolNode[MetaTags.Version.ToString()].InnerText;
                        metadata.CreationInfo.Tool_ID = metadata.CreationInfo.Tool.Id;
                    }
                }
            }
            return metadata;
        }

        public TestJobDefinition HeaderDataTag()
        {
            XmlNodeList headerData = xmldoc.GetElementsByTagName("HeaderData");
            foreach (XmlNode node in headerData)
            {
                TestJobDefinition testJobDefinition = new TestJobDefinition();
                foreach (XmlNode node_2 in node)
                {
                    testJobDefinition.TestJobId = Convert.ToDouble(node_2["TestJobId"].InnerText);
                    testJobDefinition.TestJobName = node_2["TestJobName"].InnerText;
                    testJobDefinition.TestJobCreationDate = node_2["TestJobCreationDate"].InnerText;
                    testJobDefinition.VDSName = node_2["VDSName"].InnerText;
                    testJobDefinition.VehicleConfigurationId = Convert.ToDouble(node_2["VehicleConfigurationId"].InnerText);

                    testJobDefinition.TestLocationRef.testLocationId = node_2.Attributes["TestLocationRef"].Value;
                    testJobDefinition.VPProductionScheduleRef.id = node_2.Attributes["VPProductionScheduleRef"].Value;
                    testJobDefinition.testJobCreator.Id = node_2["TestJobCreator"].Attributes["PersonRef"].Value;
                }
                return testJobDefinition;
            }
            return null;
        }

    }

    public class Camera
    {
        [XmlElement("CameraName")]
        public string MakeModel { get; set; }
        [XmlElement("CameraPrice")]
        public string Price { get; set; }
    }
}


