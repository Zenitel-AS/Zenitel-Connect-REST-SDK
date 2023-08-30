using System;
using System.Collections.Generic;
using WampSharp.V2.Core.Contracts;
using System.Threading;

namespace Wamp.Client
{
    public partial class WampClient
    {

        /***********************************************************************************************************************/
        /********************                                  Delete Calls                                  *******************/
        /***********************************************************************************************************************/

        /// <summary>
        /// This method will request the termination of all calls in which the specified dirNo takes part in.
        /// The method will return the outcome of the request via the wamp_response class.
        /// </summary>

        /// <param name="dirNo">This parameter specifies the directory number of the device.</param>

        /// <returns name="wamp_response">This class contains the result of the request execution and a describing text in case the
        /// request fails.
        /// </returns>
        /***********************************************************************************************************************/
        public wamp_response DeleteCalls(string dirNo)
        /***********************************************************************************************************************/
        {
            wamp_response wampResp = new wamp_response();

            try
            {
                Dictionary<string, object> argumentsKeywords = new Dictionary<string, object>();

                argumentsKeywords["dirno"] = dirNo;

                RPCCallback rpcCallback = new RPCCallback();

                if (_wampRealmProxy != null)
                {
                    _wampRealmProxy.RpcCatalog.Invoke(rpcCallback,
                                                      new CallOptions(),
                                                      DeleteWampCalls,
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
                            wampResp.CompletionText = "DeleteCalls sucessfully completed.";
                        }
                        else
                        {
                            wampResp.WampResponse = ResponseType.WampRequestFailed;
                            wampResp.CompletionText = "DeleteCalls failed: " + rpcCallback.CompletionText;
                        }
                    }
                    else
                    {
                        wampResp.WampResponse = ResponseType.WampNoResponce;
                        wampResp.CompletionText = "DeleteCalls. No response from WAMP.";
                    }
                }

            }
            catch (Exception ex)
            {
                OnChildLogString?.Invoke(this, "Exception in DeleteCalls: " + ex.ToString());
            }

            return wampResp;
        }
    }
}