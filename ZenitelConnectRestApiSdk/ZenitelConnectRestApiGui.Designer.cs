
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
            this.btnGETCallLegs = new System.Windows.Forms.Button();
            this.grpbxPOSTCalls = new System.Windows.Forms.GroupBox();
            this.btnPOSTCalls = new System.Windows.Forms.Button();
            this.cmbxCallAction = new System.Windows.Forms.ComboBox();
            this.lblASubscriber = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.tbxASubscriber = new System.Windows.Forms.TextBox();
            this.lblBSubscriber = new System.Windows.Forms.Label();
            this.tbxBSubscriber = new System.Windows.Forms.TextBox();
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
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CallState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CallId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxQueuedCalls = new System.Windows.Forms.GroupBox();
            this.dgrdQueuedCalls = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.gbxAuthentication.Location = new System.Drawing.Point(24, 15);
            this.gbxAuthentication.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxAuthentication.Name = "gbxAuthentication";
            this.gbxAuthentication.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxAuthentication.Size = new System.Drawing.Size(1368, 185);
            this.gbxAuthentication.TabIndex = 39;
            this.gbxAuthentication.TabStop = false;
            this.gbxAuthentication.Text = "Authentication";
            // 
            // chbxUnencrypted
            // 
            this.chbxUnencrypted.AutoSize = true;
            this.chbxUnencrypted.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxUnencrypted.Location = new System.Drawing.Point(735, 95);
            this.chbxUnencrypted.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbxUnencrypted.Name = "chbxUnencrypted";
            this.chbxUnencrypted.Size = new System.Drawing.Size(267, 26);
            this.chbxUnencrypted.TabIndex = 29;
            this.chbxUnencrypted.Text = "Unencrypted (Port 80/8087)";
            this.chbxUnencrypted.UseVisualStyleBackColor = true;
            this.chbxUnencrypted.CheckedChanged += new System.EventHandler(this.chbxUnencrypted_CheckedChanged);
            // 
            // chbxEncrypted
            // 
            this.chbxEncrypted.AutoSize = true;
            this.chbxEncrypted.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxEncrypted.Location = new System.Drawing.Point(735, 64);
            this.chbxEncrypted.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbxEncrypted.Name = "chbxEncrypted";
            this.chbxEncrypted.Size = new System.Drawing.Size(257, 26);
            this.chbxEncrypted.TabIndex = 28;
            this.chbxEncrypted.Text = "Encrypted (Port 443/8086)";
            this.chbxEncrypted.UseVisualStyleBackColor = true;
            this.chbxEncrypted.CheckedChanged += new System.EventHandler(this.chbxEncrypted_CheckedChanged);
            // 
            // edtWampRealm
            // 
            this.edtWampRealm.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtWampRealm.Location = new System.Drawing.Point(557, 75);
            this.edtWampRealm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtWampRealm.Name = "edtWampRealm";
            this.edtWampRealm.Size = new System.Drawing.Size(145, 27);
            this.edtWampRealm.TabIndex = 19;
            this.edtWampRealm.Text = "zenitel";
            // 
            // labWampRealm
            // 
            this.labWampRealm.AutoSize = true;
            this.labWampRealm.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labWampRealm.Location = new System.Drawing.Point(556, 55);
            this.labWampRealm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labWampRealm.Name = "labWampRealm";
            this.labWampRealm.Size = new System.Drawing.Size(89, 16);
            this.labWampRealm.TabIndex = 18;
            this.labWampRealm.Text = "WAMP realm";
            // 
            // labEncryption
            // 
            this.labEncryption.AutoSize = true;
            this.labEncryption.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEncryption.Location = new System.Drawing.Point(731, 44);
            this.labEncryption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labEncryption.Name = "labEncryption";
            this.labEncryption.Size = new System.Drawing.Size(138, 16);
            this.labEncryption.TabIndex = 16;
            this.labEncryption.Text = "Encryption Selection";
            // 
            // blConnectionStatus
            // 
            this.blConnectionStatus.AutoSize = true;
            this.blConnectionStatus.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blConnectionStatus.Location = new System.Drawing.Point(1035, 55);
            this.blConnectionStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.blConnectionStatus.Name = "blConnectionStatus";
            this.blConnectionStatus.Size = new System.Drawing.Size(122, 16);
            this.blConnectionStatus.TabIndex = 14;
            this.blConnectionStatus.Text = "Connection Status";
            // 
            // tbxConnectionStatus
            // 
            this.tbxConnectionStatus.Enabled = false;
            this.tbxConnectionStatus.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxConnectionStatus.Location = new System.Drawing.Point(1040, 76);
            this.tbxConnectionStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxConnectionStatus.Name = "tbxConnectionStatus";
            this.tbxConnectionStatus.Size = new System.Drawing.Size(145, 27);
            this.tbxConnectionStatus.TabIndex = 15;
            this.tbxConnectionStatus.Text = "Disconnected";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.Location = new System.Drawing.Point(1217, 101);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(131, 57);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnWampDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnConnect.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(1215, 32);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(133, 57);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnWampConnect_Click);
            // 
            // labRestApiServerAddress
            // 
            this.labRestApiServerAddress.AutoSize = true;
            this.labRestApiServerAddress.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRestApiServerAddress.Location = new System.Drawing.Point(13, 55);
            this.labRestApiServerAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labRestApiServerAddress.Name = "labRestApiServerAddress";
            this.labRestApiServerAddress.Size = new System.Drawing.Size(167, 16);
            this.labRestApiServerAddress.TabIndex = 3;
            this.labRestApiServerAddress.Text = "REST API Server Address";
            // 
            // edtConnectServerAddr
            // 
            this.edtConnectServerAddr.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtConnectServerAddr.Location = new System.Drawing.Point(13, 75);
            this.edtConnectServerAddr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtConnectServerAddr.Name = "edtConnectServerAddr";
            this.edtConnectServerAddr.Size = new System.Drawing.Size(164, 27);
            this.edtConnectServerAddr.TabIndex = 4;
            this.edtConnectServerAddr.Text = "169.254.1.5";
            // 
            // labUserName
            // 
            this.labUserName.AutoSize = true;
            this.labUserName.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUserName.Location = new System.Drawing.Point(217, 55);
            this.labUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(76, 16);
            this.labUserName.TabIndex = 5;
            this.labUserName.Text = "User Name";
            // 
            // edtUserName
            // 
            this.edtUserName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtUserName.Location = new System.Drawing.Point(221, 75);
            this.edtUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtUserName.Name = "edtUserName";
            this.edtUserName.Size = new System.Drawing.Size(145, 27);
            this.edtUserName.TabIndex = 6;
            // 
            // labPassword
            // 
            this.labPassword.AutoSize = true;
            this.labPassword.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPassword.Location = new System.Drawing.Point(397, 55);
            this.labPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labPassword.Name = "labPassword";
            this.labPassword.Size = new System.Drawing.Size(68, 16);
            this.labPassword.TabIndex = 7;
            this.labPassword.Text = "Password";
            // 
            // edtPassword
            // 
            this.edtPassword.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtPassword.Location = new System.Drawing.Point(387, 75);
            this.edtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtPassword.Name = "edtPassword";
            this.edtPassword.Size = new System.Drawing.Size(145, 27);
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
            this.gbxLogging.Location = new System.Drawing.Point(1419, 15);
            this.gbxLogging.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxLogging.Name = "gbxLogging";
            this.gbxLogging.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxLogging.Size = new System.Drawing.Size(480, 185);
            this.gbxLogging.TabIndex = 43;
            this.gbxLogging.TabStop = false;
            this.gbxLogging.Text = "Logging";
            // 
            // lblLogFileSavingLocation
            // 
            this.lblLogFileSavingLocation.AutoSize = true;
            this.lblLogFileSavingLocation.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogFileSavingLocation.Location = new System.Drawing.Point(27, 57);
            this.lblLogFileSavingLocation.Name = "lblLogFileSavingLocation";
            this.lblLogFileSavingLocation.Size = new System.Drawing.Size(41, 16);
            this.lblLogFileSavingLocation.TabIndex = 27;
            this.lblLogFileSavingLocation.Text = "label1";
            // 
            // cbxSaveLoggingToFile
            // 
            this.cbxSaveLoggingToFile.AutoSize = true;
            this.cbxSaveLoggingToFile.Location = new System.Drawing.Point(31, 30);
            this.cbxSaveLoggingToFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxSaveLoggingToFile.Name = "cbxSaveLoggingToFile";
            this.cbxSaveLoggingToFile.Size = new System.Drawing.Size(191, 23);
            this.cbxSaveLoggingToFile.TabIndex = 26;
            this.cbxSaveLoggingToFile.Text = "Save Logging to File";
            this.cbxSaveLoggingToFile.UseVisualStyleBackColor = true;
            this.cbxSaveLoggingToFile.CheckedChanged += new System.EventHandler(this.cbxSaveLoggingToFile_CheckedChanged);
            // 
            // btnClearLoggingWindow
            // 
            this.btnClearLoggingWindow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearLoggingWindow.Location = new System.Drawing.Point(324, 91);
            this.btnClearLoggingWindow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClearLoggingWindow.Name = "btnClearLoggingWindow";
            this.btnClearLoggingWindow.Size = new System.Drawing.Size(133, 66);
            this.btnClearLoggingWindow.TabIndex = 25;
            this.btnClearLoggingWindow.Text = "Clear\r\nLogging Window";
            this.btnClearLoggingWindow.UseVisualStyleBackColor = true;
            this.btnClearLoggingWindow.Click += new System.EventHandler(this.btnClearLoggingWindow_Click);
            // 
            // btnCloseLoggingWindow
            // 
            this.btnCloseLoggingWindow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseLoggingWindow.Location = new System.Drawing.Point(173, 91);
            this.btnCloseLoggingWindow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCloseLoggingWindow.Name = "btnCloseLoggingWindow";
            this.btnCloseLoggingWindow.Size = new System.Drawing.Size(133, 66);
            this.btnCloseLoggingWindow.TabIndex = 24;
            this.btnCloseLoggingWindow.Text = "Close\r\nLogging Window";
            this.btnCloseLoggingWindow.UseVisualStyleBackColor = true;
            this.btnCloseLoggingWindow.Click += new System.EventHandler(this.btnCloseLoggingWindow_Click);
            // 
            // btnOpenLoggingWindow
            // 
            this.btnOpenLoggingWindow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenLoggingWindow.Location = new System.Drawing.Point(21, 91);
            this.btnOpenLoggingWindow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpenLoggingWindow.Name = "btnOpenLoggingWindow";
            this.btnOpenLoggingWindow.Size = new System.Drawing.Size(133, 66);
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
            this.gbxSwaggerSystem.Location = new System.Drawing.Point(24, 223);
            this.gbxSwaggerSystem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxSwaggerSystem.Name = "gbxSwaggerSystem";
            this.gbxSwaggerSystem.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxSwaggerSystem.Size = new System.Drawing.Size(205, 398);
            this.gbxSwaggerSystem.TabIndex = 44;
            this.gbxSwaggerSystem.TabStop = false;
            this.gbxSwaggerSystem.Text = "System";
            // 
            // btnGETNetInterface
            // 
            this.btnGETNetInterface.Location = new System.Drawing.Point(27, 128);
            this.btnGETNetInterface.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGETNetInterface.Name = "btnGETNetInterface";
            this.btnGETNetInterface.Size = new System.Drawing.Size(147, 78);
            this.btnGETNetInterface.TabIndex = 3;
            this.btnGETNetInterface.Text = "GET\r\n Net Interfaces";
            this.btnGETNetInterface.UseVisualStyleBackColor = true;
            this.btnGETNetInterface.Click += new System.EventHandler(this.btnGETNetInterface_Click);
            // 
            // btnGETDeviceAccounts
            // 
            this.btnGETDeviceAccounts.Location = new System.Drawing.Point(27, 34);
            this.btnGETDeviceAccounts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGETDeviceAccounts.Name = "btnGETDeviceAccounts";
            this.btnGETDeviceAccounts.Size = new System.Drawing.Size(147, 78);
            this.btnGETDeviceAccounts.TabIndex = 2;
            this.btnGETDeviceAccounts.Text = "GET \r\nDevice Accounts";
            this.btnGETDeviceAccounts.UseVisualStyleBackColor = true;
            this.btnGETDeviceAccounts.Click += new System.EventHandler(this.btnGETDeviceAccounts_Click);
            // 
            // gbxCallControl
            // 
            this.gbxCallControl.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gbxCallControl.Controls.Add(this.btnGETCallLegs);
            this.gbxCallControl.Controls.Add(this.grpbxPOSTCalls);
            this.gbxCallControl.Controls.Add(this.btnGETCalls);
            this.gbxCallControl.Controls.Add(this.btnDELETECallId);
            this.gbxCallControl.Controls.Add(this.btnDELETECalls);
            this.gbxCallControl.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCallControl.Location = new System.Drawing.Point(257, 225);
            this.gbxCallControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxCallControl.Name = "gbxCallControl";
            this.gbxCallControl.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxCallControl.Size = new System.Drawing.Size(776, 395);
            this.gbxCallControl.TabIndex = 45;
            this.gbxCallControl.TabStop = false;
            this.gbxCallControl.Text = "Call Handling";
            // 
            // btnGETCallLegs
            // 
            this.btnGETCallLegs.Location = new System.Drawing.Point(21, 308);
            this.btnGETCallLegs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGETCallLegs.Name = "btnGETCallLegs";
            this.btnGETCallLegs.Size = new System.Drawing.Size(157, 74);
            this.btnGETCallLegs.TabIndex = 44;
            this.btnGETCallLegs.Text = "GET\r\nCall Legs";
            this.btnGETCallLegs.UseVisualStyleBackColor = true;
            this.btnGETCallLegs.Click += new System.EventHandler(this.btnGETCallLegs_Click);
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
            this.grpbxPOSTCalls.Location = new System.Drawing.Point(21, 27);
            this.grpbxPOSTCalls.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpbxPOSTCalls.Name = "grpbxPOSTCalls";
            this.grpbxPOSTCalls.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpbxPOSTCalls.Size = new System.Drawing.Size(537, 167);
            this.grpbxPOSTCalls.TabIndex = 42;
            this.grpbxPOSTCalls.TabStop = false;
            // 
            // btnPOSTCalls
            // 
            this.btnPOSTCalls.Location = new System.Drawing.Point(193, 18);
            this.btnPOSTCalls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPOSTCalls.Name = "btnPOSTCalls";
            this.btnPOSTCalls.Size = new System.Drawing.Size(157, 74);
            this.btnPOSTCalls.TabIndex = 15;
            this.btnPOSTCalls.Text = "POST Calls";
            this.btnPOSTCalls.UseVisualStyleBackColor = true;
            this.btnPOSTCalls.Click += new System.EventHandler(this.btnPOSTCalls_Click);
            // 
            // cmbxCallAction
            // 
            this.cmbxCallAction.FormattingEnabled = true;
            this.cmbxCallAction.Location = new System.Drawing.Point(193, 124);
            this.cmbxCallAction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbxCallAction.Name = "cmbxCallAction";
            this.cmbxCallAction.Size = new System.Drawing.Size(157, 27);
            this.cmbxCallAction.TabIndex = 41;
            // 
            // lblASubscriber
            // 
            this.lblASubscriber.AutoSize = true;
            this.lblASubscriber.Location = new System.Drawing.Point(27, 23);
            this.lblASubscriber.Name = "lblASubscriber";
            this.lblASubscriber.Size = new System.Drawing.Size(118, 19);
            this.lblASubscriber.TabIndex = 34;
            this.lblASubscriber.Text = "A-Subscriber:";
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Location = new System.Drawing.Point(189, 103);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(65, 19);
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
            this.tbxASubscriber.Location = new System.Drawing.Point(28, 44);
            this.tbxASubscriber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxASubscriber.Name = "tbxASubscriber";
            this.tbxASubscriber.Size = new System.Drawing.Size(76, 27);
            this.tbxASubscriber.TabIndex = 32;
            this.tbxASubscriber.Text = "101";
            this.tbxASubscriber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBSubscriber
            // 
            this.lblBSubscriber.AutoSize = true;
            this.lblBSubscriber.Location = new System.Drawing.Point(24, 101);
            this.lblBSubscriber.Name = "lblBSubscriber";
            this.lblBSubscriber.Size = new System.Drawing.Size(119, 19);
            this.lblBSubscriber.TabIndex = 35;
            this.lblBSubscriber.Text = "B-Subscriber:";
            // 
            // tbxBSubscriber
            // 
            this.tbxBSubscriber.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxBSubscriber.Location = new System.Drawing.Point(28, 122);
            this.tbxBSubscriber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxBSubscriber.Name = "tbxBSubscriber";
            this.tbxBSubscriber.Size = new System.Drawing.Size(76, 27);
            this.tbxBSubscriber.TabIndex = 33;
            this.tbxBSubscriber.Text = "102";
            this.tbxBSubscriber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGETCalls
            // 
            this.btnGETCalls.Location = new System.Drawing.Point(21, 213);
            this.btnGETCalls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGETCalls.Name = "btnGETCalls";
            this.btnGETCalls.Size = new System.Drawing.Size(157, 78);
            this.btnGETCalls.TabIndex = 4;
            this.btnGETCalls.Text = "GET\r\nCalls";
            this.btnGETCalls.UseVisualStyleBackColor = true;
            this.btnGETCalls.Click += new System.EventHandler(this.btnGETCalls_Click);
            // 
            // btnDELETECallId
            // 
            this.btnDELETECallId.Location = new System.Drawing.Point(401, 308);
            this.btnDELETECallId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDELETECallId.Name = "btnDELETECallId";
            this.btnDELETECallId.Size = new System.Drawing.Size(157, 78);
            this.btnDELETECallId.TabIndex = 36;
            this.btnDELETECallId.Text = "DELETE\r\nCall Id";
            this.btnDELETECallId.UseVisualStyleBackColor = true;
            this.btnDELETECallId.Click += new System.EventHandler(this.btnDELETECallId_Click);
            // 
            // btnDELETECalls
            // 
            this.btnDELETECalls.Location = new System.Drawing.Point(401, 213);
            this.btnDELETECalls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDELETECalls.Name = "btnDELETECalls";
            this.btnDELETECalls.Size = new System.Drawing.Size(157, 78);
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
            this.gbxDevice.Location = new System.Drawing.Point(1053, 226);
            this.gbxDevice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxDevice.Name = "gbxDevice";
            this.gbxDevice.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxDevice.Size = new System.Drawing.Size(339, 394);
            this.gbxDevice.TabIndex = 46;
            this.gbxDevice.TabStop = false;
            this.gbxDevice.Text = "Device (n/a)";
            // 
            // btnPOSTDeviceGPO
            // 
            this.btnPOSTDeviceGPO.Location = new System.Drawing.Point(24, 30);
            this.btnPOSTDeviceGPO.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPOSTDeviceGPO.Name = "btnPOSTDeviceGPO";
            this.btnPOSTDeviceGPO.Size = new System.Drawing.Size(171, 78);
            this.btnPOSTDeviceGPO.TabIndex = 39;
            this.btnPOSTDeviceGPO.Text = "POST\r\nDevice GPO";
            this.btnPOSTDeviceGPO.UseVisualStyleBackColor = true;
            this.btnPOSTDeviceGPO.Click += new System.EventHandler(this.btnPOSTDeviceGPO_Click);
            // 
            // tbxGPIDevice
            // 
            this.tbxGPIDevice.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxGPIDevice.Location = new System.Drawing.Point(213, 257);
            this.tbxGPIDevice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxGPIDevice.Name = "tbxGPIDevice";
            this.tbxGPIDevice.Size = new System.Drawing.Size(76, 27);
            this.tbxGPIDevice.TabIndex = 37;
            this.tbxGPIDevice.Text = "101";
            this.tbxGPIDevice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblGPIDevice
            // 
            this.lblGPIDevice.AutoSize = true;
            this.lblGPIDevice.Location = new System.Drawing.Point(211, 236);
            this.lblGPIDevice.Name = "lblGPIDevice";
            this.lblGPIDevice.Size = new System.Drawing.Size(94, 19);
            this.lblGPIDevice.TabIndex = 38;
            this.lblGPIDevice.Text = "GPI Device";
            // 
            // tbxGPODevice
            // 
            this.tbxGPODevice.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxGPODevice.Location = new System.Drawing.Point(213, 158);
            this.tbxGPODevice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxGPODevice.Name = "tbxGPODevice";
            this.tbxGPODevice.Size = new System.Drawing.Size(76, 27);
            this.tbxGPODevice.TabIndex = 35;
            this.tbxGPODevice.Text = "101";
            this.tbxGPODevice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblGPODevice
            // 
            this.lblGPODevice.AutoSize = true;
            this.lblGPODevice.Location = new System.Drawing.Point(211, 135);
            this.lblGPODevice.Name = "lblGPODevice";
            this.lblGPODevice.Size = new System.Drawing.Size(103, 19);
            this.lblGPODevice.TabIndex = 36;
            this.lblGPODevice.Text = "GPO Device";
            // 
            // btnGETDeviceGPIOs
            // 
            this.btnGETDeviceGPIOs.Location = new System.Drawing.Point(24, 230);
            this.btnGETDeviceGPIOs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGETDeviceGPIOs.Name = "btnGETDeviceGPIOs";
            this.btnGETDeviceGPIOs.Size = new System.Drawing.Size(171, 78);
            this.btnGETDeviceGPIOs.TabIndex = 4;
            this.btnGETDeviceGPIOs.Text = "GET\r\n Device GPIs";
            this.btnGETDeviceGPIOs.UseVisualStyleBackColor = true;
            // 
            // btnGETDeviceGPOs
            // 
            this.btnGETDeviceGPOs.Location = new System.Drawing.Point(24, 130);
            this.btnGETDeviceGPOs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGETDeviceGPOs.Name = "btnGETDeviceGPOs";
            this.btnGETDeviceGPOs.Size = new System.Drawing.Size(171, 78);
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
            this.grbEvent.Location = new System.Drawing.Point(1419, 226);
            this.grbEvent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbEvent.Name = "grbEvent";
            this.grbEvent.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbEvent.Size = new System.Drawing.Size(480, 394);
            this.grbEvent.TabIndex = 47;
            this.grbEvent.TabStop = false;
            this.grbEvent.Text = "Events (WAMP Interface)";
            // 
            // cbxOpenDoorEvent
            // 
            this.cbxOpenDoorEvent.AutoSize = true;
            this.cbxOpenDoorEvent.Location = new System.Drawing.Point(23, 279);
            this.cbxOpenDoorEvent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxOpenDoorEvent.Name = "cbxOpenDoorEvent";
            this.cbxOpenDoorEvent.Size = new System.Drawing.Size(167, 23);
            this.cbxOpenDoorEvent.TabIndex = 32;
            this.cbxOpenDoorEvent.Text = "Open Door Event";
            this.cbxOpenDoorEvent.UseVisualStyleBackColor = true;
            this.cbxOpenDoorEvent.CheckedChanged += new System.EventHandler(this.cbxOpenDoorEvent_CheckedChanged);
            // 
            // cbxDeviceGPIStatusEvent
            // 
            this.cbxDeviceGPIStatusEvent.AutoSize = true;
            this.cbxDeviceGPIStatusEvent.Location = new System.Drawing.Point(23, 230);
            this.cbxDeviceGPIStatusEvent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxDeviceGPIStatusEvent.Name = "cbxDeviceGPIStatusEvent";
            this.cbxDeviceGPIStatusEvent.Size = new System.Drawing.Size(263, 23);
            this.cbxDeviceGPIStatusEvent.TabIndex = 31;
            this.cbxDeviceGPIStatusEvent.Text = "Device GPI Status Event (n/a)";
            this.cbxDeviceGPIStatusEvent.UseVisualStyleBackColor = true;
            this.cbxDeviceGPIStatusEvent.CheckedChanged += new System.EventHandler(this.cbxDeviceGPIStatusEvent_CheckedChanged);
            // 
            // cbxDeviceGPOStatusEvent
            // 
            this.cbxDeviceGPOStatusEvent.AutoSize = true;
            this.cbxDeviceGPOStatusEvent.Location = new System.Drawing.Point(23, 177);
            this.cbxDeviceGPOStatusEvent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxDeviceGPOStatusEvent.Name = "cbxDeviceGPOStatusEvent";
            this.cbxDeviceGPOStatusEvent.Size = new System.Drawing.Size(272, 23);
            this.cbxDeviceGPOStatusEvent.TabIndex = 30;
            this.cbxDeviceGPOStatusEvent.Text = "Device GPO Status Event (n/a)";
            this.cbxDeviceGPOStatusEvent.UseVisualStyleBackColor = true;
            this.cbxDeviceGPOStatusEvent.CheckedChanged += new System.EventHandler(this.cbxDeviceGPOStatusEvent_CheckedChanged);
            // 
            // cbxCallStatusEvent
            // 
            this.cbxCallStatusEvent.AutoSize = true;
            this.cbxCallStatusEvent.Location = new System.Drawing.Point(23, 34);
            this.cbxCallStatusEvent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxCallStatusEvent.Name = "cbxCallStatusEvent";
            this.cbxCallStatusEvent.Size = new System.Drawing.Size(166, 23);
            this.cbxCallStatusEvent.TabIndex = 27;
            this.cbxCallStatusEvent.Text = "Call Status Event";
            this.cbxCallStatusEvent.UseVisualStyleBackColor = true;
            this.cbxCallStatusEvent.CheckedChanged += new System.EventHandler(this.cbxCallStatusEvent_CheckedChanged);
            // 
            // cbxDeviceRegistrationEvent
            // 
            this.cbxDeviceRegistrationEvent.AutoSize = true;
            this.cbxDeviceRegistrationEvent.Location = new System.Drawing.Point(23, 126);
            this.cbxDeviceRegistrationEvent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxDeviceRegistrationEvent.Name = "cbxDeviceRegistrationEvent";
            this.cbxDeviceRegistrationEvent.Size = new System.Drawing.Size(234, 23);
            this.cbxDeviceRegistrationEvent.TabIndex = 29;
            this.cbxDeviceRegistrationEvent.Text = "Device Registration Event";
            this.cbxDeviceRegistrationEvent.UseVisualStyleBackColor = true;
            this.cbxDeviceRegistrationEvent.CheckedChanged += new System.EventHandler(this.cbxDeviceRegistrationEvent_CheckedChanged);
            // 
            // cbxCallLegStatusEvent
            // 
            this.cbxCallLegStatusEvent.AutoSize = true;
            this.cbxCallLegStatusEvent.Location = new System.Drawing.Point(23, 79);
            this.cbxCallLegStatusEvent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxCallLegStatusEvent.Name = "cbxCallLegStatusEvent";
            this.cbxCallLegStatusEvent.Size = new System.Drawing.Size(200, 23);
            this.cbxCallLegStatusEvent.TabIndex = 28;
            this.cbxCallLegStatusEvent.Text = "Call Leg Status Event";
            this.cbxCallLegStatusEvent.UseVisualStyleBackColor = true;
            this.cbxCallLegStatusEvent.CheckedChanged += new System.EventHandler(this.cbxCallQueueStatusEvent_CheckedChanged);
            // 
            // grpbxRegistratedDevices
            // 
            this.grpbxRegistratedDevices.Controls.Add(this.btnClearList);
            this.grpbxRegistratedDevices.Controls.Add(this.dgrd_Registrations);
            this.grpbxRegistratedDevices.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxRegistratedDevices.Location = new System.Drawing.Point(24, 646);
            this.grpbxRegistratedDevices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpbxRegistratedDevices.Name = "grpbxRegistratedDevices";
            this.grpbxRegistratedDevices.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpbxRegistratedDevices.Size = new System.Drawing.Size(1009, 318);
            this.grpbxRegistratedDevices.TabIndex = 48;
            this.grpbxRegistratedDevices.TabStop = false;
            this.grpbxRegistratedDevices.Text = "Registered Devices";
            // 
            // btnClearList
            // 
            this.btnClearList.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearList.Location = new System.Drawing.Point(877, 250);
            this.btnClearList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(109, 39);
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
            this.dgrd_Registrations.Location = new System.Drawing.Point(21, 25);
            this.dgrd_Registrations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgrd_Registrations.Name = "dgrd_Registrations";
            this.dgrd_Registrations.RowHeadersWidth = 51;
            this.dgrd_Registrations.RowTemplate.Height = 24;
            this.dgrd_Registrations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgrd_Registrations.Size = new System.Drawing.Size(825, 265);
            this.dgrd_Registrations.TabIndex = 16;
            // 
            // dgrdDirNo
            // 
            this.dgrdDirNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgrdDirNo.HeaderText = "Dir. No";
            this.dgrdDirNo.MinimumWidth = 60;
            this.dgrdDirNo.Name = "dgrdDirNo";
            this.dgrdDirNo.Width = 92;
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
            this.gbxNetInterfaces.Location = new System.Drawing.Point(25, 969);
            this.gbxNetInterfaces.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxNetInterfaces.Name = "gbxNetInterfaces";
            this.gbxNetInterfaces.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxNetInterfaces.Size = new System.Drawing.Size(1008, 194);
            this.gbxNetInterfaces.TabIndex = 49;
            this.gbxNetInterfaces.TabStop = false;
            this.gbxNetInterfaces.Text = "Net Interfaces";
            // 
            // btnClearNetInterfaces
            // 
            this.btnClearNetInterfaces.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearNetInterfaces.Location = new System.Drawing.Point(876, 138);
            this.btnClearNetInterfaces.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClearNetInterfaces.Name = "btnClearNetInterfaces";
            this.btnClearNetInterfaces.Size = new System.Drawing.Size(109, 39);
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
            this.dgrdNetInterfaces.Location = new System.Drawing.Point(21, 30);
            this.dgrdNetInterfaces.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgrdNetInterfaces.Name = "dgrdNetInterfaces";
            this.dgrdNetInterfaces.RowHeadersWidth = 51;
            this.dgrdNetInterfaces.RowTemplate.Height = 24;
            this.dgrdNetInterfaces.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgrdNetInterfaces.Size = new System.Drawing.Size(824, 148);
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
            this.gbxActiveCalls.Location = new System.Drawing.Point(1053, 644);
            this.gbxActiveCalls.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxActiveCalls.Name = "gbxActiveCalls";
            this.gbxActiveCalls.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxActiveCalls.Size = new System.Drawing.Size(844, 279);
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
            this.dgrdActiveCalls.Location = new System.Drawing.Point(20, 30);
            this.dgrdActiveCalls.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgrdActiveCalls.Name = "dgrdActiveCalls";
            this.dgrdActiveCalls.RowHeadersWidth = 51;
            this.dgrdActiveCalls.RowTemplate.Height = 24;
            this.dgrdActiveCalls.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgrdActiveCalls.Size = new System.Drawing.Size(803, 229);
            this.dgrdActiveCalls.TabIndex = 17;
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
            // gbxQueuedCalls
            // 
            this.gbxQueuedCalls.Controls.Add(this.dgrdQueuedCalls);
            this.gbxQueuedCalls.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxQueuedCalls.Location = new System.Drawing.Point(1055, 948);
            this.gbxQueuedCalls.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxQueuedCalls.Name = "gbxQueuedCalls";
            this.gbxQueuedCalls.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxQueuedCalls.Size = new System.Drawing.Size(843, 215);
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
            this.dgrdQueuedCalls.Location = new System.Drawing.Point(19, 41);
            this.dgrdQueuedCalls.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgrdQueuedCalls.Name = "dgrdQueuedCalls";
            this.dgrdQueuedCalls.RowHeadersWidth = 51;
            this.dgrdQueuedCalls.RowTemplate.Height = 24;
            this.dgrdQueuedCalls.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgrdQueuedCalls.Size = new System.Drawing.Size(803, 158);
            this.dgrdQueuedCalls.TabIndex = 17;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1913, 1177);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Zenitel Connect REST API SDK";
            this.gbxAuthentication.ResumeLayout(false);
            this.gbxAuthentication.PerformLayout();
            this.gbxLogging.ResumeLayout(false);
            this.gbxLogging.PerformLayout();
            this.gbxSwaggerSystem.ResumeLayout(false);
            this.gbxCallControl.ResumeLayout(false);
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
    }
}

