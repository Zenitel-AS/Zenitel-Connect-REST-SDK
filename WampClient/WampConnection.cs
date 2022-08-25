using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using WampSharp.Core.Listener;
using WampSharp.V2;
using WampSharp.V2.Client;
using WampSharp.V2.Fluent;
using WampSharp.V2.Realm;


namespace Wamp.Client
{

    // no-WAMP login result serialization helper
    class json_login_result
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
    }

    public partial class WampConnection
    {
        /// <summary>This string defines the port number used for WAMP encrypted communication</summary>
        public const string WampEncryptedPort   = "8086";

        /// <summary>This string defines the port number used for WAMP unencrypted communication</summary>
        public const string WampUnencryptedPort = "8087";

        /// <summary>This string defines the port number used for HTTPS communication</summary>
        public string HttpEncryptedPort = "443";

        /// <summary>This string defines the port number used for HTTP communication</summary>
        public string HttpUnencryptedPort = "80";


        //SYSTEM:

        /// <summary>Zenitel Link Path for accessing Registered Device Accounts</summary>
        //GET api/system/devices_accounts
        public const string GetWampRegisteredDevices = "com.zenitel.system.device_accounts";

        /// <summary>Zenitel Link Path for accessing Net Interfaces.</summary>
        //GET api/system/info/net_interfaces
        public const string GetWampInterfaceList = "com.zenitel.system.info.net_interfaces";

        //GET api/system/info/ntp
        //TBD public const string GetWampSystemInfoNtp     = "com.zenitel.system.info.ntp";

        //CALL HANDLING:

        /// <summary>Zenitel Link Path for setting up a call.</summary>
        //POST api/calls
        public const string PostWampCalls = "com.zenitel.calls.post";

        /// <summary>Zenitel Link Path for retrieving all calls.</summary>
        //GET api/calls
        public const string GetWampCalls = "com.zenitel.calls";

        /// <summary>Zenitel Link Path for deleting calls.</summary>
        //DELETE api/calls
        public const string DeleteWampCalls = "com.zenitel.calls.delete";

        /// <summary>Zenitel Link Path for deleting a call using call ID.</summary>
        //DELETE api/calls/call{call_id}
        public const string DeleteWampCallsCallId = "com.zenitel.calls.call.delete";

        /// <summary>Zenitel Link Path for sending an action to a specific call.</summary>
        //POST api/calls/call{call_id} 
        public const string PostWampCallsCallId = "com.zenitel.calls.call.post";

        /// <summary>Get a list of all queued calls. Without arguments, all active queued calls are returned.
        /// Query paramters may be used to limit the selection. If multiple query parameters are provided,
        /// they are logically ANDed together which limits the selection further.</summary>
        //GET api/queues
        public const string GetWampQueues = "com.zenitel.queues";

        //DEVICE:

        /// <summary>Change a single General-Purpose Output (GPO), i.e. relay / gpio / e_relay controlled by a device.</summary>
        //POST api/devices/device/;{device_id}/gpos/gpo;{gpo_id}
        public const string PostWampDevicesGposGpoId = "com.zenitel.devices.device.gpos.gpo.post";

        /// <summary>Get all or some General-Purpose Output (GPO), i.e relay / gpio / e_relay controlled by a device.</summary>
        //GET api/devices/device/;{device_id}/gpos
        public const string GetWampDevicesGpos = "com.zenitel.devices.device.gpos";

        /// <summary>Get status of all or some General-Purpose Input (GPI) signals controlled by a device.</summary>
        //GET api/devices/device/;{device_id}/gpis
        public const string GetWampDevicesGpis = "com.zenitel.devices.device.gpis";

        //POST api/devices/device/;{device_id}/daks/dak;{dak_id}
        //TBD public const string PostWampDevicesDaksDakId = "com.zenitel.devices.device.daks.dak.post";

        //EVENTS:

        /// <summary>Subscribe to calls. Whenever a call is initiated, an event will be published on this channel.</summary>
        public const string TraceWampCalls = "com.zenitel.calls";

        /// <summary>Subscribe to queue call events whenever a call is joining or leaving a queue</summary>
        public const string TraceWampQueues = "com.zenitel.queues";

        /// <summary>Subscribe on gpo/relay changes.</summary>
        public const string TraceWampDeviceDirnoGpo = "com.zenitel.device.{dirno}.gpo";
        //TBD public const string TraceWampDeviceDirnoDak = "com.zenitel.device.{dirno}.dak";

        /// <summary>Subscribe on gpi/gpio changes.</summary>
        public const string TraceWampDeviceDirnoGpi = "com.zenitel.device.{dirno}.gpi";

        /// <summary>Subscribe to device state changes.</summary>
        public const string TraceWampRegisteredDevices = "com.zenitel.system.device_accounts";

        /// <summary>Subscribe WAMP connection start event. The event is similar to
        /// https://wamp-proto.org/_static/gen/wamp_latest.html#x14-5-1-2-session-meta-events,
        /// except that the data is placed in 'arglist[0]', not in 'details'.</summary>
        public const string TraceWampSessionOnJoin = "com.zenitel.wamp.session.on_join";

        /// <summary>Subscribe WAMP connection close event.</summary>
        public const string TraceWampSessionOnLeave = "com.zenitel.wamp.session.on_leave";

        /// <summary>Dialing digit 6 in conversation will trigger an open door event.</summary>
        public const string TraceWampSystemOpenDoor = "com.zenitel.system.open_door";


        private Timer _reconnectTimer;


        /// <summary>Zenitel Connect Server IP Address.</summary>
        public string WampServerAddr = "169.254.1.5";


        /// <summary>Zenitel Connect Server IP Port Number.</summary>
        public string WampPort = WampEncryptedPort;


        /// <summary>Zenitel Connect WAMP URL.</summary>
        public string WampUrl => string.Format("wss://{0}:{1}/wamp", WampServerAddr, WampPort);


        /// <summary>Zenitel Link WAMP Realm.</summary>
        public string WampRealm = "zenitel";


        /// <summary>Zenitel Link Server Access User Name</summary>
        public string UserName = "admin";

 
        /// <summary>Zenitel Link Server Access Password</summary>
        public string Password = "alphaadmin";


        // authenticator is created when access token is retrieved
        TicketAuthenticator _wampAuthenticator;


        // created WAMP channel
        IWampChannel _wampChannel;


        // WAMP realm proxy - created 
        IWampRealmProxy _wampRealmProxy;


        /// <summary>WAMP connection established and session open for use.</summary>
        public bool IsConnected { get; private set; }


        /// <summary>Event Handler for WAMP connection change event.</summary>
        public event EventHandler<bool> OnConnectChanged;

 
        /// <summary>Event Handler for WAMP Error event.</summary>
        public event EventHandler<string> OnError;


        /// <summary>Event Handler for logging text.</summary>
        public event EventHandler<string> OnChildLogString;


        #region public methods

        /// <summary>
        /// Start of connection to server for obtaining access token.
        /// When token is obtained, tries open WAMP channel.
        /// HostAddr, WampRealm, UserName and Password must be set before Start.
        /// </summary>
       /***********************************************************************************************************************/
        public void Start()
        /***********************************************************************************************************************/
        {
            OnChildLogString?.Invoke(this, "WampConnection.Start().");
            StartReconnect();
        }


        /// <summary>Stops opened connection or reconnecting</summary>
       /***********************************************************************************************************************/
        public void Stop()
        /***********************************************************************************************************************/
        {
            StopReconnect();
            ResetChannel();
        }

        #endregion public methods


        #region internal connect


        /***********************************************************************************************************************/
        private bool ValidateRemoteCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        /***********************************************************************************************************************/
        {
            return true;
        }


        /***********************************************************************************************************************/
        private void StartReconnect()
        /***********************************************************************************************************************/
        {
            if (_reconnectTimer == null)
            {
                _reconnectTimer = new Timer((object s) =>
                {
                    try
                    {
                        bool useEncryption = WampPort.Equals(WampEncryptedPort);

                         // Authentication is HTTP / HTTPS 
                         string uri_str = ((useEncryption) ? ("https://" + WampServerAddr + ":" + HttpEncryptedPort) :
                                                             ("http://"  + WampServerAddr)) +
                                                              "/api/auth/login";
                        Uri uri = new Uri(uri_str);

                        HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(uri);
                        rq.Method = "POST";
                        rq.ContentType = "application/json";
                        rq.Accept = "application/json";
                        rq.Timeout = 5000;

                        string encoded = System.Convert.ToBase64String(
                            Encoding.GetEncoding("ISO-8859-1").GetBytes(UserName + ":" + Password));

                        rq.Headers.Add("Authorization", "Basic " + encoded);

                        ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);

                        HttpWebResponse res = (HttpWebResponse)rq.GetResponse();
                        if (res.StatusCode == HttpStatusCode.OK)
                        {
                            var resstring = new StreamReader(res.GetResponseStream()).ReadToEnd();

                            json_login_result json_result = Newtonsoft.Json.JsonConvert.DeserializeObject<json_login_result>(resstring);

                            if (json_result == null)
                            {
                                SetConnectState(false, "null result");
                            }

                            if (string.IsNullOrEmpty(json_result.access_token))
                            {
                                SetConnectState(false, "empty token");
                            }

                            SetConnectState(true, null, json_result.access_token);

                        }
                        else
                        {
                            SetConnectState(false, "http request error: " + res.StatusCode + " " + res.StatusDescription);
                        }

                    }
                    catch (Exception ex)
                    {
                        OnChildLogString?.Invoke(this, "WampConnection.StartReconnect(). Exception: " + ex.ToString());
                        SetConnectState(false, "http request exception: " + ex.Message);
                    }
                });

                _reconnectTimer.Change(2000, 10000);
            }
            else
            {
                _reconnectTimer.Change(10000, 10000);
            }
        }


        /***********************************************************************************************************************/
        private void StopReconnect()
        /***********************************************************************************************************************/
        {
            if (_reconnectTimer != null)
            {
                _reconnectTimer.Dispose();
                _reconnectTimer = null;
            }
        }


        /***********************************************************************************************************************/
        private void ResetChannel()
        /***********************************************************************************************************************/
        {
            // close WAMP channel if it is
            if (_wampChannel != null)
            {
                try
                {
                    _wampChannel.Close();
                }
                catch (Exception ex)
                {
                    OnChildLogString?.Invoke(this, "Exception in ResetChannel(): " + ex.ToString());
                }
            }

            // reset proxy
            _wampRealmProxy = null;
        }

 
        /***********************************************************************************************************************/
        private void SetConnectState(bool connected, string error, string token = null)
        /***********************************************************************************************************************/
        {
            if (connected)
            {
                StopReconnect();

                // create authenticator
                _wampAuthenticator = new TicketAuthenticator(UserName, token);

                // try to open channel
                OpenChannel();
            }
            else
            {
                // reconnect continues...
                ResetChannel();

                OnError?.Invoke(this, error);
            }
        }


        /***********************************************************************************************************************/
        private void OpenChannel()
        /***********************************************************************************************************************/
        {
            // create channel factory
            IWampChannelFactory factory = new WampChannelFactory();

            if ( WampPort.Equals(WampEncryptedPort) )
            {
                // create connect to realm, transport, serialization and authenticator
                var stx = factory
                    .ConnectToRealm(WampRealm)
                    .WebSocket4NetTransport(WampUrl)
                    .JsonSerialization()
                    .Authenticator(_wampAuthenticator);

                // build channel
                _wampChannel = stx.Build();

                // This is also neccessary (by sample from GitHub)
                ServicePointManager.ServerCertificateValidationCallback = (s, crt, chain, policy) => true;
            }
            else
            {
                //Build raw data connection
                var stx =
                factory.ConnectToRealm(WampRealm)
                       .RawSocketTransport(WampServerAddr, int.Parse(WampPort))
                       .JsonSerialization()
                       .Authenticator(_wampAuthenticator);
                _wampChannel = stx.Build();
            }
 
            // attach handlers to monitor
            _wampRealmProxy = _wampChannel.RealmProxy;
            _wampRealmProxy.Monitor.ConnectionEstablished += Monitor_ConnectionEstablished;
            _wampRealmProxy.Monitor.ConnectionError += Monitor_ConnectionError;
            _wampRealmProxy.Monitor.ConnectionBroken += Monitor_ConnectionBroken;

            try
            {
                _wampChannel.Open().Wait();
            }
            catch (Exception ex)
            {
                OnChildLogString?.Invoke(this, "Exception in OpenChannel(): " + ex.ToString());
            }
        }

        #endregion internal connect


        #region real proxy event handlers

        private void Monitor_ConnectionEstablished(object sender, WampSessionCreatedEventArgs e)
        {
            // notify connection is established
            IsConnected = true;
            OnConnectChanged?.Invoke(this, true);
        }

        private void Monitor_ConnectionError(object sender, WampConnectionErrorEventArgs e)
        {
            // notify connection establishing error
            IsConnected = false;
            OnConnectChanged?.Invoke(this, false);
            // reconnect should be started
        }

        private void Monitor_ConnectionBroken(object sender, WampSessionCloseEventArgs e)
        {
            // notify established connection is broken
            IsConnected = false;
            OnConnectChanged?.Invoke(this, false);
            // reconnect should be started
        }

        #endregion real proxy event handlers


        #region call functions from server


 
        /***********************************************************************************************************************/
        private object GetSystemDevicesRegistered()
        /***********************************************************************************************************************/
        {
            // get service
            var svc = _wampRealmProxy.Services.GetCalleeProxy<IConnectWampServices>();

            // try call function
            return svc.SystemDevicesRegistered();
        }



        /***********************************************************************************************************************/
        private object GetInterfaceList()
        /***********************************************************************************************************************/
        {
            // get service
            var svc = _wampRealmProxy.Services.GetCalleeProxy<IConnectWampServices>();

            // try call function
            return svc.InterfaceList();
        }

 
        /***********************************************************************************************************************/
        private object GET_calls(string dirNo, string callId, string state)
        /***********************************************************************************************************************/
        {
            try
            {
                // get service
                var svc = _wampRealmProxy.Services.GetCalleeProxy<IConnectWampServices>();

                // try call function
                return svc.GET_calls(dirNo, callId, state);

            }
            catch (Exception ex)
            {
                OnChildLogString?.Invoke(this, "Exception in GET_calls: " + ex.ToString());
                return null;
            }
        }

 
        /***********************************************************************************************************************/
        private object GET_calls_queued(string agent, string fromDirno, string queueDirNo)
        /***********************************************************************************************************************/
        {
            try
            {
                // get service
                var svc = _wampRealmProxy.Services.GetCalleeProxy<IConnectWampServices>();


                // try call function
                return svc.GET_calls_queued(agent, fromDirno, queueDirNo);

            }
            catch (Exception ex)
            {
                OnChildLogString?.Invoke(this, "Exception in GET_calls_queue: " + ex.ToString());
                return null;
            }
        }


        /***********************************************************************************************************************/
        private object GET_devices_gpos(string device_id, string id)
        /***********************************************************************************************************************/
        {
            try
            {
                // get service
                var svc = _wampRealmProxy.Services.GetCalleeProxy<IConnectWampServices>();

                // try call function
                return svc.GET_devices_gpos(device_id, id);

            }
            catch (Exception ex)
            {
                OnChildLogString?.Invoke(this, "Exception in GET_devices_gpos: " + ex.ToString());
                return null;
            }
        }


        /***********************************************************************************************************************/
        private object GET_devices_gpis(string device_id, string id)
        /***********************************************************************************************************************/
        {
            try
            {
                // get service
                var svc = _wampRealmProxy.Services.GetCalleeProxy<IConnectWampServices>();

                // try call function
                return svc.GET_devices_gpis(device_id, id);

            }
            catch (Exception ex)
            {
                OnChildLogString?.Invoke(this, "Exception in GET_devices_gpis: " + ex.ToString());
                return null;
            }
        }
    }
    #endregion call functions from server
}

