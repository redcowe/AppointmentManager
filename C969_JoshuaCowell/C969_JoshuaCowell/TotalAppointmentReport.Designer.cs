
namespace C969_JoshuaCowell
{
    partial class TotalAppointmentReport
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
            this.dgvTotalAppointmentReport = new System.Windows.Forms.DataGridView();
            this.Appointments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTotalAppointmentReportExit = new System.Windows.Forms.Button();
            this.btnTotalAppointmentReportRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalAppointmentReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTotalAppointmentReport
            // 
            this.dgvTotalAppointmentReport.AllowUserToAddRows = false;
            this.dgvTotalAppointmentReport.AllowUserToDeleteRows = false;
            this.dgvTotalAppointmentReport.AllowUserToResizeColumns = false;
            this.dgvTotalAppointmentReport.AllowUserToResizeRows = false;
            this.dgvTotalAppointmentReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTotalAppointmentReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTotalAppointmentReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotalAppointmentReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Appointments,
            this.Count});
            this.dgvTotalAppointmentReport.Location = new System.Drawing.Point(12, 12);
            this.dgvTotalAppointmentReport.MultiSelect = false;
            this.dgvTotalAppointmentReport.Name = "dgvTotalAppointmentReport";
            this.dgvTotalAppointmentReport.ReadOnly = true;
            this.dgvTotalAppointmentReport.RowHeadersVisible = false;
            this.dgvTotalAppointmentReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTotalAppointmentReport.Size = new System.Drawing.Size(177, 244);
            this.dgvTotalAppointmentReport.TabIndex = 0;
            // 
            // Appointments
            // 
            this.Appointments.HeaderText = "Appointments";
            this.Appointments.Name = "Appointments";
            this.Appointments.ReadOnly = true;
            // 
            // Count
            // 
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            // 
            // btnTotalAppointmentReportExit
            // 
            this.btnTotalAppointmentReportExit.Location = new System.Drawing.Point(195, 212);
            this.btnTotalAppointmentReportExit.Name = "btnTotalAppointmentReportExit";
            this.btnTotalAppointmentReportExit.Size = new System.Drawing.Size(167, 23);
            this.btnTotalAppointmentReportExit.TabIndex = 1;
            this.btnTotalAppointmentReportExit.Text = "Exit";
            this.btnTotalAppointmentReportExit.UseVisualStyleBackColor = true;
            this.btnTotalAppointmentReportExit.Click += new System.EventHandler(this.btnTotalAppointmentReportExit_Click);
            // 
            // btnTotalAppointmentReportRefresh
            // 
            this.btnTotalAppointmentReportRefresh.Location = new System.Drawing.Point(195, 172);
            this.btnTotalAppointmentReportRefresh.Name = "btnTotalAppointmentReportRefresh";
            this.btnTotalAppointmentReportRefresh.Size = new System.Drawing.Size(167, 23);
            this.btnTotalAppointmentReportRefresh.TabIndex = 2;
            this.btnTotalAppointmentReportRefresh.Text = "Refresh";
            this.btnTotalAppointmentReportRefresh.UseVisualStyleBackColor = true;
            this.btnTotalAppointmentReportRefresh.Click += new System.EventHandler(this.btnTotalAppointmentReportRefresh_Click);
            // 
            // TotalAppointmentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 268);
            this.Controls.Add(this.btnTotalAppointmentReportRefresh);
            this.Controls.Add(this.btnTotalAppointmentReportExit);
            this.Controls.Add(this.dgvTotalAppointmentReport);
            this.Name = "TotalAppointmentReport";
            this.Text = "Report";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalAppointmentReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTotalAppointmentReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Appointments;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.Button btnTotalAppointmentReportExit;
        private System.Windows.Forms.Button btnTotalAppointmentReportRefresh;
    }
}