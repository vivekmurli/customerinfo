namespace UsageDetails
{
    partial class frmUsage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtUsage = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblUsage = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblQuery = new System.Windows.Forms.Label();
            this.rdbLinq = new System.Windows.Forms.RadioButton();
            this.rdbSql = new System.Windows.Forms.RadioButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnBrowse = new System.Windows.Forms.Button();
            this.dialogBrowse = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsage
            // 
            this.txtUsage.Location = new System.Drawing.Point(197, 143);
            this.txtUsage.Name = "txtUsage";
            this.txtUsage.Size = new System.Drawing.Size(121, 20);
            this.txtUsage.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(197, 326);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(134, 37);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(197, 85);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(121, 21);
            this.cmbMonth.TabIndex = 2;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(197, 196);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(121, 21);
            this.cmbYear.TabIndex = 3;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.Location = new System.Drawing.Point(77, 85);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(61, 23);
            this.lblMonth.TabIndex = 4;
            this.lblMonth.Text = "Month :";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(89, 192);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(49, 23);
            this.lblYear.TabIndex = 5;
            this.lblYear.Text = "Year :";
            // 
            // lblUsage
            // 
            this.lblUsage.AutoSize = true;
            this.lblUsage.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsage.Location = new System.Drawing.Point(81, 139);
            this.lblUsage.Name = "lblUsage";
            this.lblUsage.Size = new System.Drawing.Size(57, 23);
            this.lblUsage.TabIndex = 6;
            this.lblUsage.Text = "Usage :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(379, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(175, 284);
            this.dataGridView1.TabIndex = 7;
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuery.Location = new System.Drawing.Point(28, 246);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(110, 23);
            this.lblQuery.TabIndex = 8;
            this.lblQuery.Text = "Execute Using :";
            // 
            // rdbLinq
            // 
            this.rdbLinq.AutoSize = true;
            this.rdbLinq.Font = new System.Drawing.Font("Gill Sans MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLinq.Location = new System.Drawing.Point(197, 248);
            this.rdbLinq.Name = "rdbLinq";
            this.rdbLinq.Size = new System.Drawing.Size(54, 22);
            this.rdbLinq.TabIndex = 9;
            this.rdbLinq.TabStop = true;
            this.rdbLinq.Text = "LINQ";
            this.rdbLinq.UseVisualStyleBackColor = true;
            // 
            // rdbSql
            // 
            this.rdbSql.AutoSize = true;
            this.rdbSql.Font = new System.Drawing.Font("Gill Sans MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSql.Location = new System.Drawing.Point(270, 248);
            this.rdbSql.Name = "rdbSql";
            this.rdbSql.Size = new System.Drawing.Size(48, 22);
            this.rdbSql.TabIndex = 10;
            this.rdbSql.TabStop = true;
            this.rdbSql.Text = "SQL";
            this.rdbSql.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(32, 326);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(134, 37);
            this.btnBrowse.TabIndex = 11;
            this.btnBrowse.Text = "Browse Database";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // dialogBrowse
            // 
            this.dialogBrowse.FileName = "Browse Database";
            this.dialogBrowse.FileOk += new System.ComponentModel.CancelEventHandler(this.dialogBrowse_FileOk);
            // 
            // frmUsage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 423);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.rdbSql);
            this.Controls.Add(this.rdbLinq);
            this.Controls.Add(this.lblQuery);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblUsage);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtUsage);
            this.Name = "frmUsage";
            this.Text = "Water Usage Details";
            this.Load += new System.EventHandler(this.frmUsage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsage;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblUsage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblQuery;
        private System.Windows.Forms.RadioButton rdbLinq;
        private System.Windows.Forms.RadioButton rdbSql;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog dialogBrowse;
    }
}

