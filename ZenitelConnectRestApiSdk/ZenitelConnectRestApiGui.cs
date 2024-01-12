using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Rest.Api.Client;
using LogManager;
using Wamp.Client;

namespace Zenitel.Connect.RestApi.Sdk
{
    public partial class MainForm : Form
    {
        private LoggingWindow loggingWindow = null;
        private RestApiClient restApiClient = null;
        private WampClient    wampClient    = null;

        private string Zenitel_Connect_RestApi_SDK_Version = System.Diagnostics.FileVersionInfo.GetVersionInfo(
                                        System.Reflection.Assembly.GetExecutingAssembly().Location).ProductVersion;
        private string SW_Version;
        private string LogFilePath;
        private string LogFileName;

        /***********************************************************************************************************************/
        public MainForm()
        /***********************************************************************************************************************/
        {
            InitializeComponent();

            SW_Version = "Zenitel Connect REST API SDK version " + Zenitel_Connect_RestApi_SDK_Version;
            this.Text = SW_Version;

            LogFilePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) +
                                 "\\Zenitel\\Zenitel_Connect_RestApi_SDK\\Log";

            LogFileName = "Zenitel_Connect_RestApi_";
            LogMan.Instance.CreateLog(true, 30, LogFilePath, LogFileName);
            addToLog(SW_Version);

            lblLogFileSavingLocation.Text = "Location: " + LogFilePath;


            // REST API Connection
            restApiClient = new RestApiClient();
            restApiClient.OnDebugString += RestApiClient_OnDebugString;

            // WAMP API Connection
            wampClient = new WampClient();

            wampClient.OnConnectChanged += WampConnection_OnConnectChanged;
            wampClient.OnError += WampConnection_OnError;
            wampClient.OnChildLogString += wampClient_OnChildLogString;

            wampClient.OnWampCallStatusEvent         += wampClient_OnWampCallStatusEvent;
            wampClient.OnWampCallLegStatusEvent      += wampClient_OnWampCallLegStatusEvent;
            wampClient.OnWampDeviceRegistrationEvent += wampClient_OnWampDeviceRegistrationEvent;
            wampClient.OnWampOpenDoorEvent           += wampClient_OnWampOpenDoorEvent;
            wampClient.OnWampDeviceGPIStatusEvent    += wampClient_OnWampDeviceGPIStatusEvent;
            wampClient.OnWampDeviceGPOStatusEvent    += wampClient_OnWampDeviceGPOStatusEvent;

            UpdateConnectState();

            chbxEncrypted.Checked = true;
            chbxUnencrypted.Checked = false;

            cmbxCallAction.Items.Add(RestApiClient.CallAction.setup.ToString());
            cmbxCallAction.Items.Add(RestApiClient.CallAction.answer.ToString());

            cmbxCallAction.SelectedIndex = 0;
        }


