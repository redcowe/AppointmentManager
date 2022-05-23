
namespace C969_JoshuaCowell
{
    partial class AddAppointment
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
            this.lblAddAppointmentType = new System.Windows.Forms.Label();
            this.lblAddAppointmentStartTime = new System.Windows.Forms.Label();
            this.lblAddAppointmentEndTime = new System.Windows.Forms.Label();
            this.lblAddAppointmentCustomerID = new System.Windows.Forms.Label();
            this.lblAddAppointmentUserID = new System.Windows.Forms.Label();
            this.btnAddAppointmentSave = new System.Windows.Forms.Button();
            this.btnAddAppointmentCancel = new System.Windows.Forms.Button();
            this.client_scheduleDataSet2 = new C969_JoshuaCowell.client_scheduleDataSet2();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerTableAdapter = new C969_JoshuaCowell.client_scheduleDataSet2TableAdapters.customerTableAdapter();
            this.client_scheduleDataSet3 = new C969_JoshuaCowell.client_scheduleDataSet3();
            this.txtAddAppointmentUserID = new System.Windows.Forms.TextBox();
            this.txtAddAppointmentCustomerID = new System.Windows.Forms.TextBox();
            this.lblAddAppointmentDate = new System.Windows.Forms.Label();
            this.txtAddAppointmentStartHours = new System.Windows.Forms.TextBox();
            this.txtAddAppointmentStartMinutes = new System.Windows.Forms.TextBox();
            this.txtAddAppointmentStartSeconds = new System.Windows.Forms.TextBox();
            this.txtAddAppointmentEndSeconds = new System.Windows.Forms.TextBox();
            this.txtAddAppointmentEndMinutes = new System.Windows.Forms.TextBox();
            this.txtAddAppointmentEndHours = new System.Windows.Forms.TextBox();
            this.txtAddCustomerDateDays = new System.Windows.Forms.TextBox();
            this.txtAddCustomerDateMonths = new System.Windows.Forms.TextBox();
            this.txtAddCustomerDateYears = new System.Windows.Forms.TextBox();
            this.txtAddAppointmentTitle = new System.Windows.Forms.TextBox();
            this.lblAddAppointmentTitle = new System.Windows.Forms.Label();
            this.cmbAddAppointmentType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.client_scheduleDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.client_scheduleDataSet3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAddAppointmentType
            // 
            this.lblAddAppointmentType.AutoSize = true;
            this.lblAddAppointmentType.Location = new System.Drawing.Point(38, 49);
            this.lblAddAppointmentType.Name = "lblAddAppointmentType";
            this.lblAddAppointmentType.Size = new System.Drawing.Size(31, 13);
            this.lblAddAppointmentType.TabIndex = 0;
            this.lblAddAppointmentType.Text = "Type";
            // 
            // lblAddAppointmentStartTime
            // 
            this.lblAddAppointmentStartTime.AutoSize = true;
            this.lblAddAppointmentStartTime.Location = new System.Drawing.Point(38, 124);
            this.lblAddAppointmentStartTime.Name = "lblAddAppointmentStartTime";
            this.lblAddAppointmentStartTime.Size = new System.Drawing.Size(29, 13);
            this.lblAddAppointmentStartTime.TabIndex = 2;
            this.lblAddAppointmentStartTime.Text = "Start";
            // 
            // lblAddAppointmentEndTime
            // 
            this.lblAddAppointmentEndTime.AutoSize = true;
            this.lblAddAppointmentEndTime.Location = new System.Drawing.Point(38, 164);
            this.lblAddAppointmentEndTime.Name = "lblAddAppointmentEndTime";
            this.lblAddAppointmentEndTime.Size = new System.Drawing.Size(26, 13);
            this.lblAddAppointmentEndTime.TabIndex = 5;
            this.lblAddAppointmentEndTime.Text = "End";
            // 
            // lblAddAppointmentCustomerID
            // 
            this.lblAddAppointmentCustomerID.AutoSize = true;
            this.lblAddAppointmentCustomerID.Location = new System.Drawing.Point(38, 246);
            this.lblAddAppointmentCustomerID.Name = "lblAddAppointmentCustomerID";
            this.lblAddAppointmentCustomerID.Size = new System.Drawing.Size(65, 13);
            this.lblAddAppointmentCustomerID.TabIndex = 8;
            this.lblAddAppointmentCustomerID.Text = "Customer ID";
            // 
            // lblAddAppointmentUserID
            // 
            this.lblAddAppointmentUserID.AutoSize = true;
            this.lblAddAppointmentUserID.Location = new System.Drawing.Point(38, 285);
            this.lblAddAppointmentUserID.Name = "lblAddAppointmentUserID";
            this.lblAddAppointmentUserID.Size = new System.Drawing.Size(43, 13);
            this.lblAddAppointmentUserID.TabIndex = 10;
            this.lblAddAppointmentUserID.Text = "User ID";
            // 
            // btnAddAppointmentSave
            // 
            this.btnAddAppointmentSave.Location = new System.Drawing.Point(56, 336);
            this.btnAddAppointmentSave.Name = "btnAddAppointmentSave";
            this.btnAddAppointmentSave.Size = new System.Drawing.Size(75, 23);
            this.btnAddAppointmentSave.TabIndex = 12;
            this.btnAddAppointmentSave.Text = "Save";
            this.btnAddAppointmentSave.UseVisualStyleBackColor = true;
            this.btnAddAppointmentSave.Click += new System.EventHandler(this.btnAddAppointmentSave_Click);
            // 
            // btnAddAppointmentCancel
            // 
            this.btnAddAppointmentCancel.Location = new System.Drawing.Point(198, 336);
            this.btnAddAppointmentCancel.Name = "btnAddAppointmentCancel";
            this.btnAddAppointmentCancel.Size = new System.Drawing.Size(75, 23);
            this.btnAddAppointmentCancel.TabIndex = 13;
            this.btnAddAppointmentCancel.Text = "Cancel";
            this.btnAddAppointmentCancel.UseVisualStyleBackColor = true;
            this.btnAddAppointmentCancel.Click += new System.EventHandler(this.btnAddAppointmentCancel_Click);
            // 
            // client_scheduleDataSet2
            // 
            this.client_scheduleDataSet2.DataSetName = "client_scheduleDataSet2";
            this.client_scheduleDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataMember = "customer";
            this.customerBindingSource.DataSource = this.client_scheduleDataSet2;
            // 
            // customerTableAdapter
            // 
            this.customerTableAdapter.ClearBeforeFill = true;
            // 
            // client_scheduleDataSet3
            // 
            this.client_scheduleDataSet3.DataSetName = "client_scheduleDataSet3";
            this.client_scheduleDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtAddAppointmentUserID
            // 
            this.txtAddAppointmentUserID.Location = new System.Drawing.Point(142, 285);
            this.txtAddAppointmentUserID.Name = "txtAddAppointmentUserID";
            this.txtAddAppointmentUserID.Size = new System.Drawing.Size(125, 20);
            this.txtAddAppointmentUserID.TabIndex = 14;
            // 
            // txtAddAppointmentCustomerID
            // 
            this.txtAddAppointmentCustomerID.Location = new System.Drawing.Point(142, 239);
            this.txtAddAppointmentCustomerID.Name = "txtAddAppointmentCustomerID";
            this.txtAddAppointmentCustomerID.Size = new System.Drawing.Size(125, 20);
            this.txtAddAppointmentCustomerID.TabIndex = 15;
            // 
            // lblAddAppointmentDate
            // 
            this.lblAddAppointmentDate.AutoSize = true;
            this.lblAddAppointmentDate.Location = new System.Drawing.Point(38, 202);
            this.lblAddAppointmentDate.Name = "lblAddAppointmentDate";
            this.lblAddAppointmentDate.Size = new System.Drawing.Size(30, 13);
            this.lblAddAppointmentDate.TabIndex = 22;
            this.lblAddAppointmentDate.Text = "Date";
            // 
            // txtAddAppointmentStartHours
            // 
            this.txtAddAppointmentStartHours.Location = new System.Drawing.Point(142, 121);
            this.txtAddAppointmentStartHours.Name = "txtAddAppointmentStartHours";
            this.txtAddAppointmentStartHours.Size = new System.Drawing.Size(30, 20);
            this.txtAddAppointmentStartHours.TabIndex = 27;
            this.txtAddAppointmentStartHours.Text = "HH";
            // 
            // txtAddAppointmentStartMinutes
            // 
            this.txtAddAppointmentStartMinutes.Location = new System.Drawing.Point(189, 121);
            this.txtAddAppointmentStartMinutes.Name = "txtAddAppointmentStartMinutes";
            this.txtAddAppointmentStartMinutes.Size = new System.Drawing.Size(30, 20);
            this.txtAddAppointmentStartMinutes.TabIndex = 28;
            this.txtAddAppointmentStartMinutes.Text = "MM";
            // 
            // txtAddAppointmentStartSeconds
            // 
            this.txtAddAppointmentStartSeconds.Location = new System.Drawing.Point(237, 121);
            this.txtAddAppointmentStartSeconds.Name = "txtAddAppointmentStartSeconds";
            this.txtAddAppointmentStartSeconds.Size = new System.Drawing.Size(30, 20);
            this.txtAddAppointmentStartSeconds.TabIndex = 29;
            this.txtAddAppointmentStartSeconds.Text = "SS";
            // 
            // txtAddAppointmentEndSeconds
            // 
            this.txtAddAppointmentEndSeconds.Location = new System.Drawing.Point(237, 164);
            this.txtAddAppointmentEndSeconds.Name = "txtAddAppointmentEndSeconds";
            this.txtAddAppointmentEndSeconds.Size = new System.Drawing.Size(30, 20);
            this.txtAddAppointmentEndSeconds.TabIndex = 32;
            this.txtAddAppointmentEndSeconds.Text = "SS";
            // 
            // txtAddAppointmentEndMinutes
            // 
            this.txtAddAppointmentEndMinutes.Location = new System.Drawing.Point(189, 164);
            this.txtAddAppointmentEndMinutes.Name = "txtAddAppointmentEndMinutes";
            this.txtAddAppointmentEndMinutes.Size = new System.Drawing.Size(30, 20);
            this.txtAddAppointmentEndMinutes.TabIndex = 31;
            this.txtAddAppointmentEndMinutes.Text = "MM";
            // 
            // txtAddAppointmentEndHours
            // 
            this.txtAddAppointmentEndHours.Location = new System.Drawing.Point(142, 164);
            this.txtAddAppointmentEndHours.Name = "txtAddAppointmentEndHours";
            this.txtAddAppointmentEndHours.Size = new System.Drawing.Size(30, 20);
            this.txtAddAppointmentEndHours.TabIndex = 30;
            this.txtAddAppointmentEndHours.Text = "HH";
            // 
            // txtAddCustomerDateDays
            // 
            this.txtAddCustomerDateDays.Location = new System.Drawing.Point(237, 202);
            this.txtAddCustomerDateDays.Name = "txtAddCustomerDateDays";
            this.txtAddCustomerDateDays.Size = new System.Drawing.Size(30, 20);
            this.txtAddCustomerDateDays.TabIndex = 35;
            this.txtAddCustomerDateDays.Text = "DD";
            // 
            // txtAddCustomerDateMonths
            // 
            this.txtAddCustomerDateMonths.Location = new System.Drawing.Point(189, 202);
            this.txtAddCustomerDateMonths.Name = "txtAddCustomerDateMonths";
            this.txtAddCustomerDateMonths.Size = new System.Drawing.Size(30, 20);
            this.txtAddCustomerDateMonths.TabIndex = 34;
            this.txtAddCustomerDateMonths.Text = "MM";
            // 
            // txtAddCustomerDateYears
            // 
            this.txtAddCustomerDateYears.Location = new System.Drawing.Point(142, 202);
            this.txtAddCustomerDateYears.Name = "txtAddCustomerDateYears";
            this.txtAddCustomerDateYears.Size = new System.Drawing.Size(37, 20);
            this.txtAddCustomerDateYears.TabIndex = 33;
            this.txtAddCustomerDateYears.Text = "YYYY";
            // 
            // txtAddAppointmentTitle
            // 
            this.txtAddAppointmentTitle.Location = new System.Drawing.Point(142, 85);
            this.txtAddAppointmentTitle.Name = "txtAddAppointmentTitle";
            this.txtAddAppointmentTitle.Size = new System.Drawing.Size(125, 20);
            this.txtAddAppointmentTitle.TabIndex = 36;
            // 
            // lblAddAppointmentTitle
            // 
            this.lblAddAppointmentTitle.AutoSize = true;
            this.lblAddAppointmentTitle.Location = new System.Drawing.Point(38, 92);
            this.lblAddAppointmentTitle.Name = "lblAddAppointmentTitle";
            this.lblAddAppointmentTitle.Size = new System.Drawing.Size(27, 13);
            this.lblAddAppointmentTitle.TabIndex = 37;
            this.lblAddAppointmentTitle.Text = "Title";
            // 
            // cmbAddAppointmentType
            // 
            this.cmbAddAppointmentType.FormattingEnabled = true;
            this.cmbAddAppointmentType.Location = new System.Drawing.Point(142, 41);
            this.cmbAddAppointmentType.Name = "cmbAddAppointmentType";
            this.cmbAddAppointmentType.Size = new System.Drawing.Size(121, 21);
            this.cmbAddAppointmentType.TabIndex = 38;
            // 
            // AddAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 386);
            this.Controls.Add(this.cmbAddAppointmentType);
            this.Controls.Add(this.lblAddAppointmentTitle);
            this.Controls.Add(this.txtAddAppointmentTitle);
            this.Controls.Add(this.txtAddCustomerDateDays);
            this.Controls.Add(this.txtAddCustomerDateMonths);
            this.Controls.Add(this.txtAddCustomerDateYears);
            this.Controls.Add(this.txtAddAppointmentEndSeconds);
            this.Controls.Add(this.txtAddAppointmentEndMinutes);
            this.Controls.Add(this.txtAddAppointmentEndHours);
            this.Controls.Add(this.txtAddAppointmentStartSeconds);
            this.Controls.Add(this.txtAddAppointmentStartMinutes);
            this.Controls.Add(this.txtAddAppointmentStartHours);
            this.Controls.Add(this.lblAddAppointmentDate);
            this.Controls.Add(this.txtAddAppointmentCustomerID);
            this.Controls.Add(this.txtAddAppointmentUserID);
            this.Controls.Add(this.btnAddAppointmentCancel);
            this.Controls.Add(this.btnAddAppointmentSave);
            this.Controls.Add(this.lblAddAppointmentUserID);
            this.Controls.Add(this.lblAddAppointmentCustomerID);
            this.Controls.Add(this.lblAddAppointmentEndTime);
            this.Controls.Add(this.lblAddAppointmentStartTime);
            this.Controls.Add(this.lblAddAppointmentType);
            this.Name = "AddAppointment";
            this.Text = "Add Appointment";
            this.Load += new System.EventHandler(this.AddAppointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.client_scheduleDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.client_scheduleDataSet3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddAppointmentType;
        private System.Windows.Forms.Label lblAddAppointmentStartTime;
        private System.Windows.Forms.Label lblAddAppointmentEndTime;
        private System.Windows.Forms.Label lblAddAppointmentCustomerID;
        private System.Windows.Forms.Label lblAddAppointmentUserID;
        private System.Windows.Forms.Button btnAddAppointmentSave;
        private System.Windows.Forms.Button btnAddAppointmentCancel;
        private client_scheduleDataSet2 client_scheduleDataSet2;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private client_scheduleDataSet2TableAdapters.customerTableAdapter customerTableAdapter;
        private client_scheduleDataSet3 client_scheduleDataSet3;
        private System.Windows.Forms.TextBox txtAddAppointmentUserID;
        private System.Windows.Forms.TextBox txtAddAppointmentCustomerID;
        private System.Windows.Forms.Label lblAddAppointmentDate;
        private System.Windows.Forms.TextBox txtAddAppointmentStartHours;
        private System.Windows.Forms.TextBox txtAddAppointmentStartMinutes;
        private System.Windows.Forms.TextBox txtAddAppointmentStartSeconds;
        private System.Windows.Forms.TextBox txtAddAppointmentEndSeconds;
        private System.Windows.Forms.TextBox txtAddAppointmentEndMinutes;
        private System.Windows.Forms.TextBox txtAddAppointmentEndHours;
        private System.Windows.Forms.TextBox txtAddCustomerDateDays;
        private System.Windows.Forms.TextBox txtAddCustomerDateMonths;
        private System.Windows.Forms.TextBox txtAddCustomerDateYears;
        private System.Windows.Forms.TextBox txtAddAppointmentTitle;
        private System.Windows.Forms.Label lblAddAppointmentTitle;
        private System.Windows.Forms.ComboBox cmbAddAppointmentType;
    }
}