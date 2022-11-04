using System;
using System.Collections.Generic;
using WampSharp.Core.Serialization;
using WampSharp.V2.Client;
using WampSharp.V2.PubSub;
using WampSharp.V2.Core.Contracts;



namespace Wamp.Client
{
    public partial class WampClient
    {
        /***********************************************************************************************************************/
        /********************                         Trace Call Leg Status Event                            *******************/
        /***********************************************************************************************************************/

        TracerCallLegEvent tracerCallLegEvent = null;
        IAsyncDisposable tracerCallLegEventDisposable = null;

        /// <summary>
        /// If set (not null) Call Leg Status changes will be sent to event handler OnWampCallQueueStatusEvent
        /// </summary>
        public event EventHandler<wamp_call_leg_element> OnWampCallLegStatusEvent;


        /// <summary>
        /// This method enables the subscription of Call Leg Status Changes.
        /// </summary>
        /***********************************************************************************************************************/
        public async void TraceCallLegEvent()
        /***********************************************************************************************************************/
        {
            IWampTopicProxy topicProxy = _wampRealmProxy.TopicContainer.GetTopicByUri(TraceWampCallLeg);

            tracerCallLegEvent = new TracerCallLegEvent();
            tracerCallLegEvent.OnCallLegEvent +=TracerCallLegEvent_OnCallLegEvent;
            tracerCallLegEvent.OnDebugString  +=TracerCallLegEvent_OnDebugString;

            tracerCallLegEventDisposable = await topicProxy.Subscribe(tracerCallLegEvent, new SubscribeOptions()).ConfigureAwait(false);
        }


        /***********************************************************************************************************************/
        private void TracerCallLegEvent_OnDebugString(object sender, string e)
        /***********************************************************************************************************************/
        {
            OnChildLogString?.Invoke(this, "Call Leg Subscription Event: " + e);
        }


        /***********************************************************************************************************************/
        private void TracerCallLegEvent_OnCallLegEvent(object sender, wamp_call_leg_element callQueueUpd)
        /***********************************************************************************************************************/
        {
            OnWampCallLegStatusEvent?.Invoke(this, callQueueUpd);
        }


        /// <summary>This method terminates the subscription of Call Leg Status Updates.</summary>
        /***********************************************************************************************************************/
        public void TraceCallLegEventDispose()
        /***********************************************************************************************************************/
        {
            if (tracerCallLegEventDisposable != null)
            {
                tracerCallLegEventDisposable.DisposeAsync();
                tracerCallLegEventDisposable = null;
                tracerCallLegEvent = null;
            }
        }

        /// <summary>This method returns the status of Call Leg Status changes subscription.</summary>
        /// <returns>Call Leg Status change subscription enabled/disabled as true/false.</returns>
        /***********************************************************************************************************************/
        public bool TraceCallLegEventIsEnabled()
        /***********************************************************************************************************************/
        {
            if (tracerCallLegEvent == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /***********************************************************************************************************************/
        internal class TracerCallLegEvent : IWampRawTopicClientSubscriber
        /***********************************************************************************************************************/
        {

            public event EventHandler<wamp_call_leg_element> OnCallLegEvent;
            public event EventHandler<string> OnDebugString;


            /***********************************************************************************************************************/
            public void Event<TMessage>(IWampFormatter<TMessage> formatter, long publicationId, EventDetails details)
            /***********************************************************************************************************************/
            {
                OnDebugString?.Invoke(this, "Got event with publication id: " + publicationId);
            }


            /***********************************************************************************************************************/
            public void Event<TMessage>(IWampFormatter<TMessage> formatter, long publicationId, EventDetails details, TMessage[] arguments)
            /***********************************************************************************************************************/
            {
                string json_str = arguments[0].ToString();
                OnDebugString?.Invoke(this, json_str);

                wamp_call_leg_element callQueueUpdate = Newtonsoft.Json.JsonConvert.DeserializeObject<wamp_call_leg_element>(arguments[0].ToString());
                OnCallLegEvent?.Invoke(this, callQueueUpdate);
            }


            /***********************************************************************************************************************/
            public void Event<TMessage>(IWampFormatter<TMessage> formatter, long publicationId, EventDetails details, TMessage[] arguments,
                                        IDictionary<string, TMessage> argumentsKeywords)
            /***********************************************************************************************************************/
            {
                OnDebugString?.Invoke(this, "Event<TMessage>(IWampFormatter<TMessage> formatter, long publicationId, EventDetails details, TMessage[] arguments, IDictionary<string, TMessage> argumentsKeywords) IS NOT SUPPORTED");
            }

        }
    }
}


