using System;
using System.Data;

using System.Windows.Forms;
using XmlParser_DB.Globel_Classes.Header_Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace XmlParser_DB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.button1.Location = new System.Drawing.Point(35, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Header Data";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(35, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Meta Data";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(35, 338);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(859, 150);
            this.dataGridView2.TabIndex = 3;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(35, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(796, 208);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_2);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private Button button1;
        private Button button2;

        private void button2_Click(object sender, EventArgs e)
        {
            //callProcedureData();
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();
            BindingClass bc = new BindingClass();
            string FILENAME = "TCM_Test.xml";
            bc.readXmlFile(FILENAME);
            MetaData mt =  bc.metaDataTag();
            
            dt.Columns.Add("Scheme Version", typeof(string));
            dt.Columns.Add("Schema Type", typeof(string));
            dt.Columns.Add("CreationDate", typeof(string));
            dt.Columns.Add("UserID", typeof(string));
            dt.Columns.Add("ToolCase Number", typeof(string));
            dt.Columns.Add("ToolCase Version", typeof(string));
            dr["Scheme Version"] = mt.Schemaversion;
            dr["Schema Type"] = mt.SchemaType;
            dr["CreationDate"] = Convert.ToDateTime(mt.CreationInfo.CreationDate);
            dr["UserID"] = mt.CreationInfo.User_ID;
            dr["ToolCase Number"] = mt.CreationInfo.Tool.name;
            dr["ToolCase Version"] = mt.CreationInfo.Tool.version;
           
            dt.Rows.Add(dr);
            dataGridView1.DataSource = dt;
            //dataGridView1.DataBind();
        }

        public DataSet callProcedureData()
        {
            DataSet ds = new DataSet();
            try
            {
                string ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;MultipleActiveResultSets=True";
                Database database = new SqlDatabase(ConnectionString);
                database.CreateConnection();
                DbCommand command = database.GetStoredProcCommand("Pro_Metadata");
                database.AddInParameter(command, "@Id", DbType.Int32, 3);
                database.AddInParameter(command, "@Version", DbType.String, "");
                database.AddInParameter(command, "@Type", DbType.String, "");
                ds = database.ExecuteDataSet(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable headdata = new DataTable();
            DataRow dr = headdata.NewRow();
            BindingClass bc = new BindingClass();
            string FILENAME = "TCM_Test.xml";
            bc.readXmlFile(FILENAME);
            TestJobDefinition tj = bc.HeaderDataTag();

            headdata.Columns.Add("TestLocationRef", typeof(string));
            headdata.Columns.Add("VPProductionScheduleRef", typeof(string));
            headdata.Columns.Add("TestJobIdType", typeof(string));
            headdata.Columns.Add("TestJobName", typeof(string));
            headdata.Columns.Add("TestJobCreationDate", typeof(string));
            headdata.Columns.Add("VDSName", typeof(string));
            headdata.Columns.Add("Test Job Creater PersonRef", typeof(string));
            headdata.Columns.Add("Vehicle Configuration Id", typeof(string));

            dr["TestLocationRef"] = tj.TestLocationRef.testLocationId;
            dr["VPProductionScheduleRef"] = tj.VPProductionScheduleRef.id;
            dr["TestJobIdType"] = tj.TestJobId;
            dr["TestJobName"] = tj.TestJobName;
            dr["TestJobCreationDate"] = Convert.ToDateTime(tj.TestJobCreationDate);
            dr["VDSName"] = tj.VDSName;
            
            dr["Test Job Creater PersonRef"] = tj.testJobCreator.Id;
            dr["Vehicle Configuration Id"] = tj.VehicleConfigurationId;
           


            headdata.Rows.Add(dr);
            dataGridView2.DataSource = headdata;
        }
            

             private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
             {

             }

             private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
             {

             }

             private DataGridView dataGridView2;

             private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
             {

             }
             private DataGridView dataGridView1;
         
        }


    }

