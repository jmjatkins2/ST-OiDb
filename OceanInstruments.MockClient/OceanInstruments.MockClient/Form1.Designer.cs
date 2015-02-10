namespace OceanInstruments.MockClient
{
    partial class Form1
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
            this.btnGetCalibrationData = new System.Windows.Forms.Button();
            this.modelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvCalibrations = new System.Windows.Forms.DataGridView();
            this.cboModels = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSeialNo = new System.Windows.Forms.TextBox();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.btnGetDeviceData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFullDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnAddModel = new System.Windows.Forms.Button();
            this.dgvModels = new System.Windows.Forms.DataGridView();
            this.btnGetModelData = new System.Windows.Forms.Button();
            this.cboDevice = new System.Windows.Forms.ComboBox();
            this.deviceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLow = new System.Windows.Forms.TextBox();
            this.btnAddCalibration = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHigh = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTone = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRefLevel = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtDeviceSearch = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnUpdateModels = new System.Windows.Forms.Button();
            this.btnDeleteModel = new System.Windows.Forms.Button();
            this.cboUsername = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalibrations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetCalibrationData
            // 
            this.btnGetCalibrationData.Location = new System.Drawing.Point(548, 457);
            this.btnGetCalibrationData.Name = "btnGetCalibrationData";
            this.btnGetCalibrationData.Size = new System.Drawing.Size(110, 23);
            this.btnGetCalibrationData.TabIndex = 31;
            this.btnGetCalibrationData.Text = "Refresh Calibrations";
            this.btnGetCalibrationData.UseVisualStyleBackColor = true;
            this.btnGetCalibrationData.Click += new System.EventHandler(this.btnGetCalibrationData_Click);
            // 
            // dgvCalibrations
            // 
            this.dgvCalibrations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalibrations.Location = new System.Drawing.Point(16, 486);
            this.dgvCalibrations.Name = "dgvCalibrations";
            this.dgvCalibrations.Size = new System.Drawing.Size(642, 135);
            this.dgvCalibrations.TabIndex = 32;
            // 
            // cboModels
            // 
            this.cboModels.DataSource = this.modelBindingSource;
            this.cboModels.DisplayMember = "Code";
            this.cboModels.FormattingEnabled = true;
            this.cboModels.Location = new System.Drawing.Point(208, 428);
            this.cboModels.Name = "cboModels";
            this.cboModels.Size = new System.Drawing.Size(234, 21);
            this.cboModels.TabIndex = 30;
            this.cboModels.ValueMember = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 431);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Model:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 431);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "SerialNo:";
            // 
            // txtSeialNo
            // 
            this.txtSeialNo.Location = new System.Drawing.Point(73, 428);
            this.txtSeialNo.MaxLength = 50;
            this.txtSeialNo.Name = "txtSeialNo";
            this.txtSeialNo.Size = new System.Drawing.Size(85, 20);
            this.txtSeialNo.TabIndex = 27;
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.Location = new System.Drawing.Point(448, 426);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(210, 23);
            this.btnAddDevice.TabIndex = 26;
            this.btnAddDevice.Text = "Add Device";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // dgvDevices
            // 
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevices.Location = new System.Drawing.Point(16, 285);
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.Size = new System.Drawing.Size(642, 135);
            this.dgvDevices.TabIndex = 25;
            // 
            // btnGetDeviceData
            // 
            this.btnGetDeviceData.Location = new System.Drawing.Point(548, 256);
            this.btnGetDeviceData.Name = "btnGetDeviceData";
            this.btnGetDeviceData.Size = new System.Drawing.Size(110, 23);
            this.btnGetDeviceData.TabIndex = 24;
            this.btnGetDeviceData.Text = "Refresh Devices";
            this.btnGetDeviceData.UseVisualStyleBackColor = true;
            this.btnGetDeviceData.Click += new System.EventHandler(this.btnGetDeviceData_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Desc:";
            // 
            // txtFullDesc
            // 
            this.txtFullDesc.Location = new System.Drawing.Point(204, 196);
            this.txtFullDesc.MaxLength = 50;
            this.txtFullDesc.Name = "txtFullDesc";
            this.txtFullDesc.Size = new System.Drawing.Size(238, 20);
            this.txtFullDesc.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Code:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(54, 196);
            this.txtCode.MaxLength = 5;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 20;
            // 
            // btnAddModel
            // 
            this.btnAddModel.Location = new System.Drawing.Point(448, 194);
            this.btnAddModel.Name = "btnAddModel";
            this.btnAddModel.Size = new System.Drawing.Size(210, 23);
            this.btnAddModel.TabIndex = 19;
            this.btnAddModel.Text = "Add Model";
            this.btnAddModel.UseVisualStyleBackColor = true;
            this.btnAddModel.Click += new System.EventHandler(this.btnAddModel_Click);
            // 
            // dgvModels
            // 
            this.dgvModels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModels.Location = new System.Drawing.Point(12, 53);
            this.dgvModels.MultiSelect = false;
            this.dgvModels.Name = "dgvModels";
            this.dgvModels.Size = new System.Drawing.Size(642, 135);
            this.dgvModels.TabIndex = 18;
            // 
            // btnGetModelData
            // 
            this.btnGetModelData.Location = new System.Drawing.Point(544, 24);
            this.btnGetModelData.Name = "btnGetModelData";
            this.btnGetModelData.Size = new System.Drawing.Size(110, 23);
            this.btnGetModelData.TabIndex = 17;
            this.btnGetModelData.Text = "Refresh Models";
            this.btnGetModelData.UseVisualStyleBackColor = true;
            this.btnGetModelData.Click += new System.EventHandler(this.btnGetModelData_Click);
            // 
            // cboDevice
            // 
            this.cboDevice.DataSource = this.deviceBindingSource;
            this.cboDevice.DisplayMember = "SerialNo";
            this.cboDevice.FormattingEnabled = true;
            this.cboDevice.Location = new System.Drawing.Point(54, 625);
            this.cboDevice.Name = "cboDevice";
            this.cboDevice.Size = new System.Drawing.Size(234, 21);
            this.cboDevice.TabIndex = 37;
            this.cboDevice.ValueMember = "Id";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 628);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Device:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 655);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Low:";
            // 
            // txtLow
            // 
            this.txtLow.Location = new System.Drawing.Point(54, 652);
            this.txtLow.Name = "txtLow";
            this.txtLow.Size = new System.Drawing.Size(85, 20);
            this.txtLow.TabIndex = 34;
            // 
            // btnAddCalibration
            // 
            this.btnAddCalibration.Location = new System.Drawing.Point(448, 625);
            this.btnAddCalibration.Name = "btnAddCalibration";
            this.btnAddCalibration.Size = new System.Drawing.Size(206, 23);
            this.btnAddCalibration.TabIndex = 33;
            this.btnAddCalibration.Text = "Add Calibration";
            this.btnAddCalibration.UseVisualStyleBackColor = true;
            this.btnAddCalibration.Click += new System.EventHandler(this.btnAddCalibration_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(154, 655);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "High:";
            // 
            // txtHigh
            // 
            this.txtHigh.Location = new System.Drawing.Point(190, 652);
            this.txtHigh.Name = "txtHigh";
            this.txtHigh.Size = new System.Drawing.Size(85, 20);
            this.txtHigh.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(299, 655);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "Tone:";
            // 
            // txtTone
            // 
            this.txtTone.Location = new System.Drawing.Point(335, 652);
            this.txtTone.Name = "txtTone";
            this.txtTone.Size = new System.Drawing.Size(85, 20);
            this.txtTone.TabIndex = 40;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(433, 655);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "RefLevel:";
            // 
            // txtRefLevel
            // 
            this.txtRefLevel.Location = new System.Drawing.Point(486, 652);
            this.txtRefLevel.Name = "txtRefLevel";
            this.txtRefLevel.Size = new System.Drawing.Size(85, 20);
            this.txtRefLevel.TabIndex = 42;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(544, 1);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(110, 23);
            this.btnLogin.TabIndex = 44;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtDeviceSearch
            // 
            this.txtDeviceSearch.Location = new System.Drawing.Point(119, 259);
            this.txtDeviceSearch.Name = "txtDeviceSearch";
            this.txtDeviceSearch.Size = new System.Drawing.Size(301, 20);
            this.txtDeviceSearch.TabIndex = 45;
            this.txtDeviceSearch.TextChanged += new System.EventHandler(this.txtDeviceSearch_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 262);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "Search by Serial No";
            // 
            // btnUpdateModels
            // 
            this.btnUpdateModels.Location = new System.Drawing.Point(12, 222);
            this.btnUpdateModels.Name = "btnUpdateModels";
            this.btnUpdateModels.Size = new System.Drawing.Size(127, 23);
            this.btnUpdateModels.TabIndex = 47;
            this.btnUpdateModels.Text = "Update Models";
            this.btnUpdateModels.UseVisualStyleBackColor = true;
            this.btnUpdateModels.Click += new System.EventHandler(this.btnUpdateModels_Click);
            // 
            // btnDeleteModel
            // 
            this.btnDeleteModel.Location = new System.Drawing.Point(145, 222);
            this.btnDeleteModel.Name = "btnDeleteModel";
            this.btnDeleteModel.Size = new System.Drawing.Size(127, 23);
            this.btnDeleteModel.TabIndex = 48;
            this.btnDeleteModel.Text = "Delete Selected Model";
            this.btnDeleteModel.UseVisualStyleBackColor = true;
            this.btnDeleteModel.Click += new System.EventHandler(this.btnDeleteModel_Click);
            // 
            // cboUsername
            // 
            this.cboUsername.FormattingEnabled = true;
            this.cboUsername.Items.AddRange(new object[] {
            "g.atkins@massey.ac.nz",
            "goa_hb@hotmail.com"});
            this.cboUsername.Location = new System.Drawing.Point(76, 3);
            this.cboUsername.Name = "cboUsername";
            this.cboUsername.Size = new System.Drawing.Size(246, 21);
            this.cboUsername.TabIndex = 49;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(386, 3);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(152, 20);
            this.txtPassword.TabIndex = 50;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(328, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 51;
            this.label11.Text = "Password:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 52;
            this.label12.Text = "Username:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 684);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.cboUsername);
            this.Controls.Add(this.btnDeleteModel);
            this.Controls.Add(this.btnUpdateModels);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDeviceSearch);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRefLevel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTone);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtHigh);
            this.Controls.Add(this.cboDevice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLow);
            this.Controls.Add(this.btnAddCalibration);
            this.Controls.Add(this.btnGetCalibrationData);
            this.Controls.Add(this.dgvCalibrations);
            this.Controls.Add(this.cboModels);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSeialNo);
            this.Controls.Add(this.btnAddDevice);
            this.Controls.Add(this.dgvDevices);
            this.Controls.Add(this.btnGetDeviceData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFullDesc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.btnAddModel);
            this.Controls.Add(this.dgvModels);
            this.Controls.Add(this.btnGetModelData);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalibrations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetCalibrationData;
        private System.Windows.Forms.BindingSource modelBindingSource;
        private System.Windows.Forms.DataGridView dgvCalibrations;
        private System.Windows.Forms.ComboBox cboModels;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSeialNo;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.Button btnGetDeviceData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFullDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnAddModel;
        private System.Windows.Forms.DataGridView dgvModels;
        private System.Windows.Forms.Button btnGetModelData;
        private System.Windows.Forms.ComboBox cboDevice;
        private System.Windows.Forms.BindingSource deviceBindingSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLow;
        private System.Windows.Forms.Button btnAddCalibration;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHigh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRefLevel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtDeviceSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnUpdateModels;
        private System.Windows.Forms.Button btnDeleteModel;
        private System.Windows.Forms.ComboBox cboUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

