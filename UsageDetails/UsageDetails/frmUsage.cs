﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsageDetails
{
    public partial class frmUsage : Form
    {
        public frmUsage()
        {
            InitializeComponent();
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmUsage_Load(object sender, EventArgs e)
        {
            getMonth();
            getYear();
            rdbSql.Checked = true;
        }

        //To Populate ComboBox cmbMonth
        public void getMonth()
        {
            DBFunctions s = new SQLFunctions();
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
            DBFunctions s = new SQLFunctions();
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
            dataGridView1.DataSource = name.Select(x => new { Value = x }).ToList();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string mon = cmbMonth.Text;
            int year = Convert.ToInt32(cmbYear.Text);
            int usage = Convert.ToInt32(txtUsage.Text);
            if (rdbSql.Checked == true)
            {
                DBFunctions s = new SQLFunctions();
                frmUsage f = new frmUsage();
                List<string> name = s.retrieveData(mon, year, usage);
                dataGridView1.DataSource = name.Select(x => new { Value = x }).ToList();
                GridView(name);
            }
            else
            {
                DBFunctions s = new LINQFunctions();
                frmUsage f = new frmUsage();
                List<string> name = s.retrieveData(mon, year, usage);
                GridView(name);
            }
        }
    }
}