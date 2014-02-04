using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.EntityClient;
using System.Data.SqlClient;

namespace UsageDetails
{
    public partial class frmUsage : Form
    {
        string path,linqpath,conStr;
        public frmUsage()
        {
            InitializeComponent();
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmUsage_Load(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false;
            txtUsage.Enabled = false;
            cmbMonth.Enabled = false;
            cmbYear.Enabled = false;
            rdbSql.Checked = true;
        }

        //To Populate ComboBox cmbMonth
        public void getMonth()
        {
           DBFunctions s = new SQLFunctions(path);
           List<string> month = s.cmbboxMonth();
           foreach (var y in month)
           {
                cmbMonth.DataSource = month;
                cmbMonth.DisplayMember = y;
           }            
        }

        //To Populate ComboBox cmbYear
        public void getYear()
        {
            DBFunctions s = new SQLFunctions(path);
            List<string> year = s.cmbboxYear();
            foreach (var y in year)
            {
                cmbYear.DataSource = year;
                cmbYear.DisplayMember = y;
            }
        }

        //To Populate DataGridView
        public void GridView(List<string> name)
        {
            dataGridView1.DataSource = name.Select(x => new { PersonName = x }).ToList();
        }

        public bool txtValidate(TextBox txt)
        {
            bool str = false;

            if (txt.Text != "")
            {
                str = true;
                foreach (char c in txtUsage.Text)
                {
                    if (char.IsLetter(c))
                    {
                        str = false;
                        return str;
                    }
                    return str;
                }
            }
            return str;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            bool result=txtValidate(this.txtUsage);

            if(result==false)
            {
                errorProvider1.SetError(txtUsage, "Please enter a valid number");
            }
            else
            {
                errorProvider1.Clear();
                string mon = cmbMonth.Text;
                int year = Convert.ToInt32(cmbYear.Text);
                int usage = Convert.ToInt32(txtUsage.Text);

                if (rdbSql.Checked == true)   //To Execute SQL
                {
                    DBFunctions s = new SQLFunctions(path);
                    frmUsage f = new frmUsage();
                    List<string> name = s.retrieveData(mon, year, usage);                    
                    GridView(name);
                }
                else                         //To Execute LINQ    
                {
                    DBFunctions s = new LINQFunctions(conStr);
                    frmUsage f = new frmUsage();
                    List<string> name = s.retrieveData(mon, year, usage);
                    GridView(name);
                }                
            }
        }

        //To Set Connection String for Entity (query using LINQ)
        public string setEntityPath(string path)
        {
            EntityConnectionStringBuilder conn = new EntityConnectionStringBuilder();
            conn.Metadata = @"res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl";
            conn.Provider = "System.Data.SQLite";
            conn.ProviderConnectionString = new SqlConnectionStringBuilder() { DataSource = linqpath }.ConnectionString;
            string str = conn.ConnectionString;
            //MessageBox.Show(conn.ConnectionString);
            return str;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            dialogBrowse.ShowDialog();
        }

        private void dialogBrowse_FileOk(object sender, CancelEventArgs e)
        {            
            path = @"Data Source="+dialogBrowse.FileName;
            linqpath = dialogBrowse.FileName;
            conStr = setEntityPath(linqpath); 
            getMonth();
            getYear();
            btnSubmit.Enabled = true;
            txtUsage.Enabled = true;
            cmbMonth.Enabled = true;
            cmbYear.Enabled =  true;
        }

    }
}