        /***********************************************************************************************************************/
        private void UpdateConnectState()
        /***********************************************************************************************************************/
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(UpdateConnectState));
                return;
            }

            if (wampClient.IsConnected)
            {
                tbxConnectionStatus.Text = "Connected";

                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;

                btnGETDeviceAccounts.Enabled = true;
                btnGETNetInterface.Enabled = true;

                btnPOSTCalls.Enabled = true;
                btnDELETECalls.Enabled = true;
                btnDELETECallId.Enabled = true;
                btnGETCalls.Enabled = true;

                // Currently not available
                //btnPOSTDeviceGPO.Enabled = true;
                //btnGETDeviceGPOs.Enabled = true;
                //btnGETDeviceGPIOs.Enabled = true;

                //Clear Check Marks
                cbxCallLegStatusEvent.Checked = false;
                cbxCallStatusEvent.Checked = false;
                cbxDeviceRegistrationEvent.Checked = false;

                cbxDeviceGPOStatusEvent.Checked = false;
                cbxDeviceGPIStatusEvent.Checked = false;
                cbxOpenDoorEvent.Checked = false;

                //Enable Check Fields
                cbxCallLegStatusEvent.Enabled = true;
                cbxCallStatusEvent.Enabled = true;
                cbxDeviceRegistrationEvent.Enabled = true;

                // Currently not available
                //cbxDeviceGPOStatusEvent.Enabled = true;
                //cbxDeviceGPIStatusEvent.Enabled = true;

                cbxOpenDoorEvent.Enabled = true;

                if (cbxCallStatusEvent.Checked)
                {
                    addToLog("Subscribe Call Events.");
                    wampClient.TraceCallEvent();
                }
                if (cbxCallLegStatusEvent.Checked)
                {
                    addToLog("Subscribe Call Leg Status Events.");
                    wampClient.TraceCallLegEvent();
                }
                if (cbxDeviceRegistrationEvent.Checked)
                {
                    addToLog("Subscribe Device Registration Events.");
                    wampClient.TraceDeviceRegistrationEvent();
                }
            }
            else
            {
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;

                btnGETDeviceAccounts.Enabled = false;
                btnGETNetInterface.Enabled = false;

                btnPOSTCalls.Enabled = false;
                btnDELETECalls.Enabled = false;
                btnDELETECallId.Enabled = false;
                btnGETCalls.Enabled = false;

                btnPOSTDeviceGPO.Enabled = false;
                btnGETDeviceGPOs.Enabled = false;
                btnGETDeviceGPIOs.Enabled = false;

                //Enable Check Fields
                cbxCallLegStatusEvent.Enabled = false;
                cbxCallStatusEvent.Enabled = false;
                cbxDeviceRegistrationEvent.Enabled = false;

                cbxDeviceGPOStatusEvent.Enabled = false;
                cbxDeviceGPIStatusEvent.Enabled = false;
                cbxOpenDoorEvent.Enabled = false;
            }
        }


        /***********************************************************************************************************************/
        private void WampConnection_OnConnectChanged(object sender, bool e)
        /***********************************************************************************************************************/
        {
            UpdateConnectState();
        }


        private delegate void WampConnection_OnErrorCallBack(object sender, string e);

        /***********************************************************************************************************************/
        private void WampConnection_OnError(object sender, string e)
        /***********************************************************************************************************************/
        {
            if (InvokeRequired)
            {
                WampConnection_OnErrorCallBack callBack = new WampConnection_OnErrorCallBack(WampConnection_OnError);
                this.Invoke(callBack, new object[] { sender, e });
            }
            else
            {

            }
        }


        /***********************************************************************************************************************/
        protected override void OnClosed(EventArgs e)
        /***********************************************************************************************************************/
        {
            if (wampClient.IsConnected)
            {
                wampClient.Stop();
            }
            base.OnClosed(e);
        }


        /***********************************************************************************************************************/
        private void wampClient_OnChildLogString(object sender, string e)
        /***********************************************************************************************************************/
        {
            addToLog(e);
        }


        #region  ----------  Subscripted WAMP Event Handling Methods  ----------

        private delegate void wampClient_OnWampCallStatusEventCallBack(object sender, WampClient.wamp_call_element callUpd);

        /***********************************************************************************************************************/
        private void wampClient_OnWampCallStatusEvent(object sender, WampClient.wamp_call_element callUpd)
        /***********************************************************************************************************************/
        {
            try
            {
                if (this.dgrdActiveCalls.InvokeRequired)
                {
                    wampClient_OnWampCallStatusEventCallBack cb =
                        new wampClient_OnWampCallStatusEventCallBack(wampClient_OnWampCallStatusEvent);

                    this.Invoke(cb, new object[] { sender, callUpd });
                }
                else
                {
                    string txt = "SDK-Event. Call State Update: Call from " + callUpd.from_dirno + " to dir-no " + callUpd.to_dirno +
                         ". State = " + callUpd.state + ". id = " + callUpd.call_id;

                    addToLog(txt);

                    bool found = false;
                    int i = 0;
                    int i_save = 0;

                    if (callUpd.call_type.Equals("normal_call"))
                    {
                        addToLog("Normal Call");

                        while ((i < dgrdActiveCalls.Rows.Count) && (!found))
                        {
                            if (string.Compare(dgrdActiveCalls.Rows[i].Cells[3].Value.ToString(), callUpd.call_id) == 0)
                            {
                                found = true;
                                i_save = i;
                            }
                            i++;
                        }

                        if (found)
                        {
                            addToLog(string.Format("Call Found at index: {0}", i_save));

                            if (callUpd.state.Equals("ended"))
                            {
                                dgrdActiveCalls.Rows.RemoveAt(i_save);
                            }
                            else
                            {
                                addToLog("Normal Call - Update call.");

                                // Update call found
                                if (!string.IsNullOrEmpty(callUpd.from_dirno))
                                {
                                    dgrdActiveCalls.Rows[i_save].Cells[0].Value = callUpd.from_dirno;
                                }
                                if (!string.IsNullOrEmpty(callUpd.to_dirno))
                                {
                                    dgrdActiveCalls.Rows[i_save].Cells[1].Value = callUpd.to_dirno_current;
                                }
                                if (!string.IsNullOrEmpty(callUpd.state))
                                {
                                    dgrdActiveCalls.Rows[i_save].Cells[2].Value = callUpd.state;
                                }
                                if (!string.IsNullOrEmpty(callUpd.call_id))
                                {
                                    dgrdActiveCalls.Rows[i_save].Cells[3].Value = callUpd.call_id;
                                }
                            }
                        }
                        else
                        {
                            addToLog("Normal Call - New call.");

                            // This is a new call
                            if (!callUpd.state.Equals("ended"))
                            {
                                addToLog("Normal Call - Not a call ended.");

                                // Do not insert a call that has already been removed
                                // See if transfered from queueud call to narmal call

                                found = false;
                                i = 0;
                                i_save = 0;


                                // See if call id is in the queued calls
                                while ((i < dgrdQueuedCalls.Rows.Count) && (!found))
                                {
                                    if (string.Compare(dgrdQueuedCalls.Rows[i].Cells[3].Value.ToString(), callUpd.call_id) == 0)
                                    {

                                        if ((string.Compare(dgrdQueuedCalls.Rows[i].Cells[0].Value.ToString(), callUpd.from_dirno) == 0) &&
                                            (string.Compare(dgrdQueuedCalls.Rows[i].Cells[1].Value.ToString(), callUpd.to_dirno) == 0))
                                        {
                                            found = true;
                                            i_save = i;
                                        }
                                    }
                                    i++;
                                }

                                if (found)
                                {
                                    addToLog("Normal Call. Call removed from queued calls.");
                                    dgrdQueuedCalls.Rows.RemoveAt(i_save);
                                }
                                else
                                {
                                    addToLog("Normal Call - Not in the queued calls.");
                                }

                                string[] row = { callUpd.from_dirno, callUpd.to_dirno_current, callUpd.state, callUpd.call_id };
                                dgrdActiveCalls.Rows.Add(row);
                            }
                        }
                    }

                    else if (callUpd.call_type.Equals("queue_call"))
                    {
                        found = false;
                        i = 0;
                        i_save = 0;

                        while ((i < dgrdQueuedCalls.Rows.Count) && (!found))
                        {
                            if ((string.Compare(dgrdQueuedCalls.Rows[i].Cells[0].Value.ToString(), callUpd.from_dirno) == 0) &&
                                (string.Compare(dgrdQueuedCalls.Rows[i].Cells[1].Value.ToString(), callUpd.to_dirno) == 0))
                            {
                                found = true;
                                i_save = i;
                            }
                            i++;
                        }

                        if (found)
                        {
                            addToLog(string.Format("Call Found at index: {0}", i_save));

                            if (callUpd.state.Equals("in_call") ||
                                callUpd.state.Equals("ended"))
                            {
                                addToLog("Queued Call. Call is removed.");
                                dgrdQueuedCalls.Rows.RemoveAt(i_save);
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(callUpd.from_dirno))
                                {
                                    dgrdQueuedCalls.Rows[i_save].Cells[0].Value = callUpd.from_dirno;
                                }
                                if (!string.IsNullOrEmpty(callUpd.to_dirno))
                                {
                                    dgrdQueuedCalls.Rows[i_save].Cells[1].Value = callUpd.to_dirno;
                                }
                                if (!string.IsNullOrEmpty(callUpd.state))
                                {
                                    dgrdQueuedCalls.Rows[i_save].Cells[2].Value = callUpd.state;
                                }
                                if (!string.IsNullOrEmpty(callUpd.call_id))
                                {
                                    dgrdQueuedCalls.Rows[i_save].Cells[3].Value = callUpd.call_id;
                                }
                            }
                        }
                        else
                        {
                            if (!callUpd.state.Equals("ended"))
                            {
                                string[] row = { callUpd.from_dirno, callUpd.to_dirno, callUpd.state, callUpd.call_id };
                                dgrdQueuedCalls.Rows.Add(row);
                            }
                        }
                    }
                }
 
            }
            catch (Exception ex)
            {
                string txt = "Exception in wampClient_OnWampCallStatusEvent: " + ex.ToString();
                addToLog(txt);
            }
        }



        private delegate void _wampConnection_OnWampCallLegStatusEventCallBack(object sender, WampClient.wamp_call_leg_element callLegStatus);

        /***********************************************************************************************************************/
        private void wampClient_OnWampCallLegStatusEvent(object sender, WampClient.wamp_call_leg_element callLegStatus)
        /***********************************************************************************************************************/
        {
            try
            {
                if (InvokeRequired)
                {
                    _wampConnection_OnWampCallLegStatusEventCallBack cb =
                       new _wampConnection_OnWampCallLegStatusEventCallBack(wampClient_OnWampCallLegStatusEvent);

                    this.Invoke(cb, new object[] { sender, callLegStatus });
                }
                else
                {
                    string txt = "SDK. Call Leg State Update: " +
                                 "  call_id " + callLegStatus.call_id +
                                 ". call_type: " + callLegStatus.call_type +
                                 ". channel: " + callLegStatus.channel +
                                 ". dirno: " + callLegStatus.dirno +
                                 ". from_dirno: " + callLegStatus.from_dirno +
                                 ". leg_id: " + callLegStatus.leg_id +
                                 ". leg_role: " + callLegStatus.leg_role +
                                 ". priority: " + callLegStatus.priority +
                                 ". reason: " + callLegStatus.reason +
                                 ". state: " + callLegStatus.state +
                                 ". to_dirno: " + callLegStatus.to_dirno;

                    addToLog(txt);


                    bool found = false;
                    int i = 0;
                    int i_save = 0;

                    if (callLegStatus.call_type.Equals("normal_call"))
                    {
                        addToLog("Normal Call");

                        if (callLegStatus.leg_role.Equals("callee"))
                        {

                            while ((i < dgrdActiveCalls.Rows.Count) && (!found))
                            {
                                if (string.Compare(dgrdActiveCalls.Rows[i].Cells[3].Value.ToString(), callLegStatus.call_id) == 0)
                                {
                                    found = true;
                                    i_save = i;
                                }
                                i++;
                            }

                            if (found)
                            {
                                addToLog(string.Format("Normal Call Found at index: {0}", i_save));

                                if (callLegStatus.state.Equals("ended"))
                                {
                                    addToLog("Normal Call - Ended");
                                    dgrdActiveCalls.Rows.RemoveAt(i_save);
                                }
                                else
                                {
                                    addToLog("Normal Call - Update call.");

                                    // Update call found
                                    if (!string.IsNullOrEmpty(callLegStatus.from_dirno))
                                    {
                                        dgrdActiveCalls.Rows[i_save].Cells[0].Value = callLegStatus.from_dirno;
                                    }
                                    if (!string.IsNullOrEmpty(callLegStatus.to_dirno))
                                    {
                                        dgrdActiveCalls.Rows[i_save].Cells[1].Value = callLegStatus.to_dirno;
                                    }
                                    if (!string.IsNullOrEmpty(callLegStatus.state))
                                    {
                                        dgrdActiveCalls.Rows[i_save].Cells[2].Value = callLegStatus.state;
                                    }
                                    if (!string.IsNullOrEmpty(callLegStatus.call_id))
                                    {
                                        dgrdActiveCalls.Rows[i_save].Cells[3].Value = callLegStatus.call_id;
                                    }

                                    found = false;
                                    i = 0;
                                    i_save = 0;


                                    // See if call id is in the queued calls
                                    while ((i < dgrdQueuedCalls.Rows.Count) && (!found))
                                    {
                                        if (string.Compare(dgrdQueuedCalls.Rows[i].Cells[3].Value.ToString(), callLegStatus.call_id) == 0)
                                        {

                                            if ((string.Compare(dgrdQueuedCalls.Rows[i].Cells[0].Value.ToString(), callLegStatus.from_dirno) == 0) &&
                                                 (string.Compare(dgrdQueuedCalls.Rows[i].Cells[1].Value.ToString(), callLegStatus.dirno) == 0))
                                            {
                                                found = true;
                                                i_save = i;
                                            }
                                        }
                                        i++;
                                    }

                                    if (found)
                                    {
                                        addToLog("Normal Call. Call removed from queued calls.");
                                        dgrdQueuedCalls.Rows.RemoveAt(i_save);
                                    }
                                    else
                                    {
                                        addToLog("Normal Call - Not in the queued calls.");
                                    }
                                }
                            }
                            else
                            {
                                addToLog("Normal Call - New call.");

                                // This is a new call
                                if (!callLegStatus.state.Equals("ended"))
                                {
                                    addToLog("Normal Call - Not a call ended.");

                                    // Do not insert a call that has already been removed
                                    // See if transfered from queueud call to narmal call

                                    found = false;
                                    i = 0;
                                    i_save = 0;


                                    // See if call id is in the queued calls
                                    while ((i < dgrdQueuedCalls.Rows.Count) && (!found))
                                    {
                                        if (string.Compare(dgrdQueuedCalls.Rows[i].Cells[3].Value.ToString(), callLegStatus.call_id) == 0)
                                        {

                                            if ((string.Compare(dgrdQueuedCalls.Rows[i].Cells[0].Value.ToString(), callLegStatus.from_dirno) == 0) &&
                                                 (string.Compare(dgrdQueuedCalls.Rows[i].Cells[1].Value.ToString(), callLegStatus.dirno) == 0))
                                            {
                                                found = true;
                                                i_save = i;
                                            }
                                        }
                                        i++;
                                    }

                                    if (found)
                                    {
                                        addToLog("Normal Call. Call removed from queued calls.");
                                        dgrdQueuedCalls.Rows.RemoveAt(i_save);
                                    }
                                    else
                                    {
                                        addToLog("Normal Call - Not in the queued calls.");
                                    }

                                    string[] row = { callLegStatus.from_dirno, callLegStatus.dirno, callLegStatus.state, callLegStatus.call_id };
                                    dgrdActiveCalls.Rows.Add(row);
                                }
                            }
                        }
                        else
                        {
                            found = false;

                            // See if call id is in the queued calls
                            while ((i < dgrdQueuedCalls.Rows.Count) && (!found))
                            {
                                if (string.Compare(dgrdQueuedCalls.Rows[i].Cells[3].Value.ToString(), callLegStatus.call_id) == 0)
                                {
                                    found = true;
                                    i_save = i;
                                }
                                i++;
                            }

                            if (found)
                            {
                                if (callLegStatus.state.Equals("in_call"))
                                {
                                    addToLog("Normal Call - Queued call answered");
                                    dgrdQueuedCalls.Rows.RemoveAt(i_save);
                                }
                            }
                        }
                    }

                    else if (callLegStatus.call_type.Equals("queue_call"))
                    {
                        addToLog("Normal Call");

                        if (callLegStatus.leg_role.Equals("callee"))
                        {
                            found = false;
                            i = 0;
                            i_save = 0;

                            while ((i < dgrdQueuedCalls.Rows.Count) && (!found))
                            {
                                if ((string.Compare(dgrdQueuedCalls.Rows[i].Cells[0].Value.ToString(), callLegStatus.from_dirno) == 0) &&
                                     (string.Compare(dgrdQueuedCalls.Rows[i].Cells[1].Value.ToString(), callLegStatus.dirno) == 0))
                                {
                                    found = true;
                                    i_save = i;
                                }
                                i++;
                            }

                            if (found)
                            {
                                addToLog(string.Format("Call Found at index: {0}", i_save));

                                if (callLegStatus.state.Equals("in_call") ||
                                     callLegStatus.state.Equals("ended"))
                                {
                                    addToLog("Queued Call. Call is removed.");
                                    dgrdQueuedCalls.Rows.RemoveAt(i_save);
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(callLegStatus.from_dirno))
                                    {
                                        dgrdQueuedCalls.Rows[i_save].Cells[0].Value = callLegStatus.from_dirno;
                                    }
                                    if (!string.IsNullOrEmpty(callLegStatus.dirno))
                                    {
                                        dgrdQueuedCalls.Rows[i_save].Cells[1].Value = callLegStatus.dirno;
                                    }
                                    if (!string.IsNullOrEmpty(callLegStatus.state))
                                    {
                                        dgrdQueuedCalls.Rows[i_save].Cells[2].Value = callLegStatus.state;
                                    }
                                    if (!string.IsNullOrEmpty(callLegStatus.call_id))
                                    {
                                        dgrdQueuedCalls.Rows[i_save].Cells[3].Value = callLegStatus.call_id;
                                    }
                                }
                            }
                            else
                            {
                                if (!callLegStatus.state.Equals("ended"))
                                {
                                    string[] row = { callLegStatus.from_dirno, callLegStatus.dirno, callLegStatus.state, callLegStatus.call_id };
                                    dgrdQueuedCalls.Rows.Add(row);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string txt = "Exception in btnGetCallQueued_Clic: " + ex.ToString();
                addToLog(txt);
            }
        }


        /***********************************************************************************************************************/
        private void wampClient_OnWampOpenDoorEvent(object sender, WampClient.wamp_open_door_event doorOpenEvent)
        /***********************************************************************************************************************/
        {
            string txt = "SDK. Device Open Door Event: from_dirno: " + doorOpenEvent.from_dirno + ". from_name: " + doorOpenEvent.from_name +
                                                    ". door_dirno: " + doorOpenEvent.door_dirno + ". door_name: " + doorOpenEvent.door_name;
            addToLog(txt);
        }




        /*****************************************************************************************/
        private void wampClient_OnWampDeviceGPOStatusEvent(object sender, WampClient.wamp_device_gpio_element e)
        /*****************************************************************************************/
        {
            try
            {
                string txt = "SDK. GPO Event: id: " + e.id + ". state: " + e.state + ". Type: " + e.type;
            }
            catch (Exception ex)
            {
                string txt = "Exception in wampClient_OnWampDeviceGPOStatusEvent: " + ex.ToString();
                addToLog(txt);
            }
        }


        /*****************************************************************************************/
        private void wampClient_OnWampDeviceGPIStatusEvent(object sender, WampClient.wamp_device_gpio_element e)
        /*****************************************************************************************/
        {
            try
            {
                string txt = "SDK. GPI Event: id: " + e.id + ". state: " + e.state + ". Type: " + e.type;

            }
            catch (Exception ex)
            {
                string txt = "Exception in wampClient_OnWampDeviceGPIStatusEvent: " + ex.ToString();
                addToLog(txt);
            }
        }


        private delegate void wampClient_OnWampDeviceRegistrationEventCallBack(object sender, WampClient.wamp_device_registration_element regUpd);

        /***********************************************************************************************************************/
        private void wampClient_OnWampDeviceRegistrationEvent(object sender, WampClient.wamp_device_registration_element regUpd)
        /***********************************************************************************************************************/
        {
            if (this.dgrd_Registrations.InvokeRequired)
            {
                wampClient_OnWampDeviceRegistrationEventCallBack cb =
                    new wampClient_OnWampDeviceRegistrationEventCallBack(wampClient_OnWampDeviceRegistrationEvent);

                this.Invoke(cb, new object[] { sender, regUpd });
            }
            else
            {
                if (regUpd != null)
                {
                    string txt = "SDK-Event. Device Registration Update: Dir-no " + regUpd.dirno + ". State: " + regUpd.state;
                    addToLog(txt);

                    bool found = false;
                    int i = 0;
                    int i_save = 0;

                    while ((i < (dgrd_Registrations.Rows.Count)) && (!found))
                    {
                        if (string.Compare(dgrd_Registrations.Rows[i].Cells[0].Value.ToString(), regUpd.dirno) == 0)
                        {
                            found = true;
                            i_save = i;
                        }
                        i++;
                    }

                    if (found)
                    {
                        dgrd_Registrations.Rows.RemoveAt(i_save);
                        string[] row = { regUpd.dirno, regUpd.state };
                        dgrd_Registrations.Rows.Add(row);
                    }
                }
            }
        }


        #endregion  ----------  Subscripted WAMP Event Handling Methods  ----------

        private delegate void addToLogCallBack(string txt);

        /***********************************************************************************************************************/
        private void addToLog(string txt)
        /***********************************************************************************************************************/
        {
            if (cbxSaveLoggingToFile.Checked)
            {
                LogMan.Instance.Log(txt);
            }

            if (loggingWindow != null)
            {
                loggingWindow.addToLog(txt);
            }
        }


        /***********************************************************************************************************************/
        private void RestApiClient_OnDebugString(object sender, string e)
        /***********************************************************************************************************************/
        {
            addToLog(e);
        }


        #region  ----------  Button Handling Methods  ----------

        /***********************************************************************************************************************/
        private void btnOpenLoggingWindow_Click(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            if (loggingWindow == null)
            {
                loggingWindow = new LoggingWindow();
                loggingWindow.Show();
            }
            else
            {
                MessageBox.Show("Logging Windows already Opened.");
            }
        }


        /***********************************************************************************************************************/
        private void btnCloseLoggingWindow_Click(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            if (loggingWindow != null)
            {
                loggingWindow.Close();
                loggingWindow = null;
            }
            else
            {
                MessageBox.Show("Logging Windows already Closed.");
            }
        }


        /***********************************************************************************************************************/
        private void btnClearLoggingWindow_Click(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            if (loggingWindow != null)
            {
                loggingWindow.ClearWindow();
            }
        }


        /***********************************************************************************************************************/
        private void cbxSaveLoggingToFile_CheckedChanged(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            if (cbxSaveLoggingToFile.Checked)
            {
                LogMan.Instance.CreateLog(true, 30, LogFilePath, LogFileName);
                addToLog(SW_Version);
            }
        }


        /***********************************************************************************************************************/
        private void btnWampConnect_Click(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            try
            {
                addToLog("REST API connect button activated");

                if (restApiClient == null)
                {
                    restApiClient = new RestApiClient();
                    restApiClient.OnDebugString += RestApiClient_OnDebugString;
                }

                if (restApiClient != null)
                {
                    if (chbxUnencrypted.Checked)
                    {
                        restApiClient.RestApiPortNumber = restApiClient.HttpUnencryptedPort;
                    }
                    else
                    {
                        restApiClient.RestApiPortNumber = restApiClient.HttpEncryptedPort;
                    }

                    restApiClient.ConnectServerAddr = edtConnectServerAddr.Text;
                    restApiClient.UserName          = edtUserName.Text;
                    restApiClient.Password          = edtPassword.Text;
                    restApiClient.Authentication();
                }

                if (wampClient.IsConnected)
                {
                    MessageBox.Show("WAMP already connected.");
                }
                else
                {
                    wampClient.WampServerAddr = edtConnectServerAddr.Text;
                    wampClient.UserName = edtUserName.Text;
                    wampClient.Password = edtPassword.Text;

                    if (chbxUnencrypted.Checked)
                    {
                        wampClient.WampPort = WampClient.WampUnencryptedPort;
                    }
                    else
                    {
                        wampClient.WampPort = WampClient.WampEncryptedPort;
                    }

                    wampClient.WampRealm = edtWampRealm.Text;
                    wampClient.Start();
                }
            }

            catch (Exception ex)
            {
                string txt = "btnAuthentication_Click. Exception: " + ex.ToString();
                addToLog(txt);
            }
        }


        /***********************************************************************************************************************/
        private void btnWampDisconnect_Click(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            if (restApiClient != null)
            {
                restApiClient = null;
            }

            wampClient.Stop();
            tbxConnectionStatus.Text = "Disconnected";
        }


        /***********************************************************************************************************************/
        private void btnGETDeviceAccounts_Click(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            try
            {
                if (restApiClient != null)
                {
                    List<restapi_device_registration_element> registeredDevices = restApiClient.GET_device_accounts();

                    if (registeredDevices != null)
                    {
                        dgrd_Registrations.Rows.Clear();

                        string txt = "SDK. Registered Devices:";
                        addToLog(txt);
                        foreach (restapi_device_registration_element dev in registeredDevices)
                        {
                            txt = ("IP-Address: " + dev.device_ip + "Device-type: " + dev.device_type + "Dir-no: " + dev.dirno +
                                   ". Location: " + dev.location + ". Name: " + dev.name + ". Status: " + dev.state);
                            addToLog(txt);

                            string[] row = { dev.device_ip, dev.device_type, dev.dirno, dev.name, dev.location, dev.state };
                            dgrd_Registrations.Rows.Add(row);
                        }
                    }
                    else
                    {
                        addToLog("No Devices Available.");
                    }
                }
                else
                {
                    MessageBox.Show("Zenitel REST API Client not connected.");
                }
            }

            catch (Exception ex)
            {
                string txt = "btnGET_device_accounts_Click. Exception: " + ex.ToString();
                addToLog(txt);

            }
        }


        /***********************************************************************************************************************/
        private void btnGETNetInterface_Click(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            try
            {
                if (restApiClient != null)
                {
                    List<restapi_interface_list> interfaceList = restApiClient.GET_net_interfaces();

                    if (interfaceList != null)
                    {
                        string txt = "SDK. Interface List:";
                        addToLog(txt);
                        foreach (restapi_interface_list intf in interfaceList)
                        {
                            txt = ("MAC-Addr: " + intf.address + ". IF-Name: " + intf.ifname + ". OperState: " + intf.operstate);
                            addToLog(txt);

                            // Insert new interface element
                            string[] row = { intf.address, intf.ifname, intf.operstate };
                            dgrdNetInterfaces.Rows.Add(row);
                        }
                    }
                    else
                    {
                        addToLog("No Interfaces Available.");
                    }

                }
                else
                {
                    MessageBox.Show("Zenitel REST API Client not connected.");
                }
            }

            catch (Exception ex)
            {
                string txt = "btnGET_net_interfaces_Click. Exception: " + ex.ToString();
                addToLog(txt);
            }
        }


        /***********************************************************************************************************************/
        private void btnClearList_Click(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            dgrd_Registrations.Rows.Clear();
        }


        /***********************************************************************************************************************/
        private void btnClearNetInterfaces_Click(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            dgrdNetInterfaces.Rows.Clear();
        }


        /***********************************************************************************************************************/
        private void btnGETCalls_Click(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            List<restapi_call_element> callList;
            callList = restApiClient.GET_Calls("", "", "");

            if (callList != null)
            {
                if (callList.Count > 0)
                {
                    string txt = "SDK. Call List:";
                    addToLog(txt);

                    foreach (restapi_call_element call in callList)
                    {
                        txt = ("from_dirno: " + call.from_dirno + ". to_dirno: " + call.to_dirno + ". id: " + call.id + ". state: " + call.state);
                        addToLog(txt);
                    }

                    foreach (restapi_call_element call in callList)
                    {
                        txt = ("from_dirno: " + call.from_dirno + ". id: " + call.id + ". state: " + call.state + ". to_dirno: " + call.to_dirno);

                        restapi_call_element newCall = new restapi_call_element();
                        newCall.from_dirno = call.from_dirno;
                        newCall.to_dirno = call.to_dirno;
                        newCall.state = call.state;
                        newCall.id = call.id;

                        bool found = false;
                        int i = 0;
                        int i_save = 0;

                        while ((i < (dgrdActiveCalls.Rows.Count)) && (!found))
                        {
                            if (string.Compare(dgrdActiveCalls.Rows[i].Cells[3].Value.ToString(), newCall.id) == 0)
                            {
                                found = true;
                                i_save = i;
                            }
                            i++;
                        }

                        if (found)
                        {
                            LogMan.Instance.Log(string.Format("Call Found at index: {0}", i_save));

                            if ((string.Compare(newCall.state, "call_ended") == 0) ||
                                 (string.Compare(newCall.state, "canceled") == 0))
                            {
                                dgrdActiveCalls.Rows.RemoveAt(i_save);
                            }
                            else
                            {
                                if (newCall.from_dirno != string.Empty)
                                {
                                    dgrdActiveCalls.Rows[i_save].Cells[0].Value = newCall.from_dirno;
                                }
                                if (newCall.to_dirno != string.Empty)
                                {
                                    dgrdActiveCalls.Rows[i_save].Cells[1].Value = newCall.to_dirno;
                                }
                                if (newCall.state != string.Empty)
                                {
                                    dgrdActiveCalls.Rows[i_save].Cells[2].Value = newCall.state;
                                }
                            }
                        }
                        else
                        {
                            if (string.Compare(newCall.state, "call_ended") == 0)
                            {
                                // Call already cleared
                            }
                            else
                            {
                                // Insert new call
                                string[] row = { newCall.from_dirno, newCall.to_dirno, newCall.state, newCall.id };
                                dgrdActiveCalls.Rows.Add(row);
                            }
                        }
                    }
                }
                else
                {
                    dgrdActiveCalls.Rows.Clear();
                }
            }
            else
            {
                MessageBox.Show("Zenitel REST API Client not connected.");
            }
        }


        /***********************************************************************************************************************/
        private void btnGETCallLegs_Click(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            try
            {
                if (restApiClient != null)
                {
                    List<restapi_call_leg_element> callLegList;

                    callLegList = restApiClient.requestCallLegs("", "", "", "", "", "", "");

                    if (callLegList != null)
                    {
                        if (callLegList.Count > 0)
                        {
                            string txt = "btnGETCallLegs_Click. Calls Leg List:";
                            addToLog(txt);

                            foreach (restapi_call_leg_element callQueued in callLegList)
                            {
                                txt = "SDK. Call Leg State Update: " +
                                    "  call_id " + callQueued.call_id +
                                    ". call_type: " + callQueued.call_type +
                                    ". channel: " + callQueued.channel +
                                    ". dirno: " + callQueued.dirno +
                                    ". from_dirno: " + callQueued.from_dirno +
                                    ". leg_id: " + callQueued.leg_id +
                                    ". leg_role: " + callQueued.leg_role +
                                    ". priority: " + callQueued.priority +
                                    ". reason: " + callQueued.reason +
                                    ". state: " + callQueued.state +
                                    ". to_dirno: " + callQueued.to_dirno;

                                addToLog(txt);

                                bool found = false;
                                int i = 0;
                                int i_save = 0;

                                while ((i < (dgrdQueuedCalls.Rows.Count)) && (!found))
                                {
                                    if ((string.Compare(dgrdQueuedCalls.Rows[i].Cells[0].Value.ToString(), callQueued.from_dirno) == 0) &&
                                         (string.Compare(dgrdQueuedCalls.Rows[i].Cells[1].Value.ToString(), callQueued.dirno) == 0))
                                    {
                                        found = true;
                                        i_save = i;
                                    }
                                    i++;
                                }

                                if (found)
                                {
                                    addToLog(string.Format("Call Found at index: {0}", i_save));


                                    if (callQueued.leg_role.Equals("callee"))
                                    {
                                        if (callQueued.state.Equals("in_call") ||
                                             callQueued.state.Equals("ended"))
                                        {
                                            dgrdQueuedCalls.Rows.RemoveAt(i_save);
                                        }
                                        else
                                        {
                                            if (!string.IsNullOrEmpty(callQueued.from_dirno))
                                            {
                                                dgrdQueuedCalls.Rows[i_save].Cells[0].Value = callQueued.from_dirno;
                                            }
                                            if (!string.IsNullOrEmpty(callQueued.dirno))
                                            {
                                                dgrdQueuedCalls.Rows[i_save].Cells[1].Value = callQueued.dirno;
                                            }
                                            if (!string.IsNullOrEmpty(callQueued.state))
                                            {
                                                dgrdQueuedCalls.Rows[i_save].Cells[2].Value = callQueued.state;
                                            }
                                            if (!string.IsNullOrEmpty(callQueued.call_id))
                                            {
                                                dgrdQueuedCalls.Rows[i_save].Cells[3].Value = callQueued.call_id;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (callQueued.leg_role.Equals("callee"))
                                    {

                                        if (!callQueued.state.Equals("ended"))
                                        {
                                            string[] row = { callQueued.from_dirno, callQueued.dirno, callQueued.state, callQueued.call_id };
                                            dgrdQueuedCalls.Rows.Add(row);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            dgrdQueuedCalls.Rows.Clear();
                        }
                    }
                    else
                    {
                        string txt = "SDK. Call Leg List is empty.";
                        addToLog(txt);
                    }
                }
                else
                {
                    MessageBox.Show("Zenitel REST API Client not connected.");
                }
            }
            catch (Exception ex)
            {
                string txt = "btnGETCallLegs_Click. Exception: " + ex.ToString();
                addToLog(txt);
            }

        }


        /***********************************************************************************************************************/
        private void btnPOSTCalls_Click(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            try
            {
                if (restApiClient != null)
                {
                    string aSub = tbxASubscriber.Text;
                    string bSub = tbxBSubscriber.Text;
                    string act  = cmbxCallAction.SelectedItem.ToString();

                     restapi_response restApiResp = restApiClient.POST_Calls(aSub, bSub, act);

                    addToLog("btnPOST_calls_Click: RestApi Response  = " + restApiResp.RestApiResponse.ToString());
                    addToLog("btnPOST_calls_Click: CompletionText = " + restApiResp.CompletionText);
                }
                else
                {
                    MessageBox.Show("Zenitel REST API Client not connected.");
                }
            }

            catch (Exception ex)
            {
                string txt = "btnPOST_calls_Click. Exception: " + ex.ToString();
                addToLog(txt);

            }
        }


        /***********************************************************************************************************************/
        private void btnDELETECalls_Click(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            try
            {
                if (restApiClient != null)
                {
                    bool singleRowSelected = false;

                    DataGridViewSelectedRowCollection selRow = dgrdActiveCalls.SelectedRows;

                    if ((selRow != null) && (selRow.Count == 1))
                    {
                        singleRowSelected = true;
                    }
                    else
                    {
                        selRow = dgrdQueuedCalls.SelectedRows;
                        if ((selRow != null) && (selRow.Count == 1))
                        {
                            singleRowSelected = true;
                        }
                    }

                    if (singleRowSelected)
                    {
                        string source = selRow[0].Cells[0].Value.ToString();
                        restapi_response restApiResp =  restApiClient.DELETE_Calls(source);
                        addToLog("btn_ClearConnection_Click: Wamp Response  = " + restApiResp.RestApiResponse.ToString());
                        addToLog("btn_ClearConnection_Click: CompletionText = " + restApiResp.CompletionText);
                    }
                    else
                    {
                        string message = "No Connection Selected";
                        string title = "Clear Down Error";
                        MessageBox.Show(message, title);
                    }
                }
                else
                {
                    MessageBox.Show("Zenitel REST API Client not connected.");
                }
            }
            catch (Exception ex)
            {
                string txt = "Exception in btnDELETECalls_Click: " + ex.ToString();
                addToLog(txt);
            }
        }


        /***********************************************************************************************************************/
        private void btnDELETECallId_Click(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            try
            {
                if (restApiClient != null)
                {
                    bool singleRowSelected = false;

                    DataGridViewSelectedRowCollection selRow = dgrdActiveCalls.SelectedRows;

                    if ((selRow != null) && (selRow.Count == 1))
                    {
                        singleRowSelected = true;
                    }
                    else
                    {
                        selRow = dgrdQueuedCalls.SelectedRows;
                        if ((selRow != null) && (selRow.Count == 1))
                        {
                            singleRowSelected = true;
                        }
                    }

                    if (singleRowSelected)
                    {
                        string callId = selRow[0].Cells[3].Value.ToString();
                        restapi_response restapi_Response = restApiClient.DELETE_CallId(callId);

                        addToLog("btnClearConnectionId_Click: Wamp Response  = " + restapi_Response.ToString());
                        addToLog("btnClearConnectionId_Click: CompletionText = " + restapi_Response.CompletionText);
                    }
                    else
                    {
                        string message = "No Connection Selected";
                        string title = "Clear Down Error";
                        MessageBox.Show(message, title);
                    }
                }
                else
                {
                    MessageBox.Show("Zenitel REST API Client not connected.");
                }
            }
            catch (Exception ex)
            {
                string txt = "Exception in btnDELETECallId_Click: " + ex.ToString();
                addToLog(txt);
            }
        }


        /***********************************************************************************************************************/
        private void btnPOSTDeviceGPO_Click(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            try
            {
                if (restApiClient != null)
                {
                    string deviceId = tbxGPODevice.Text;
                    string gpoId = "relay1";

                    restApiClient.POST_DevicesGPOS(deviceId, gpoId);
                }
                else
                {
                    MessageBox.Show("Zenitel REST API Client not connected.");
                }
            }
            catch (Exception ex)
            {
                string txt = "Exception in btnPOSTDeviceGPO_Click: " + ex.ToString();
                addToLog(txt);
            }
        }

        #endregion  ----------  Button Handling Methods  ----------


        /***********************************************************************************************************************/
        /**********************                   Event Subscription Control Methods                          ******************/
        /***********************************************************************************************************************/

        #region  ----------  Event Subscription Control Methods  ----------

        /***********************************************************************************************************************/
        private void cbxCallStatusEvent_CheckedChanged(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            try
            {
                if (cbxCallStatusEvent.Checked)
                {
                    addToLog("Call Status Event is check mark set.");

                    if (!wampClient.TraceCallEventIsEnabled())
                    {
                        addToLog("Enable Call Status Event.");
                        if (wampClient.IsConnected)
                        {
                            wampClient.TraceCallEvent();
                        }
                        else
                        {
                            cbxCallStatusEvent.Checked = false;
                            MessageBox.Show("WAMP Connection not established.");
                        }
                    }
                }
                else
                {
                    addToLog("Call Status Event check mark cleared.");

                    if (wampClient.TraceCallEventIsEnabled())
                    {
                        addToLog("Disable Call Status Event.");
                        wampClient.TraceCallEventDispose();
                    }
                }
            }
            catch (Exception ex)
            {
                string txt = "Exception in cbxCallStatusEvent_CheckedChanged: " + ex.ToString();
                addToLog(txt);
            }
        }


        /***********************************************************************************************************************/
        private void cbxCallQueueStatusEvent_CheckedChanged(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            try
            {
                if (cbxCallLegStatusEvent.Checked)
                {
                    addToLog("Call Leg Status Event is check mark set.");

                    if (!wampClient.TraceCallLegEventIsEnabled())
                    {
                        addToLog("Enable Call Leg Status Event.");
                        if (wampClient.IsConnected)
                        {
                            wampClient.TraceCallLegEvent();
                        }
                        else
                        {
                            cbxCallLegStatusEvent.Checked = false;
                            MessageBox.Show("WAMP Connection not established.");
                        }
                    }
                }
                else
                {
                    addToLog("Call Leg Status Event check mark cleared.");
                    if (wampClient.TraceCallLegEventIsEnabled())
                    {
                        addToLog("Disable Call Queue Status Event.");
                        wampClient.TraceCallLegEventDispose();
                    }
                }
            }
            catch (Exception ex)
            {
                string txt = "Exception in cbxCallLegStatusEvent_CheckedChanged: " + ex.ToString();
                addToLog(txt);
            }
        }


        /***********************************************************************************************************************/
        private void cbxDeviceRegistrationEvent_CheckedChanged(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            try
            {
                if (cbxDeviceRegistrationEvent.Checked)
                {
                    addToLog("Device Registration Status Event check mark set.");

                    if (!wampClient.TraceDeviceRegistrationIsEnabled())
                    {
                        addToLog("Enable Device Registration Status Event.");
                        if (wampClient.IsConnected)
                        {
                            wampClient.TraceDeviceRegistrationEvent();
                        }
                        else
                        {
                            cbxDeviceRegistrationEvent.Checked = false;
                            MessageBox.Show("WAMP Connection not established.");
                        }
                    }
                }
                else
                {
                    addToLog("Device Registration Status Event check mark cleared.");
                    if (wampClient.TraceDeviceRegistrationIsEnabled())
                    {
                        addToLog("Disable Device Registration Status Event.");
                        wampClient.TraceDeviceRegistrationEventDispose();
                    }
                }
            }
            catch (Exception ex)
            {
                string txt = "Exception in cbxDeviceRegistrationEvent_CheckedChanged: " + ex.ToString();
                addToLog(txt);
            }

        }


        /***********************************************************************************************************************/
        private void cbxDeviceGPOStatusEvent_CheckedChanged(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            try
            {
                if (cbxDeviceGPOStatusEvent.Checked)
                {
                    addToLog("Device GPO Staus Event check mark set.");

                    if (!wampClient.TraceDeviceGPOStatusEventIsEnabled())
                    {
                        addToLog("Enable Device GPO Status Event.");
                        if (wampClient.IsConnected)
                        {
                            wampClient.TraceDeviceGPOStatusEvent(tbxGPODevice.Text);
                        }
                        else
                        {
                            cbxDeviceGPOStatusEvent.Checked = false;
                            MessageBox.Show("WAMP Connection not established.");
                        }
                    }
                }
                else
                {
                    addToLog("Device GPO Status Event check mark cleared.");

                    if (wampClient.TraceDeviceGPOStatusEventIsEnabled())
                    {
                        addToLog("Disable Device GPO Status Event.");
                        wampClient.TraceDeviceGPOStatusEventDispose();
                    }
                }
            }
            catch (Exception ex)
            {
                string txt = "Exception in cbxGPOStatusEvent_CheckedChanged: " + ex.ToString();
                addToLog(txt);
            }
        }


        /***********************************************************************************************************************/
        private void cbxDeviceGPIStatusEvent_CheckedChanged(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            try
            {
                if (cbxDeviceGPIStatusEvent.Checked)
                {
                    addToLog("Device GPI Staus Event check mark set.");

                    if (!wampClient.TraceDeviceGPIStatusEventIsEnabled())
                    {
                        addToLog("Enable Device GPI Status Event.");
                        if (wampClient.IsConnected)
                        {
                            wampClient.TraceDeviceGPIStatusEvent(tbxGPIDevice.Text);
                        }
                        else
                        {
                            cbxDeviceGPIStatusEvent.Checked = false;
                            MessageBox.Show("WAMP Connection not established.");
                        }
                    }
                }
                else
                {
                    addToLog("Device GPI Status Event check mark cleared.");

                    if (wampClient.TraceDeviceGPIStatusEventIsEnabled())
                    {
                        addToLog("Disable Device GPI Status Event.");
                        wampClient.TraceDeviceGPIStatusEventDispose();
                    }
                }
            }
            catch (Exception ex)
            {
                string txt = "Exception in cbxDeviceGPIStatusEvent_CheckedChanged: " + ex.ToString();
                addToLog(txt);
            }

        }


        /***********************************************************************************************************************/
        private void cbxOpenDoorEvent_CheckedChanged(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            try
            {
                if (cbxOpenDoorEvent.Checked)
                {
                    addToLog("Open Door Event check mark set.");

                    if (!wampClient.TraceOpenDoorEventIsEnabled())
                    {
                        addToLog("Enable Open Door Event.");
                        if (wampClient.IsConnected)
                        {
                            wampClient.TraceOpenDoorEvent();
                        }
                        else
                        {
                            cbxOpenDoorEvent.Checked = false;
                            MessageBox.Show("WAMP Connection not established.");
                        }
                    }
                }
                else
                {
                    addToLog("Open Door Event check mark cleared.");

                    if (wampClient.TraceOpenDoorEventIsEnabled())
                    {
                        addToLog("Disable Open Door Event.");
                        wampClient.TraceDeviceGPOStatusEventDispose();
                    }
                }
            }
            catch (Exception ex)
            {
                string txt = "Exception in cbxOpenDoor_CheckedChanged: " + ex.ToString();
                addToLog(txt);
            }
        }

        #endregion  ----------  Event Subscription Control Methods  ----------


        /***********************************************************************************************************************/
        private void chbxEncrypted_CheckedChanged(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {          
            if (chbxEncrypted.Checked)
            {
                chbxUnencrypted.Checked = false;
            }
            else
            {
                chbxUnencrypted.Checked = true;
            }
        }


        /***********************************************************************************************************************/
        private void chbxUnencrypted_CheckedChanged(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            if (chbxUnencrypted.Checked)
            {
                chbxEncrypted.Checked = false;
            }
            else
            {
                chbxEncrypted.Checked = true;
            }

        }

       
        /***********************************************************************************************************************/
        private void btnPOSTOpenDoor_Click(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            try
            {
                if (wampClient.IsConnected)
                {
                    string aSub = tbxASubscriber.Text;

                    WampClient.wamp_response wampResp = wampClient.PostOpenDoor(aSub);

                    addToLog("btnPOSTOpenDoor_Click: Wamp Response  = " + wampResp.WampResponse.ToString());
                    addToLog("btnPOSTOpenDoor_Click: CompletionText = " + wampResp.CompletionText);
                }
                else
                {
                    MessageBox.Show("WAMP Connection not established.");
                }
            }
            catch (Exception ex)
            {
                string txt = "Exception in btnPOSTOpenDoor_Click: " + ex.ToString();
                addToLog(txt);
            }

        }


        /***********************************************************************************************************************/
        private async void btnRegisterCalleeServices_Click(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            try
            {
                if (wampClient.IsConnected)
                {
                    addToLog("btnRegisterCalleeServices_Click.");
                    await wampClient.RegisterCalleeServices();
                    addToLog("btnRegisterCalleeServices_Click completed.");
                }
                else
                {
                    MessageBox.Show("WAMP is NOT connected.");
                }
            }

            catch (Exception ex)
            {
                string txt = "btnRegisterCalleeServices_Click: " + ex.ToString();
                addToLog(txt);
            }
        }


        /***********************************************************************************************************************/
        private void btnNewUCTTime_Click(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            try
            {
                if (wampClient.IsConnected)
                {
                    wampClient.Publish_NewUCTTime();
                }
                else
                {
                    MessageBox.Show("WAMP is NOT connected.");
                }
            }

            catch (Exception ex)
            {
                string txt = "btnNewUCTTime_Clic: " + ex.ToString();
                addToLog(txt);
            }
        }
    }
}