using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using XmlParser_DB.Globel_Classes;

namespace XmlParser_DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ParsingDemo;Integrated Security=True;MultipleActiveResultSets=True")
        {
            Database.SetInitializer<AppDbContext>(null);
        }

        public DbSet<MetaData> MetaData { get; set; }
        public DbSet<CreationInfo> CreationInfo { get; set; }
        public DbSet<Tool> Tool { get; set; }
        public DbSet<Person> Person { get; set; }

    }
}
    