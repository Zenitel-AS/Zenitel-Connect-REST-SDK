﻿using System;
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
            wampClient.OnWampCallQueueStatusEvent    += wampClient_OnWampCallQueueStatusEvent;
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
                btnPOSTcallId.Enabled = true;
                btnDELETECalls.Enabled = true;
                btnDELETECallId.Enabled = true;
                btnGETCalls.Enabled = true;
                btnGETQueues.Enabled = true;

                btnPOSTDeviceGPO.Enabled = true;
                btnGETDeviceGPOs.Enabled = true;
                btnGETDeviceGPIOs.Enabled = true;

                //Clear Check Marks
                cbxCallQueueStatusEvent.Checked = false;
                cbxCallStatusEvent.Checked = false;
                cbxDeviceRegistrationEvent.Checked = false;

                cbxDeviceGPOStatusEvent.Checked = false;
                cbxDeviceGPIStatusEvent.Checked = false;
                cbxOpenDoorEvent.Checked = false;

                //Enable Check Fields
                cbxCallQueueStatusEvent.Enabled = true;
                cbxCallStatusEvent.Enabled = true;
                cbxDeviceRegistrationEvent.Enabled = true;

                cbxDeviceGPOStatusEvent.Enabled = true;
                cbxDeviceGPIStatusEvent.Enabled = true;
                cbxOpenDoorEvent.Enabled = true;

                if (cbxCallStatusEvent.Checked)
                {
                    addToLog("Subscribe Call Events.");
                    wampClient.TraceCallEvent();
                }
                if (cbxCallQueueStatusEvent.Checked)
                {
                    addToLog("Subscribe Call Queue Events.");
                    wampClient.TraceCallQueueEvent();
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
                btnPOSTcallId.Enabled = false;
                btnDELETECalls.Enabled = false;
                btnDELETECallId.Enabled = false;
                btnGETCalls.Enabled = false;
                btnGETQueues.Enabled = false;

                btnPOSTDeviceGPO.Enabled = false;
                btnGETDeviceGPOs.Enabled = false;
                btnGETDeviceGPIOs.Enabled = false;

                //Enable Check Fields
                cbxCallQueueStatusEvent.Enabled = false;
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
                if (this.dgrd_ActiveCalls.InvokeRequired)
                {
                    wampClient_OnWampCallStatusEventCallBack cb =
                        new wampClient_OnWampCallStatusEventCallBack(wampClient_OnWampCallStatusEvent);

                    this.Invoke(cb, new object[] { sender, callUpd });
                }
                else
                {
                    string txt = "SDK-Event. Call State Update: Call from " + callUpd.from_dirno + " to dir-no " + callUpd.to_dirno +
                         ". State = " + callUpd.state + ". id = " + callUpd.id;

                    WampClient.wamp_call_element newCall = new WampClient.wamp_call_element();
                    newCall.from_dirno = callUpd.from_dirno;
                    newCall.to_dirno = callUpd.to_dirno;
                    newCall.state = callUpd.state;
                    newCall.id = callUpd.id;

                    addToLog(txt);

                    bool found = false;
                    int i = 0;
                    int i_save = 0;

                    while ((i < dgrd_ActiveCalls.Rows.Count) && (!found))
                    {
                        if (string.Compare(dgrd_ActiveCalls.Rows[i].Cells[3].Value.ToString(), newCall.id) == 0)
                        {
                            found = true;
                            i_save = i;
                        }
                        i++;
                    }

                    if (found)
                    {
                        addToLog(string.Format("Call Found at index: {0}", i_save));

                        if (string.Compare(newCall.state, "call_ended") == 0)
                        {
                            dgrd_ActiveCalls.Rows.RemoveAt(i_save);
                        }
                        else
                        {
                            if (newCall.from_dirno != string.Empty)
                            {
                                dgrd_ActiveCalls.Rows[i_save].Cells[0].Value = newCall.from_dirno;
                            }
                            if (newCall.to_dirno != string.Empty)
                            {
                                dgrd_ActiveCalls.Rows[i_save].Cells[1].Value = newCall.to_dirno;
                            }
                            if (newCall.state != string.Empty)
                            {
                                dgrd_ActiveCalls.Rows[i_save].Cells[2].Value = newCall.state;
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
                            dgrd_ActiveCalls.Rows.Add(row);
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


        private delegate void wampClient_OnWampCallQueueStatusEventCallBack(object sender, WampClient.wamp_call_queue_element callQueueUpd);

        /***********************************************************************************************************************/
        private void wampClient_OnWampCallQueueStatusEvent(object sender, WampClient.wamp_call_queue_element callQueueUpd)
        /***********************************************************************************************************************/
        {
            try
            {
                if (InvokeRequired)
                {
                    wampClient_OnWampCallQueueStatusEventCallBack cb =
                       new wampClient_OnWampCallQueueStatusEventCallBack(wampClient_OnWampCallQueueStatusEvent);

                    this.Invoke(cb, new object[] { sender, callQueueUpd });
                }
                else
                {

                    if (callQueueUpd.agents != null)
                    {
                        string txt = "SDK-Event. Call Queue State Update: Agents: [" + string.Join(",", callQueueUpd.agents) +
                                     "]. Call from " + callQueueUpd.from_dirno +
                                     ". From_id: " + callQueueUpd.from_id +
                                     ". Position: " + callQueueUpd.position.ToString() +
                                     ". Queue_size: " + callQueueUpd.queue_size.ToString() +
                                     ". Queued_time: " + callQueueUpd.queue_time.ToString() +
                                     ". Start-time: " + callQueueUpd.start_time +
                                     ". State: " + callQueueUpd.state;
                        addToLog(txt);

                        bool found = false;
                        int i = 0;
                        int i_save = 0;

                        while ((i < dgrdQueuedCalls.Rows.Count) && (!found))
                        {
                            if (string.Compare(dgrdQueuedCalls.Rows[i].Cells[0].Value.ToString(), callQueueUpd.from_dirno) == 0)
                            {
                                found = true;
                                i_save = i;
                            }
                            i++;
                        }

                        if (found)
                        {
                            addToLog(string.Format("Call Found at index: {0}", i_save));

                            {
                                if (string.Compare(callQueueUpd.state, "leave") == 0)
                                {
                                    dgrdQueuedCalls.Rows.RemoveAt(i_save);
                                }
                                else
                                {
                                    if (callQueueUpd.from_dirno != string.Empty)
                                    {
                                        dgrdQueuedCalls.Rows[i_save].Cells[0].Value = callQueueUpd.from_dirno;
                                    }
                                    if (callQueueUpd.agents.Count > 0)
                                    {
                                        dgrdQueuedCalls.Rows[i_save].Cells[1].Value = string.Join(",", callQueueUpd.agents);
                                    }
                                    if (callQueueUpd.state != string.Empty)
                                    {
                                        dgrdQueuedCalls.Rows[i_save].Cells[2].Value = callQueueUpd.state;
                                    }
                                    if (callQueueUpd.queue_size > 0)
                                    {
                                        dgrdQueuedCalls.Rows[i_save].Cells[3].Value = callQueueUpd.queue_size;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // Insert new call
                            string[] row = { callQueueUpd.from_dirno, string.Join(",", callQueueUpd.agents), callQueueUpd.state, callQueueUpd.queue_size.ToString() };
                            dgrdQueuedCalls.Rows.Add(row);
                        }
                    }
                    else
                    {
                        addToLog("No agents in message !!");
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
                            txt = ("Dir-no: " + dev.dirno + ". Location: " + dev.location + ". Name: " + dev.name + ". Status: " + dev.state);
                            addToLog(txt);

                            string[] row = { dev.dirno, dev.name, dev.location, dev.state };
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

                    while ((i < (dgrd_ActiveCalls.Rows.Count)) && (!found))
                    {
                        if (string.Compare(dgrd_ActiveCalls.Rows[i].Cells[3].Value.ToString(), newCall.id) == 0)
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
                            dgrd_ActiveCalls.Rows.RemoveAt(i_save);
                        }
                        else
                        {
                            if (newCall.from_dirno != string.Empty)
                            {
                                dgrd_ActiveCalls.Rows[i_save].Cells[0].Value = newCall.from_dirno;
                            }
                            if (newCall.to_dirno != string.Empty)
                            {
                                dgrd_ActiveCalls.Rows[i_save].Cells[1].Value = newCall.to_dirno;
                            }
                            if (newCall.state != string.Empty)
                            {
                                dgrd_ActiveCalls.Rows[i_save].Cells[2].Value = newCall.state;
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
                            dgrd_ActiveCalls.Rows.Add(row);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Zenitel REST API Client not connected.");
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
        private void btnPOSTcallId_Click(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            try
            {
                if (restApiClient != null)
                {
                    DataGridViewSelectedRowCollection selRow = dgrd_ActiveCalls.SelectedRows;

                    if ((selRow != null) && (selRow.Count == 1))
                    {
                        if (cmbxCallAction.SelectedIndex >= 0)
                        {
                            string act = cmbxCallAction.SelectedItem.ToString();
                            string callId = selRow[0].Cells[3].Value.ToString();

                            addToLog("btnPOSTcallId_Click: CallId: " + callId + ". Action: Answer");

                            restapi_response restApiResp  =  restApiClient.POST_CallsCallId(callId, RestApiClient.CallAction.answer.ToString());

                            addToLog("btnPOSTcallId_Click: Wamp Response  = " + restApiResp.RestApiResponse.ToString());
                            addToLog("btnPOSTcallId_Click: CompletionText = " + restApiResp.CompletionText);
                        }
                        else
                        {
                            string message = "No Action Selected";
                            string title = "Function Setup Error";
                            MessageBox.Show(message, title);
                        }
                    }
                    else
                    {
                        string message = "No Call ID Selected";
                        string title = "Function Setup Error";
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
                string txt = "Exception in btnPOSTcallId_Click:: " + ex.ToString();
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
                        DataGridViewSelectedRowCollection selRow = dgrd_ActiveCalls.SelectedRows;

                    if ((selRow != null) && (selRow.Count == 1))
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
                        DataGridViewSelectedRowCollection selRow = dgrd_ActiveCalls.SelectedRows;

                    if ((selRow != null) && (selRow.Count == 1))
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
        private void btnGETQueues_Click(object sender, EventArgs e)
        /***********************************************************************************************************************/
        {
            try
            {
                if (restApiClient != null)
                {
                    List<restapi_call_queue_element> callQueuedList;
                    callQueuedList = restApiClient.GET_Queues("", "", "");

                    if (callQueuedList != null)
                    {
                        string txt = "SDK. Calls Queued List:";
                        addToLog(txt);

                        foreach (restapi_call_queue_element callQueued in callQueuedList)
                        {
                            if (callQueued.agents != null)
                            {
                                txt = "SDK. Call Queue State Update: Agents: [" + string.Join(",", callQueued.agents) +
                                  "]. Call from " + callQueued.from_dirno +
                                  ". From_id: " + callQueued.from_id +
                                  ". Position: " + callQueued.position.ToString() +
                                  ". Queue_size: " + callQueued.queue_size.ToString() +
                                  ". Queued_time: " + callQueued.queue_time.ToString() +
                                  ". Start-time: " + callQueued.start_time +
                                  ". State: " + callQueued.state;
                                addToLog(txt);

                                bool found = false;
                                int i = 0;
                                int i_save = 0;

                                while ((i < (dgrdQueuedCalls.Rows.Count)) && (!found))
                                {
                                    if (string.Compare(dgrdQueuedCalls.Rows[i].Cells[0].Value.ToString(), callQueued.from_dirno) == 0)
                                    {
                                        found = true;
                                        i_save = i;
                                    }
                                    i++;
                                }

                                if (found)
                                {
                                    LogMan.Instance.Log(string.Format("Call Found at index: {0}", i_save));

                                    {
                                        if (string.Compare(callQueued.state, "leave") == 0)
                                        {
                                            dgrdQueuedCalls.Rows.RemoveAt(i_save);
                                        }
                                        else
                                        {
                                            if (callQueued.from_dirno != string.Empty)
                                            {
                                                dgrdQueuedCalls.Rows[i_save].Cells[0].Value = callQueued.from_dirno;
                                            }
                                            if (callQueued.agents.Count > 0)
                                            {
                                                dgrdQueuedCalls.Rows[i_save].Cells[1].Value = string.Join(",", callQueued.agents);
                                            }
                                            if (callQueued.state != string.Empty)
                                            {
                                                dgrdQueuedCalls.Rows[i_save].Cells[2].Value = callQueued.state;
                                            }
                                            if (callQueued.queue_size > 0)
                                            {
                                                dgrdQueuedCalls.Rows[i_save].Cells[3].Value = callQueued.queue_size;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // Insert new call
                                    string[] row = { callQueued.from_dirno, string.Join(",", callQueued.agents), callQueued.state, callQueued.queue_size.ToString() };
                                    dgrdQueuedCalls.Rows.Add(row);
                                }
                            }
                            else
                            {
                                addToLog("No agents in message !!");
                            }
                        }
                    }
                    else
                    {
                        string txt = "SDK. Calls Queued List is empty.";
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
                string txt = "Exception in btnGETQueues_Click: " + ex.ToString();
                addToLog(txt);
            }
        }



        private void btnPOSTDeviceGPO_Click(object sender, EventArgs e)
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
                if (cbxCallQueueStatusEvent.Checked)
                {
                    addToLog("Call Queue Status Event is check mark set.");

                    if (!wampClient.TraceCallQueueEventIsEnabled())
                    {
                        addToLog("Enable Call Queue Status Event.");
                        if (wampClient.IsConnected)
                        {
                            wampClient.TraceCallQueueEvent();
                        }
                        else
                        {
                            cbxCallQueueStatusEvent.Checked = false;
                            MessageBox.Show("WAMP Connection not established.");
                        }
                    }
                }
                else
                {
                    addToLog("Call Queue Status Event check mark cleared.");
                    if (wampClient.TraceCallQueueEventIsEnabled())
                    {
                        addToLog("Disable Call Queue Status Event.");
                        wampClient.TraceCallQueueEventDispose();
                    }
                }
            }
            catch (Exception ex)
            {
                string txt = "Exception in cbxCallQueueStatusEvent_CheckedChanged: " + ex.ToString();
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
    }
}