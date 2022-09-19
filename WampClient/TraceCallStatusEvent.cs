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
        /********************                       Trace Call Status Event                                  *******************/
        /***********************************************************************************************************************/

        TracerCallEvent tracerCallEvent = null;
 
        IAsyncDisposable  tracerCallEventsDisposable = null;

        /// <summary>
        /// If set (not null) Call Status changes will be sent to event handler OnWampCallStatusEvent
        /// </summary>
        public event EventHandler<wamp_call_element> OnWampCallStatusEvent;

        /// <summary>
        /// This method enables the subscription of Call Status Changes.
        /// </summary>
        /***********************************************************************************************************************/
        public async void TraceCallEvent()
        /***********************************************************************************************************************/       
        {
            IWampTopicProxy topicProxy = _wampRealmProxy.TopicContainer.GetTopicByUri(TraceWampCalls);

            tracerCallEvent = new TracerCallEvent();
            tracerCallEvent.OnCallEvent += TracerCallEvent_OnCallEvent;
            tracerCallEvent.OnDebugString += TracerCallEvent_OnDebugString;

            tracerCallEventsDisposable = await topicProxy.Subscribe(tracerCallEvent, new SubscribeOptions()).ConfigureAwait(false);
        }


        /***********************************************************************************************************************/
        private void TracerCallEvent_OnDebugString(object sender, string e)
        /***********************************************************************************************************************/
        {
            OnChildLogString?.Invoke(this, "Call Subscription Event: " + e);
        }


        /***********************************************************************************************************************/
        private void TracerCallEvent_OnCallEvent(object sender,wamp_call_element callUpd)
        /***********************************************************************************************************************/       
        {
            OnWampCallStatusEvent?.Invoke(this, callUpd);
        }


        /// <summary>This method terminates the subscription of Call Status Updates.</summary>
        /***********************************************************************************************************************/
        public void TraceCallEventDispose()
        /***********************************************************************************************************************/
        {
            if (tracerCallEventsDisposable != null)
            {
                tracerCallEventsDisposable.DisposeAsync();
                tracerCallEventsDisposable = null;
                tracerCallEvent = null;
            }
        }


        /// <summary>This method returns the status of Call Status changes subscription.</summary>
        /// <returns>Call Status change subscription enabled/disabled as true/false.</returns>
        /***********************************************************************************************************************/
        public bool TraceCallEventIsEnabled()
        /***********************************************************************************************************************/
        {
            if (tracerCallEvent == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /***********************************************************************************************************************/
        internal class TracerCallEvent : IWampRawTopicClientSubscriber
        /***********************************************************************************************************************/
        {

            public event EventHandler<wamp_call_element> OnCallEvent;
            public event EventHandler<string> OnDebugString;

            /***********************************************************************************************************************/
            public void Event<TMessage>(IWampFormatter<TMessage> formatter, long publicationId, EventDetails details)
            /***********************************************************************************************************************/
            {
                string txt = "Got event with publication id: " + publicationId.ToString();
                OnDebugString?.Invoke(this, txt);
            }


            /***********************************************************************************************************************/
            public void Event<TMessage>(IWampFormatter<TMessage> formatter, long publicationId, EventDetails details, TMessage[] arguments)
            /***********************************************************************************************************************/
            {
                string json_str = arguments[0].ToString();
                OnDebugString?.Invoke(this, json_str);

               wamp_call_element callUpdate = Newtonsoft.Json.JsonConvert.DeserializeObject<wamp_call_element>(arguments[0].ToString());
                OnCallEvent?.Invoke(this, callUpdate);
            }


            /***********************************************************************************************************************/
            public void Event<TMessage>(IWampFormatter<TMessage> formatter, long publicationId, EventDetails details, TMessage[] arguments,
                                        IDictionary<string, TMessage> argumentsKeywords)
            /***********************************************************************************************************************/
            {
                string txt = "Event<TMessage>(IWampFormatter<TMessage> formatter, long publicationId, EventDetails details, TMessage[] arguments, IDictionary<string, TMessage> argumentsKeywords) IS NOT SUPPORTED";
                OnDebugString?.Invoke(this, txt);
            }
        }
    }
}
