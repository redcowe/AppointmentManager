
namespace C969_JoshuaCowell
{
    partial class ConsultantReport
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
            this.dgvConsultantSchedule = new System.Windows.Forms.DataGridView();
            this.btnConsultantReportRefresh = new System.Windows.Forms.Button();
            this.btnConsultantReportExit = new System.Windows.Forms.Button();
            this.lblConsultantReport = new System.Windows.Forms.Label();
            this.cmbUserID = new System.Windows.Forms.ComboBox();
            this.lblUserId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultantSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConsultantSchedule
            // 
            this.dgvConsultantSchedule.AllowUserToAddRows = false;
            this.dgvConsultantSchedule.AllowUserToDeleteRows = false;
            this.dgvConsultantSchedule.AllowUserToResizeColumns = false;
            this.dgvConsultantSchedule.AllowUserToResizeRows = false;
            this.dgvConsultantSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConsultantSchedule.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvConsultantSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultantSchedule.Location = new System.Drawing.Point(12, 55);
            this.dgvConsultantSchedule.MultiSelect = false;
            this.dgvConsultantSchedule.Name = "dgvConsultantSchedule";
            this.dgvConsultantSchedule.ReadOnly = true;
            this.dgvConsultantSchedule.RowHeadersVisible = false;
            this.dgvConsultantSchedule.Size = new System.Drawing.Size(555, 249);
            this.dgvConsultantSchedule.TabIndex = 0;
            // 
            // btnConsultantReportRefresh
            // 
            this.btnConsultantReportRefresh.Location = new System.Drawing.Point(12, 359);
            this.btnConsultantReportRefresh.Name = "btnConsultantReportRefresh";
            this.btnConsultantReportRefresh.Size = new System.Drawing.Size(235, 23);
            this.btnConsultantReportRefresh.TabIndex = 1;
            this.btnConsultantReportRefresh.Text = "Refresh";
            this.btnConsultantReportRefresh.UseVisualStyleBackColor = true;
            this.btnConsultantReportRefresh.Click += new System.EventHandler(this.btnConsultantReportRefresh_Click);
            // 
            // btnConsultantReportExit
            // 
            this.btnConsultantReportExit.Location = new System.Drawing.Point(332, 359);
            this.btnConsultantReportExit.Name = "btnConsultantReportExit";
            this.btnConsultantReportExit.Size = new System.Drawing.Size(235, 23);
            this.btnConsultantReportExit.TabIndex = 2;
            this.btnConsultantReportExit.Text = "Exit";
            this.btnConsultantReportExit.UseVisualStyleBackColor = true;
            this.btnConsultantReportExit.Click += new System.EventHandler(this.btnConsultantReportExit_Click);
            // 
            // lblConsultantReport
            // 
            this.lblConsultantReport.AutoSize = true;
            this.lblConsultantReport.Location = new System.Drawing.Point(12, 26);
            this.lblConsultantReport.Name = "lblConsultantReport";
            this.lblConsultantReport.Size = new System.Drawing.Size(52, 13);
            this.lblConsultantReport.TabIndex = 3;
            this.lblConsultantReport.Text = "Schedule";
            // 
            // cmbUserID
            // 
            this.cmbUserID.FormattingEnabled = true;
            this.cmbUserID.Location = new System.Drawing.Point(446, 28);
            this.cmbUserID.Name = "cmbUserID";
            this.cmbUserID.Size = new System.Drawing.Size(121, 21);
            this.cmbUserID.TabIndex = 4;
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(388, 31);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(43, 13);
            this.lblUserId.TabIndex = 5;
            this.lblUserId.Text = "User ID";
            // 
            // ConsultantReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 450);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.cmbUserID);
            this.Controls.Add(this.lblConsultantReport);
            this.Controls.Add(this.btnConsultantReportExit);
            this.Controls.Add(this.btnConsultantReportRefresh);
            this.Controls.Add(this.dgvConsultantSchedule);
            this.Name = "ConsultantReport";
            this.Text = "Consultant Report";
            this.Load += new System.EventHandler(this.ConsultantReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultantSchedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConsultantSchedule;
        private System.Windows.Forms.Button btnConsultantReportRefresh;
        private System.Windows.Forms.Button btnConsultantReportExit;
        private System.Windows.Forms.Label lblConsultantReport;
        private System.Windows.Forms.ComboBox cmbUserID;
        private System.Windows.Forms.Label lblUserId;
    }
}