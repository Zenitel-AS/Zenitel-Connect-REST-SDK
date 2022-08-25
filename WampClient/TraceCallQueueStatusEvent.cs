using System;
using System.Collections.Generic;
using WampSharp.Core.Serialization;
using WampSharp.V2.Client;
using WampSharp.V2.PubSub;
using WampSharp.V2.Core.Contracts;



namespace Wamp.Client
{
    public partial class WampConnection
    {
        /***********************************************************************************************************************/
        /********************                       Trace Call Queue Status Event                            *******************/
        /***********************************************************************************************************************/

        TracerCallQueueEvent tracerCallQueueEvent = null;
        IAsyncDisposable tracerCallQueueEventDisposable = null;

        /// <summary>
        /// If set (not null) Call Queue Status changes will be sent to event handler OnWampCallQueueStatusEvent
        /// </summary>
        public event EventHandler<wamp_call_queue_element> OnWampCallQueueStatusEvent;


        /// <summary>
        /// This method enables the subscription of Call Queue Status Changes.
        /// </summary>
        /***********************************************************************************************************************/
        public async void TraceCallQueueEvent()
        /***********************************************************************************************************************/
        {
            IWampTopicProxy topicProxy = _wampRealmProxy.TopicContainer.GetTopicByUri(TraceWampQueues);

            tracerCallQueueEvent = new TracerCallQueueEvent();
            tracerCallQueueEvent.OnCallQueueEvent +=TracerCallQueueEvent_OnCallQueueEvent;
            tracerCallQueueEvent.OnDebugString +=TracerCallQueueEvent_OnDebugString;

            tracerCallQueueEventDisposable = await topicProxy.Subscribe(tracerCallQueueEvent, new SubscribeOptions()).ConfigureAwait(false);
        }


        /***********************************************************************************************************************/
        private void TracerCallQueueEvent_OnDebugString(object sender, string e)
        /***********************************************************************************************************************/
        {
            OnChildLogString?.Invoke(this, "Call Queue Subscription Event: " + e);
        }


        /***********************************************************************************************************************/
        private void TracerCallQueueEvent_OnCallQueueEvent(object sender, wamp_call_queue_element callQueueUpd)
        /***********************************************************************************************************************/
        {
            OnWampCallQueueStatusEvent?.Invoke(this, callQueueUpd);
        }


        /// <summary>This method terminates the subscription of Call Queue Status Updates.</summary>
        /***********************************************************************************************************************/
        public void TraceCallQueueEventDispose()
        /***********************************************************************************************************************/
        {
            if (tracerCallQueueEventDisposable != null)
            {
                tracerCallQueueEventDisposable.DisposeAsync();
                tracerCallQueueEventDisposable = null;
                tracerCallQueueEvent = null;
            }
        }

        /// <summary>This method returns the status of Call Queue Status changes subscription.</summary>
        /// <returns>Call Queue Status change subscription enabled/disabled as true/false.</returns>
        /***********************************************************************************************************************/
        public bool TraceCallQueueEventIsEnabled()
        /***********************************************************************************************************************/
        {
            if (tracerCallQueueEvent == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /***********************************************************************************************************************/
        internal class TracerCallQueueEvent : IWampRawTopicClientSubscriber
        /***********************************************************************************************************************/
        {

            public event EventHandler<wamp_call_queue_element> OnCallQueueEvent;
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

                wamp_call_queue_element callQueueUpdate = Newtonsoft.Json.JsonConvert.DeserializeObject<wamp_call_queue_element>(arguments[0].ToString());
                OnCallQueueEvent?.Invoke(this, callQueueUpdate);
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


