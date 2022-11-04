using System;
using System.Collections.Generic;
using WampSharp.V2.Core.Contracts;
using System.Threading;

namespace Wamp.Client
{
    public partial class WampClient
    {
        /***********************************************************************************************************************/
        /********************                                  Post Device Id Key                            *******************/
        /***********************************************************************************************************************/
        /// <summary>
        /// This method sends a call request to the connected Zenitel Connect Platform. It will return the outcome of the request
        /// execution in the wamp_response class.
        /// </summary>
        /// 
        /// <param name="device">This parameter specifies the directory number of the calling party (A-subscriber).</param>
        /// <param name="key">This parameter specifies the directory number of the called party (B-subscriber).</param>
        /// <param name="edge">This parameter specifies action - press.</param>
        /// 
        /// <returns name="wamp_response">This class contains the result of the request execution and a describing text in case the
        /// request fails.
        /// </returns>
        public wamp_response PostDeviceIdKey(string device, string key, string edge)
        /***********************************************************************************************************************/
        {
            wamp_response wampResp = new wamp_response();

            try
            {
                Dictionary<string, object> argumentsKeywords = new Dictionary<string, object>();

                argumentsKeywords["dirno"] = device;
                argumentsKeywords["edge"] = edge;
                argumentsKeywords["id"] = key;


                RPCCallback rpcCallback = new RPCCallback();

                _wampRealmProxy.RpcCatalog.Invoke(rpcCallback,
                                                  new CallOptions(),
                                                  PostWampDevicesDeviceIdKey,
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
                        wampResp.CompletionText = "PostKeyId sucessfully completed.";
                    }
                    else
                    {
                        wampResp.WampResponse = ResponseType.WampRequestFailed;
                        wampResp.CompletionText = "PostKeyId failed: " + rpcCallback.CompletionText;
                    }
                }
                else
                {
                    wampResp.WampResponse = ResponseType.WampNoResponce;
                    wampResp.CompletionText = "PostKeyId failed. No response from WAMP.";
                }
            }
            catch (Exception ex)
            {
                OnChildLogString?.Invoke(this, "Exception in PostKeyId: " + ex.ToString());
            }

            return wampResp;
        }

    }
}