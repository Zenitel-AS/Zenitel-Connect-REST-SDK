using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using WampSharp.V2.Core.Contracts;
using static Wamp.Client.WampClient;

namespace Wamp.Client
{
    public partial class WampClient
    {
        /// <summary>
        /// The method Publish_NewUCTTime will publish to subscriber(s) current UCT-time 
        /// </summary>
        /***********************************************************************************************************************/
        public void Publish_NewUCTTime()
        /***********************************************************************************************************************/
        {
            try
            {
                OnChildLogString?.Invoke(this, "Publish_NewUCTTime() invoked.");

                ISubject<wamp_UCT_time> subject = _wampRealmProxy.Services.GetSubject<wamp_UCT_time>(WampClient.UCT_Time_event);

                wamp_UCT_time UCT_time_event = new wamp_UCT_time { newTime = DateTime.UtcNow.ToString()};

                subject.OnNext(UCT_time_event);

                OnChildLogString?.Invoke(this, "Publish_NewUCTTime() completed sucessfully.");
            }

            catch (Exception ex)
            {
                OnChildLogString?.Invoke(this, "Exception in Publish_NewUCTTime(): " + ex.ToString());
            }
        }
    }
}