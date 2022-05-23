
namespace C969_JoshuaCowell
{
    partial class MonthReportForm
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
            this.dgvMonthReport = new System.Windows.Forms.DataGridView();
            this.cmbReportMonths = new System.Windows.Forms.ComboBox();
            this.lblReportsMonths = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMonthReport
            // 
            this.dgvMonthReport.AllowUserToAddRows = false;
            this.dgvMonthReport.AllowUserToDeleteRows = false;
            this.dgvMonthReport.AllowUserToResizeColumns = false;
            this.dgvMonthReport.AllowUserToResizeRows = false;
            this.dgvMonthReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonthReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMonthReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonthReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Count});
            this.dgvMonthReport.Location = new System.Drawing.Point(12, 12);
            this.dgvMonthReport.MultiSelect = false;
            this.dgvMonthReport.Name = "dgvMonthReport";
            this.dgvMonthReport.ReadOnly = true;
            this.dgvMonthReport.RowHeadersVisible = false;
            this.dgvMonthReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonthReport.Size = new System.Drawing.Size(227, 250);
            this.dgvMonthReport.TabIndex = 0;
            // 
            // cmbReportMonths
            // 
            this.cmbReportMonths.FormattingEnabled = true;
            this.cmbReportMonths.Location = new System.Drawing.Point(361, 105);
            this.cmbReportMonths.Name = "cmbReportMonths";
            this.cmbReportMonths.Size = new System.Drawing.Size(121, 21);
            this.cmbReportMonths.TabIndex = 27;
            // 
            // lblReportsMonths
            // 
            this.lblReportsMonths.AutoSize = true;
            this.lblReportsMonths.Location = new System.Drawing.Point(260, 108);
            this.lblReportsMonths.Name = "lblReportsMonths";
            this.lblReportsMonths.Size = new System.Drawing.Size(37, 13);
            this.lblReportsMonths.TabIndex = 26;
            this.lblReportsMonths.Text = "Month";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(263, 239);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(219, 23);
            this.btnExit.TabIndex = 28;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(263, 190);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(219, 23);
            this.btnRefresh.TabIndex = 29;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Count
            // 
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            // 
            // MonthReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 276);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cmbReportMonths);
            this.Controls.Add(this.lblReportsMonths);
            this.Controls.Add(this.dgvMonthReport);
            this.Name = "MonthReportForm";
            this.Text = "Month Report";
            this.Load += new System.EventHandler(this.MonthReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMonthReport;
        private System.Windows.Forms.ComboBox cmbReportMonths;
        private System.Windows.Forms.Label lblReportsMonths;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
    }
}