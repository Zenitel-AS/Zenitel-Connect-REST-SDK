using System;
using System.Collections.Generic;
//using WampSharp.V2.Core.Contracts;
//using System.Threading;
using System.Threading.Tasks;

namespace Wamp.Client
{
    public partial class WampClient
    {
        /// <summary>
        /// The RegisterCalleServices will reguster a defined services at callee
        /// </summary>
        /// <returns></returns>
        /***********************************************************************************************************************/
        public async Task RegisterCalleeServices()
        /***********************************************************************************************************************/
        {
            try
            {
                OnChildLogString?.Invoke(this, "RegisterCalleeServices() invoked.");
                IArgumentsService instance = new ArgumentsService();
                Task<IAsyncDisposable> registrationTask = _wampRealmProxy.Services.RegisterCallee(instance);
                await registrationTask;
                OnChildLogString?.Invoke(this, "RegisterCalleeServices() completed sucessfully.");
            }

            catch (Exception ex)
            {
                OnChildLogString?.Invoke(this, "Exception in RegisterCalleeService: " + ex.ToString());
            }
        }
    }
}