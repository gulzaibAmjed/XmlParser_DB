using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlParser_DB.Globel_Classes;
using System.Xml.Serialization;

namespace XmlParser_DB
{
    public enum MetaTags
    {
        MetaData,
        Schemaversion,
        SchemaType,
        CreationInfo,
        Tool,
        User,
        Name,
        Version
    }
    public enum MetaTagsAttribute
    {
        PersonRef,
    }
}
