using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

//EM
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace Rest.Api.Client
{

    class json_login_result
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
    }


    public class restapi_device_registration_element
    {
        public string dirno { get; set; }
        public string location { get; set; }
        public string name { get; set; }
        public string state { get; set; }
    }

    public class addrInfo
    {
        public string broadcast { get; set; }
        public string family { get; set; }
        public string label { get; set; }
        public string local { get; set; }
        public string preferred_life_time { get; set; }
        public string prefixlen { get; set; }
        public string scope { get; set; }
        public string valid_life_time { get; set; }
    }

    public class restapi_interface_list
    {
        public List<addrInfo> addr_info { get; set; }
        public string address { get; set; }
        public string broadcast { get; set; }
        public List<string> flags { get; set; }
        public string group { get; set; }
        public int ifindex { get; set; }
        public string ifname { get; set; }
        public string link_type { get; set; }
        public int mtu { get; set; }
        public string operstate { get; set; }
        public string qdisc { get; set; }
        public int txqlen { get; set; }
    }


    public enum ResponseType
    {
        RestApiNoResponce,
        RestApiRequestFailed,
        RestApiRequestSucceeded
    }


    public class restapi_response
    {
        public ResponseType RestApiResponse { get; set; }
        public string CompletionText { get; set; }
        public restapi_response()
        {
            RestApiResponse = ResponseType.RestApiNoResponce;
            CompletionText = "";
        }
    }


    public class restapi_POST_calls_element
    {
        public string from_dirno { get; set; }
        public string to_dirno { get; set; }
        public string action { get; set; }
        public restapi_POST_calls_element(string fromDirno, string toDirNo, string act)
        {
            from_dirno = fromDirno;
            to_dirno = toDirNo;
            action = act;
        }
    }


    public class restapi_POST_callsId_element
    {
        public string id { get; set; }
        public string action { get; set; }
        public restapi_POST_callsId_element(string callId, string callAction)
        {
            id = callId;
            action = callAction;
        }
    }


    public class restapi_GET_calls_element
    {
        public string dirno { get; set; }
        public string call_id { get; set; }
        public string state { get; set; }
        public restapi_GET_calls_element(string dirNo, string callId, string sta)
        {
            dirno = dirNo;
            call_id = callId;
            state = sta;
        }
    }


    public class restapi_call_element
    {
        public string from_dirno { get; set; }
        public string to_dirno { get; set; }
        public string id { get; set; }
        public string state { get; set; }
    }


    public class restapi_call_queue_element
    {
        public List<int> agents { get; set; }
        public string from_dirno { get; set; }
        public string from_id { get; set; }
        public string leave_reason { get; set; }
        public int position { get; set; }
        public string queue_dirno { get; set; }
        public int queue_size { get; set; }
        public int queue_time { get; set; }
        public string start_time { get; set; }
        public string state { get; set; }
    }


 

    /***********************************************************************************************************************/
    public class RestApiClient
    /***********************************************************************************************************************/
    {

        public string HttpEncryptedPort = "443";
        public string HttpUnencryptedPort = "80";

        public string Token { get; set; }

        public string ConnectServerAddr { get; set; }
        public string RestApiPortNumber { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public event EventHandler<string> OnDebugString;


        // SYSTEM
        private const string GetRestApiDevice_accounts = "api/system/device_accounts";
        private const string GetRestApiInterfaceList = "api/system/info/net_interfaces";
        private const string GetWampSystemInfoNtp = "api/system/info/ntp"; //Not implemented

        // CALL HANDLING
        public const string PostRestApiCalls = "api/calls";
        public const string PostRestApiCallsCallId = "api/calls/call";
        public const string GetRespApiCalls = "api/calls";
        public const string DeleteRestApiCalls = "api/calls";
        public const string DeleteRestApiCallsCallId = "api/calls/call/";
         public const string GetRespApiQueues = "api/queues";

        // DEVICE
        public const string PostRestApiDevicesGposGpoId = "api/devices/device/gpos/gpo";
        public const string GetRestApiDevicesGpos = "api/devices/device/gpos";
        public const string GetRestApiDevicesGpis = "api/devices/device/gpis";


        /***********************************************************************************************************************/
        public RestApiClient()
        /***********************************************************************************************************************/
        {
            // REST API Client Constructor
            Token = string.Empty;
            ConnectServerAddr = "169.254.1.5";
            UserName = "admin";
            Password = "alphaadmin";
            OnDebugString?.Invoke(this, "RestApiClient constructor invoked.");
        }


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
                            OnDebugString?.Invoke(this, "restApiClient.Authentication. Token: " + json_result.access_token);
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


        /***********************************************************************************************************************/
        public restapi_response POST_CallsCallId(string callId, string callAction)
        /***********************************************************************************************************************/
        {
            restapi_response RestApiResp = new restapi_response();

            try
            {
                bool useEncryption = RestApiPortNumber.Equals(HttpEncryptedPort);

                string uriStr = ((useEncryption) ? ("https://" + ConnectServerAddr + ":" + RestApiPortNumber) :
                                                   ("http://" + ConnectServerAddr)) +
                                                    "/" + PostRestApiCallsCallId;

                HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(uriStr);

                rq.Method = "POST";
                rq.ContentType = "application/json";
                rq.Accept = "application/json";
                rq.Timeout = 5000;
                rq.Headers.Add("Authorization", "Bearer " + Token);

                restapi_POST_callsId_element callIdEle = new restapi_POST_callsId_element(callId, callAction);
                string postData = Newtonsoft.Json.JsonConvert.SerializeObject(callIdEle);

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

                    OnDebugString?.Invoke(this, "restApiClient.POST_CallsId. Accepted: " + resstring);
                }
                else if(res.StatusCode == HttpStatusCode.OK)
                {
                    var resstring = new StreamReader(res.GetResponseStream()).ReadToEnd();

                    RestApiResp.RestApiResponse = ResponseType.RestApiRequestSucceeded;
                    RestApiResp.CompletionText = resstring;

                    OnDebugString?.Invoke(this, "restApiClient.POST_CallsId. OK: " + resstring);

                }
                else
                {
                    var resstring = new StreamReader(res.GetResponseStream()).ReadToEnd();

                    RestApiResp.RestApiResponse = ResponseType.RestApiRequestFailed;
                    RestApiResp.CompletionText = resstring;

                    OnDebugString?.Invoke(this, "restApiClient.POST_CallsId: http request error: " + resstring);
                }
            }

            catch (Exception ex)
            {
                string txt = "restApiClient.POST_CallsId. Exception: " + ex.ToString();
                RestApiResp.RestApiResponse = ResponseType.RestApiRequestFailed;
                RestApiResp.CompletionText = txt;

                OnDebugString?.Invoke(this, txt);
            }

            return RestApiResp;
        }



        public class restapi_GET_calls_element
        {
            public string dirno { get; set; }
            public string call_id { get; set; }
            public string state { get; set; }
            public restapi_GET_calls_element(string Dirno, string CallId, string State)
            {
                dirno = Dirno;
                call_id = CallId;
                state = State;
            }
        }


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




        public class restapi_DELETE_calls_element
        {
            public string dirno { get; set; }
            public restapi_DELETE_calls_element(string Dirno)
            {
                dirno = Dirno;
            }
        }


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


        public class restapi_DELETE_callId_element
        {
            public string id { get; set; }
            public restapi_DELETE_callId_element(string CallId)
            {
                id = CallId;
            }
        }


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


        public class restapi_POST_callId_element
        {
            public string id { get; set; }
            public restapi_POST_callId_element(string CallId)
            {
                id = CallId;
            }
        }


        /***********************************************************************************************************************/
        public restapi_response POST_CallId(string callId)
        /***********************************************************************************************************************/
        {
            restapi_response RestApiResp = new restapi_response();

            try
            {
                bool useEncryption = RestApiPortNumber.Equals(HttpEncryptedPort);

                string uriStr = ((useEncryption) ? ("https://" + ConnectServerAddr + ":" + RestApiPortNumber) :
                                                   ("http://" + ConnectServerAddr)) +
                                                    "/" + PostRestApiCallsCallId;

                HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(uriStr);

                rq.Method = "POST";
                rq.ContentType = "application/json";
                rq.Accept = "application/json";
                rq.Timeout = 5000;
                rq.Headers.Add("Authorization", "Bearer " + Token);

                restapi_POST_callId_element postCallEle = new restapi_POST_callId_element(callId);
                string postData = Newtonsoft.Json.JsonConvert.SerializeObject(postCallEle);
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

                    OnDebugString?.Invoke(this, "restApiClient.POST_CallId. Accepted: " + resstring);
                }
                else
                {
                    RestApiResp.RestApiResponse = ResponseType.RestApiRequestFailed;
                    string txt = "restApiClient.POST_CallId. " + "http request error - " + res.StatusCode + " " + res.StatusDescription;
                    RestApiResp.CompletionText = txt;

                    OnDebugString?.Invoke(this, txt);
                }
            }

            catch (Exception ex)
            {
                string txt = "restApiClient.POST_CallId. Exception: " + ex.ToString();
                RestApiResp.RestApiResponse = ResponseType.RestApiRequestFailed;
                RestApiResp.CompletionText = txt;

                OnDebugString?.Invoke(this, txt);
            }

            return RestApiResp;
        }


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
                                                    "/" + GetRespApiQueues;

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


        public class restapi_POST_gpo_element
        {
            public string device_id { get; set; }
            public string gpo_id { get; set; }
            public restapi_POST_gpo_element(string DeviceId, string GpoId)
            {
                device_id = DeviceId;
                gpo_id = GpoId;
            }
        }


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
