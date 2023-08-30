using System;
using System.Collections.Generic;
using WampSharp.V2.Core.Contracts;
using System.Threading;

namespace Wamp.Client

{
    /// <summary>
    /// This Class implements the Zenitel Link Protocol
    /// </summary>

    public partial class WampClient
    {

        /***********************************************************************************************************************/
        /********************                                  Delete Call ID                                *******************/
        /***********************************************************************************************************************/

        /// <summary>This method will request the termination of the call identified by callId. The callId is assigbed during the call
        /// call establishment. The method will return the outcome of the request via the wamp_response class.
        /// </summary>

        /// <param name="callId">This is the call ID of the established call.</param>

        /// <returns name="wamp_response">This class contains the result of the request execution and a describing text in case the
        /// request fails.
        /// </returns>
        /***********************************************************************************************************************/
        public wamp_response DeleteCallId(string callId)
        /***********************************************************************************************************************/
        {
            wamp_response wampResp = new wamp_response();

            try
            {
                Dictionary<string, object> argumentsKeywords = new Dictionary<string, object>();

                argumentsKeywords["call_id"] = callId;

                RPCCallback rpcCallback = new RPCCallback();

                _wampRealmProxy.RpcCatalog.Invoke(rpcCallback,
                                                  new CallOptions(),
                                                  DeleteWampCallsCallId,
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
                        if (loopCount > 30) cont = false;
                    }
                }

                if (rpcCallback.RespRecv)
                {
                    if (rpcCallback.CompletedSuccessfully)
                    {
                        wampResp.WampResponse = ResponseType.WampRequestSucceeded;
                        wampResp.CompletionText = "DeleteCallId sucessfully completed.";
                    }
                    else
                    {
                        wampResp.WampResponse = ResponseType.WampRequestFailed;
                        wampResp.CompletionText = "DeleteCallId failed: " + rpcCallback.CompletionText;
                    }
                }
                else
                {
                    wampResp.WampResponse = ResponseType.WampNoResponce;
                    wampResp.CompletionText = "DeleteCallId. No response from WAMP.";
                }
            }
            catch (Exception ex)
            {
                OnChildLogString?.Invoke(this, "Exception in DeleteCallId: " + ex.ToString());
            }

            return wampResp;
        }
    }
}