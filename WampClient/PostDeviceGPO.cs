
using System;
using System.Collections.Generic;
using WampSharp.Core.Serialization;
using WampSharp.V2.Core.Contracts;
using System.Threading;
using WampSharp.V2.Rpc;

namespace Wamp.Client
{
    public partial class WampClient
    {
        /***********************************************************************************************************************/
        /********************                                  Post Device GPO                               *******************/
        /***********************************************************************************************************************/

        /// <summary>
        /// This method sends a Device GPO (General Purpose Output) request to the connected Zenitel Connect Platform.
        /// It will return the outcome of the request execution in the wamp_response class.
        /// </summary>

        /// <param name="deviceId">This parameter specifies directory number of the selected device.</param>
        /// <param name="gpoId">This parameter specifies the port name {relay1, relay2, gpio1 ...}.</param>

        /// <returns name="wamp_response">This class contains the result of the request execution and a describing text in case the
        /// request fails.
        /// </returns>

        /***********************************************************************************************************************/
        public wamp_response PostDeviceGPO(string deviceId, string gpoId)
        /***********************************************************************************************************************/
        {
            wamp_response wampResp = new wamp_response();

            try
            {
                Dictionary<string, object> argumentsKeywords = new Dictionary<string, object>();

                argumentsKeywords["device_id"] = deviceId;
                argumentsKeywords["gpo_id"] = gpoId;

                RPCCallback rpcCallback = new RPCCallback();

                _wampRealmProxy.RpcCatalog.Invoke(rpcCallback,
                                                  new CallOptions(),
                                                  PostWampDevicesGposGpoId,
                                                  new object[] { argumentsKeywords });

                // Wait time limited for a reply from the WAMP-protocol
                bool cont = true;
                int loopCount = 0;
                int sleepTime = 10;

                while (cont)
                {
                    //Wait for RPC response
                    Thread.Sleep(sleepTime);
                    if (rpcCallback.RespRecv)
                    {
                        cont = false;
                    }
                    else
                    {
                        loopCount++;
                        if (loopCount > 300) cont = false;
                    }
                }

                if (rpcCallback.RespRecv)
                {
                    if (rpcCallback.CompletedSuccessfully)
                    {
                        wampResp.WampResponse = ResponseType.WampRequestSucceeded;
                        wampResp.CompletionText = "PostDeviceGPO sucessfully completed.";
                    }
                    else
                    {
                        wampResp.WampResponse = ResponseType.WampRequestFailed;
                        wampResp.CompletionText = "PostDeviceGPO failed: " + rpcCallback.CompletionText;
                    }
                }
                else
                {
                    wampResp.WampResponse = ResponseType.WampNoResponce;
                    wampResp.CompletionText = "PostDeviceGPO failed. No response from WAMP.";
                }

            }
            catch (Exception ex)
            {
                OnChildLogString?.Invoke(this, "Exception in PostDeviceGPO: " + ex.ToString());
            }

            return wampResp;
        }


        internal class RPCCallback : IWampRawRpcOperationClientCallback
        {
            public bool   RespRecv = false;
            public bool   CompletedSuccessfully = false;
            public string CompletionText = string.Empty;


            public void Result<TMessage>(IWampFormatter<TMessage> formatter, ResultDetails details)
            {
                RespRecv = true;
                CompletedSuccessfully = true;
            }


            public void Result<TMessage>(IWampFormatter<TMessage> formatter, ResultDetails details, TMessage[] arguments)
            {
                RespRecv = true;
                CompletedSuccessfully = true;
            }


            public void Result<TMessage>(IWampFormatter<TMessage> formatter,
                                         ResultDetails details,
                                         TMessage[] arguments,
                                         IDictionary<string, TMessage> argumentsKeywords)
            {
                RespRecv = true;
                CompletedSuccessfully = true;
            }


            public void Error<TMessage>(IWampFormatter<TMessage> formatter, TMessage details, string error)
            {
                RespRecv = true;
                CompletedSuccessfully = false;
                CompletionText = error;
            }


            public void Error<TMessage>(IWampFormatter<TMessage> formatter, TMessage details, string error, TMessage[] arguments)
            {
                RespRecv = true;
                CompletedSuccessfully = false;
                CompletionText = error;
            }


            public void Error<TMessage>(IWampFormatter<TMessage> formatter, TMessage details, string error, TMessage[] arguments,
                                        TMessage argumentsKeywords)
            {
                RespRecv = true;
                CompletedSuccessfully = false;
                CompletionText = error;
            }
        }
    }
}