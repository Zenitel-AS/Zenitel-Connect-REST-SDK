using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace Rest.Api.Client
{

    class json_login_result
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
    }


    /// <summary>This class contains device registration element.</summary>
    public class restapi_device_registration_element
    {
        /// <summary>
        /// Device_ip is the IP-Address of the device.
        /// </summary>
        public string device_ip { get; set; }

        /// <summary>
        /// Device_type is the HW-type of the device.
        /// </summary>
        public string device_type { get; set; }

        /// <summary>
        /// Dirno is the directory number of the device.
        /// </summary>
        public string dirno { get; set; }

        /// <summary>
        /// Location is the where the device is placed.
        /// </summary>
        public string location { get; set; }

        /// <summary>
        /// Name is the assigned name of the device.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// State indicates if the device is "reachable" or "not reachable".
        /// </summary>
        public string state { get; set; }
    }

    /// <summary>
    /// This class encapsulates the address information of the Interface List request.
    /// </summary>
    public class addrInfo
    {
        /// <summary>
        /// IP-Net Broadcast address.
        /// </summary>
        public string broadcast { get; set; }

        /// <summary>
        /// Family name.
        /// </summary>
        public string family { get; set; }

        /// <summary>
        /// Name of the IP port
        /// </summary>
        public string label { get; set; }

        /// <summary>
        /// IP address of the port.
        /// </summary>
        public string local { get; set; }

        /// <summary>
        /// TBD
        /// </summary>
        public string preferred_life_time { get; set; }

        /// <summary>
        /// TBD
        /// </summary>
        public string prefixlen { get; set; }

        /// <summary>
        /// Globel/Link
        /// </summary>
        public string scope { get; set; }

        /// <summary>
        /// TBD
        /// </summary>
        public string valid_life_time { get; set; }
    }

    /// <summary>
    /// This class encapsulates the IP Interface Status
    /// </summary>
    public class restapi_interface_list
    {
        /// <summary>
        ///  List of available WAMP connections
        /// </summary>
        public List<addrInfo> addr_info { get; set; }

        /// <summary>
        /// MAC-address of the IP port
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// TBD
        /// </summary>
        public string broadcast { get; set; }

        /// <summary>
        /// TBD
        /// </summary>
        public List<string> flags { get; set; }

        /// <summary>
        /// TBD
        /// </summary>
        public string group { get; set; }

        /// <summary>
        /// TBD
        /// </summary>
        public int ifindex { get; set; }

        /// <summary>
        /// Interface name
        /// </summary>
        public string ifname { get; set; }

        /// <summary>
        /// Type of link ("ether")
        /// </summary>
        public string link_type { get; set; }

        /// <summary>
        /// TBD
        /// </summary>
        public int mtu { get; set; }

        /// <summary>
        /// Operational state (UP/DOWN)
        /// </summary>
        public string operstate { get; set; }

        /// <summary>
        /// TBD
        /// </summary>
        public string qdisc { get; set; }

        /// <summary>
        /// TBD
        /// </summary>
        public int txqlen { get; set; }
    }


    /// <summary>
    /// These enums define the response possible received from the WAMP connection when sending a request
    /// </summary>
    public enum ResponseType
    {
        /// <summary>No Response received from WAMP Connection.</summary>
        RestApiNoResponce,

        /// <summary>A negative response received from WAMP Connection.</summary>
        RestApiRequestFailed,

        /// <summary>A positive response received from WAMP Connection.</summary>
        RestApiRequestSucceeded
    }


    /// <summary>
    /// This class defines the response received from the WAMP connection when sending a request.
    /// </summary>
    public class restapi_response
    {
        /// <summary>
        /// Contains the result of the WAMP request (no response, failed, success)
        /// </summary>
        public ResponseType RestApiResponse { get; set; }

        /// <summary>
        /// Contains additional information of the request completion
        /// </summary>
        public string CompletionText { get; set; }

        /// <summary>
        /// WAMP Response creator
        /// </summary>
        public restapi_response()
        {
            RestApiResponse = ResponseType.RestApiNoResponce;
            CompletionText = "";
        }
    }


    /// <summary>
    /// This class incapsulates the call element
    /// </summary>
    public class restapi_POST_calls_element
    {
        /// <summary>
        /// This attribute defines the caller device of the call 
        /// </summary>
        public string from_dirno { get; set; }

        /// <summary>
        /// This attribute defines the called device of the call 
        /// </summary>
        public string to_dirno { get; set; }

        /// <summary>
        /// This attribute defines the action to be executed ("setup"/"answer") 
        /// </summary>
        public string action { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool verbose { get; set; }


        /// <summary>
        /// This is the constructor of the restapi_POST_calls_element class
        /// </summary>
        /// <param name="fromDirno">Defines the directory number of the calling station.</param>
        /// <param name="toDirNo">Defines the directory number of the called station.</param>
        /// <param name="act">Defines the action to be executed ("setup"/"answer").</param>
        public restapi_POST_calls_element(string fromDirno, string toDirNo, string act)
        {
            from_dirno = fromDirno;
            to_dirno = toDirNo;
            action = act;
            verbose = true;
        }
    }

    /// <summary>
    /// This class defines the request to change the state of a call
    /// </summary>
    public class restapi_POST_callsId_element
    {
        /// <summary>
        /// This attribute is the ID of the call 
        /// </summary>
        public string call_id { get; set; }

        /// <summary>
        /// This attribute defines the action to be execured ("setup"/"answer") 
        /// </summary>
        public string action { get; set; }

        /// <summary>
        /// This is the constructor of the restapi_POST_callsId_element class.
        /// </summary>
        /// <param name="callId">Defines the ID of the call.</param>
        /// <param name="callAction">Defines the action to be executed ("setup"/"answer").</param>
        public restapi_POST_callsId_element(string callId, string callAction)
        {
            call_id = callId;
            action = callAction;
        }
    }


    /// <summary>
    /// This class defines the request to retrieve call(s) from the registered calls.
    /// </summary>
    public class restapi_GET_calls_element
    {
        /// <summary>
        /// This attribute defines directory number of the station in the call .
        /// </summary>
        public string dirno { get; set; }

        /// <summary>
        /// This attribute defines the call ID.
        /// </summary>
        public string call_id { get; set; }

        /// <summary>
        /// This attribute defines the action to be execured ("setup"/"answer").
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// This is the constructor of the restapi_GET_calls_element class.
        /// </summary>
        /// <param name="dirNo">Defines the directory number of the station in the call.</param>
        /// <param name="callId">Defines the ID of the call.</param>
        /// <param name="sta">Defines the status of the call.</param>
        public restapi_GET_calls_element(string dirNo, string callId, string sta)
        {
            dirno = dirNo;
            call_id = callId;
            state = sta;
        }
    }


    /// <summary>
    /// This class incapsulates the call element.
    /// </summary>
    public class restapi_call_element
    {
        /// <summary>
        /// This attribute defines the caller device of the call.
        /// </summary>
        public string from_dirno { get; set; }

        /// <summary>
        /// This attribute defines the called device of the call.
        /// </summary>
        public string to_dirno { get; set; }

        /// <summary>
        /// This attribute defines the unique Identification of the call.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// This attribute defines the calling state of the call.
        /// </summary>
        public string state { get; set; }
    }

    /// <summary>
    /// This class defines a call leg
    /// </summary>
    public class restapi_call_leg_element
    {
        /// <summary>
        /// This list defines the directory number of the operators, who can answer a call in the queue. 
        /// </summary>
        public string call_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string call_type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string channel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string dirno { get; set; }

        /// <summary>
        /// Defines the directory number of the calling device.
        /// </summary>
        public string from_dirno { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string leg_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string leg_role { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string priority { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string reason { get; set; }

        /// <summary>
        /// Current state of the call in the queueu (join/leave)
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string to_dirno { get; set; }
    }



    /// <summary>
    /// This class defines a call queue
    /// </summary>
    public class restapi_call_queue_element
    {
        /// <summary>
        /// This list defines the directory number of the operators, who can answer a call in the queue. 
        /// </summary>
        public List<int> agents { get; set; }

        /// <summary>
        /// Defines the directory number of the calling device.
        /// </summary>
        public string from_dirno { get; set; }

        /// <summary>
        /// Channel id. Can be used for hanging up the call.
        /// </summary>
        public string from_id { get; set; }

        /// <summary>
        /// Defines the cause for leaving the queue (abandon, answered, pichup).
        /// </summary>
        public string leave_reason { get; set; }

        /// <summary>
        /// Position in the queue.
        /// </summary>
        public int position { get; set; }

        /// <summary>
        /// Directory number of the call queue.
        /// </summary>
        public string queue_dirno { get; set; }

        /// <summary>
        /// Number of calls in the queue.
        /// </summary>
        public int queue_size { get; set; }

        /// <summary>
        /// The number of seconds the call has been queued.
        /// </summary>
        public int queue_time { get; set; }

        /// <summary>
        /// The timestamp in UTC when the call was entered in the queue.
        /// </summary>
        public string start_time { get; set; }

        /// <summary>
        /// Current state of the call in the queueu (join/leave)
        /// </summary>
        public string state { get; set; }
    }


    /// <summary>
    /// This Class implements the Zenitel REST API Link Protocol
    /// </summary>
    /***********************************************************************************************************************/
    public class RestApiClient
    /***********************************************************************************************************************/
    {
        /// <summary>This string defines the port number used for HTTPS communication</summary>
        public string HttpEncryptedPort = "443";

        /// <summary>This string defines the port number used for HTTP communication</summary>
        public string HttpUnencryptedPort = "80";

        /// <summary>This is the token received from the Zenitel Connect Server during login procedure.</summary>
        public string Token { get; set; }

        /// <summary>Zenitel Connect Server IP Address.</summary>
        public string ConnectServerAddr { get; set; }

        /// <summary>Zenitel Connect Server IP Port Number.</summary>
        public string RestApiPortNumber { get; set; }

        /// <summary>Zenitel Link Server Access User Name</summary>
        public string UserName { get; set; }

        /// <summary>Zenitel Link Server Access Password</summary>
        public string Password { get; set; }

        /// <summary>Event Handler for logging text.</summary>
        public event EventHandler<string> OnDebugString;


        // SYSTEM
        private const string GetRestApiDevice_accounts = "api/system/device_accounts";
        private const string GetRestApiInterfaceList = "api/system/info/net_interfaces";
        //private const string GetWampSystemInfoNtp = "api/system/info/ntp"; //Not implemented

        // CALL HANDLING
        private const string PostRestApiCalls = "api/calls";
        private const string PostRestApiCallsCallId = "api/calls/call";
        //private const string GetRespApiCalls = "api/calls";
        private const string DeleteRestApiCalls = "api/calls";
        private const string DeleteRestApiCallsCallId = "api/calls/call/";
        private const string GetRestApiQueues = "api/queues";
        private const string  GetRestApiCallLegs = "api/call_legs";


        // DEVICE
        private const string PostRestApiDevicesGposGpoId = "api/devices/device/gpos/gpo";
        private const string GetRestApiDevicesGpos = "api/devices/device/gpos";
        private const string GetRestApiDevicesGpis = "api/devices/device/gpis";

        /// <summary>
        /// Defines the actions possible for a call
        /// </summary>
        public enum CallAction
        {
            /// <summary>
            /// Defines the call setup action
            /// </summary>
            setup,
            /// <summary>
            /// Defines the call answer action
            /// </summary>
            answer
        }

        /// <summary>
        /// This method is the constructor of the Zenitel REST API Link Protocol
        /// </summary>
        /***********************************************************************************************************************/
        public RestApiClient()
        /***********************************************************************************************************************/
        {
            // REST API Client Constructor
            Token = string.Empty;
            ConnectServerAddr = "169.254.1.5";
            UserName = string.Empty;
            Password = string.Empty;
            OnDebugString?.Invoke(this, "RestApiClient constructor invoked.");
        }

        /// <summary>
        /// This method is the destructor of the Zenitel REST API Link Protocol
        /// </summary>
        /***********************************************************************************************************************/
        ~RestApiClient()
        /***********************************************************************************************************************/
        {
            // REST API Client Destructor
            OnDebugString?.Invoke(this, "RestApiClient destructor invoked.");
        }


        /***********************************************************************************************************************/
        private bool ValidateRemoteCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        /***********************************************************************************************************************/
        {
            return true;
        }


        /// <summary>
        /// This method makes the Zinitel Link login and retrieves the access token from the Zenitel Connect Platform
        /// </summary>
        /// <returns>boolean value indicating if the authentication was successfully executed (true) of failed (false)</returns>
        /***********************************************************************************************************************/
        public bool Authentication()
        /***********************************************************************************************************************/
        {
            bool completedOk = false;
            try
            {
                bool useEncryption = RestApiPortNumber.Equals(HttpEncryptedPort);
             
                string uriStr = ((useEncryption) ?  ("https://" + ConnectServerAddr + ":" + RestApiPortNumber) :
                                                    ("http://"  + ConnectServerAddr )) +
                                                     "/api/auth/login";
                Uri uri = new Uri(uriStr);

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
                        OnDebugString?.Invoke(this, "restApiClient.Authentication. Null response");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(json_result.access_token))
                        {
                            OnDebugString?.Invoke(this, "restApiClient.Authentication. Empty token");
                        }
                        else
                        {
                            Token = json_result.access_token;
                            completedOk = true;
//                            OnDebugString?.Invoke(this, "restApiClient.Authentication. Token: " + json_result.access_token);
                        }
                    }
                }
                else
                {
                    OnDebugString?.Invoke(this, "restApiClient.Authentication. " + "http request error - " + res.StatusCode + " " + res.StatusDescription);
                }
            }


            catch (Exception ex)
            {
                string txt = "restApiClient.Authentication. Exception: " + ex.ToString();
                OnDebugString?.Invoke(this, txt);
            }


            return completedOk;
        }


        /***********************************************************************************************************************/
        /// <summary>This method will request all registered devices.</summary>
        /// <returns>
        /// The method returns the list of all registered devices. Each element contains the device directory number and the current
        /// connection state reachable / not reachable.
        /// </returns>
        public List<restapi_device_registration_element> GET_device_accounts()
        /***********************************************************************************************************************/
        {
            List<restapi_device_registration_element> registeredDevices = null;

            try
            {
                if (string.IsNullOrEmpty(Token))
                {
                    OnDebugString?.Invoke(this, "restApiClient.GET_device_accounts. Token is empty");
                }
                else
                {
                    bool useEncryption = RestApiPortNumber.Equals(HttpEncryptedPort);

                    string uriStr = ((useEncryption) ? ("https://" + ConnectServerAddr + ":" + RestApiPortNumber) :
                                                       ("http://" + ConnectServerAddr)) +
                                                        "/" + GetRestApiDevice_accounts;

                    HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(uriStr);
                    rq.Method = "GET";
                    rq.ContentType = "application/json";
                    rq.Accept = "application/json";
                    rq.Timeout = 5000;

                    rq.Headers.Add("Authorization", "Bearer " + Token);
                    rq.Headers.Add("state", "registered");

                    HttpWebResponse res = (HttpWebResponse)rq.GetResponse();
                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        var resstring = new StreamReader(res.GetResponseStream()).ReadToEnd();
                        registeredDevices = Newtonsoft.Json.JsonConvert.DeserializeObject<List<restapi_device_registration_element>>(resstring);
                    }
                }
            }

            catch (Exception ex)
            {
                string txt = "restApiClient.GET_device_accounts. Exception: " + ex.ToString();
                OnDebugString?.Invoke(this, txt);
            }

            return registeredDevices;
        }

        /// <summary>
        /// This method requests a list of IP interfaces available on the Zenitel Connect Platform 
        /// </summary>
        /// <returns>The method returns a list of IP interface Ports. Each element contains the MAC-Addres, status and name</returns>
        /***********************************************************************************************************************/
        public List<restapi_interface_list> GET_net_interfaces()
        /***********************************************************************************************************************/
        {
            List<restapi_interface_list> interfaceList = null;

            try
            {
                if (string.IsNullOrEmpty(Token))
                {
                    OnDebugString?.Invoke(this, "restApiClient.GET_net_interfaces. Token is empty");
                }
                else
                {
                    bool useEncryption = RestApiPortNumber.Equals(HttpEncryptedPort);

                    string uriStr = ((useEncryption) ? ("https://" + ConnectServerAddr + ":" + RestApiPortNumber) :
                                                       ("http://" + ConnectServerAddr)) +
                                                        "/" + GetRestApiInterfaceList;

                    HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(uriStr);

                    rq.Method = "GET";
                    rq.ContentType = "application/json";
                    rq.Accept = "application/json";
                    rq.Timeout = 5000;

                    rq.Headers.Add("Authorization", "Bearer " + Token);
                    rq.Headers.Add("state", "registered");

                    HttpWebResponse res = (HttpWebResponse)rq.GetResponse();
                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        var resstring = new StreamReader(res.GetResponseStream()).ReadToEnd();
                        interfaceList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<restapi_interface_list>>(resstring);
                    }
                }
            }

            catch (Exception ex)
            {
                string txt = "restApiClient.GET_net_interfaces. Exception: " + ex.ToString();
                OnDebugString?.Invoke(this, txt);
            }


            return interfaceList;
        }

        /// <summary>
        /// This method sends a call request to the connected Zenitel Connect Platform. It will return the outcome of the request
        /// execution in the wamp_response class.
        /// </summary>
        /// 
        /// <param name="fromDirNo">This parameter specifies the directory number of the calling party (A-subscriber).</param>
        /// <param name="toDirNo">This parameter specifies the directory number of the called party (B-subscriber).</param>
        /// <param name="action">This parameter specifies if the it is a csll setup or call answer request.</param>
        /// 
        /// <returns name="restapi_response">This class contains the result of the request execution and a describing text in case the
        /// request fails.
        /// </returns>
        /***********************************************************************************************************************/
        public restapi_response POST_Calls(string fromDirNo, string toDirNo, string action)
        /***********************************************************************************************************************/
        {
            restapi_response RestApiResp = new restapi_response();

            try
            {
                bool useEncryption = RestApiPortNumber.Equals(HttpEncryptedPort);

                string uriStr = ((useEncryption) ? ("https://" + ConnectServerAddr + ":" + RestApiPortNumber) :
                                                   ("http://" + ConnectServerAddr)) +
                                                    "/" + PostRestApiCalls;

                HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(uriStr);

                rq.Method = "POST";
                rq.ContentType = "application/json";
                rq.Accept = "application/json";
                rq.Timeout = 5000;
                rq.Headers.Add("Authorization", "Bearer " + Token);

                restapi_POST_calls_element callEle = new restapi_POST_calls_element(fromDirNo, toDirNo, action);
                string postData = Newtonsoft.Json.JsonConvert.SerializeObject(callEle);

                byte[] postBytes = Encoding.UTF8.GetBytes(postData);
                rq.ContentLength = postBytes.Length;

                Stream requestStream = rq.GetRequestStream();
                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

                HttpWebResponse res = (HttpWebResponse)rq.GetResponse();

                if (res.StatusCode == HttpStatusCode.Accepted)
                {
                    var resstring = new StreamReader(res.GetResponseStream()).ReadToEnd();

                    RestApiResp.RestApiResponse = ResponseType.RestApiRequestSucceeded;
                    RestApiResp.CompletionText = resstring;

                    OnDebugString?.Invoke(this, "restApiClient.POST_Calls. Accepted: " + resstring);
                }
                else
                {
                    RestApiResp.RestApiResponse = ResponseType.RestApiRequestFailed;
                    string txt = "restApiClient.POST_Call. " + "http request error - " + res.StatusCode + " " + res.StatusDescription;
                    RestApiResp.CompletionText = txt;

                    OnDebugString?.Invoke(this, txt);
                }
            }

            catch (Exception ex)
            {
                string txt = "restApiClient.POST_Calls. Exception: " + ex.ToString();
                RestApiResp.RestApiResponse = ResponseType.RestApiRequestFailed;
                RestApiResp.CompletionText = txt;

                OnDebugString?.Invoke(this, txt);
            }

            return RestApiResp;
        }


        /// <summary>
        /// This class defines the GET calls request from the Zenitel Connect Platform
        /// </summary>
        public class restapi_GET_calls_element
        {
            /// <summary>
            /// Dirno is the directory number filtering of the device.
            /// </summary>
            public string dirno { get; set; }

            /// <summary>
            /// Call_id is the ID filtering of the call.
            /// </summary>
            public string call_id { get; set; }

            /// <summary>
            /// State is the state filtering of the call.
            /// </summary>
            public string state { get; set; }

            /// <summary>
            /// This class is defines constructor of the restapi_GET_calls_element class.
            /// </summary>
            /// <param name="Dirno">Defines the directory number filtering.</param>
            /// <param name="CallId">Defines the call ID filtering.</param>
            /// <param name="State">Defines the call state filtering.</param>
            public restapi_GET_calls_element(string Dirno, string CallId, string State)
            {
                dirno = Dirno;
                call_id = CallId;
                state = State;
            }
        }

        /// <summary>
        /// This method requests a list of calls registered at the Zenitel Connect Platform. The returned list may be filtered (reduced)
        /// by specifying the filtering parameters. A filtering parameter not being used is specified as an empty string. 
        /// </summary>
        /// <param name="dirNo">Only return calls having this directory number as member.</param>
        /// <param name="callId">Only return the call having this call identification.</param>
        /// <param name="state">Only return calls being in the specified state.</param>
        /// <returns>The method returns a list of calls according to the filtering specified via the parameters.</returns>
        /***********************************************************************************************************************/
        public List<restapi_call_element> GET_Calls(string dirNo, string callId, string state)
        /***********************************************************************************************************************/
        {
            List<restapi_call_element> callList = null;

            try
            {
                bool useEncryption = RestApiPortNumber.Equals(HttpEncryptedPort);

                string uriStr = ((useEncryption) ? ("https://" + ConnectServerAddr + ":" + RestApiPortNumber) :
                                                   ("http://" + ConnectServerAddr)) +
                                                    "/" + PostRestApiCalls;

                HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(uriStr);

                rq.Method = "GET";
                rq.ContentType = "application/json";
                rq.Accept = "application/json";
                rq.Timeout = 5000;
                rq.Headers.Add("Authorization", "Bearer " + Token);

                rq.Headers.Add("dirno", dirNo);
                rq.Headers.Add("call_id", callId);
                rq.Headers.Add("state", state);

                HttpWebResponse res = (HttpWebResponse)rq.GetResponse();

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    var resstring = new StreamReader(res.GetResponseStream()).ReadToEnd();

                    callList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<restapi_call_element>>(resstring);

                    OnDebugString?.Invoke(this, "restApiClient.GET_Calls. OK: " + resstring);
                }
                else
                {
                    OnDebugString?.Invoke(this, "restApiClient.GET_Calls. " + "http request error - " + res.StatusCode + " " + res.StatusDescription);
                }
            }

            catch (Exception ex)
            {
                string txt = "restApiClient.GET_Calls. Exception: " + ex.ToString();
                OnDebugString?.Invoke(this, txt);
            }

            return callList;
        }


        /// <summary>
        /// This method requests a list of call legs registered at the Zenitel Connect Platform. The returned list may be filtered (reduced)
        /// by specifying the filtering parameters. A filtering parameter not being used is specified as an empty string. 
        /// </summary>
        /// <param name="fromDirNo">Only return calls having this directory number as member.</param>
        /// <param name="toDirNo">Only return the call having this call identification.</param>
        /// <param name="dirNo">Only return calls being in the specified state.</param>
        /// <param name="legId">Only return calls being in the specified state.</param>
        /// <param name="callId">Only return calls being in the specified state.</param>
        /// <param name="State">Only return calls being in the specified state.</param>
        /// <param name="legRole">Only return calls being in the specified state.</param>
        /// <returns>The method returns a list of calls according to the filtering specified via the parameters.</returns>
        /***********************************************************************************************************************/
        public List<restapi_call_leg_element> requestCallLegs(string fromDirNo, string toDirNo, string dirNo, string legId,
                                                              string callId, string State, string legRole)
        /***********************************************************************************************************************/
        {
            List<restapi_call_leg_element> callLegList = null;

            try
            {
                bool useEncryption = RestApiPortNumber.Equals(HttpEncryptedPort);

                string uriStr = ((useEncryption) ? ("https://" + ConnectServerAddr + ":" + RestApiPortNumber) :
                                                   ("http://" + ConnectServerAddr)) +
                                                    "/" + GetRestApiCallLegs;

                HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(uriStr);

                rq.Method = "GET";
                rq.ContentType = "application/json";
                rq.Accept = "application/json";
                rq.Timeout = 5000;
                rq.Headers.Add("Authorization", "Bearer " + Token);

                rq.Headers.Add("from_dirno", fromDirNo);
                rq.Headers.Add("to_dirno", toDirNo);
                rq.Headers.Add("dirno", dirNo);
                rq.Headers.Add("leg_id", legId);
                rq.Headers.Add("call_id", callId);
                rq.Headers.Add("state", State);
                rq.Headers.Add("leg_role", legRole);

                HttpWebResponse res = (HttpWebResponse)rq.GetResponse();

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    var resstring = new StreamReader(res.GetResponseStream()).ReadToEnd();

                    callLegList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<restapi_call_leg_element>>(resstring);

                    OnDebugString?.Invoke(this, "restApiClient.GET_Calls. OK: " + resstring);
                }
                else
                {
                    OnDebugString?.Invoke(this, "restApiClient.GET_Calls. " + "http request error - " + res.StatusCode + " " + res.StatusDescription);
                }
            }

            catch (Exception ex)
            {
                string txt = "restApiClient.requestCallLegs. Exception: " + ex.ToString();
                OnDebugString?.Invoke(this, txt);
            }

            return callLegList;
        }


        /// <summary>
        /// This class defines the DELETE call request.
        /// </summary>
        public class restapi_DELETE_calls_element
        {
            /// <summary>
            /// Dirno is the directory number of the station partipating in the call to be deleted.
            /// </summary>
            public string dirno { get; set; }

            /// <summary>
            /// his is the constructor of the restapi_DELETE_calls request.
            /// </summary>
            /// <param name="Dirno">Defines the directory number station in the call.</param>
            public restapi_DELETE_calls_element(string Dirno)
            {
                dirno = Dirno;
            }
        }

        /// <summary>
        /// This method will request the termination of all calls in which the specified dirNo takes part in.
        /// The method will return the outcome of the request via the wamp_response class.
        /// </summary>
        /// <param name="dirNo">This parameter specifies the directory number of the device.</param>
        /// <returns name="restapi_response">This class contains the result of the request execution and a describing text in case the
        /// request fails.
        /// </returns>
        /***********************************************************************************************************************/
        public restapi_response DELETE_Calls(string dirNo)
        /***********************************************************************************************************************/
        {
            restapi_response RestApiResp = new restapi_response();

            try
            {
                bool useEncryption = RestApiPortNumber.Equals(HttpEncryptedPort);

                string uriStr = ((useEncryption) ? ("https://" + ConnectServerAddr + ":" + RestApiPortNumber) :
                                                   ("http://" + ConnectServerAddr)) +
                                                    "/" + DeleteRestApiCalls;

                HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(uriStr);

                rq.Method = "DELETE";
                rq.ContentType = "application/json";
                rq.Accept = "application/json";
                rq.Timeout = 5000;
                rq.Headers.Add("Authorization", "Bearer " + Token);

                restapi_DELETE_calls_element deleteCallEle = new restapi_DELETE_calls_element(dirNo);
                string deleteData = Newtonsoft.Json.JsonConvert.SerializeObject(deleteCallEle);
                byte[] deleteBytes = Encoding.UTF8.GetBytes(deleteData);

                rq.ContentLength = deleteBytes.Length;
                Stream requestStream = rq.GetRequestStream();

                // Now send it
                requestStream.Write(deleteBytes, 0, deleteBytes.Length);
                requestStream.Close();

                HttpWebResponse res = (HttpWebResponse)rq.GetResponse();

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    var resstring = new StreamReader(res.GetResponseStream()).ReadToEnd();

                    RestApiResp.RestApiResponse = ResponseType.RestApiRequestSucceeded;
                    RestApiResp.CompletionText = resstring;

                    OnDebugString?.Invoke(this, "restApiClient.DELETE_Calls. Accepted: " + resstring);
                }
                else
                {
                    RestApiResp.RestApiResponse = ResponseType.RestApiRequestFailed;
                    string txt = "restApiClient.DELETE_Calls. " + "http request error - " + res.StatusCode + " " + res.StatusDescription;
                    RestApiResp.CompletionText = txt;

                    OnDebugString?.Invoke(this, txt);
                }
            }

            catch (Exception ex)
            {
                string txt = "restApiClient.DELETE_Calls. Exception: " + ex.ToString();
                RestApiResp.RestApiResponse = ResponseType.RestApiRequestFailed;
                RestApiResp.CompletionText = txt;

                OnDebugString?.Invoke(this, txt);
            }

            return RestApiResp;
        }


        /// <summary>
        /// This class defines the DELETE call id request.
        /// </summary>
        public class restapi_DELETE_callId_element
        {
            /// <summary>
            /// This attribute defines the id of the call to be deleted.
            /// </summary>
            public string call_id { get; set; }

            /// <summary>
            /// This method is the construvtor of the restapi_DELETE_callId_element class.
            /// </summary>
            /// <param name="CallId">Defines the ID of the call.</param>
            public restapi_DELETE_callId_element(string CallId)
            {
                call_id = CallId;
            }
        }


        /// <summary>This method will request the termination of the call identified by callId. The callId is assigbed during the call
        /// call establishment. The method will return the outcome of the request via the wamp_response class.
        /// </summary>
        /// <param name="callId">This is the call ID of the established call.</param>
        /// <returns name="restapi_response">This class contains the result of the request execution and a describing text in case the
        /// request fails.
        /// </returns>
        /***********************************************************************************************************************/
        public restapi_response DELETE_CallId(string callId)
        /***********************************************************************************************************************/
        {
            restapi_response RestApiResp = new restapi_response();

            try
            {
                bool useEncryption = RestApiPortNumber.Equals(HttpEncryptedPort);

                string uriStr = ((useEncryption) ? ("https://" + ConnectServerAddr + ":" + RestApiPortNumber) :
                                                    ("http://" + ConnectServerAddr)) +
                                                      "/" + DeleteRestApiCallsCallId;

                HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(uriStr);

                rq.Method = "DELETE";
                rq.ContentType = "application/json";
                rq.Accept = "application/json";
                rq.Timeout = 5000;
                rq.Headers.Add("Authorization", "Bearer " + Token);

                restapi_DELETE_callId_element deleteCallEle = new restapi_DELETE_callId_element(callId);
                string deleteData = Newtonsoft.Json.JsonConvert.SerializeObject(deleteCallEle);
                byte[] deleteBytes = Encoding.UTF8.GetBytes(deleteData);

                rq.ContentLength = deleteBytes.Length;
                Stream requestStream = rq.GetRequestStream();

                // Now send it
                requestStream.Write(deleteBytes, 0, deleteBytes.Length);
                requestStream.Close();

                HttpWebResponse res = (HttpWebResponse)rq.GetResponse();

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    var resstring = new StreamReader(res.GetResponseStream()).ReadToEnd();

                    RestApiResp.RestApiResponse = ResponseType.RestApiRequestSucceeded;
                    RestApiResp.CompletionText = resstring;

                    OnDebugString?.Invoke(this, "restApiClient.DELETE_CallId. Accepted: " + resstring);
                }
                else
                {
                    RestApiResp.RestApiResponse = ResponseType.RestApiRequestFailed;
                    string txt = "restApiClient.DELETE_CallId. " + "http request error - " + res.StatusCode + " " + res.StatusDescription;
                    RestApiResp.CompletionText = txt;

                    OnDebugString?.Invoke(this, txt);
                }
            }

            catch (Exception ex)
            {
                string txt = "restApiClient.DELETE_CallId. Exception: " + ex.ToString();
                RestApiResp.RestApiResponse = ResponseType.RestApiRequestFailed;
                RestApiResp.CompletionText = txt;

                OnDebugString?.Invoke(this, txt);
            }

            return RestApiResp;
        }


        /// <summary>
        /// This method requests a list of queued calls registered at the Zenitel Connect Platform. The returned list may be filtered (reduced)
        /// by specifying the filtering parameters. A filtering parameter not being used is specified as an empty string. 
        /// </summary>
        /// <param name="agent">Only return call queues handled by this agent.</param>
        /// <param name="fromDirNo">Only return call queues with calls from this directory number.</param>
        /// <param name="queueDirNo">Only return call queue with this directory number.</param>
        /// <returns>The method returns a list of call queues according to the filtering specified via the parameters.</returns>
        /***********************************************************************************************************************/
        public List<restapi_call_queue_element> GET_Queues(string agent, string fromDirNo, string queueDirNo)
        /***********************************************************************************************************************/
        {
            List<restapi_call_queue_element> callQueueList = null;

            try
            {
                bool useEncryption = RestApiPortNumber.Equals(HttpEncryptedPort);

                string uriStr = ((useEncryption) ? ("https://" + ConnectServerAddr + ":" + RestApiPortNumber) :
                                                   ("http://" + ConnectServerAddr)) +
                                                    "/" + GetRestApiQueues;

                HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(uriStr);

                rq.Method = "GET";
                rq.ContentType = "application/json";
                rq.Accept = "application/json";
                rq.Timeout = 5000;
                rq.Headers.Add("Authorization", "Bearer " + Token);

                rq.Headers.Add("agent", agent);
                rq.Headers.Add("from_dirno", fromDirNo);
                rq.Headers.Add("queue_dirno", queueDirNo);

                HttpWebResponse res = (HttpWebResponse)rq.GetResponse();

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    var resstring = new StreamReader(res.GetResponseStream()).ReadToEnd();

                    callQueueList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<restapi_call_queue_element>>(resstring);

                    OnDebugString?.Invoke(this, "restApiClient.GET_Queues. OK: " + resstring);
                }
                else
                {
                    OnDebugString?.Invoke(this, "restApiClient.GET_Queues. " + "http request error - " + res.StatusCode + " " + res.StatusDescription);
                }
            }

            catch (Exception ex)
            {
                string txt = "restApiClient.GET_Queues. Exception: " + ex.ToString();
                OnDebugString?.Invoke(this, txt);
            }

            return callQueueList;
        }


        /// <summary>
        /// This class defines the POST gpo element request.
        /// </summary>
        public class restapi_POST_gpo_element
        {
            /// <summary>
            /// Device_id is the directiry number of the device equipped with the GPO port.
            /// </summary>
            public string device_id { get; set; }

            /// <summary>
            /// Gpo_id is the id of the selected port.
            /// </summary>
            public string gpo_id { get; set; }

            /// <summary>
            /// This method is the constructor of the restapi_POST_gpo request class.
            /// </summary>
            /// <param name="DeviceId">Defines the directiry number of the device equipped with the GPO port.</param>
            /// <param name="GpoId">Defines the id of the selected port.</param>
            public restapi_POST_gpo_element(string DeviceId, string GpoId)
            {
                device_id = DeviceId;
                gpo_id = GpoId;
            }
        }


        /// <summary>
        /// This method sends a Device GPO (General Purpose Output) request to the connected Zenitel Connect Platform.
        /// It will return the outcome of the request execution in the wamp_response class.
        /// </summary>
        /// <param name="deviceId">This parameter specifies directory number of the selected device.</param>
        /// <param name="gpoId">This parameter specifies the port name {relay1, relay2, gpio1 ...}.</param>
        /// <returns name="restapi_response">This class contains the result of the request execution and a describing text in case the
        /// request fails.
        /// </returns>
        /***********************************************************************************************************************/
        public restapi_response POST_DevicesGPOS(string deviceId, string gpoId)
        /***********************************************************************************************************************/
        {
            restapi_response RestApiResp = new restapi_response();

            try
            {
                bool useEncryption = RestApiPortNumber.Equals(HttpEncryptedPort);

                string uriStr = ((useEncryption) ? ("https://" + ConnectServerAddr + ":" + RestApiPortNumber) :
                                                    ("http://" + ConnectServerAddr)) +
                                                      "/" + PostRestApiDevicesGposGpoId;

                HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(uriStr);

                rq.Method = "POST";
                rq.ContentType = "application/json";
                rq.Accept = "application/json";
                rq.Timeout = 5000;
                rq.Headers.Add("Authorization", "Bearer " + Token);

                restapi_POST_gpo_element postGpoEle = new restapi_POST_gpo_element(deviceId, gpoId);
                string postData = Newtonsoft.Json.JsonConvert.SerializeObject(postGpoEle);
                byte[] postBytes = Encoding.UTF8.GetBytes(postData);

                rq.ContentLength = postBytes.Length;
                Stream requestStream = rq.GetRequestStream();

                // Now send it
                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

                HttpWebResponse res = (HttpWebResponse)rq.GetResponse();

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    var resstring = new StreamReader(res.GetResponseStream()).ReadToEnd();

                    RestApiResp.RestApiResponse = ResponseType.RestApiRequestSucceeded;
                    RestApiResp.CompletionText = resstring;

                    OnDebugString?.Invoke(this, "restApiClient.POST_DevicesGPOS. Accepted: " + resstring);
                }
                else
                {
                    RestApiResp.RestApiResponse = ResponseType.RestApiRequestFailed;
                    string txt = "restApiClient.POST_DevicesGPOS. " + "http request error - " + res.StatusCode + " " + res.StatusDescription;
                    RestApiResp.CompletionText = txt;

                    OnDebugString?.Invoke(this, txt);
                }
            }

            catch (Exception ex)
            {
                string txt = "restApiClient.POST_DevicesGPOS. Exception: " + ex.ToString();
                RestApiResp.RestApiResponse = ResponseType.RestApiRequestFailed;
                RestApiResp.CompletionText = txt;

                OnDebugString?.Invoke(this, txt);
            }

            return RestApiResp;
        }

    }
}
