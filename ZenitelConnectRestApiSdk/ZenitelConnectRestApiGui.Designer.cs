
namespace Zenitel.Connect.RestApi.Sdk
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gbxAuthentication = new System.Windows.Forms.GroupBox();
            this.chbxUnencrypted = new System.Windows.Forms.CheckBox();
            this.chbxEncrypted = new System.Windows.Forms.CheckBox();
            this.edtWampRealm = new System.Windows.Forms.TextBox();
            this.labWampRealm = new System.Windows.Forms.Label();
            this.labEncryption = new System.Windows.Forms.Label();
            this.blConnectionStatus = new System.Windows.Forms.Label();
            this.tbxConnectionStatus = new System.Windows.Forms.TextBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.labRestApiServerAddress = new System.Windows.Forms.Label();
            this.edtConnectServerAddr = new System.Windows.Forms.TextBox();
            this.labUserName = new System.Windows.Forms.Label();
            this.edtUserName = new System.Windows.Forms.TextBox();
            this.labPassword = new System.Windows.Forms.Label();
            this.edtPassword = new System.Windows.Forms.TextBox();
            this.gbxLogging = new System.Windows.Forms.GroupBox();
            this.lblLogFileSavingLocation = new System.Windows.Forms.Label();
            this.cbxSaveLoggingToFile = new System.Windows.Forms.CheckBox();
            this.btnClearLoggingWindow = new System.Windows.Forms.Button();
            this.btnCloseLoggingWindow = new System.Windows.Forms.Button();
            this.btnOpenLoggingWindow = new System.Windows.Forms.Button();
            this.gbxSwaggerSystem = new System.Windows.Forms.GroupBox();
            this.btnGETNetInterface = new System.Windows.Forms.Button();
            this.btnGETDeviceAccounts = new System.Windows.Forms.Button();
            this.gbxCallControl = new System.Windows.Forms.GroupBox();
            this.grpbxPOSTCalls = new System.Windows.Forms.GroupBox();
            this.btnPOSTCalls = new System.Windows.Forms.Button();
            this.cmbxCallAction = new System.Windows.Forms.ComboBox();
            this.lblASubscriber = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.tbxASubscriber = new System.Windows.Forms.TextBox();
            this.lblBSubscriber = new System.Windows.Forms.Label();
            this.tbxBSubscriber = new System.Windows.Forms.TextBox();
            this.btnPOSTcallId = new System.Windows.Forms.Button();
            this.btnGETCalls = new System.Windows.Forms.Button();
            this.btnDELETECallId = new System.Windows.Forms.Button();
            this.btnDELETECalls = new System.Windows.Forms.Button();
            this.gbxDevice = new System.Windows.Forms.GroupBox();
            this.btnPOSTDeviceGPO = new System.Windows.Forms.Button();
            this.tbxGPIDevice = new System.Windows.Forms.TextBox();
            this.lblGPIDevice = new System.Windows.Forms.Label();
            this.tbxGPODevice = new System.Windows.Forms.TextBox();
            this.lblGPODevice = new System.Windows.Forms.Label();
            this.btnGETDeviceGPIOs = new System.Windows.Forms.Button();
            this.btnGETDeviceGPOs = new System.Windows.Forms.Button();
            this.grbEvent = new System.Windows.Forms.GroupBox();
            this.cbxOpenDoorEvent = new System.Windows.Forms.CheckBox();
            this.cbxDeviceGPIStatusEvent = new System.Windows.Forms.CheckBox();
            this.cbxDeviceGPOStatusEvent = new System.Windows.Forms.CheckBox();
            this.cbxCallStatusEvent = new System.Windows.Forms.CheckBox();
            this.cbxDeviceRegistrationEvent = new System.Windows.Forms.CheckBox();
            this.cbxCallLegStatusEvent = new System.Windows.Forms.CheckBox();
            this.grpbxRegistratedDevices = new System.Windows.Forms.GroupBox();
            this.btnClearList = new System.Windows.Forms.Button();
            this.dgrd_Registrations = new System.Windows.Forms.DataGridView();
            this.dgrdDirNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgrdLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgrdState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxNetInterfaces = new System.Windows.Forms.GroupBox();
            this.btnClearNetInterfaces = new System.Windows.Forms.Button();
            this.dgrdNetInterfaces = new System.Windows.Forms.DataGridView();
            this.NetMACaddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxActiveCalls = new System.Windows.Forms.GroupBox();
            this.dgrdActiveCalls = new System.Windows.Forms.DataGridView();
            this.gbxQueuedCalls = new System.Windows.Forms.GroupBox();
            this.dgrdQueuedCalls = new System.Windows.Forms.DataGridView();
            this.btnGETCallLegs = new System.Windows.Forms.Button();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CallState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CallId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxAuthentication.SuspendLayout();
            this.gbxLogging.SuspendLayout();
            this.gbxSwaggerSystem.SuspendLayout();
            this.gbxCallControl.SuspendLayout();
            this.grpbxPOSTCalls.SuspendLayout();
            this.gbxDevice.SuspendLayout();
            this.grbEvent.SuspendLayout();
            this.grpbxRegistratedDevices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrd_Registrations)).BeginInit();
            this.gbxNetInterfaces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdNetInterfaces)).BeginInit();
            this.gbxActiveCalls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdActiveCalls)).BeginInit();
            this.gbxQueuedCalls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdQueuedCalls)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxAuthentication
            // 
            this.gbxAuthentication.Controls.Add(this.chbxUnencrypted);
            this.gbxAuthentication.Controls.Add(this.chbxEncrypted);
            this.gbxAuthentication.Controls.Add(this.edtWampRealm);
            this.gbxAuthentication.Controls.Add(this.labWampRealm);
            this.gbxAuthentication.Controls.Add(this.labEncryption);
            this.gbxAuthentication.Controls.Add(this.blConnectionStatus);
            this.gbxAuthentication.Controls.Add(this.tbxConnectionStatus);
            this.gbxAuthentication.Controls.Add(this.btnDisconnect);
            this.gbxAuthentication.Controls.Add(this.btnConnect);
            this.gbxAuthentication.Controls.Add(this.labRestApiServerAddress);
            this.gbxAuthentication.Controls.Add(this.edtConnectServerAddr);
            this.gbxAuthentication.Controls.Add(this.labUserName);
            this.gbxAuthentication.Controls.Add(this.edtUserName);
            this.gbxAuthentication.Controls.Add(this.labPassword);
            this.gbxAuthentication.Controls.Add(this.edtPassword);
            this.gbxAuthentication.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAuthentication.Location = new System.Drawing.Point(18, 12);
            this.gbxAuthentication.Name = "gbxAuthentication";
            this.gbxAuthentication.Size = new System.Drawing.Size(1026, 150);
            this.gbxAuthentication.TabIndex = 39;
            this.gbxAuthentication.TabStop = false;
            this.gbxAuthentication.Text = "Authentication";
            // 
            // chbxUnencrypted
            // 
            this.chbxUnencrypted.AutoSize = true;
            this.chbxUnencrypted.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxUnencrypted.Location = new System.Drawing.Point(551, 77);
            this.chbxUnencrypted.Margin = new System.Windows.Forms.Padding(2);
            this.chbxUnencrypted.Name = "chbxUnencrypted";
            this.chbxUnencrypted.Size = new System.Drawing.Size(206, 21);
            this.chbxUnencrypted.TabIndex = 29;
            this.chbxUnencrypted.Text = "Unencrypted (Port 80/8087)";
            this.chbxUnencrypted.UseVisualStyleBackColor = true;
            this.chbxUnencrypted.CheckedChanged += new System.EventHandler(this.chbxUnencrypted_CheckedChanged);
            // 
            // chbxEncrypted
            // 
            this.chbxEncrypted.AutoSize = true;
            this.chbxEncrypted.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxEncrypted.Location = new System.Drawing.Point(551, 52);
            this.chbxEncrypted.Margin = new System.Windows.Forms.Padding(2);
            this.chbxEncrypted.Name = "chbxEncrypted";
            this.chbxEncrypted.Size = new System.Drawing.Size(198, 21);
            this.chbxEncrypted.TabIndex = 28;
            this.chbxEncrypted.Text = "Encrypted (Port 443/8086)";
            this.chbxEncrypted.UseVisualStyleBackColor = true;
            this.chbxEncrypted.CheckedChanged += new System.EventHandler(this.chbxEncrypted_CheckedChanged);
            // 
            // edtWampRealm
            // 
            this.edtWampRealm.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtWampRealm.Location = new System.Drawing.Point(418, 61);
            this.edtWampRealm.Name = "edtWampRealm";
            this.edtWampRealm.Size = new System.Drawing.Size(110, 23);
            this.edtWampRealm.TabIndex = 19;
            this.edtWampRealm.Text = "zenitel";
            // 
            // labWampRealm
            // 
            this.labWampRealm.AutoSize = true;
            this.labWampRealm.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labWampRealm.Location = new System.Drawing.Point(417, 45);
            this.labWampRealm.Name = "labWampRealm";
            this.labWampRealm.Size = new System.Drawing.Size(76, 14);
            this.labWampRealm.TabIndex = 18;
            this.labWampRealm.Text = "WAMP realm";
            // 
            // labEncryption
            // 
            this.labEncryption.AutoSize = true;
            this.labEncryption.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEncryption.Location = new System.Drawing.Point(548, 36);
            this.labEncryption.Name = "labEncryption";
            this.labEncryption.Size = new System.Drawing.Size(119, 14);
            this.labEncryption.TabIndex = 16;
            this.labEncryption.Text = "Encryption Selection";
            // 
            // blConnectionStatus
            // 
            this.blConnectionStatus.AutoSize = true;
            this.blConnectionStatus.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blConnectionStatus.Location = new System.Drawing.Point(776, 45);
            this.blConnectionStatus.Name = "blConnectionStatus";
            this.blConnectionStatus.Size = new System.Drawing.Size(108, 14);
            this.blConnectionStatus.TabIndex = 14;
            this.blConnectionStatus.Text = "Connection Status";
            // 
            // tbxConnectionStatus
            // 
            this.tbxConnectionStatus.Enabled = false;
            this.tbxConnectionStatus.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxConnectionStatus.Location = new System.Drawing.Point(780, 62);
            this.tbxConnectionStatus.Name = "tbxConnectionStatus";
            this.tbxConnectionStatus.Size = new System.Drawing.Size(110, 23);
            this.tbxConnectionStatus.TabIndex = 15;
            this.tbxConnectionStatus.Text = "Disconnected";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.Location = new System.Drawing.Point(913, 82);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(98, 46);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnWampDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnConnect.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(911, 26);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 46);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnWampConnect_Click);
            // 
            // labRestApiServerAddress
            // 
            this.labRestApiServerAddress.AutoSize = true;
            this.labRestApiServerAddress.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRestApiServerAddress.Location = new System.Drawing.Point(10, 45);
            this.labRestApiServerAddress.Name = "labRestApiServerAddress";
            this.labRestApiServerAddress.Size = new System.Drawing.Size(146, 14);
            this.labRestApiServerAddress.TabIndex = 3;
            this.labRestApiServerAddress.Text = "REST API Server Address";
            // 
            // edtConnectServerAddr
            // 
            this.edtConnectServerAddr.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtConnectServerAddr.Location = new System.Drawing.Point(10, 61);
            this.edtConnectServerAddr.Name = "edtConnectServerAddr";
            this.edtConnectServerAddr.Size = new System.Drawing.Size(124, 23);
            this.edtConnectServerAddr.TabIndex = 4;
            this.edtConnectServerAddr.Text = "169.254.1.5";
            // 
            // labUserName
            // 
            this.labUserName.AutoSize = true;
            this.labUserName.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUserName.Location = new System.Drawing.Point(163, 45);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(67, 14);
            this.labUserName.TabIndex = 5;
            this.labUserName.Text = "User Name";
            // 
            // edtUserName
            // 
            this.edtUserName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtUserName.Location = new System.Drawing.Point(166, 61);
            this.edtUserName.Name = "edtUserName";
            this.edtUserName.Size = new System.Drawing.Size(110, 23);
            this.edtUserName.TabIndex = 6;
            // 
            // labPassword
            // 
            this.labPassword.AutoSize = true;
            this.labPassword.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPassword.Location = new System.Drawing.Point(298, 45);
            this.labPassword.Name = "labPassword";
            this.labPassword.Size = new System.Drawing.Size(63, 14);
            this.labPassword.TabIndex = 7;
            this.labPassword.Text = "Password";
            // 
            // edtPassword
            // 
            this.edtPassword.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtPassword.Location = new System.Drawing.Point(290, 61);
            this.edtPassword.Name = "edtPassword";
            this.edtPassword.Size = new System.Drawing.Size(110, 23);
            this.edtPassword.TabIndex = 8;
            this.edtPassword.UseSystemPasswordChar = true;
            // 
            // gbxLogging
            // 
            this.gbxLogging.Controls.Add(this.lblLogFileSavingLocation);
            this.gbxLogging.Controls.Add(this.cbxSaveLoggingToFile);
            this.gbxLogging.Controls.Add(this.btnClearLoggingWindow);
            this.gbxLogging.Controls.Add(this.btnCloseLoggingWindow);
            this.gbxLogging.Controls.Add(this.btnOpenLoggingWindow);
            this.gbxLogging.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxLogging.Location = new System.Drawing.Point(1064, 12);
            this.gbxLogging.Margin = new System.Windows.Forms.Padding(2);
            this.gbxLogging.Name = "gbxLogging";
            this.gbxLogging.Padding = new System.Windows.Forms.Padding(2);
            this.gbxLogging.Size = new System.Drawing.Size(360, 150);
            this.gbxLogging.TabIndex = 43;
            this.gbxLogging.TabStop = false;
            this.gbxLogging.Text = "Logging";
            // 
            // lblLogFileSavingLocation
            // 
            this.lblLogFileSavingLocation.AutoSize = true;
            this.lblLogFileSavingLocation.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogFileSavingLocation.Location = new System.Drawing.Point(20, 46);
            this.lblLogFileSavingLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLogFileSavingLocation.Name = "lblLogFileSavingLocation";
            this.lblLogFileSavingLocation.Size = new System.Drawing.Size(35, 14);
            this.lblLogFileSavingLocation.TabIndex = 27;
            this.lblLogFileSavingLocation.Text = "label1";
            // 
            // cbxSaveLoggingToFile
            // 
            this.cbxSaveLoggingToFile.AutoSize = true;
            this.cbxSaveLoggingToFile.Location = new System.Drawing.Point(23, 24);
            this.cbxSaveLoggingToFile.Margin = new System.Windows.Forms.Padding(2);
            this.cbxSaveLoggingToFile.Name = "cbxSaveLoggingToFile";
            this.cbxSaveLoggingToFile.Size = new System.Drawing.Size(171, 20);
            this.cbxSaveLoggingToFile.TabIndex = 26;
            this.cbxSaveLoggingToFile.Text = "Save Logging to File";
            this.cbxSaveLoggingToFile.UseVisualStyleBackColor = true;
            this.cbxSaveLoggingToFile.CheckedChanged += new System.EventHandler(this.cbxSaveLoggingToFile_CheckedChanged);
            // 
            // btnClearLoggingWindow
            // 
            this.btnClearLoggingWindow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearLoggingWindow.Location = new System.Drawing.Point(243, 74);
            this.btnClearLoggingWindow.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearLoggingWindow.Name = "btnClearLoggingWindow";
            this.btnClearLoggingWindow.Size = new System.Drawing.Size(100, 54);
            this.btnClearLoggingWindow.TabIndex = 25;
            this.btnClearLoggingWindow.Text = "Clear\r\nLogging Window";
            this.btnClearLoggingWindow.UseVisualStyleBackColor = true;
            this.btnClearLoggingWindow.Click += new System.EventHandler(this.btnClearLoggingWindow_Click);
            // 
            // btnCloseLoggingWindow
            // 
            this.btnCloseLoggingWindow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseLoggingWindow.Location = new System.Drawing.Point(130, 74);
            this.btnCloseLoggingWindow.Margin = new System.Windows.Forms.Padding(2);
            this.btnCloseLoggingWindow.Name = "btnCloseLoggingWindow";
            this.btnCloseLoggingWindow.Size = new System.Drawing.Size(100, 54);
            this.btnCloseLoggingWindow.TabIndex = 24;
            this.btnCloseLoggingWindow.Text = "Close\r\nLogging Window";
            this.btnCloseLoggingWindow.UseVisualStyleBackColor = true;
            this.btnCloseLoggingWindow.Click += new System.EventHandler(this.btnCloseLoggingWindow_Click);
            // 
            // btnOpenLoggingWindow
            // 
            this.btnOpenLoggingWindow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenLoggingWindow.Location = new System.Drawing.Point(16, 74);
            this.btnOpenLoggingWindow.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenLoggingWindow.Name = "btnOpenLoggingWindow";
            this.btnOpenLoggingWindow.Size = new System.Drawing.Size(100, 54);
            this.btnOpenLoggingWindow.TabIndex = 23;
            this.btnOpenLoggingWindow.Text = "Open\r\nLogging Window";
            this.btnOpenLoggingWindow.UseVisualStyleBackColor = true;
            this.btnOpenLoggingWindow.Click += new System.EventHandler(this.btnOpenLoggingWindow_Click);
            // 
            // gbxSwaggerSystem
            // 
            this.gbxSwaggerSystem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gbxSwaggerSystem.Controls.Add(this.btnGETNetInterface);
            this.gbxSwaggerSystem.Controls.Add(this.btnGETDeviceAccounts);
            this.gbxSwaggerSystem.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxSwaggerSystem.Location = new System.Drawing.Point(18, 181);
            this.gbxSwaggerSystem.Margin = new System.Windows.Forms.Padding(2);
            this.gbxSwaggerSystem.Name = "gbxSwaggerSystem";
            this.gbxSwaggerSystem.Padding = new System.Windows.Forms.Padding(2);
            this.gbxSwaggerSystem.Size = new System.Drawing.Size(154, 323);
            this.gbxSwaggerSystem.TabIndex = 44;
            this.gbxSwaggerSystem.TabStop = false;
            this.gbxSwaggerSystem.Text = "System";
            // 
            // btnGETNetInterface
            // 
            this.btnGETNetInterface.Location = new System.Drawing.Point(20, 104);
            this.btnGETNetInterface.Name = "btnGETNetInterface";
            this.btnGETNetInterface.Size = new System.Drawing.Size(110, 63);
            this.btnGETNetInterface.TabIndex = 3;
            this.btnGETNetInterface.Text = "GET\r\n Net Interfaces";
            this.btnGETNetInterface.UseVisualStyleBackColor = true;
            this.btnGETNetInterface.Click += new System.EventHandler(this.btnGETNetInterface_Click);
            // 
            // btnGETDeviceAccounts
            // 
            this.btnGETDeviceAccounts.Location = new System.Drawing.Point(20, 28);
            this.btnGETDeviceAccounts.Name = "btnGETDeviceAccounts";
            this.btnGETDeviceAccounts.Size = new System.Drawing.Size(110, 63);
            this.btnGETDeviceAccounts.TabIndex = 2;
            this.btnGETDeviceAccounts.Text = "GET \r\nDevice Accounts";
            this.btnGETDeviceAccounts.UseVisualStyleBackColor = true;
            this.btnGETDeviceAccounts.Click += new System.EventHandler(this.btnGETDeviceAccounts_Click);
            // 
            // gbxCallControl
            // 
            this.gbxCallControl.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gbxCallControl.Controls.Add(this.label1);
            this.gbxCallControl.Controls.Add(this.btnGETCallLegs);
            this.gbxCallControl.Controls.Add(this.grpbxPOSTCalls);
            this.gbxCallControl.Controls.Add(this.btnPOSTcallId);
            this.gbxCallControl.Controls.Add(this.btnGETCalls);
            this.gbxCallControl.Controls.Add(this.btnDELETECallId);
            this.gbxCallControl.Controls.Add(this.btnDELETECalls);
            this.gbxCallControl.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCallControl.Location = new System.Drawing.Point(193, 183);
            this.gbxCallControl.Margin = new System.Windows.Forms.Padding(2);
            this.gbxCallControl.Name = "gbxCallControl";
            this.gbxCallControl.Padding = new System.Windows.Forms.Padding(2);
            this.gbxCallControl.Size = new System.Drawing.Size(582, 321);
            this.gbxCallControl.TabIndex = 45;
            this.gbxCallControl.TabStop = false;
            this.gbxCallControl.Text = "Call Handling";
            // 
            // grpbxPOSTCalls
            // 
            this.grpbxPOSTCalls.Controls.Add(this.btnPOSTCalls);
            this.grpbxPOSTCalls.Controls.Add(this.cmbxCallAction);
            this.grpbxPOSTCalls.Controls.Add(this.lblASubscriber);
            this.grpbxPOSTCalls.Controls.Add(this.lblAction);
            this.grpbxPOSTCalls.Controls.Add(this.tbxASubscriber);
            this.grpbxPOSTCalls.Controls.Add(this.lblBSubscriber);
            this.grpbxPOSTCalls.Controls.Add(this.tbxBSubscriber);
            this.grpbxPOSTCalls.Location = new System.Drawing.Point(16, 22);
            this.grpbxPOSTCalls.Margin = new System.Windows.Forms.Padding(2);
            this.grpbxPOSTCalls.Name = "grpbxPOSTCalls";
            this.grpbxPOSTCalls.Padding = new System.Windows.Forms.Padding(2);
            this.grpbxPOSTCalls.Size = new System.Drawing.Size(403, 136);
            this.grpbxPOSTCalls.TabIndex = 42;
            this.grpbxPOSTCalls.TabStop = false;
            // 
            // btnPOSTCalls
            // 
            this.btnPOSTCalls.Location = new System.Drawing.Point(145, 15);
            this.btnPOSTCalls.Name = "btnPOSTCalls";
            this.btnPOSTCalls.Size = new System.Drawing.Size(118, 60);
            this.btnPOSTCalls.TabIndex = 15;
            this.btnPOSTCalls.Text = "POST Calls";
            this.btnPOSTCalls.UseVisualStyleBackColor = true;
            this.btnPOSTCalls.Click += new System.EventHandler(this.btnPOSTCalls_Click);
            // 
            // cmbxCallAction
            // 
            this.cmbxCallAction.FormattingEnabled = true;
            this.cmbxCallAction.Location = new System.Drawing.Point(145, 101);
            this.cmbxCallAction.Margin = new System.Windows.Forms.Padding(2);
            this.cmbxCallAction.Name = "cmbxCallAction";
            this.cmbxCallAction.Size = new System.Drawing.Size(92, 24);
            this.cmbxCallAction.TabIndex = 41;
            // 
            // lblASubscriber
            // 
            this.lblASubscriber.AutoSize = true;
            this.lblASubscriber.Location = new System.Drawing.Point(20, 19);
            this.lblASubscriber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblASubscriber.Name = "lblASubscriber";
            this.lblASubscriber.Size = new System.Drawing.Size(103, 16);
            this.lblASubscriber.TabIndex = 34;
            this.lblASubscriber.Text = "A-Subscriber:";
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Location = new System.Drawing.Point(142, 84);
            this.lblAction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(56, 16);
            this.lblAction.TabIndex = 40;
            this.lblAction.Text = "Action:";
            // 
            // tbxASubscriber
            // 
            this.tbxASubscriber.AutoCompleteCustomSource.AddRange(new string[] {
            "141",
            "142",
            "143",
            "144",
            "145"});
            this.tbxASubscriber.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxASubscriber.Location = new System.Drawing.Point(21, 36);
            this.tbxASubscriber.Margin = new System.Windows.Forms.Padding(2);
            this.tbxASubscriber.Name = "tbxASubscriber";
            this.tbxASubscriber.Size = new System.Drawing.Size(58, 23);
            this.tbxASubscriber.TabIndex = 32;
            this.tbxASubscriber.Text = "101";
            this.tbxASubscriber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBSubscriber
            // 
            this.lblBSubscriber.AutoSize = true;
            this.lblBSubscriber.Location = new System.Drawing.Point(18, 82);
            this.lblBSubscriber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBSubscriber.Name = "lblBSubscriber";
            this.lblBSubscriber.Size = new System.Drawing.Size(104, 16);
            this.lblBSubscriber.TabIndex = 35;
            this.lblBSubscriber.Text = "B-Subscriber:";
            // 
            // tbxBSubscriber
            // 
            this.tbxBSubscriber.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxBSubscriber.Location = new System.Drawing.Point(21, 99);
            this.tbxBSubscriber.Margin = new System.Windows.Forms.Padding(2);
            this.tbxBSubscriber.Name = "tbxBSubscriber";
            this.tbxBSubscriber.Size = new System.Drawing.Size(58, 23);
            this.tbxBSubscriber.TabIndex = 33;
            this.tbxBSubscriber.Text = "102";
            this.tbxBSubscriber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPOSTcallId
            // 
            this.btnPOSTcallId.Location = new System.Drawing.Point(160, 175);
            this.btnPOSTcallId.Name = "btnPOSTcallId";
            this.btnPOSTcallId.Size = new System.Drawing.Size(118, 63);
            this.btnPOSTcallId.TabIndex = 38;
            this.btnPOSTcallId.Text = "POST\r\nCall Id";
            this.btnPOSTcallId.UseVisualStyleBackColor = true;
            this.btnPOSTcallId.Click += new System.EventHandler(this.btnPOSTcallId_Click);
            // 
            // btnGETCalls
            // 
            this.btnGETCalls.Location = new System.Drawing.Point(16, 173);
            this.btnGETCalls.Name = "btnGETCalls";
            this.btnGETCalls.Size = new System.Drawing.Size(118, 63);
            this.btnGETCalls.TabIndex = 4;
            this.btnGETCalls.Text = "GET\r\nCalls";
            this.btnGETCalls.UseVisualStyleBackColor = true;
            this.btnGETCalls.Click += new System.EventHandler(this.btnGETCalls_Click);
            // 
            // btnDELETECallId
            // 
            this.btnDELETECallId.Location = new System.Drawing.Point(301, 250);
            this.btnDELETECallId.Name = "btnDELETECallId";
            this.btnDELETECallId.Size = new System.Drawing.Size(118, 63);
            this.btnDELETECallId.TabIndex = 36;
            this.btnDELETECallId.Text = "DELETE\r\nCall Id";
            this.btnDELETECallId.UseVisualStyleBackColor = true;
            this.btnDELETECallId.Click += new System.EventHandler(this.btnDELETECallId_Click);
            // 
            // btnDELETECalls
            // 
            this.btnDELETECalls.Location = new System.Drawing.Point(301, 173);
            this.btnDELETECalls.Name = "btnDELETECalls";
            this.btnDELETECalls.Size = new System.Drawing.Size(118, 63);
            this.btnDELETECalls.TabIndex = 16;
            this.btnDELETECalls.Text = "DELETE\r\nCalls";
            this.btnDELETECalls.UseVisualStyleBackColor = true;
            this.btnDELETECalls.Click += new System.EventHandler(this.btnDELETECalls_Click);
            // 
            // gbxDevice
            // 
            this.gbxDevice.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gbxDevice.Controls.Add(this.btnPOSTDeviceGPO);
            this.gbxDevice.Controls.Add(this.tbxGPIDevice);
            this.gbxDevice.Controls.Add(this.lblGPIDevice);
            this.gbxDevice.Controls.Add(this.tbxGPODevice);
            this.gbxDevice.Controls.Add(this.lblGPODevice);
            this.gbxDevice.Controls.Add(this.btnGETDeviceGPIOs);
            this.gbxDevice.Controls.Add(this.btnGETDeviceGPOs);
            this.gbxDevice.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDevice.Location = new System.Drawing.Point(790, 184);
            this.gbxDevice.Margin = new System.Windows.Forms.Padding(2);
            this.gbxDevice.Name = "gbxDevice";
            this.gbxDevice.Padding = new System.Windows.Forms.Padding(2);
            this.gbxDevice.Size = new System.Drawing.Size(254, 320);
            this.gbxDevice.TabIndex = 46;
            this.gbxDevice.TabStop = false;
            this.gbxDevice.Text = "Device (n/a)";
            // 
            // btnPOSTDeviceGPO
            // 
            this.btnPOSTDeviceGPO.Location = new System.Drawing.Point(18, 24);
            this.btnPOSTDeviceGPO.Name = "btnPOSTDeviceGPO";
            this.btnPOSTDeviceGPO.Size = new System.Drawing.Size(128, 63);
            this.btnPOSTDeviceGPO.TabIndex = 39;
            this.btnPOSTDeviceGPO.Text = "POST\r\nDevice GPO";
            this.btnPOSTDeviceGPO.UseVisualStyleBackColor = true;
            this.btnPOSTDeviceGPO.Click += new System.EventHandler(this.btnPOSTDeviceGPO_Click);
            // 
            // tbxGPIDevice
            // 
            this.tbxGPIDevice.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxGPIDevice.Location = new System.Drawing.Point(160, 209);
            this.tbxGPIDevice.Margin = new System.Windows.Forms.Padding(2);
            this.tbxGPIDevice.Name = "tbxGPIDevice";
            this.tbxGPIDevice.Size = new System.Drawing.Size(58, 23);
            this.tbxGPIDevice.TabIndex = 37;
            this.tbxGPIDevice.Text = "101";
            this.tbxGPIDevice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblGPIDevice
            // 
            this.lblGPIDevice.AutoSize = true;
            this.lblGPIDevice.Location = new System.Drawing.Point(158, 192);
            this.lblGPIDevice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGPIDevice.Name = "lblGPIDevice";
            this.lblGPIDevice.Size = new System.Drawing.Size(85, 16);
            this.lblGPIDevice.TabIndex = 38;
            this.lblGPIDevice.Text = "GPI Device";
            // 
            // tbxGPODevice
            // 
            this.tbxGPODevice.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxGPODevice.Location = new System.Drawing.Point(160, 128);
            this.tbxGPODevice.Margin = new System.Windows.Forms.Padding(2);
            this.tbxGPODevice.Name = "tbxGPODevice";
            this.tbxGPODevice.Size = new System.Drawing.Size(58, 23);
            this.tbxGPODevice.TabIndex = 35;
            this.tbxGPODevice.Text = "101";
            this.tbxGPODevice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblGPODevice
            // 
            this.lblGPODevice.AutoSize = true;
            this.lblGPODevice.Location = new System.Drawing.Point(158, 110);
            this.lblGPODevice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGPODevice.Name = "lblGPODevice";
            this.lblGPODevice.Size = new System.Drawing.Size(92, 16);
            this.lblGPODevice.TabIndex = 36;
            this.lblGPODevice.Text = "GPO Device";
            // 
            // btnGETDeviceGPIOs
            // 
            this.btnGETDeviceGPIOs.Location = new System.Drawing.Point(18, 187);
            this.btnGETDeviceGPIOs.Name = "btnGETDeviceGPIOs";
            this.btnGETDeviceGPIOs.Size = new System.Drawing.Size(128, 63);
            this.btnGETDeviceGPIOs.TabIndex = 4;
            this.btnGETDeviceGPIOs.Text = "GET\r\n Device GPIs";
            this.btnGETDeviceGPIOs.UseVisualStyleBackColor = true;
            // 
            // btnGETDeviceGPOs
            // 
            this.btnGETDeviceGPOs.Location = new System.Drawing.Point(18, 106);
            this.btnGETDeviceGPOs.Name = "btnGETDeviceGPOs";
            this.btnGETDeviceGPOs.Size = new System.Drawing.Size(128, 63);
            this.btnGETDeviceGPOs.TabIndex = 3;
            this.btnGETDeviceGPOs.Text = "GET\r\n Device GPOs";
            this.btnGETDeviceGPOs.UseVisualStyleBackColor = true;
            // 
            // grbEvent
            // 
            this.grbEvent.Controls.Add(this.cbxOpenDoorEvent);
            this.grbEvent.Controls.Add(this.cbxDeviceGPIStatusEvent);
            this.grbEvent.Controls.Add(this.cbxDeviceGPOStatusEvent);
            this.grbEvent.Controls.Add(this.cbxCallStatusEvent);
            this.grbEvent.Controls.Add(this.cbxDeviceRegistrationEvent);
            this.grbEvent.Controls.Add(this.cbxCallLegStatusEvent);
            this.grbEvent.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbEvent.Location = new System.Drawing.Point(1064, 184);
            this.grbEvent.Margin = new System.Windows.Forms.Padding(2);
            this.grbEvent.Name = "grbEvent";
            this.grbEvent.Padding = new System.Windows.Forms.Padding(2);
            this.grbEvent.Size = new System.Drawing.Size(360, 320);
            this.grbEvent.TabIndex = 47;
            this.grbEvent.TabStop = false;
            this.grbEvent.Text = "Events (WAMP Interface)";
            // 
            // cbxOpenDoorEvent
            // 
            this.cbxOpenDoorEvent.AutoSize = true;
            this.cbxOpenDoorEvent.Location = new System.Drawing.Point(17, 227);
            this.cbxOpenDoorEvent.Margin = new System.Windows.Forms.Padding(2);
            this.cbxOpenDoorEvent.Name = "cbxOpenDoorEvent";
            this.cbxOpenDoorEvent.Size = new System.Drawing.Size(148, 20);
            this.cbxOpenDoorEvent.TabIndex = 32;
            this.cbxOpenDoorEvent.Text = "Open Door Event";
            this.cbxOpenDoorEvent.UseVisualStyleBackColor = true;
            this.cbxOpenDoorEvent.CheckedChanged += new System.EventHandler(this.cbxOpenDoorEvent_CheckedChanged);
            // 
            // cbxDeviceGPIStatusEvent
            // 
            this.cbxDeviceGPIStatusEvent.AutoSize = true;
            this.cbxDeviceGPIStatusEvent.Location = new System.Drawing.Point(17, 187);
            this.cbxDeviceGPIStatusEvent.Margin = new System.Windows.Forms.Padding(2);
            this.cbxDeviceGPIStatusEvent.Name = "cbxDeviceGPIStatusEvent";
            this.cbxDeviceGPIStatusEvent.Size = new System.Drawing.Size(232, 20);
            this.cbxDeviceGPIStatusEvent.TabIndex = 31;
            this.cbxDeviceGPIStatusEvent.Text = "Device GPI Status Event (n/a)";
            this.cbxDeviceGPIStatusEvent.UseVisualStyleBackColor = true;
            this.cbxDeviceGPIStatusEvent.CheckedChanged += new System.EventHandler(this.cbxDeviceGPIStatusEvent_CheckedChanged);
            // 
            // cbxDeviceGPOStatusEvent
            // 
            this.cbxDeviceGPOStatusEvent.AutoSize = true;
            this.cbxDeviceGPOStatusEvent.Location = new System.Drawing.Point(17, 144);
            this.cbxDeviceGPOStatusEvent.Margin = new System.Windows.Forms.Padding(2);
            this.cbxDeviceGPOStatusEvent.Name = "cbxDeviceGPOStatusEvent";
            this.cbxDeviceGPOStatusEvent.Size = new System.Drawing.Size(239, 20);
            this.cbxDeviceGPOStatusEvent.TabIndex = 30;
            this.cbxDeviceGPOStatusEvent.Text = "Device GPO Status Event (n/a)";
            this.cbxDeviceGPOStatusEvent.UseVisualStyleBackColor = true;
            this.cbxDeviceGPOStatusEvent.CheckedChanged += new System.EventHandler(this.cbxDeviceGPOStatusEvent_CheckedChanged);
            // 
            // cbxCallStatusEvent
            // 
            this.cbxCallStatusEvent.AutoSize = true;
            this.cbxCallStatusEvent.Location = new System.Drawing.Point(17, 28);
            this.cbxCallStatusEvent.Margin = new System.Windows.Forms.Padding(2);
            this.cbxCallStatusEvent.Name = "cbxCallStatusEvent";
            this.cbxCallStatusEvent.Size = new System.Drawing.Size(146, 20);
            this.cbxCallStatusEvent.TabIndex = 27;
            this.cbxCallStatusEvent.Text = "Call Status Event";
            this.cbxCallStatusEvent.UseVisualStyleBackColor = true;
            this.cbxCallStatusEvent.CheckedChanged += new System.EventHandler(this.cbxCallStatusEvent_CheckedChanged);
            // 
            // cbxDeviceRegistrationEvent
            // 
            this.cbxDeviceRegistrationEvent.AutoSize = true;
            this.cbxDeviceRegistrationEvent.Location = new System.Drawing.Point(17, 102);
            this.cbxDeviceRegistrationEvent.Margin = new System.Windows.Forms.Padding(2);
            this.cbxDeviceRegistrationEvent.Name = "cbxDeviceRegistrationEvent";
            this.cbxDeviceRegistrationEvent.Size = new System.Drawing.Size(211, 20);
            this.cbxDeviceRegistrationEvent.TabIndex = 29;
            this.cbxDeviceRegistrationEvent.Text = "Device Registration Event";
            this.cbxDeviceRegistrationEvent.UseVisualStyleBackColor = true;
            this.cbxDeviceRegistrationEvent.CheckedChanged += new System.EventHandler(this.cbxDeviceRegistrationEvent_CheckedChanged);
            // 
            // cbxCallLegStatusEvent
            // 
            this.cbxCallLegStatusEvent.AutoSize = true;
            this.cbxCallLegStatusEvent.Location = new System.Drawing.Point(17, 64);
            this.cbxCallLegStatusEvent.Margin = new System.Windows.Forms.Padding(2);
            this.cbxCallLegStatusEvent.Name = "cbxCallLegStatusEvent";
            this.cbxCallLegStatusEvent.Size = new System.Drawing.Size(197, 20);
            this.cbxCallLegStatusEvent.TabIndex = 28;
            this.cbxCallLegStatusEvent.Text = "Call Queue Status Event";
            this.cbxCallLegStatusEvent.UseVisualStyleBackColor = true;
            this.cbxCallLegStatusEvent.CheckedChanged += new System.EventHandler(this.cbxCallQueueStatusEvent_CheckedChanged);
            // 
            // grpbxRegistratedDevices
            // 
            this.grpbxRegistratedDevices.Controls.Add(this.btnClearList);
            this.grpbxRegistratedDevices.Controls.Add(this.dgrd_Registrations);
            this.grpbxRegistratedDevices.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxRegistratedDevices.Location = new System.Drawing.Point(18, 525);
            this.grpbxRegistratedDevices.Margin = new System.Windows.Forms.Padding(2);
            this.grpbxRegistratedDevices.Name = "grpbxRegistratedDevices";
            this.grpbxRegistratedDevices.Padding = new System.Windows.Forms.Padding(2);
            this.grpbxRegistratedDevices.Size = new System.Drawing.Size(757, 258);
            this.grpbxRegistratedDevices.TabIndex = 48;
            this.grpbxRegistratedDevices.TabStop = false;
            this.grpbxRegistratedDevices.Text = "Registered Devices";
            // 
            // btnClearList
            // 
            this.btnClearList.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearList.Location = new System.Drawing.Point(658, 203);
            this.btnClearList.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(82, 32);
            this.btnClearList.TabIndex = 24;
            this.btnClearList.Text = "Clear List";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // dgrd_Registrations
            // 
            this.dgrd_Registrations.AllowUserToAddRows = false;
            this.dgrd_Registrations.AllowUserToDeleteRows = false;
            this.dgrd_Registrations.AllowUserToResizeColumns = false;
            this.dgrd_Registrations.AllowUserToResizeRows = false;
            this.dgrd_Registrations.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgrd_Registrations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrd_Registrations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgrdDirNo,
            this.dgrdName,
            this.dgrdLocation,
            this.dgrdState});
            this.dgrd_Registrations.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgrd_Registrations.Location = new System.Drawing.Point(16, 20);
            this.dgrd_Registrations.Margin = new System.Windows.Forms.Padding(2);
            this.dgrd_Registrations.Name = "dgrd_Registrations";
            this.dgrd_Registrations.RowHeadersWidth = 51;
            this.dgrd_Registrations.RowTemplate.Height = 24;
            this.dgrd_Registrations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgrd_Registrations.Size = new System.Drawing.Size(619, 215);
            this.dgrd_Registrations.TabIndex = 16;
            // 
            // dgrdDirNo
            // 
            this.dgrdDirNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgrdDirNo.HeaderText = "Dir. No";
            this.dgrdDirNo.MinimumWidth = 60;
            this.dgrdDirNo.Name = "dgrdDirNo";
            this.dgrdDirNo.Width = 79;
            // 
            // dgrdName
            // 
            this.dgrdName.HeaderText = "Name";
            this.dgrdName.MinimumWidth = 120;
            this.dgrdName.Name = "dgrdName";
            this.dgrdName.Width = 120;
            // 
            // dgrdLocation
            // 
            this.dgrdLocation.HeaderText = "Location";
            this.dgrdLocation.MinimumWidth = 120;
            this.dgrdLocation.Name = "dgrdLocation";
            this.dgrdLocation.Width = 120;
            // 
            // dgrdState
            // 
            this.dgrdState.HeaderText = "State";
            this.dgrdState.MinimumWidth = 180;
            this.dgrdState.Name = "dgrdState";
            this.dgrdState.Width = 180;
            // 
            // gbxNetInterfaces
            // 
            this.gbxNetInterfaces.Controls.Add(this.btnClearNetInterfaces);
            this.gbxNetInterfaces.Controls.Add(this.dgrdNetInterfaces);
            this.gbxNetInterfaces.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxNetInterfaces.Location = new System.Drawing.Point(19, 787);
            this.gbxNetInterfaces.Margin = new System.Windows.Forms.Padding(2);
            this.gbxNetInterfaces.Name = "gbxNetInterfaces";
            this.gbxNetInterfaces.Padding = new System.Windows.Forms.Padding(2);
            this.gbxNetInterfaces.Size = new System.Drawing.Size(756, 158);
            this.gbxNetInterfaces.TabIndex = 49;
            this.gbxNetInterfaces.TabStop = false;
            this.gbxNetInterfaces.Text = "Net Interfaces";
            // 
            // btnClearNetInterfaces
            // 
            this.btnClearNetInterfaces.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearNetInterfaces.Location = new System.Drawing.Point(657, 112);
            this.btnClearNetInterfaces.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearNetInterfaces.Name = "btnClearNetInterfaces";
            this.btnClearNetInterfaces.Size = new System.Drawing.Size(82, 32);
            this.btnClearNetInterfaces.TabIndex = 24;
            this.btnClearNetInterfaces.Text = "Clear List";
            this.btnClearNetInterfaces.UseVisualStyleBackColor = true;
            this.btnClearNetInterfaces.Click += new System.EventHandler(this.btnClearNetInterfaces_Click);
            // 
            // dgrdNetInterfaces
            // 
            this.dgrdNetInterfaces.AllowUserToAddRows = false;
            this.dgrdNetInterfaces.AllowUserToDeleteRows = false;
            this.dgrdNetInterfaces.AllowUserToResizeColumns = false;
            this.dgrdNetInterfaces.AllowUserToResizeRows = false;
            this.dgrdNetInterfaces.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgrdNetInterfaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdNetInterfaces.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NetMACaddr,
            this.NetName,
            this.NetState});
            this.dgrdNetInterfaces.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgrdNetInterfaces.Location = new System.Drawing.Point(16, 24);
            this.dgrdNetInterfaces.Margin = new System.Windows.Forms.Padding(2);
            this.dgrdNetInterfaces.Name = "dgrdNetInterfaces";
            this.dgrdNetInterfaces.RowHeadersWidth = 51;
            this.dgrdNetInterfaces.RowTemplate.Height = 24;
            this.dgrdNetInterfaces.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgrdNetInterfaces.Size = new System.Drawing.Size(618, 120);
            this.dgrdNetInterfaces.TabIndex = 16;
            // 
            // NetMACaddr
            // 
            this.NetMACaddr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.NetMACaddr.HeaderText = "MAC-addr";
            this.NetMACaddr.MinimumWidth = 160;
            this.NetMACaddr.Name = "NetMACaddr";
            this.NetMACaddr.Width = 160;
            // 
            // NetName
            // 
            this.NetName.HeaderText = "Name";
            this.NetName.MinimumWidth = 120;
            this.NetName.Name = "NetName";
            this.NetName.Width = 120;
            // 
            // NetState
            // 
            this.NetState.HeaderText = "State";
            this.NetState.MinimumWidth = 100;
            this.NetState.Name = "NetState";
            this.NetState.Width = 125;
            // 
            // gbxActiveCalls
            // 
            this.gbxActiveCalls.Controls.Add(this.dgrdActiveCalls);
            this.gbxActiveCalls.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxActiveCalls.Location = new System.Drawing.Point(790, 523);
            this.gbxActiveCalls.Margin = new System.Windows.Forms.Padding(2);
            this.gbxActiveCalls.Name = "gbxActiveCalls";
            this.gbxActiveCalls.Padding = new System.Windows.Forms.Padding(2);
            this.gbxActiveCalls.Size = new System.Drawing.Size(633, 227);
            this.gbxActiveCalls.TabIndex = 50;
            this.gbxActiveCalls.TabStop = false;
            this.gbxActiveCalls.Text = "Active Calls";
            // 
            // dgrdActiveCalls
            // 
            this.dgrdActiveCalls.AllowUserToAddRows = false;
            this.dgrdActiveCalls.AllowUserToDeleteRows = false;
            this.dgrdActiveCalls.AllowUserToResizeColumns = false;
            this.dgrdActiveCalls.AllowUserToResizeRows = false;
            this.dgrdActiveCalls.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgrdActiveCalls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdActiveCalls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Source,
            this.Destination,
            this.CallState,
            this.CallId});
            this.dgrdActiveCalls.Location = new System.Drawing.Point(15, 24);
            this.dgrdActiveCalls.Margin = new System.Windows.Forms.Padding(2);
            this.dgrdActiveCalls.Name = "dgrdActiveCalls";
            this.dgrdActiveCalls.RowHeadersWidth = 51;
            this.dgrdActiveCalls.RowTemplate.Height = 24;
            this.dgrdActiveCalls.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgrdActiveCalls.Size = new System.Drawing.Size(602, 186);
            this.dgrdActiveCalls.TabIndex = 17;
            // 
            // gbxQueuedCalls
            // 
            this.gbxQueuedCalls.Controls.Add(this.dgrdQueuedCalls);
            this.gbxQueuedCalls.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxQueuedCalls.Location = new System.Drawing.Point(791, 770);
            this.gbxQueuedCalls.Margin = new System.Windows.Forms.Padding(2);
            this.gbxQueuedCalls.Name = "gbxQueuedCalls";
            this.gbxQueuedCalls.Padding = new System.Windows.Forms.Padding(2);
            this.gbxQueuedCalls.Size = new System.Drawing.Size(632, 175);
            this.gbxQueuedCalls.TabIndex = 51;
            this.gbxQueuedCalls.TabStop = false;
            this.gbxQueuedCalls.Text = "Queued Calls";
            // 
            // dgrdQueuedCalls
            // 
            this.dgrdQueuedCalls.AllowUserToAddRows = false;
            this.dgrdQueuedCalls.AllowUserToDeleteRows = false;
            this.dgrdQueuedCalls.AllowUserToResizeColumns = false;
            this.dgrdQueuedCalls.AllowUserToResizeRows = false;
            this.dgrdQueuedCalls.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgrdQueuedCalls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdQueuedCalls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgrdQueuedCalls.Location = new System.Drawing.Point(14, 33);
            this.dgrdQueuedCalls.Margin = new System.Windows.Forms.Padding(2);
            this.dgrdQueuedCalls.Name = "dgrdQueuedCalls";
            this.dgrdQueuedCalls.RowHeadersWidth = 51;
            this.dgrdQueuedCalls.RowTemplate.Height = 24;
            this.dgrdQueuedCalls.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgrdQueuedCalls.Size = new System.Drawing.Size(602, 128);
            this.dgrdQueuedCalls.TabIndex = 17;
            // 
            // btnGETCallLegs
            // 
            this.btnGETCallLegs.Location = new System.Drawing.Point(16, 250);
            this.btnGETCallLegs.Name = "btnGETCallLegs";
            this.btnGETCallLegs.Size = new System.Drawing.Size(118, 60);
            this.btnGETCallLegs.TabIndex = 44;
            this.btnGETCallLegs.Text = "GET\r\nCall Legs";
            this.btnGETCallLegs.UseVisualStyleBackColor = true;
            this.btnGETCallLegs.Click += new System.EventHandler(this.btnGETCallLegs_Click);
            // 
            // Source
            // 
            this.Source.HeaderText = "Call from";
            this.Source.MinimumWidth = 130;
            this.Source.Name = "Source";
            this.Source.Width = 130;
            // 
            // Destination
            // 
            this.Destination.HeaderText = "Call to";
            this.Destination.MinimumWidth = 130;
            this.Destination.Name = "Destination";
            this.Destination.Width = 130;
            // 
            // CallState
            // 
            this.CallState.HeaderText = "Call State";
            this.CallState.MinimumWidth = 130;
            this.CallState.Name = "CallState";
            this.CallState.Width = 130;
            // 
            // CallId
            // 
            this.CallId.HeaderText = "Call ID";
            this.CallId.MinimumWidth = 250;
            this.CallId.Name = "CallId";
            this.CallId.Width = 300;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Call from";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 130;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 130;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Call tp";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 130;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 130;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "State";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 130;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 130;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Call ID";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 250;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 300;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(162, 160);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 14);
            this.label1.TabIndex = 52;
            this.label1.Text = "answer queued call";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1435, 956);
            this.Controls.Add(this.gbxQueuedCalls);
            this.Controls.Add(this.gbxActiveCalls);
            this.Controls.Add(this.gbxNetInterfaces);
            this.Controls.Add(this.grpbxRegistratedDevices);
            this.Controls.Add(this.grbEvent);
            this.Controls.Add(this.gbxDevice);
            this.Controls.Add(this.gbxCallControl);
            this.Controls.Add(this.gbxSwaggerSystem);
            this.Controls.Add(this.gbxLogging);
            this.Controls.Add(this.gbxAuthentication);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Zenitel Connect REST API SDK";
            this.gbxAuthentication.ResumeLayout(false);
            this.gbxAuthentication.PerformLayout();
            this.gbxLogging.ResumeLayout(false);
            this.gbxLogging.PerformLayout();
            this.gbxSwaggerSystem.ResumeLayout(false);
            this.gbxCallControl.ResumeLayout(false);
            this.gbxCallControl.PerformLayout();
            this.grpbxPOSTCalls.ResumeLayout(false);
            this.grpbxPOSTCalls.PerformLayout();
            this.gbxDevice.ResumeLayout(false);
            this.gbxDevice.PerformLayout();
            this.grbEvent.ResumeLayout(false);
            this.grbEvent.PerformLayout();
            this.grpbxRegistratedDevices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrd_Registrations)).EndInit();
            this.gbxNetInterfaces.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdNetInterfaces)).EndInit();
            this.gbxActiveCalls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdActiveCalls)).EndInit();
            this.gbxQueuedCalls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdQueuedCalls)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxAuthentication;
        private System.Windows.Forms.Label blConnectionStatus;
        private System.Windows.Forms.TextBox tbxConnectionStatus;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label labRestApiServerAddress;
        private System.Windows.Forms.TextBox edtConnectServerAddr;
        private System.Windows.Forms.Label labUserName;
        private System.Windows.Forms.TextBox edtUserName;
        private System.Windows.Forms.Label labPassword;
        private System.Windows.Forms.TextBox edtPassword;
        private System.Windows.Forms.GroupBox gbxLogging;
        private System.Windows.Forms.Label lblLogFileSavingLocation;
        private System.Windows.Forms.CheckBox cbxSaveLoggingToFile;
        private System.Windows.Forms.Button btnClearLoggingWindow;
        private System.Windows.Forms.Button btnCloseLoggingWindow;
        private System.Windows.Forms.Button btnOpenLoggingWindow;
        private System.Windows.Forms.GroupBox gbxSwaggerSystem;
        private System.Windows.Forms.Button btnGETNetInterface;
        private System.Windows.Forms.Button btnGETDeviceAccounts;
        private System.Windows.Forms.GroupBox gbxCallControl;
        private System.Windows.Forms.ComboBox cmbxCallAction;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Button btnPOSTcallId;
        private System.Windows.Forms.Button btnGETCalls;
        private System.Windows.Forms.Button btnDELETECallId;
        private System.Windows.Forms.TextBox tbxBSubscriber;
        private System.Windows.Forms.Label lblBSubscriber;
        private System.Windows.Forms.TextBox tbxASubscriber;
        private System.Windows.Forms.Label lblASubscriber;
        private System.Windows.Forms.Button btnPOSTCalls;
        private System.Windows.Forms.Button btnDELETECalls;
        private System.Windows.Forms.GroupBox gbxDevice;
        private System.Windows.Forms.TextBox tbxGPIDevice;
        private System.Windows.Forms.Label lblGPIDevice;
        private System.Windows.Forms.TextBox tbxGPODevice;
        private System.Windows.Forms.Label lblGPODevice;
        private System.Windows.Forms.Button btnGETDeviceGPIOs;
        private System.Windows.Forms.Button btnGETDeviceGPOs;
        private System.Windows.Forms.GroupBox grbEvent;
        private System.Windows.Forms.CheckBox cbxOpenDoorEvent;
        private System.Windows.Forms.CheckBox cbxDeviceGPIStatusEvent;
        private System.Windows.Forms.CheckBox cbxDeviceGPOStatusEvent;
        private System.Windows.Forms.CheckBox cbxCallStatusEvent;
        private System.Windows.Forms.CheckBox cbxDeviceRegistrationEvent;
        private System.Windows.Forms.CheckBox cbxCallLegStatusEvent;
        private System.Windows.Forms.GroupBox grpbxRegistratedDevices;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.DataGridView dgrd_Registrations;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgrdDirNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgrdLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgrdState;
        private System.Windows.Forms.GroupBox gbxNetInterfaces;
        private System.Windows.Forms.Button btnClearNetInterfaces;
        private System.Windows.Forms.DataGridView dgrdNetInterfaces;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetMACaddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetState;
        private System.Windows.Forms.GroupBox gbxActiveCalls;
        private System.Windows.Forms.DataGridView dgrdActiveCalls;
        private System.Windows.Forms.GroupBox gbxQueuedCalls;
        private System.Windows.Forms.DataGridView dgrdQueuedCalls;
        private System.Windows.Forms.Label labEncryption;
        private System.Windows.Forms.TextBox edtWampRealm;
        private System.Windows.Forms.Label labWampRealm;
        private System.Windows.Forms.Button btnPOSTDeviceGPO;
        private System.Windows.Forms.CheckBox chbxUnencrypted;
        private System.Windows.Forms.CheckBox chbxEncrypted;
        private System.Windows.Forms.GroupBox grpbxPOSTCalls;
        private System.Windows.Forms.Button btnGETCallLegs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destination;
        private System.Windows.Forms.DataGridViewTextBoxColumn CallState;
        private System.Windows.Forms.DataGridViewTextBoxColumn CallId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label1;
    }
}

